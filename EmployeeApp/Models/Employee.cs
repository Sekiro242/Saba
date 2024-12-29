using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string ?Name { get; set; }
        public int Salary { get; set; }
        
        public int DepId { get; set; }
        [ForeignKey("DepId")]
        public Department Department { get; set; }
    }

}
