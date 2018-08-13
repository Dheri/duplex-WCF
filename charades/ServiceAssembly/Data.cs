﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAssembly
{
    class Data
    {
    }

    [DataContract]
    public class Message
    {
        private Dictionary<string, string> content = new Dictionary<string, string>();

        [DataMember]
        public string Sender { get; set; }

        [DataMember]
        public Dictionary<string, string> Content { get; set; }
    }


    [DataContract]
    public class Client
    {
        [DataMember]
        public string Name { get; set; }

    }
}
