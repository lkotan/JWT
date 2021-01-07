using System;
using System.Collections.Generic;
using System.Text;

namespace Jwt.Core.Models.UserRole
{
    public class UserRoleListModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
