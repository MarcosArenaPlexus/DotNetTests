using ApiNetCore.Domain.Modules.Product.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ApiNetCore.Data
{
    public class ApiNetCoreContext : DbContext
    {
        public ApiNetCoreContext([NotNullAttribute] DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
