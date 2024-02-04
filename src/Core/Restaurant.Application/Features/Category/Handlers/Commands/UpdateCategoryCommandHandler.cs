using Restaurant.Application.Features.Category.Requests.Commands;

namespace Restaurant.Application.Features.Category.Handlers.Commands;

public class UpdateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IFileUploadService fileUploadService,
    IOptionsMonitor<SiteSettings> options) : IRequestHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IFileUploadService _fileUploadService = fileUploadService;
    private readonly string _categoryPicturesFolderPath = options.CurrentValue.FileFolders.CategoryPictures;

    public async Task Handle(UpdateCategoryCommand request,CancellationToken cancellationToken)
    {
        var caregory = await _categoryRepository.FindByIdAsync(request.Id,false) ?? throw new NotFoundException("Category");

        bool isExists = await _categoryRepository.IsExistsByTitleOrSlug(request.Title,request.Slug);
        if(isExists && (caregory.Title != request.Title || caregory.Slug != request.Slug))
        {
            throw new BadRequestException([Messages.Errors.TitleOrSlugIsExists]);
        }

        if(request.ParentId is not null and not 0 && request.Id != request.ParentId)
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
            var fileUploadResult = await _fileUploadService.ReUploadBase64(request.PictureBase64,_categoryPicturesFolderPath.CombineWithCurrentDirectory(),caregory.Picture!);
            if(!fileUploadResult.IsSuccedded)
            {
                throw new BadRequestException([Messages.Errors.FileUploadFiled]);
            }
            caregory.Picture = fileUploadResult.FileName;
        }

        caregory.Title = request.Title;
        caregory.Slug = request.Slug;
        caregory.Description = request.Description;
        await _categoryRepository.UpdateAsync(caregory);
    }
}