using System;
using System.Configuration;
using System.Xml.Serialization;

namespace mHosts.Net.entities
{
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public class Host
    {
        [XmlAttribute] public string Id { get; set; }

        [XmlAttribute] public string Name { get; set; }
        
        public bool ReadOnly { get; set; } = false;

        public bool AlwaysApply { get; set; } = false;
        
        public string Url { get; set; }

        public DateTime LastUpdateTime { get; set; }

        public bool Active { get; set; } = false;
        
        public string Content { get; set; }
        
        public string Icon { get; set; }
    }
}