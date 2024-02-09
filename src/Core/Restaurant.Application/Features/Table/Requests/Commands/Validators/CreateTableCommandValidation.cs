using Restaurant.Application.Configs;

namespace Restaurant.Application.Features.Table.Requests.Commands.Validators;

public class CreateTableCommandValidation : AbstractValidator<CreateTableCommand>
{
    public CreateTableCommandValidation()
    {
        RuleFor(p => p.Title)
        .NotEmpty().WithMessage(Messages.Validation.Required)
        .NotNull().WithMessage(Messages.Validation.Required)
        .MaximumLength(100).WithMessage(Messages.Validation.MaxLength);

        RuleFor(p => p.Description)
          .NotEmpty().WithMessage(Messages.Validation.Required)
          .NotNull().WithMessage(Messages.Validation.Required)
          .MaximumLength(5000).WithMessage(Messages.Validation.MaxLength);

        RuleFor(p => p.Slug)
          .MaximumLength(100).WithMessage(Messages.Validation.MaxLength)
          .Matches(RegularExpressions.Slug).WithMessage(Messages.Validation.RegularExpression);

        RuleFor(p => p.BranchId)
          .NotNull().WithMessage(Messages.Validation.Required)
          .GreaterThan(0).WithMessage(Messages.Validation.GreaterThanZero);

        RuleForEach(p => p.ImagesBase64)
           .Matches(RegularExpressions.Base64).WithMessage(Messages.Validation.RegularExpression)
           .Base64SizeCheck(500)
           .Base64ExtensionCheck(["png","jpg","webp"]);
    }
}