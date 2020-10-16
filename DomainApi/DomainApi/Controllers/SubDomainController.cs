using DomainApi.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DomainApi.Controllers
{
    //[RoutePrefix("api/subdomain")]
    [EnableCors("*", "*", "*")]
    public class SubDomainController : ApiController
    {
        private ISubDomainService _subDomainService;

        public SubDomainController()
            : this(new SubDomainService())
        {
        }

        public SubDomainController(ISubDomainService subDomainService)
        {
            _subDomainService = subDomainService;
        }

        [HttpGet]
        [Route("enumerate/{domainname}")]
        public IHttpActionResult Get(string domainname)
        {
            var result = _subDomainService.Enumerate(domainname);
            return Ok(result);
        }

        [HttpPost]
        [Route("findipaddresses")]
        public IHttpActionResult FindIpAddress([FromBody]List<string> subDomains)
        {
            var result = _subDomainService.FindIpAddresses(subDomains);
            return Ok(result);
        }
    }
}