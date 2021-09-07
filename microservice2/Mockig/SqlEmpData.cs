using System.Collections.Generic;
using System.Linq;

namespace microservice2
{
    public class SqlEmpData : IEmployeeData
    {
        private readonly MS2Context MS2Context;

        public SqlEmpData(MS2Context ms2Context)
        {
            MS2Context = ms2Context;    
        }
        public Employee AddEmployee(Employee employee)
        {
            if(employee!=null)
            {
                MS2Context.Employees.Add(employee);
                MS2Context.SaveChanges();
            }

            return employee;
        }

        public void DeleteEmployee(int id)
        {

                Employee emp = MS2Context.Employees.Where(x => x.Id == id).FirstOrDefault();
                if(emp != null)
                {
                    MS2Context.Employees.Remove(emp);
                    MS2Context.SaveChanges();
                }
           
        }

        public Employee GetEmployee(int id)
        {
            return MS2Context.Employees.Where(x => x.Id==id).FirstOrDefault();
        }

        public List<Employee> GetEmployees()
        {
            return MS2Context.Employees.ToList();
        }

        public Employee UpdateEmployee(int id, Employee employee)
        {
            if (employee!=null)
            {
                Employee emp = MS2Context.Employees.Where(x => x.Id==id).FirstOrDefault();
                emp.Name = employee.Name;
                MS2Context.SaveChanges();
                employee.Id=id;
            }
            return employee;
        }
    }
}
