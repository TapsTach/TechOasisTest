using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TechOasisTest.Shared.Entities;

namespace TechOasisTest.WebApi.Services
{
    /// <summary>
    /// Defines the <see cref="SeedingServices" />.
    /// </summary>
    public class SeedingServices
    {
        /// <summary>
        /// Defines the database.
        /// </summary>
        private readonly Database database;

        /// <summary>
        /// Defines the rand.
        /// </summary>
        static Random rand = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="SeedingServices"/> class.
        /// </summary>
        /// <param name="database">The database<see cref="Database"/>.</param>
        public SeedingServices(Database database)
        {
            this.database = database;
        }

        /// <summary>
        /// The SeedData.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task SeedData()
        {

            List<string> names = JsonSerializer.Deserialize<List<string>>(File.ReadAllText("SeedData/commonNames.json"));
            List<string> surnames = JsonSerializer.Deserialize<List<string>>(File.ReadAllText("SeedData/commonLastNames.json"));
            bool seeded = database.JobSeekerProfiles.Count() > 0;
            if (seeded) return;
            List<JobSeekerProfile> profiles = new List<JobSeekerProfile>();
            for (int i = 0; i < 512; i++)
            {
                string name = names[rand.Next(0, names.Count)];
                string surname = surnames[rand.Next(0, surnames.Count)];
                JobSeekerProfile profile = new JobSeekerProfile
                {
                    FirstName = name,
                    Surname = surname,
                    About = GenerateLorem(rand.Next(500, 2000)),
                    ContactDetails = new ContactDetail
                    {
                        Email = GenerateEmail(name, surname),
                        Phone = $"{rand.Next(0, 999):###}-{rand.Next(0, 999):###}-{rand.Next(0, 999):###}",
                        WebSite = "test.com"
                    },
                    ImageFilePath = "profilePics/" + "profile" + rand.Next(1, 65) + ".jpg",
                };
                profiles.Add(profile);
            }

            database.JobSeekerProfiles.AddRange(profiles);
            await database.SaveChangesAsync();
        }

        /// <summary>
        /// The GenerateEmail.
        /// </summary>
        /// <param name="name">The name<see cref="string"/>.</param>
        /// <param name="surname">The surname<see cref="string"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private string GenerateEmail(string name, string surname)
        {
            string[] mailProviders =
            {
                "gmail.comm",
                "yahoo.com",
                "yahoomail.com",
                "rocketmail.com",
                "mailer.com",
                "mailer.co.zw",
                "mailer.co.za",
                "mailer.com",
                "test.co.za",
                "test.co.zw",
                "mail.co.zw",
                "mail.co.za",
                "mail.com",
                "live.com",
                "outlook.com",
                "company.com",
                "organisation.com",
                "toool.com",
            };
            return name + (rand.Next(0, 10) % 2 == 0 ? "." : "") + surname + "@" + mailProviders[rand.Next(0, mailProviders.Length)];
        }

        /// <summary>
        /// The GenerateLorem.
        /// </summary>
        /// <param name="max">The max<see cref="int"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private string GenerateLorem(int max)
        {
            List<string> lorems = JsonSerializer.Deserialize<List<string>>(File.ReadAllText("SeedData/lorem.json"));
            StringBuilder builder = new StringBuilder();
            int breakLine = rand.Next(25, 100);
            for (int i = 0; i < max; i++)
            {
                if (i == breakLine)
                {
                    builder.AppendLine();
                    breakLine = i + rand.Next(25, 100);
                }
                builder.Append(lorems[rand.Next(0, lorems.Count)]+" ");
            }
            return builder.ToString();
        }
    }
}
