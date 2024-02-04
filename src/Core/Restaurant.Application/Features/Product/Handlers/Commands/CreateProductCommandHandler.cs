using Restaurant.Application.Features.Product.Requests.Commands;

namespace Restaurant.Application.Features.Product.Handlers.Commands;

public class CreateProductCommandHandler(
    IMapper mapper,
    IProductRepository productRepository,
    IImageRepository imageRepository,
    ICategoryRepository categoryRepository,
    IFileUploadService fileUploadService,
    IOptionsMonitor<SiteSettings> options) : IRequestHandler<CreateProductCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IImageRepository _imageRepository = imageRepository;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IFileUploadService _fileUploadService = fileUploadService;
    private readonly string _productPicturesFolderPath = options.CurrentValue.FileFolders.ProductPictures;

    public async Task Handle(CreateProductCommand request,CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Entities.Product>(request);

        bool isExists = await _productRepository.IsExistsByTitleOrSlug(request.Title,request.Slug);
        if(isExists)
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
            product.Categories = [];
            foreach(var id in request.CategoryIds)
            {
                product.Categories.Add(new() { CategoryId = id });
            }
        }

        if(request.ImagesBase64?.Count > 0)
        {
            FileUploadResult fileUploadResult = new(true);
            foreach(string img in request.ImagesBase64)
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
        await _productRepository.CreateAsync(product);
    }
}