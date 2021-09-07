using System.ComponentModel.DataAnnotations;

namespace microservice1
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}