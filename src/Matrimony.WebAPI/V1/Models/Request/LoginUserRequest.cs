using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matrimony.WebAPI.V1.Models.Request
{
    public class LoginUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
