using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace okko.uzblazorclient.Models
{
    [Table("PersonLocations")]
    public class PersonLocationsModel
    {
        public int Id { get; set; }
        public string Locations { get; set; }
    }
}
