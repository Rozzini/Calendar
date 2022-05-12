using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace calendar.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        public string Address { get; set; }

        public ICollection<ProjectCard> projectCards { get; set; }
    }
}
