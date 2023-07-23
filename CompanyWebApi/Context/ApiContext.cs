using CompanyWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApi.Context
{
    public class ApiContext: DbContext
    {
        public ApiContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Company> companies { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<Contact> contacts { get; set; }
    }
}
