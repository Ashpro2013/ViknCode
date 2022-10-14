using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ViknCode_Core.Models;

namespace ViknCode_Core.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ViknCode_Core.Models.EmployeeDetails> EmployeeDetails { get; set; }
        public DbSet<ViknCode_Core.Models.Designation> Designation { get; set; }

    }
}