using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CorujaPresentation.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //Additional fields

        public int IdUser { get; set; }

        public DateTime? RegisterDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? LastLogin { get; set; }

        public string FirstName { get; set; }
  
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public string Graduation { get; set; }

        public string Cep { get; set; }

        public string Address { get; set; }

        public string AddressNumber { get; set; }

        public string AddressDetail { get; set; }

        public string Nhood { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        //public string Country { get; set; }

        public bool NewsLetter { get; set; } = true;

        public string CellPhoneNumber { get; set; }

        ////////////////////////////////////


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
           
}