using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace microservice2
{
    public class Platform 
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int ExternalId { get; set; }
        public string Name { get; set; }

        public ICollection<Command> Commands { get; set; } = new List<Command>();
    }
}