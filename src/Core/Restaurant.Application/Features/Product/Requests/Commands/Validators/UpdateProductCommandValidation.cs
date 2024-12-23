﻿using Restaurant.Application.Configs;

namespace Restaurant.Application.Features.Product.Requests.Commands.Validators;

public class UpdateProductCommandValidation : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidation()
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

        RuleFor(p => p.Price)
          .NotNull().WithMessage(Messages.Validation.MaxLength)
          .GreaterThan(0).WithMessage(Messages.Validation.GreaterThanZero);

        RuleForEach(p => p.NewImagesBase64)
          .Matches(RegularExpressions.Base64).WithMessage(Messages.Validation.RegularExpression)
          .Base64SizeCheck(500)
          .Base64ExtensionCheck(["png","jpg","webp"]);
    }
}