namespace Restaurant.Application.Features.User.Requests.Commands.Validators;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(p => p.PhoneNumber)
            .NotEmpty().WithMessage(Messages.Validation.Required)
            .NotNull().WithMessage(Messages.Validation.Required)
            .Matches(RegularExpressions.PhoneNumber).WithMessage(Messages.Validation.RegularExpression);

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage(Messages.Validation.Required)
            .NotNull().WithMessage(Messages.Validation.Required)
            .Matches(RegularExpressions.Email).WithMessage(Messages.Validation.RegularExpression);

        RuleFor(p => p.UserName)
            .NotEmpty().WithMessage(Messages.Validation.Required)
            .NotNull().WithMessage(Messages.Validation.Required)
            .MaximumLength(50).WithMessage(Messages.Validation.MaxLength)
            .Matches(RegularExpressions.UserName).WithMessage(Messages.Validation.RegularExpression);

        RuleFor(p => p.IsActive).NotNull().WithMessage(Messages.Validation.Required);
        RuleFor(p => p.Id).NotNull().WithMessage(Messages.Validation.Required);
    }
}