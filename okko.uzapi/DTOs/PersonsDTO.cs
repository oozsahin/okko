using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace okko.uzapi.DTOs
{
    public class PersonsDTO
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
    public class PersonsCreateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string IPT { get; set; }
        [Required]
        public string CelPhone { get; set; }
    }
}
