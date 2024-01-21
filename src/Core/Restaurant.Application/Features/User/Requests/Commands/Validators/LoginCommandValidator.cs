namespace Restaurant.Application.Features.User.Requests.Commands.Validators;

public class LoginCommandValidator : AbstractValidator<VerifyLoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(p => p.PhoneNumberOrEmail)
          .NotEmpty().WithMessage(Messages.Validation.Required)
          .NotNull().WithMessage(Messages.Validation.Required)
          .MaximumLength(200).WithMessage(Messages.Validation.MaxLength)
          .Matches(@"^([\w-\.]+@([\w-]+\.)+[\w-]{2,})|09[\d]{9}$").WithMessage(Messages.Validation.RegularExpression);

        RuleFor(p => p.Code)
            .NotEmpty().WithMessage(Messages.Validation.Required)
            .NotNull().WithMessage(Messages.Validation.Required)
            .Matches(@"^[0-9]{1,6}$").WithMessage(Messages.Validation.RegularExpression);
    }
}