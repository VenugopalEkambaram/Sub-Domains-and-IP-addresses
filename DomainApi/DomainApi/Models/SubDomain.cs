using System.Collections.Generic;
using System.Net;

namespace DomainApi.Models
{
    public class SubDomain
    {
        public string Name { get; set; }
        public List<string> IpAddresses { get; set; }
    }
}