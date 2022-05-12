using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace calendar.Models
{
    public class ProjectCard
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string LaunchDate { get; set; }

        public string Description { get; set; }

        public string BlockChain { get; set; }

        public int Supply { get; set; }

        public int WhiteListSpots { get; set; }

        public string WebSite { get; set; }

        public string Discord { get; set; }

        public string Twitter { get; set; }

        public string Inst { get; set; }

        public bool Listed { get; set; }

        public bool Promoted { get; set; }

        public virtual User User { get; set; }
    }
}
