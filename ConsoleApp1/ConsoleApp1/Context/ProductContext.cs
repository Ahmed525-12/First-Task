using ConsoleApp1.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Context
{
    internal class ProductContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = LAPTOP-1TU092KA\\SQLEXPRESS ; Database = ProductContext ; Trusted_Connection = true");
        }

        public DbSet<Product> product { get; set; }
    }
}