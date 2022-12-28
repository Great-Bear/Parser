using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Model.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }

        public string? DateCreation { get; set; }

        [NotMapped]
        public string LinkToConfig { get; set; }

        public ICollection<Configuration_Car?> Configuration_Cars { get; set; }
    }
}
