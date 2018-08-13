using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAssembly
{
    
    [DataContract]
    public class Client
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Score { get; set; }

    }

    [DataContract]
    public class Message
    {
        public Dictionary<string, string> content = new Dictionary<string, string>();

        [DataMember]
        public string Sender { get; set; }

        [DataMember]
        //public Dictionary<string, string> Content { get; set; }
        public string Content { get; set; }

    }


}
