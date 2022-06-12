using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BDMI.Model
{
    public class AppUser : IdentityUser
    {
        public string? Nickname { get; set; }
    }
}
