namespace Restaurant.Application.Features.ProductBranch.Requests.Commands.Validators;

public class UpdateProductToBranchIsActiveCommandValidation : AbstractValidator<UpdateProductToBranchIsActiveCommand>
{
    public UpdateProductToBranchIsActiveCommandValidation()
    {
        RuleFor(p => p.ProductId)
        .NotNull().WithMessage(Messages.Validation.Required)
        .GreaterThan(0).WithMessage(Messages.Validation.GreaterThanZero);

        RuleFor(p => p.BranchId)
        .NotNull().WithMessage(Messages.Validation.Required)
        .GreaterThan(0).WithMessage(Messages.Validation.GreaterThanZero);
    }
}