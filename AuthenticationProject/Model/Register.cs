using System.ComponentModel.DataAnnotations;

namespace AuthenticationProject.Model
{
    public class Register
    {
        
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password",ErrorMessage ="mismatch of password and confirm password")]
        public string ConfirmPassword { get; set; }
        public string RoleName { get; set; }
    }
}
