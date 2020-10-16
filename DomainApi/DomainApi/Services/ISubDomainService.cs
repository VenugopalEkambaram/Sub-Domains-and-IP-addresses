using DomainApi.Models;
using System.Collections.Generic;

namespace DomainApi.Services
{
    public interface ISubDomainService
    {
        List<string> Enumerate(string domainName);

        List<SubDomain> FindIpAddresses(List<string> subDomains);
    }
}