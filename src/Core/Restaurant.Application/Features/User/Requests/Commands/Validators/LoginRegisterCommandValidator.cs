namespace Restaurant.Application.Features.User.Requests.Commands.Validators;

public class LoginRegisterCommandValidator : AbstractValidator<LoginRegisterCommand>
{
    public LoginRegisterCommandValidator()
    {
        RuleFor(p => p.PhoneNumberOrEmail)
           .NotEmpty().WithMessage(Messages.Validation.Required)
           .NotNull().WithMessage(Messages.Validation.Required)
           .MaximumLength(200).WithMessage(Messages.Validation.MaxLength)
           .Matches(RegularExpressions.PhoneNumberOrEmail).WithMessage(Messages.Validation.RegularExpression);
    }
}