using Jwt.Core.Signatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jwt.Entities
{
    public class User:IBaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiredDate { get; set; }
    }
}
