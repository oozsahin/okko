using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace okko.uzapi.Models
{

    [Table("Persons")]
    public partial class Persons
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Title { get; set; }
        public string Position { get; set; }
        public string Location { get; set; }
        public string IPT { get; set; }
        public string CelPhone { get; set; }
    }
}
