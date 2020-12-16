using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETapp.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETapp.Data
{
    public class AspNetAppDbContext : DbContext
    {
        public AspNetAppDbContext(DbContextOptions<AspNetAppDbContext> options) : base(options)
        {
        }

        public DbSet<PersonalContact> PersonalContacts { get; set; }    
        public DbSet<BusinessContact> BusinessContacts { get; set; }
    }
}
