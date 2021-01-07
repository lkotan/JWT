using Jwt.Core.Signatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jwt.Entities
{
    public class Role:IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
