using System;
using System.Configuration;
using System.Xml.Serialization;

namespace mHosts.Net.entities
{
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public class Tool
    {
        [XmlAttribute]
        public string Id { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        public string Cmd { get; set; }

        public string Args { get; set; }

        public Tool[] Children { get; set; } = new Tool[0];
    }
}
