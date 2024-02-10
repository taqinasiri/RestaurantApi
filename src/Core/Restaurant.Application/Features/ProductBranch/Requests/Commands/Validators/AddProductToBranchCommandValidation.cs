namespace Restaurant.Application.Features.ProductBranch.Requests.Commands.Validators;

public class AddProductToBranchCommandValidation : AbstractValidator<AddProductToBranchCommand>
{
    public AddProductToBranchCommandValidation()
    {
        RuleFor(p => p.ProductId)
        .NotNull().WithMessage(Messages.Validation.Required)
        .GreaterThan(0).WithMessage(Messages.Validation.GreaterThanZero);

        RuleFor(p => p.BranchId)
        .NotNull().WithMessage(Messages.Validation.Required)
        .GreaterThan(0).WithMessage(Messages.Validation.GreaterThanZero);
    }
}