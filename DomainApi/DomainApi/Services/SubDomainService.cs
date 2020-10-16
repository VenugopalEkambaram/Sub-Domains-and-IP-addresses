using DomainApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace DomainApi.Services
{
    public class SubDomainService : ISubDomainService
    {
        public List<string> Enumerate(string domainName)
        {
            var alphabets = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (char)i);
            var alphaSet1 = alphabets as IList<char> ?? alphabets.ToList();
            var alphaSet2 = alphaSet1.Select(x => x.ToString());

            var subDomainLength = 2;
            for (var i = 0; i < subDomainLength - 1; i++)
            {
                alphaSet2 = alphaSet2.SelectMany(x => alphaSet1, (x, y) => string.Format("{0}{1}.{2}", x, y, domainName));
            }

            var result = alphaSet1.Select(x => string.Format("{0}.{1}", x, domainName)).ToList();
            result.AddRange(alphaSet2.ToList());
            return result;
        }

        public List<SubDomain> FindIpAddresses(List<string> subDomains)
        {
            var result = new List<SubDomain>();
            foreach (var s in subDomains)
            {
                var ipAddresses = new List<string>();
                try
                {
                    ipAddresses = Dns.GetHostAddresses(s).ToList().Select(x => x.ToString()).ToList();
                }
                catch (SocketException e)
                {
                    ipAddresses.Add(e.Message);
                }

                result.Add(new SubDomain { Name = s, IpAddresses = ipAddresses });
            }

            return result;
        }
    }
}