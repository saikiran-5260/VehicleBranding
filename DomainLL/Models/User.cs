using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainLL.Models
{
    public class User
    {
        [JsonIgnore]
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string gender { get; set; }
        public string pwd { get; set; }
        public DateTime memberSince { get; set; }

    }
}
