using Restaurant.Application.Features.Table.Requests.Commands;

namespace Restaurant.Application.Features.Table.Handlers.Commands;

public class UpdateTableCommandHandler(
    IMapper mapper,
    IBranchRepository branchRepository,
    IFileUploadService fileUploadService,
    ITableRepository tableRepository,
    IImageRepository imageRepository,
    IOptionsMonitor<SiteSettings> options) : IRequestHandler<UpdateTableCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IBranchRepository _branchRepository = branchRepository;
    private readonly IFileUploadService _fileUploadService = fileUploadService;
    private readonly IImageRepository _imageRepository = imageRepository;
    private readonly ITableRepository _tableRepository = tableRepository;
    private readonly string _tablePicturesFolderPath = options.CurrentValue.FileFolders.TablePictures;

    public async Task Handle(UpdateTableCommand request,CancellationToken cancellationToken)
    {
        var table = await _tableRepository.FindByIdAsync(request.Id) ?? throw new NotFoundException("Table");

        bool isExists = await _tableRepository.IsExistsByTitleOrSlug(request.Title,request.Slug);
        if(isExists && (table.Title != request.Title || table.Slug != request.Slug))
        {
            throw new BadRequestException([Messages.Errors.TitleOrSlugIsExists]);
        }

        if(request.NewImagesBase64?.Count > 0)
        {
            FileUploadResult fileUploadResult = new(true);
            foreach(string img in request.NewImagesBase64)
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

        if(request.RemoveImageNames?.Count > 0)
        {
            foreach(string imgName in request.RemoveImageNames)
            {
                var image = await _imageRepository.FindForTable(imgName,table.Id);
                if(image is not null)
                {
                    _fileUploadService.DeleteFile(_tablePicturesFolderPath.CombineWithCurrentDirectory(),imgName);
                    await _imageRepository.DeleteAsync(image,false,false);
                }
            }
        }

        table.Title = request.Title;
        table.Slug = request.Slug;
        table.Description = request.Description;
        table.RentalMinutePrice = request.RentalMinutePrice;
        table.Space = request.Space;
        await _tableRepository.UpdateAsync(table);
    }
}