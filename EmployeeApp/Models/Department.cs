using System.ComponentModel;

namespace EmployeeApp.Models
{
    public class Department
    {
        [DisplayName("Department ID")]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
