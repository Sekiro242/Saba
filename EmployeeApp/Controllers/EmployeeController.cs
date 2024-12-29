using Microsoft.AspNetCore.Mvc;
using EmployeeApp.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EmployeeApp.ViewModels;

namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        // Display the list of employees
        public async Task<IActionResult> GetAll()
        {
            var emps = await _context.Employees.Include(x => x.Department).ToListAsync();

            return View(emps);
        }

        // Show the form to create a new employee
        //[HttpGet]
        public async Task<IActionResult> AddEmployee()
        {
            var depList = await _context.Departments.ToListAsync();
            EmployeeViewModel model = new EmployeeViewModel
            {
                DepartmentList = depList
            };
            return View(model);
        }

        // Handle the form submission to add a new employee
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeViewModel employees)
        {
            Employee emp = new Employee
            {
                Name = employees.Name,
                Salary = employees.Salary,
                DepId = employees.DepId
            };

            await _context.Employees.AddAsync(emp);
            await _context.SaveChangesAsync();

            return RedirectToAction("GetAll");
        }

        // update employee
        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            var depList = await _context.Departments.ToListAsync();
            EmployeeViewModel model = new EmployeeViewModel
            {
                Name = emp.Name,
                Salary = emp.Salary,
                DepId = emp.DepId,
                DepartmentList = depList
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(EmployeeViewModel employees, int Id )
        {
            var employee = await _context.Employees.FindAsync(Id);
            if (employee == null)
            {
                return View();
            }
            employee.Name = employees.Name;
            employee.Salary = employees.Salary;
            employee.DepId = employees.DepId;

            _context.Employees.Update(employee);
             _context.SaveChangesAsync();

            return RedirectToAction("GetAll");
        }
    }
}
