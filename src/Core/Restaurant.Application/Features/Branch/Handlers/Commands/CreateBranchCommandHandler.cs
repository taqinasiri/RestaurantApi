using Restaurant.Application.Contracts.Identity;
using Restaurant.Application.Features.Branch.Requests.Commands;

namespace Restaurant.Application.Features.Branch.Handlers.Commands;

public class CreateBranchCommandHandler(
    IMapper mapper,
    IBranchRepository branchRepository,
    IImageRepository imageRepository,
    IFileUploadService fileUploadService,
    IApplicationUserManager userManager,
    IOptionsMonitor<SiteSettings> options) : IRequestHandler<CreateBranchCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IBranchRepository _branchRepository = branchRepository;
    private readonly IImageRepository _imageRepository = imageRepository;
    private readonly IFileUploadService _fileUploadService = fileUploadService;
    private readonly IApplicationUserManager _userManager = userManager;
    private readonly string _branchPicturesFolderPath = options.CurrentValue.FileFolders.BranchPictures;

    public async Task Handle(CreateBranchCommand request,CancellationToken cancellationToken)
    {
        bool isExitsUser = await _userManager.IsExists(request.AdminId);
        if(!isExitsUser)
            throw new NotFoundException("User");

        var brach = _mapper.Map<Entities.Branch>(request);
        bool isExists = await _branchRepository.IsExistsByTitleOrSlug(request.Title,request.Slug);
        if(isExists)
        {
            throw new BadRequestException([Messages.Errors.TitleOrSlugIsExists]);
        }

        if(request.ImagesBase64?.Count > 0)
        {
            FileUploadResult fileUploadResult = new(true);
            foreach(string img in request.ImagesBase64)
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
                image.Branches.Add(new() { Branch = brach });
                await _imageRepository.CreateAsync(image,false);
            }
        }
        await _branchRepository.CreateAsync(brach);
    }
}