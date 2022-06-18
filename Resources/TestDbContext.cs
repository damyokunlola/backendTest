using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
 using System.Linq;
using System.Threading.Tasks;
using Test.Model;

namespace Test.Resources
{
    public class TestDbContext:DbContext
    {

        public TestDbContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }

    }
}
