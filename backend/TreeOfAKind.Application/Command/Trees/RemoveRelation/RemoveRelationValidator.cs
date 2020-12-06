﻿using FluentValidation;

namespace TreeOfAKind.Application.Command.Trees.RemoveRelation
{
    public class RemoveRelationValidator : AbstractValidator<RemoveRelationCommand>
    {
        public RemoveRelationValidator()
        {
            RuleFor(x => x.First)
                .NotEmpty();

            RuleFor(x => x.Second)
                .NotEmpty();
        }
    }
}