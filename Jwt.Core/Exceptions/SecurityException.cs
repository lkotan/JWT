using System;
using System.Collections.Generic;
using System.Text;

namespace Jwt.Core.Exceptions
{
    public class SecurityException:Exception
    {
        public SecurityException(string message) : base(message)
        { }
    }
}
