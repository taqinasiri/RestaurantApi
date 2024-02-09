using Restaurant.Application.Features.Table.Requests.Commands;

namespace Restaurant.Application.Features.Table.Handlers.Commands;

public class CreateTableCommandHandler(
    IMapper mapper,
    IBranchRepository branchRepository,
    IFileUploadService fileUploadService,
    ITableRepository tableRepository,
    IImageRepository imageRepository,
    IOptionsMonitor<SiteSettings> options) : IRequestHandler<CreateTableCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IBranchRepository _branchRepository = branchRepository;
    private readonly IFileUploadService _fileUploadService = fileUploadService;
    private readonly IImageRepository _imageRepository = imageRepository;
    private readonly ITableRepository _tableRepository = tableRepository;
    private readonly string _tablePicturesFolderPath = options.CurrentValue.FileFolders.TablePictures;

    public async Task Handle(CreateTableCommand request,CancellationToken cancellationToken)
    {
        bool isExitsBranch = await _branchRepository.IsExists(request.BranchId);
        if(!isExitsBranch)
        {
            throw new NotFoundException("Branch");
        }

        bool isExists = await _tableRepository.IsExistsByTitleOrSlug(request.Title,request.Slug);
        if(isExists)
        {
            throw new BadRequestException([Messages.Errors.TitleOrSlugIsExists]);
        }

        var table = _mapper.Map<Entities.Table>(request);

        if(request.ImagesBase64?.Count > 0)
        {
            FileUploadResult fileUploadResult = new(true);
            foreach(string img in request.ImagesBase64)
            {
                fileUploadResult = await _fileUploadService.UploadBase64(img,_tablePicturesFolderPath.CombineWithCurrentDirectory());
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
                    Tables = []
                };
                image.Tables.Add(new() { Table = table });
                await _imageRepository.CreateAsync(image,false);
            }
        }

        table.IsAvailable = true;
        await _tableRepository.CreateAsync(table);
    }
}