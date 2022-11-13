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

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecords { get; set; }
    }
}
