using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO
{
    public class EmployeeDTO
    {
      

        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
