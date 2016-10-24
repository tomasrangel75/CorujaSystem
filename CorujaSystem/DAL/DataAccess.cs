using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using CorujaSystem.Models;


namespace CorujaSystem.DAL
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

        public DbSet<UserAction> UserActions { get; set; }

        public DbSet<Report> Rpts { get; set; }
        public DbSet<UserFile> UserFiles { get; set; }

        public DbSet<Test> Tests { get; set; }
        public DbSet<Especialist> Especialists { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Pontuacao> Pontuacaos { get; set; }




    }

}