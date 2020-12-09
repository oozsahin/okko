using System.Collections.Generic;

namespace okko.uzblazorclient.Models
{
    public class ComboBoxViewModel
    {
        public List<PersonLocationsModel> PersonLocationList { get; set; }
        public List<PersonPositionsModel> PersonPositionList { get; set; }
        public List<PersonTitlesModel> PersonTitleList { get; set; }

    }
}
