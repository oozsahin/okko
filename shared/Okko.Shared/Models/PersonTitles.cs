using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Okko.Shared.Models
{
    [Table("PersonTitles")]
    public class PersonTitles
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
