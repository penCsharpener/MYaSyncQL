using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYaSyncQL.Client.Forms.Common {
    internal static class StaticElements {
        internal static ConnectionManager ConMan = new ConnectionManager();
        internal static LocalSettingsManager Settings = new LocalSettingsManager();
    }
}
