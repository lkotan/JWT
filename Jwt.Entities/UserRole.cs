using Jwt.Core.Signatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jwt.Entities
{
    public class UserRole:IBaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }
    }
}
