using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace okko.uzapi.Models
{
    [Table("PersonTitles")]
    public class PersonTitles
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
