using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Date Of Join")]
        public DateTime DateOfJoin { get; set; }

        [Required]
        public string Department { get; set; }

    }
}
