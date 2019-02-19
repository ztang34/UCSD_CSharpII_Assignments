using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Lab5
{
    [DataContract]
    class DocumentStatistics
    {
        [DataMember]
        public int DocumentCount { get; set; }
        [DataMember]
        public List<string> Documents { get; set; }
        [DataMember]
        public Dictionary<String, int> WordCounts { get; set; }

        public DocumentStatistics()
        {
            DocumentCount = 0;
            Documents = new List<String>();
            WordCounts = new Dictionary<string, int>();
        }
    }
}
