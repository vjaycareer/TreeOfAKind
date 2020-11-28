﻿using TreeOfAKind.Domain.UserProfiles;
using TreeOfAKind.Domain.UserProfiles.Rules;

namespace TreeOfAKind.Application.DomainServices
{
    public class AuthUserIdUniquenessChecker : IAuthUserIdUniquenessChecker
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public AuthUserIdUniquenessChecker(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public bool IsUnique(string authUserId) =>
            _userProfileRepository.GetByAuthUserId(authUserId) is null;
    }
}