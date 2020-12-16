 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

 namespace ASP.NETapp.Data
{
    public class DbInitializer
    {
        public static void Initialize(AspNetAppDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
