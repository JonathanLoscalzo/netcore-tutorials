using System.Collections.Generic;
using webapi_stub.Models;

namespace webapi_stub.Contracts
{
    public interface IProfilesService
    {
        string GetProfileName(int id);

        IEnumerable<Profile> Get();

        void Add(Profile profile);

        int Delete(int id);
        
        Profile Get(int id);
    }
}