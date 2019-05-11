using MYaSyncQL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYaSyncQL.Client.Forms.Common {
    public class UserSettings {
        public List<ConnectionString> ConnectionStrings { get; set; } = new List<ConnectionString>();
    }
}
