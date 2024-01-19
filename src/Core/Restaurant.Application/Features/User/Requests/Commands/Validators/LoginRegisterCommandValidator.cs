namespace Restaurant.Application.Features.User.Requests.Commands.Validators;

public class LoginRegisterCommandValidator : AbstractValidator<LoginRegisterCommand>
{
    public LoginRegisterCommandValidator()
    {
        RuleFor(p => p.PhoneNumberOrEmail)
           .NotEmpty().WithMessage(Messages.Validation.Required)
           .NotNull().WithMessage(Messages.Validation.Required)
           .MaximumLength(200).WithMessage(Messages.Validation.MaxLength)
           .Matches(@"^([\w-\.]+@([\w-]+\.)+[\w-]{2,})|09[\d]{9}$").WithMessage(Messages.Validation.RegularExpression);
    }
}