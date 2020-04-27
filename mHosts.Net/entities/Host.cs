using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace mHosts.Net.entities
{
    internal class Host:ISerializable
    {
        public string Id;
        public string Name;
        public bool ReadOnly = false;
        public bool AlwaysApply = false;
        public string Url;
        public DateTime LastUpdateTime;
        public bool Active = false;
        public string Content;
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
