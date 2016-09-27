using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CorujaPresentation.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("CorujaConnection", throwIfV1Schema: false)
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // Add a DbSet for each one of your Entities
        public DbSet<ReportKey> ReportKeys { get; set; }
        public DbSet<UserMapKey> UserMapKeys { get; set; }
        public DbSet<UserFile> UserFiles { get; set; }

    }

}