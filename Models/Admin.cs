using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Admin
    {
        public string ApplicationuserId { get; set; }
        public ApplicationUser Applicationuser { get; set; }

    }
}
