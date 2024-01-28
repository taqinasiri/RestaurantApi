using Restaurant.Application.Configs;

namespace Restaurant.Application.Features.Category.Requests.Commands.Validators;

public class UpdateCategoryCommandValidation : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidation()
    {
        RuleFor(p => p.Id)
          .NotEmpty().WithMessage(Messages.Validation.Required)
          .NotNull().WithMessage(Messages.Validation.Required);

        RuleFor(p => p.Title)
          .NotEmpty().WithMessage(Messages.Validation.Required)
          .NotNull().WithMessage(Messages.Validation.Required)
          .MaximumLength(100).WithMessage(Messages.Validation.MaxLength);

        RuleFor(p => p.Description)
          .NotEmpty().WithMessage(Messages.Validation.Required)
          .NotNull().WithMessage(Messages.Validation.Required)
          .MaximumLength(4000).WithMessage(Messages.Validation.MaxLength);

        RuleFor(p => p.Slug)
          .MaximumLength(100).WithMessage(Messages.Validation.MaxLength)
          .Matches(RegularExpressions.Slug).WithMessage(Messages.Validation.RegularExpression);

        RuleFor(p => p.PictureBase64)
          .Matches(RegularExpressions.Base64).WithMessage(Messages.Validation.RegularExpression)
          .Base64SizeCheck(50)
          .Base64ExtensionCheck(["png","jpg"]);
    }
}