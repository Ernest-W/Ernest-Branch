using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyDBService.Entity
{
    [DataContract]
    public class Complaints
     {
        [DataMember]
        public int title_id { get; set; }
        [DataMember]
        public Nullable<int> customer_id { get; set; }

        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string category { get; set; }
        [DataMember]
        public string body { get; set; }

        [DataMember]
        public string status { get; set; }

    }
}
