using Restaurant.Application.Contracts.Identity;
using Restaurant.Application.Features.User.Requests.Commands;

namespace Restaurant.Application.Features.User.Handlers.Commands;

public class UpdateUserCommandHandler(
    IApplicationUserManager userManager,
    IImageRepository imageRepository,
    IFileUploadService fileUploadService,
    IOptionsMonitor<SiteSettings> options) : IRequestHandler<UpdateUserCommand>
{
    private readonly IApplicationUserManager _userManager = userManager;
    private readonly IImageRepository _imageRepository = imageRepository;
    private readonly IFileUploadService _fileUploadService = fileUploadService;
    private readonly string _defaultAvatar = options.CurrentValue.UserDefaultAvatar;
    private readonly string _avatarsPathFolder = options.CurrentValue.FileFolders.UserAvatars;

    public async Task Handle(UpdateUserCommand request,CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id.ToString()) ?? throw new NotFoundException("User");

        if(request.AvatarBase64.IsNotNull())
        {
            string currentImageName = "";
            var image = new Image();

            if(user.AvatarId is not null)
            {
                image = await _imageRepository.FindByIdAsync(user.AvatarId.Value);
                if(image is not null)
                {
                    currentImageName = image.Name;
                    await _imageRepository.DeleteAsync(image,false);
                }
            }

            var fileUploadResult = new FileUploadResult(false);
            if(currentImageName == _defaultAvatar)
            {
                fileUploadResult = await _fileUploadService.UploadBase64(request.AvatarBase64,_avatarsPathFolder.CombineWithCurrentDirectory());
            }
            else
            {
                fileUploadResult = await _fileUploadService.ReUploadBase64(request.AvatarBase64,_avatarsPathFolder.CombineWithCurrentDirectory(),currentImageName);
            }
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
            user.Avatar = image;
        }

        user.UserName = request.UserName;
        user.Email = request.Email;
        user.PhoneNumber = request.PhoneNumber;
        user.IsActive = request.IsActive;
        await _userManager.UpdateAsync(user);
    }
}