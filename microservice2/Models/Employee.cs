using System.ComponentModel.DataAnnotations;

namespace microservice2
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}