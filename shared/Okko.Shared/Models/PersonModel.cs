using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Okko.Shared.Models
{

    public class PersonModel : IPersonModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int TitleId { get; set; }
        public string Title { get; set; }
        public int PositionId { get; set; }
        public string Position { get; set; }
        public int LocationId { get; set; }
        public string Location { get; set; }
        public string IPT { get; set; }
        public string CellPhone { get; set; }
        public string RecordUser { get; set; }
        public DateTime RecordDate { get; set; } = DateTime.UtcNow;
        public string RecordStatus { get; set; }
        public string Picture { get; set; }

    }
}
