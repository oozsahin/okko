using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace okko.uzapi.Models
{
    public class ComboBoxViewModel
    {
        public List<PersonLocations> PersonLocationList { get; set; }
        public List<PersonPositions> PersonPositionList { get; set; }
        public List<PersonTitles> PersonTitleList { get; set; }

    }
}
