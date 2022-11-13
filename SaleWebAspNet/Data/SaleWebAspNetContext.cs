using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SaleWebAspNet.Models;

namespace SaleWebAspNet.Data
{
    public class SaleWebAspNetContext : DbContext
    {
        public SaleWebAspNetContext (DbContextOptions<SaleWebAspNetContext> options)
            : base(options)
        {
        }

        public DbSet<SaleWebAspNet.Models.Department> Department { get; set; }
    }
}
