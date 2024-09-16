﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    public class OperationClaim : Entity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }

        public OperationClaim()
        {
            Name = string.Empty;
        }

        public OperationClaim(string name)
        {
            Name = name;
        }

        public OperationClaim(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
