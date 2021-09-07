using System.Collections.Generic;
using System.Linq;

namespace microservice2
{
    public class MockEmployeeData : IEmployeeData
    {
         private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id=1,
                Name="Thameera"
            },
            new Employee()
            {
                Id=2,
                Name="Dananjaya"
            },
            new Employee()
            {
                Id=3,
                Name="GameKankanamge"
            },

        };

        public Employee AddEmployee(Employee Employee)
        {
            Employee.Id = employees.Count + 1;
            employees.Add(Employee);
            return Employee;
        }

        public void DeleteEmployee(int id)
        {
           Employee employee = GetEmployee(id);
           employees.Remove(employee);
        }

        public Employee GetEmployee(int id)
        {
            return employees.Find(x => x.Id==id);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public Employee UpdateEmployee(int id, Employee employee)
        {
            Employee updatedEmployee = new Employee();
            foreach(Employee emp in employees.Where(x => x.Id==id))
            {
                emp.Name=employee.Name;
                updatedEmployee= emp;
            }
                return updatedEmployee;

        }
    }

}