using EmployeeApp.Models;

namespace EmployeeApp.ViewModels
{
    public class EmployeeViewModel
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public int DepId { get; set; }
        public List<Department>? DepartmentList { get; set; }


    }
}
