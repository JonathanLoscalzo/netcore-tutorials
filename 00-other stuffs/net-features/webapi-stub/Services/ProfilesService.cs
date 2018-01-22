using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using webapi_stub.Contracts;
using webapi_stub.Models;

namespace webapi_stub.Services
{
    public class ProfilesService : IProfilesService
    {
        private DbMemory db;

        public ProfilesService(ILogger<ProfilesService> logger, DbMemory db)
        {
            Console.Write("Creación de ProfilesController");
            logger.LogError("ESTO ES UN ERROR!!!! TENÉ CUIDADO LA PROXIMA");
            this.db = db;
        }

        string IProfilesService.GetProfileName(int id)
        {
            return "Un ProfileName";
        }

        public void Add(Profile profile) {
            db.profiles.Add(profile);
        }

        public IEnumerable<Profile> Get() {
            return db.profiles;
        }

        public Profile Get(int id) {
            return db.profiles.Find(x => x.Id == id);
        }

        public int Delete(int id) {
            return db.profiles.RemoveAll(x => x.Id == id);
        }
    }
}