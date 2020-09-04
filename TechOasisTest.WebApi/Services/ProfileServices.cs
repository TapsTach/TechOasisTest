using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechOasisTest.Shared.DTO;
using TechOasisTest.Shared.Entities;

namespace TechOasisTest.WebApi.Services
{
    public class ProfileServices
    {
        private readonly Database database;

        public ProfileServices(Database database)
        {
            this.database = database;
        }

        public async Task<JobSeekerProfile> GetJobSeekerProfileAsync(long profileID)
        {
            return await database.JobSeekerProfiles.Include(p => p.ContactDetails).FirstOrDefaultAsync(p=>p.JobSeekerProfileID == profileID);
        }

        public async Task<SearchModel<JobSeekerProfile>> SearchJobSeekerProfileAsync(string token,
                                                                                int page,
                                                                                int pageSize)
        {
            var query = database.JobSeekerProfiles
                .Include(p=>p.ContactDetails)
                .Where(p =>
            token == null ||
            p.FirstName.Contains(token) ||
            p.Surname.Contains(token));

            return new SearchModel<JobSeekerProfile>
            {
                Count = query.Count(),
                Items = await query.OrderByDescending(p => p.JobSeekerProfileID).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync()
            };
        }

        public async Task<JobSeekerProfile> GetFirstProfileAsync()
        {
            return await database.JobSeekerProfiles.Include(p => p.ContactDetails).FirstOrDefaultAsync();
        }
        public async Task<bool> RequestCVAsync(long profileID)
        {
            try
            {
                var profile = await database.JobSeekerProfiles.FindAsync(profileID);
                profile.CVRequested = true;
                await database.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
