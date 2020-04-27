using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mHosts.Net.entities
{
    class Tool
    {
        public string Id;
        public string Name;
        public string Cmd;
        public string Args;
        public Tool[] Children;
    }
}
