using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UET_CSE.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

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
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

       
        [Required]
        [Display(Name = "Student Name ")]
        [RegularExpression(@"^(([A-Z][a-z]+[\s]{1}[A-za-z]+)|([A-Z][a-z]+))$", ErrorMessage = "Student Name must be valid alphabets")]
        public string StudentName { get; set; }

        [Required]
        [Display(Name = "Father Name")]
        [RegularExpression(@"^(([A-Z][a-z]+[\s]{1}[A-za-z]+)|([A-Z][a-z]+))$", ErrorMessage = "Father Name must be valid alphabets")]
        public string FatherName { get; set; }

        [Required]
        [Display(Name = "CNIC")]
        [RegularExpression(@"[\d]{13}", ErrorMessage ="Length of CNIC must be 13")]
        public string CNIC { get; set; }

        [Required]
        [Display(Name = "Registration Number")]
        [RegularExpression(@"[\d]{4}[-][A-Z|a-z][A-Z|a-z][-][\d]+", ErrorMessage ="Registeration Number must be entered in correct format i.e 0000-ab-0")]
        
        public string RegistrationNumber { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [RegularExpression(@"[\d]{4}", ErrorMessage ="Invalid Session")]
        public string Session { get; set; }

        [Required]
        [RegularExpression(@"[A-Z]", ErrorMessage ="Invalid Section")]
        public string Section { get; set; }



    }

    public class AdminRegistration
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Admin Name")]
        [RegularExpression(@"^(([A-Z][a-z]+[\s]{1}[A-za-z]+)|([A-Z][a-z]+))$", ErrorMessage = "Admin Name must be valid alphabets")]

        public string AdminName { get; set; }


    }

    public class ResetPasswordViewModel
    {
        //[Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        [StringLength(100, ErrorMessage ="The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string NewPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
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

    public class CreatePassword
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }
}


