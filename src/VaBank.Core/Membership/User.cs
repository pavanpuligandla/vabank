﻿using System;
using System.Collections.Generic;
using VaBank.Core.Common;

namespace VaBank.Core.Membership
{
    public class User : Entity<Guid>
    {
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public string UserName { get; set; }
        public int AccessFailedCount { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<UserClaim> Claims { get; set; }
        public virtual UserProfile Profile { get; set; }
        public byte[] RowVersion { get; set; }
    }
}