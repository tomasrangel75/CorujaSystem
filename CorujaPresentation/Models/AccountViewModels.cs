using CorujaPresentation.Models.Validation;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CorujaPresentation.Models
{

    public class ForgotViewModel
    {
        [Required(ErrorMessage = "Email obrigatório")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email obrigatório")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatória")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Me relembrar?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {

        //Custom fields ////////////////////////////////////

        [Required(ErrorMessage ="Nome obrigatório")]
        [StringLength(30, ErrorMessage = "O {0} deve ter ao menos {2} caracteres", MinimumLength = 3)]
        [Display(Name = "Nome")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Sobrenome obrigatório")]
        [StringLength(30, ErrorMessage = "O {0} deve ter ao menos {2} caracteres", MinimumLength = 3)]
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }

        
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date,ErrorMessage = "O formato da data deve ser dd/mm/yyyy")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public System.DateTime? BirthDate { get; set; }


        [Display(Name = "CPF")]
        [Required(ErrorMessage = "CPF obrigatório")]
        [Cpf(ErrorMessage = "CPF inválido")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "RG obrigatório")]
        [Display(Name = "RG")]
        public string Rg { get; set; }

        [Display(Name = "Graduação")]
        [StringLength(30)]
        public string Graduation { get; set; }

        [Display(Name = "CEP")]
        //[Cep("Cep inválido")]
        public string Cep { get; set; }
 
        [Display(Name = "Endereço")]
        [StringLength(50)]
        public string Address { get; set; }

        [Display(Name = "Número")]
        [StringLength(20)]
        public string AddressNumber { get; set; }

        [Display(Name = "Complemento")]
        [StringLength(20)]
        public string AddressDetail { get; set; }

        [Display(Name = "Bairro")]
        [StringLength(20)]
        public string Nhood { get; set; }

        [Display(Name = "Cidade")]
        [StringLength(20)]
        public string City { get; set; }

        [Display(Name = "UF")]
        [StringLength(2)]
        public string State { get; set; }

        public bool NewsLetter { get; set; } = true;

        ////////////////////////////////////////////////////////
        
     
        [Required(ErrorMessage = "Email obrigatório")]
        [EmailAddress(ErrorMessage ="Email inválido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

         [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Celular")]
        public string CellPhoneNumber { get; set; }

        ////////////////////////////////////////////////////////

        [Required(ErrorMessage = "Senha obrigatória")]
        [StringLength(100, ErrorMessage = "A {0} deve ter ao menos {2} caracteres", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Password", ErrorMessage = "A senha e a senha de confirmação não conferem")]
        public string ConfirmPassword { get; set; }
    }

    public class EditViewModel
    {
        
        public EditViewModel(ApplicationUser user)
        {
            this.IdUser = user.IdUser;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Email = user.Email;
            this.BirthDate = user.BirthDate;
            this.Cpf = user.Cpf;
            this.Rg = user.Rg;
            this.Graduation = user.Graduation;
            this.Cep = user.Cep;
            this.Address = user.Address;
            this.AddressNumber = user.AddressNumber;
            this.AddressDetail = user.AddressDetail;
            this.Nhood = user.Nhood;
            this.City = user.City;
            this.State = user.State;
            this.NewsLetter = user.NewsLetter;
            this.Email = user.Email;
            this.PhoneNumber = user.PhoneNumber;
            this.CellPhoneNumber = user.CellPhoneNumber;
        }

        public int IdUser { get; set; }

        public string UserName { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        [StringLength(30, ErrorMessage = "O {0} deve ter ao menos {2} caracteres", MinimumLength = 3)]
        [Display(Name = "Nome")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Sobrenome obrigatório")]
        [StringLength(30, ErrorMessage = "O {0} deve ter ao menos {2} caracteres", MinimumLength = 3)]
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }


        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date, ErrorMessage = "O formato da data deve ser dd/mm/yyyy")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public System.DateTime? BirthDate { get; set; }


        [Display(Name = "CPF")]
        [Required(ErrorMessage = "CPF obrigatório")]
        [Cpf(ErrorMessage = "CPF inválido")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "RG obrigatório")]
        [Display(Name = "RG")]
        public string Rg { get; set; }

        [Display(Name = "Graduação")]
        [StringLength(30)]
        public string Graduation { get; set; }

        [Display(Name = "CEP")]
        //[Cep("Cep inválido")]
        public string Cep { get; set; }

        [Display(Name = "Endereço")]
        [StringLength(50)]
        public string Address { get; set; }

        [Display(Name = "Número")]
        [StringLength(20)]
        public string AddressNumber { get; set; }

        [Display(Name = "Complemento")]
        [StringLength(20)]
        public string AddressDetail { get; set; }

        [Display(Name = "Bairro")]
        [StringLength(20)]
        public string Nhood { get; set; }

        [Display(Name = "Cidade")]
        [StringLength(20)]
        public string City { get; set; }

        [Display(Name = "UF")]
        [StringLength(2)]
        public string State { get; set; }

        public bool NewsLetter { get; set; } = true;
        
        [Required]
        [StringLength(50, ErrorMessage = "O {0} deve ter ao menos {2} caracteres", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Celular")]
        public string CellPhoneNumber { get; set; }
        
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Email obrigatório")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatória")]
        [StringLength(100, ErrorMessage = "A {0} deve ter ao menos {2} caracteres", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Password", ErrorMessage = "A senha e a senha de confirmação não conferem")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Email obrigatório")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Senha atual obrigatória")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha atual")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Nova Senha obrigatória")]
        [StringLength(100, ErrorMessage = "A {0} deve ter ao menos {2} caracteres", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova senha")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar nova senha")]
        [Compare("NewPassword", ErrorMessage = "A nova senha e a senha de confirmação não conferem")]
        public string ConfirmPassword { get; set; }
    }

    public class RoleUsers
    {

        public string UserMail { get; set; }
        public string UserName { get; set; }
        public System.DateTime? RegisterDate { get; set; }
    }

    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nome")]
        public string Name { get; set; }
    }

    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }
    }

}
