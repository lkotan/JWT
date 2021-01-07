using Jwt.Core.Signatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jwt.Models.User
{
    public class UserModel:IBaseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
    }
}
