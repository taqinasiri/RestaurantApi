namespace Restaurant.Application.Features.Order.Requests.Commands.Validators;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(c => c.ToTime)
            .GreaterThan(c => c.FromTime).WithMessage(Messages.Validation.FromAndToDateGreaterThan);
        RuleFor(c => c.FromTime)
            .GreaterThan(c => DateTime.Now).WithMessage(Messages.Validation.GreaterThanNowDateTime);
        RuleFor(c => c.FromTime.GetDate())
            .Equal(c => c.ToTime.GetDate()).WithMessage(Messages.Validation.EqualFromAndToDateDays);
    }
}