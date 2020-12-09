using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace okko.uzblazorclient.Models
{
    [Table("PersonTitles")]
    public class PersonTitlesModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
