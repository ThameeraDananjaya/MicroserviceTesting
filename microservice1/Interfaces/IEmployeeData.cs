using System.Collections.Generic;

namespace microservice1
{
    public interface IEmployeeData
    {
       
        List<Employee> GetEmployees();

        Employee GetEmployee(int id);

        Employee AddEmployee(Employee Employee);
        
        Employee UpdateEmployee(int id,Employee employee);

        void DeleteEmployee(int id);
    }
    
}