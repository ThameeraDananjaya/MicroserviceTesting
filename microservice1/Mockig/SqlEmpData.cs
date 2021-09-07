using System.Collections.Generic;
using System.Linq;

namespace microservice1
{
    public class SqlEmpData : IEmployeeData
    {
        private readonly MS1Context MS1Context;

        public SqlEmpData(MS1Context ms1Context)
        {
            MS1Context = ms1Context;    
        }
        public Employee AddEmployee(Employee employee)
        {
            if(employee!=null)
            {
                MS1Context.Employees.Add(employee);
                MS1Context.SaveChanges();
            }

            return employee;
        }

        public void DeleteEmployee(int id)
        {

                Employee emp = MS1Context.Employees.Where(x => x.Id == id).FirstOrDefault();
                if(emp != null)
                {
                    MS1Context.Employees.Remove(emp);
                    MS1Context.SaveChanges();
                }
           
        }

        public Employee GetEmployee(int id)
        {
            return MS1Context.Employees.Where(x => x.Id==id).FirstOrDefault();
        }

        public List<Employee> GetEmployees()
        {
            return MS1Context.Employees.ToList();
        }

        public Employee UpdateEmployee(int id, Employee employee)
        {
            if (employee!=null)
            {
                Employee emp = MS1Context.Employees.Where(x => x.Id==id).FirstOrDefault();
                emp.Name = employee.Name;
                MS1Context.SaveChanges();
                employee.Id=id;
            }
            return employee;
        }
    }
}
