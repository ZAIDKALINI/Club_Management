using System.ComponentModel.DataAnnotations;


namespace MyApps.Models
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
