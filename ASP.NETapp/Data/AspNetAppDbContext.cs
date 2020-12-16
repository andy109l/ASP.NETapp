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
        /// <summary>
        /// Puts together all of the models so they could be used in the database
        /// </summary>
        /// <param name="options"></param>
        public AspNetAppDbContext(DbContextOptions<AspNetAppDbContext> options) : base(options)
        {
        }

        public DbSet<PersonalContact> PersonalContacts { get; set; }    
        public DbSet<BusinessContact> BusinessContacts { get; set; }
    }
}
