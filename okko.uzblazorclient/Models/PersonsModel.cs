using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace okko.uzblazorclient.Models
{

    [Table("Persons")]
    public class PersonsModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "You need to keep the first name to a max of 50 characters")]
        [MinLength(3, ErrorMessage = "You need to enter at least 3 characters for an first name")]
        [DisplayName("First Name")]
        public string Firstname { get; set; }
        [DisplayName("Last Name")]
        public string Lastname { get; set; }
        [DisplayName("Title Id")]
        public int TitleId { get; set; }
        [DisplayName("Title")]
        public string Title { get; set; }
        [DisplayName("Position Id")]
        public int PositionId { get; set; }
        [DisplayName("Position")]
        public string Position { get; set; }
        [DisplayName("Location Id")]
        public int LocationId { get; set; }
        [DisplayName("Location")]
        public string Location { get; set; }
        [DisplayName("IPT")]
        public string IPT { get; set; }
        [DisplayName("Cell Phone")]
        public string CelPhone { get; set; }
        public string RecordUser { get; set; }
        public DateTime RecordDate { get; set; }
        public string RecordStatus { get; set; }

    }


}
