using Restaurant.Application.Contracts.Persistence;
using Restaurant.Application.Features.Category.Requests.Commands;

namespace Restaurant.Application.Features.Category.Handlers.Commands;

public class UpdateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IFileUploadService fileUploadService,
    IImageRepository imageRepository,
    IOptionsMonitor<SiteSettings> options) : IRequestHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IFileUploadService _fileUploadService = fileUploadService;
    private readonly IImageRepository _imageRepository = imageRepository;
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
            string currentImageName = "";
            var image = new Image();

            if(caregory.ImageId is not null)
            {
                image = await _imageRepository.FindByIdAsync(caregory.ImageId.Value);
                if(image is not null)
                {
                    currentImageName = image.Name;
                    await _imageRepository.DeleteAsync(image,false);
                }
            }

            var fileUploadResult = await _fileUploadService.ReUploadBase64(request.PictureBase64,_categoryPicturesFolderPath.CombineWithCurrentDirectory(),currentImageName);
            if(!fileUploadResult.IsSuccedded)
            {
                throw new BadRequestException([Messages.Errors.FileUploadFiled]);
            }

            image = new Image
            {
                Name = fileUploadResult.FileName!,
                Extension = fileUploadResult.FileExtention,
                Size = fileUploadResult.FileSize,
                UploadDate = DateTime.Now
            };
            caregory.Image = image;
        }

        caregory.Title = request.Title;
        caregory.Slug = request.Slug;
        caregory.Description = request.Description;
        await _categoryRepository.UpdateAsync(caregory);
    }
}