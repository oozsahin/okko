using System;
using System.Collections.Generic;
using System.Text;

namespace Okko.Shared.Helpers
{
    public class NLogHelper : NLogBase
    {
        public NLogHelper() : base(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
        {
            Log.Info("Instance created");
        }
    }
}
