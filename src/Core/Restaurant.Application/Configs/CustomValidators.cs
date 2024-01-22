using Restaurant.Application.Helpers;

namespace Restaurant.Application.Configs;

public static class CustomValidators
{
    public static IRuleBuilderOptions<T,string> Base64SizeCheck<T>(this IRuleBuilder<T,string> ruleBuilder,int sizeKB)
        => ruleBuilder.Must(b => b.RemoveBase64Header().GetBase64FileSize() <= (sizeKB * 1024)).WithMessage(Messages.Validation.MaxFileSize);

    public static IRuleBuilderOptions<T,string> Base64ExtensionCheck<T>(this IRuleBuilder<T,string> ruleBuilder,string[] validExtensions)
        => ruleBuilder.Must(b => validExtensions.Contains(b.RemoveBase64Header().GetBase64Extension())).WithMessage(Messages.Validation.FileExtensionNotValid);
}