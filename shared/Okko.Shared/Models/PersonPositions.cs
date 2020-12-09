using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Okko.Shared.Models
{
    [Table("PersonPositions")]
    public class PersonPositions
    {
        public int Id { get; set; }
        public string Position { get; set; }
    }
}
