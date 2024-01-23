using Restaurant.Application.Features.Category.Requests.Commands;

namespace Restaurant.Application.Features.Category.Handlers.Commands;

public class CreateCategoryCommandHandler(
    IMapper mapper,
    ICategoryRepository categoryRepository,
    IFileUploadService fileUploadService,
    IOptionsMonitor<SiteSettings> options) : IRequestHandler<CreateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IFileUploadService _fileUploadService = fileUploadService;
    private readonly IMapper _mapper = mapper;
    private readonly string _categoryPicturesFolderPath = options.CurrentValue.FileFolders.CategoryPictures;

    public async Task Handle(CreateCategoryCommand request,CancellationToken cancellationToken)
    {
        var caregory = _mapper.Map<Entities.Category>(request);

        bool isExists = await _categoryRepository.IsExistsByTitleOrSlug(request.Title,request.Slug);
        if(isExists)
        {
            throw new BadRequestException([Messages.Errors.TitleOrSlugIsExists]);
        }

        if(request.ParentId is not null and not 0)
        {
            bool isExistsParent = await _categoryRepository.IsExists(request.ParentId.Value);
            if(!isExistsParent)
            {
                throw new NotFoundException("Parent");
            }
            caregory.ParentId = request.ParentId.Value;
        }

        if(!request.PictureBase64.IsNull())
        {
            var fileUploadResult = await _fileUploadService.UploadBase64(request.PictureBase64,_categoryPicturesFolderPath.CombineWithCurrentDirectory());
            if(!fileUploadResult.IsSuccedded)
            {
                throw new BadRequestException([Messages.Errors.FileUploadFiled]);
            }
            caregory.Picture = fileUploadResult.fileName;
        }

        await _categoryRepository.CreateAsync(caregory);
    }
}