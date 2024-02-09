namespace Restaurant.Application.Features.ProductBranch.Requests.Commands.Validators;

public class UpdateProductToBranchPriceCommandValidation : AbstractValidator<UpdateProductToBranchPriceCommand>
{
    public UpdateProductToBranchPriceCommandValidation()
    {
        RuleFor(p => p.Price)
        .NotNull().WithMessage(Messages.Validation.Required)
        .GreaterThan(0).WithMessage(Messages.Validation.GreaterThanZero);

        RuleFor(p => p.ProductId)
        .NotNull().WithMessage(Messages.Validation.Required)
        .GreaterThan(0).WithMessage(Messages.Validation.GreaterThanZero);

        RuleFor(p => p.BranchId)
        .NotNull().WithMessage(Messages.Validation.Required)
        .GreaterThan(0).WithMessage(Messages.Validation.GreaterThanZero);
    }
}