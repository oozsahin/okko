using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace okko.uzapi.DTOs
{
    public class PersonsDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
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
    }
    public class PersonsCreateDTO
    {
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public int TitleId { get; set; }
        [Required]
        public int PositionId { get; set; }
        [Required]
        public int LocationId { get; set; }
        [Required]
        public string IPT { get; set; }
        [Required]
        public string CellPhone { get; set; }
        public string RecordUser { get; set; }
    }

    public class PersonsUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public int TitleId { get; set; }
        [Required]
        public int PositionId { get; set; }
        [Required]
        public int LocationId { get; set; }
        [Required]
        public string IPT { get; set; }
        [Required]
        public string CellPhone { get; set; }
        public string RecordUser { get; set; }
    }
}
