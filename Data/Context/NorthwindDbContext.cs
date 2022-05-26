
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class NorthwindDbContext:DbContext
    {
        public NorthwindDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
    
}
