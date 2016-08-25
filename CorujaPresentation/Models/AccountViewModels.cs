using CorujaPresentation.Models.Validation;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CorujaPresentation.Models
{

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Me relembrar?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        
        //Custom fields ////////////////////////////////////

        [Required(ErrorMessage ="O campo Nome é obrigatório")]
        [StringLength(30, ErrorMessage = "O {0} deve ter ao menos {2} caracteres.", MinimumLength = 3)]
        [Display(Name = "Nome")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "O campo Sobrenome é obrigatório")]
        [StringLength(30, ErrorMessage = "O {0} deve ter ao menos {2} caracteres.", MinimumLength = 3)]
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }

        
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
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

        [Display(Name = "Estado")]
        [StringLength(2)]
        public string State { get; set; }

        //[Display(Name = "País")]
        //[StringLength(20)]
        //public string Country { get; set; }
     
        public bool NewsLetter { get; set; } = true;

        ////////////////////////////////////////////////////////

        [Required]
        [StringLength(50, ErrorMessage = "O {0} deve ter ao menos {2} caracteres.", MinimumLength = 3)]
        public string Name { get; set; }
     
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [EmailAddress(ErrorMessage ="Email inválido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

         [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone Residencial")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Celular")]
        public string CellPhoneNumber { get; set; }

        ////////////////////////////////////////////////////////

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter ao menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Password", ErrorMessage = "A senha e a senha de confirmação não conferem.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter ao menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Password", ErrorMessage = "A senha e a senha de confirmação não conferem.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
