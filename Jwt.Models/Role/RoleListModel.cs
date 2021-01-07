using Jwt.Core.Signatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jwt.Models.Role
{
    public class RoleListModel:IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
