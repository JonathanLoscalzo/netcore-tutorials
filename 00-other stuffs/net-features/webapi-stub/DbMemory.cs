using System.Collections.Generic;
using System.Linq;
using webapi_stub.Models;

namespace webapi_stub
{
    public class DbMemory
    {
        public List<Profile> profiles { get; set; }

        public DbMemory()
        {

            this.profiles = new List<Profile> {
                new Profile() { Id = 1, Name ="Profile1" },
                new Profile() { Id = 2, Name ="Profile2" }
            };

        }
    }
}