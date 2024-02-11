using Restaurant.Application.Contracts.Identity;
using Restaurant.Application.Features.Branch.Requests.Commands;

namespace Restaurant.Application.Features.Branch.Handlers.Commands;

public class UpdateBranchCommandHandler(
    IMapper mapper,
    IBranchRepository branchRepository,
    IImageRepository imageRepository,
    IFileUploadService fileUploadService,
    IApplicationUserManager userManager,
    IOptionsMonitor<SiteSettings> options) : IRequestHandler<UpdateBranchCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IBranchRepository _branchRepository = branchRepository;
    private readonly IImageRepository _imageRepository = imageRepository;
    private readonly IFileUploadService _fileUploadService = fileUploadService;
    private readonly IApplicationUserManager _userManager = userManager;

    private readonly string _branchPicturesFolderPath = options.CurrentValue.FileFolders.BranchPictures;

    public async Task Handle(UpdateBranchCommand request,CancellationToken cancellationToken)
    {
        if(request.AdminId is not null and not 0)
        {
            bool isExitsUser = await _userManager.IsExists(request.AdminId.Value);
            if(!isExitsUser)
                throw new NotFoundException("User");
        }

        var branch = await _branchRepository.FindByIdAsync(request.Id,false) ?? throw new NotFoundException("Branch");

        bool isExists = await _branchRepository.IsExistsByTitleOrSlug(request.Title,request.Slug);
        if(isExists && (branch.Title != request.Title || branch.Slug != request.Slug))
        {
            throw new BadRequestException([Messages.Errors.TitleOrSlugIsExists]);
        }

        if(request.NewImagesBase64?.Count > 0)
        {
            FileUploadResult fileUploadResult = new(true);
            foreach(string img in request.NewImagesBase64)
            {
                fileUploadResult = await _fileUploadService.UploadBase64(img,_branchPicturesFolderPath.CombineWithCurrentDirectory());
                if(!fileUploadResult.IsSuccedded)
                {
                    throw new BadRequestException([Messages.Errors.FileUploadFiled]);
                }
                var image = new Image
                {
                    Name = fileUploadResult.FileName!,
                    Extension = fileUploadResult.FileExtention,
                    Size = fileUploadResult.FileSize,
                    UploadDate = DateTime.Now,
                    Branches = []
                };
                image.Branches.Add(new() { Branch = branch });
                await _imageRepository.CreateAsync(image,false);
            }
        }

        if(request.RemoveImageNames?.Count > 0)
        {
            foreach(string imgName in request.RemoveImageNames)
            {
                var image = await _imageRepository.FindForBranch(imgName,branch.Id);
                if(image is not null)
                {
                    _fileUploadService.DeleteFile(_branchPicturesFolderPath.CombineWithCurrentDirectory(),imgName);
                    await _imageRepository.DeleteAsync(image,false,false);
                }
            }
        }

        branch.Title = request.Title;
        branch.Slug = request.Slug;
        branch.Description = request.Description;
        branch.Address = request.Address;
        await _branchRepository.UpdateAsync(branch);
    }
}