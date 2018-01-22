using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi_stub.Contracts;
using webapi_stub.Models;

namespace webapi_stub.Controllers
{
    /*
        get /api/profiles 
        post /api/profiles
        put /api/profiles
        patch /api/profiles

        SEE:
        CreatedResult
        NotFoundResult();
        EmptyResult();app.UseMvc(routes =>
{
routes.MapRoute(
name: "default",
template: "{controller=Home}/{action=Index}/{id?}");
});

     */
    [Route("api/[controller]")]
    public class ProfilesController : Controller
    {
        private readonly IProfilesService profileService;
        private readonly AppSettingConfig configuration;

        public ProfilesController(IProfilesService profileService, AppSettingConfig configuration)
        {
            this.profileService = profileService;
            this.configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<Profile> Get()
        {
            return this.profileService.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Profile Get(int id)
        {
            return this.profileService.Get(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Profile profile)
        {
            this.profileService.Add(profile);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public int Delete([FromQuery]int id)
        {
            return this.profileService.Delete(id);
        }


    }
}