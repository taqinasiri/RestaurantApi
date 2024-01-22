namespace Restaurant.Application.Features.User.Requests.Commands.Validators;

public class LoginCommandValidator : AbstractValidator<VerifyLoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(p => p.PhoneNumberOrEmail)
          .NotEmpty().WithMessage(Messages.Validation.Required)
          .NotNull().WithMessage(Messages.Validation.Required)
          .MaximumLength(200).WithMessage(Messages.Validation.MaxLength)
          .Matches(RegularExpressions.PhoneNumberOrEmail).WithMessage(Messages.Validation.RegularExpression);

        RuleFor(p => p.Code)
            .NotEmpty().WithMessage(Messages.Validation.Required)
            .NotNull().WithMessage(Messages.Validation.Required)
            .Matches(RegularExpressions.VerificationCode).WithMessage(Messages.Validation.RegularExpression);
    }
}