using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Okko.Shared.Options
{
    public class AppSettingsOptions
    {
        public DefaultSettingsModel defaultSettings { get; set; }
        public IEnumerable<DefaultRolesModel> defaultRoles { get; set; }
        public IEnumerable<DefaultUsersModel> defaultUsers { get; set; }
    }
}
