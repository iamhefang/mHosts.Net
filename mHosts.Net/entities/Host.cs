using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace mHosts.Net.entities
{
    [Serializable]
    internal class Host
    {
        [XmlAttribute] public string Id { get; set; }

        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public bool ReadOnly { get; set; } = false;
        [XmlAttribute]
        public bool AlwaysApply { get; set; } = false;
        [XmlAttribute]
        public string Url { get; set; }
        [XmlAttribute]
        public DateTime LastUpdateTime { get; set; }
        [XmlAttribute]
        public bool Active { get; set; } = false;
        [XmlAttribute]
        public string Content { get; set; }

        public Host()
        {

        }

    }
}
