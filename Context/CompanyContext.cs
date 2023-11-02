using EFLCT.Models;
using Microsoft.EntityFrameworkCore;

namespace EFLCT.Context
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions options) : base (options)
        { 

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
