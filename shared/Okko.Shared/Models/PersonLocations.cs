using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Okko.Shared.Models
{
    [Table("PersonLocations")]
    public class PersonLocations
    {
        public int Id { get; set; }
        public string Locations { get; set; }
    }
}
