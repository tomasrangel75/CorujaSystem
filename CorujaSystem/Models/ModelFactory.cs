using CorujaSystem.Models;
using CorujaSystem.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorujaSystem.Models
{
    public class ModelFactory : IModelFactory
    {

        public ApplicationUser Create(RegisterViewModel RegVm)
        {
            return new ApplicationUser()
            {
                UserName = RegVm.Email,
                Email = RegVm.Email,
                PhoneNumber = RegVm.PhoneNumber,
                SecurityStamp = Guid.NewGuid().ToString(),

                //Additional Fields
                IdUser = RegVm.IdUser,
                RegisterDate = DateTime.Now,
                FirstName = RegVm.FirstName,
                LastName = RegVm.LastName,
                BirthDate = (RegVm.BirthDate.HasValue) ? Convert.ToDateTime(RegVm.BirthDate) : RegVm.BirthDate,
                Cpf = RegVm.Cpf,
                Rg = RegVm.Rg,
                Graduation = RegVm.Graduation,
                Cep = RegVm.Cep,
                Address = RegVm.Address,
                AddressNumber = RegVm.AddressNumber,
                AddressDetail = RegVm.AddressDetail,
                Nhood = RegVm.Nhood,
                City = RegVm.City,
                State = RegVm.State,
                NewsLetter = RegVm.NewsLetter,
                CellPhoneNumber = RegVm.CellPhoneNumber

            };
        }

        public RegisterViewModel Create(ApplicationUser AppUser)
        {
            return new RegisterViewModel()
            {

            };
        }

        public ApplicationUser CreateEdt(EditViewModel EditVm)
        {
            return new ApplicationUser
            {



            };
        }

        public EditViewModel CreateEdt(ApplicationUser AppUser)
        {
            return new EditViewModel
            {
                IdUser = AppUser.IdUser,
                UserName = AppUser.UserName,

                FirstName = AppUser.FirstName,
                LastName = AppUser.LastName,

                BirthDate = AppUser.BirthDate,

                Cpf = AppUser.Cpf,
                Rg = AppUser.Rg,
                Graduation = AppUser.Graduation,
                Cep = AppUser.Cep,
                Address = AppUser.Address,
                AddressNumber = AppUser.AddressNumber,
                AddressDetail = AppUser.AddressDetail,
                Nhood = AppUser.Nhood,
                City = AppUser.City,
                State = AppUser.State,

                NewsLetter = AppUser.NewsLetter,
                Email = AppUser.Email,
                PhoneNumber = AppUser.PhoneNumber,
                CellPhoneNumber = AppUser.CellPhoneNumber,

            };

        }

    }
}
