using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Reso.AuthorizationBase.DbManager.Identity
{
    public class ResoUserIntManager : UserManager<ResoUserInt>
    {
        public ResoUserIntManager(IUserStore<ResoUserInt> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<ResoUserInt> passwordHasher, IEnumerable<IUserValidator<ResoUserInt>> userValidators, IEnumerable<IPasswordValidator<ResoUserInt>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<ResoUserInt>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }
    }
}