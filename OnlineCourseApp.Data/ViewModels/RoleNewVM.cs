using System.ComponentModel.DataAnnotations;
namespace OnlineCourseApp.Data.ViewModels
{
    public class RoleNewVM
    {
        [Required(ErrorMessage = "Obavezno polje")]
        [Display(Name = "Uloga")]
        public string RoleName { get; set; }
    }
}
