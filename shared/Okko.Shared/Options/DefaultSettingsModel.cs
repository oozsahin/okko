using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Okko.Shared.Options
{
    public class DefaultSettingsModel
    {
        public string ListPageSize { get; set; }
        public string DefaultPassword { get; set; }
        public string APIBaseUrl { get; set; }
        public string APIPathDeposit { get; set; }
        public string APIPathCredit { get; set; }
        public string APIPathUser { get; set; }
        public string APIPathToken { get; set; }
    }
}
