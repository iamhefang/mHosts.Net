using System;
using System.Xml.Serialization;

namespace mHosts.Net.entities
{
    [Serializable]
    class Tool
    {
        [XmlAttribute]
        public string Id { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string Cmd { get; set; }

        [XmlAttribute]
        public string Args { get; set; }

        public Tool[] Children { get; set; } = new Tool[0];
    }
}
