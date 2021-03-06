﻿using FluentValidation.Results;
using VaBank.Core.Membership.Entities;
using VaBank.Services.Contracts.Common.Commands;
using VaBank.Services.Contracts.Common.Queries;

namespace VaBank.Services.Common.Security
{
    public class UserCommandValidator : SecurityValidator<IUserCommand>
    {
        public UserCommandValidator(VaBankIdentity identity) : base(identity)
        {
            Inherit(new AuthenticatedSecurityValidator(identity));
            Custom(IsSecure);
        }

        private ValidationFailure IsSecure(IUserCommand command)
        {
            if (Identity.IsInRole(UserClaim.Roles.Customer) && command.UserId != Identity.UserId)
            {
                return new ValidationFailure(RootPropertyName, Messages.InsufficientRights);
            }
            return null;
        }
    }
}
