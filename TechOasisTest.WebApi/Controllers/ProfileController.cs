using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechOasisTest.WebApi.Services;

namespace TechOasisTest.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileServices services;

        public ProfileController(ProfileServices services)
        {
            this.services = services;

        }

        [HttpGet]
        [Route("FirstProfile")]
        public async Task<IActionResult> GetFirstProfile()
        {
            return Ok(await services.GetFirstProfileAsync());
        }

        [HttpPost]
        [Route("RequestCV")]
        public async Task<IActionResult> RequestCV(long profileID)
        {
            return Ok(await services.RequestCVAsync(profileID));
        }

        [HttpGet]
        [Route("SearchProfiles")]
        public async Task<IActionResult> SearchProfiles(string token,int page, int pageSize)
        {
            return Ok(await services.SearchJobSeekerProfileAsync(token, page, pageSize));
        }
    }
}
