using System;
using NLog;

namespace Okko.Shared.Helpers
{
    public class NLogBase
    {
        protected Logger Log { get; set; }
        protected NLogBase(Type declaringType)
        {
            Log = LogManager.GetLogger(declaringType.FullName);

        }
    }
}
