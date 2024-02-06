using Restaurant.Application.Configs;

namespace Restaurant.Application.Features.Branch.Requests.Commands.Validators;

public class UpdateBranchCommandValidation : AbstractValidator<UpdateBranchCommand>
{
    public UpdateBranchCommandValidation()
    {
        RuleFor(p => p.Id)
          .NotEmpty().WithMessage(Messages.Validation.Required)
          .NotNull().WithMessage(Messages.Validation.Required);

        RuleFor(p => p.Title)
         .NotEmpty().WithMessage(Messages.Validation.Required)
         .NotNull().WithMessage(Messages.Validation.Required)
         .MaximumLength(100).WithMessage(Messages.Validation.MaxLength);

        RuleFor(p => p.Description)
          .MaximumLength(5000).WithMessage(Messages.Validation.MaxLength);

        RuleFor(p => p.Address)
          .NotEmpty().WithMessage(Messages.Validation.Required)
          .NotNull().WithMessage(Messages.Validation.Required)
          .MaximumLength(200).WithMessage(Messages.Validation.MaxLength);

        RuleFor(p => p.Slug)
          .MaximumLength(100).WithMessage(Messages.Validation.MaxLength)
          .Matches(RegularExpressions.Slug).WithMessage(Messages.Validation.RegularExpression);

        RuleForEach(p => p.NewImagesBase64)
          .Matches(RegularExpressions.Base64).WithMessage(Messages.Validation.RegularExpression)
          .Base64SizeCheck(500)
          .Base64ExtensionCheck(["png","jpg","webp"]);
    }
}