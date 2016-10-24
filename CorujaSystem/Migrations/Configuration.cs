namespace CorujaSystem.Migrations
{
    using DAL;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;
    internal sealed class Configuration : DbMigrationsConfiguration<CorujaSystem.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }


        protected override void Seed(ApplicationDbContext context)
        {
            // Role 
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (RoleManager.RoleExists("Admin") == false)
            {
                RoleManager.Create(new IdentityRole("Admin"));
            }

            if (RoleManager.RoleExists("Basico") == false)
            {
                RoleManager.Create(new IdentityRole("Basico"));
            }

            // User
            var PasswordHash = new PasswordHasher();


            var userUpdate = new ApplicationUser
            {
                // Add the following so our Seed data is complete:
                //Custom Fields //////////////////////////////////////////
                IdUser = 1,
                RegisterDate = DateTime.Now,
                FirstName = "Tomás",
                LastName = "Rangel",
                BirthDate = Convert.ToDateTime("10/05/1975"),
                Cpf = "278230298-12",
                Rg = "22174992-5",
                Graduation = "Malabarismo no sinal",
                Cep = "05376050",
                Address = "Rua Maso di Bianco",
                AddressNumber = "102",
                AddressDetail = "Barraco dos Fundos",
                Nhood = "Buraco fundo",
                City = "São Paulo",
                State = "SP",
                //Country = "BrasilVaronil",
                NewsLetter = true,
                //////////////////////////////////////////////////////////

                UserName = "tomas@devtomas.com.br",
                Email = "tomas@devtomas.com.br",
                PhoneNumber = "551100000000",
                CellPhoneNumber = "5511984076905",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = PasswordHash.HashPassword("C0ruj@2013"),
                UsedReport = 0
            };

            context.Users.AddOrUpdate(U => U.UserName,
            userUpdate
            );


            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            UserManager.AddToRole(userUpdate.Id, "Admin");

            SaveChanges(context);

        }

        private void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
    }
}
