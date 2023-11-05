using ConsoleApp1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Company
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }

        public Company(string name)
        {
            Name = name;
            Employees = new List<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public Employee GetEmployeeById(int id)
        {
            Employee foundEmployee = Employees.Find(e => e.Id == id);
            if (foundEmployee == null)
            {
                throw new EmployeeNotFoundException($"Employee with ID {id} not found.");
            }
            return foundEmployee;
        }

        public void UpdateEmployee(Employee employee)
        {
            int index = Employees.FindIndex(e => e.Id == employee.Id);
            if (index != -1)
            {
                Employees[index] = employee;
            }
            else
            {
                throw new EmployeeNotFoundException($"Employee{employee} with ID {employee.Id} not found when trying to update.");
            }
        }

        public void RemoveEmployee(Employee employee)
        {
            Employees.Remove(employee);
        }

        public List<Employee> GetEmployees()
        {
            return Employees;
        }
    }
}


