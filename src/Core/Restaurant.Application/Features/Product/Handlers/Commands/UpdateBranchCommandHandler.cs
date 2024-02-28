using Restaurant.Application.Features.Product.Requests.Commands;

namespace Restaurant.Application.Features.Product.Handlers.Commands;

public class UpdateProductCommandHandler(
    IMapper mapper,
    IProductRepository productRepository,
    IImageRepository imageRepository,
    IFileUploadService fileUploadService,
    ICategoryRepository categoryRepository,
    IOptionsMonitor<SiteSettings> options) : IRequestHandler<UpdateProductCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IImageRepository _imageRepository = imageRepository;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IFileUploadService _fileUploadService = fileUploadService;
    private readonly string _productPicturesFolderPath = options.CurrentValue.FileFolders.ProductPictures;

    public async Task Handle(UpdateProductCommand request,CancellationToken cancellationToken)
    {
        var product = await _productRepository.FindWithCategoriesByIdAsync(request.Id,false) ?? throw new NotFoundException("Product");

        bool isExists = await _productRepository.IsExistsByTitleOrSlug(request.Title,request.Slug);
        if(isExists && (product.Title != request.Title || product.Slug != request.Slug))
        {
            throw new BadRequestException([Messages.Errors.TitleOrSlugIsExists]);
        }

        if(request.CategoryIds?.Count > 0)
        {
            bool isExitsCategories = await _categoryRepository.IsExistsRange(request.CategoryIds);
            if(!isExitsCategories)
            {
                throw new NotFoundException("Category");
            }
        }

        product.Categories.Clear();
        foreach(var id in request.CategoryIds)
        {
            product.Categories.Add(new() { CategoryId = id });
        }

        if(request.NewImagesBase64?.Count > 0)
        {
            FileUploadResult fileUploadResult = new(true);
            foreach(string img in request.NewImagesBase64)
            {
                fileUploadResult = await _fileUploadService.UploadBase64(img,_productPicturesFolderPath.CombineWithCurrentDirectory());
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
                    Products = []
                };
                image.Products.Add(new() { Product = product });
                await _imageRepository.CreateAsync(image,false);
            }
        }

        if(request.RemoveImageNames?.Count > 0)
        {
            foreach(string imgName in request.RemoveImageNames)
            {
                var image = await _imageRepository.FindForProduct(imgName,product.Id);
                if(image is not null)
                {
                    _fileUploadService.DeleteFile(_productPicturesFolderPath.CombineWithCurrentDirectory(),imgName);
                    await _imageRepository.DeleteAsync(image,false,false);
                }
            }
        }

        product.Title = request.Title;
        product.Slug = request.Slug;
        product.Description = request.Description;
        product.Price = request.Price;
        await _productRepository.UpdateAsync(product);
    }
}