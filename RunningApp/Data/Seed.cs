using RunningApp.Models;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;

namespace RunningApp.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<RunningAppDbContext>();

                context.Database.EnsureCreated();

                if (!context.UserProfiles.Any())
                {
                    context.UserProfiles.AddRange(new List<UserProfile>()
                    {
                        new UserProfile()
                        {
                            Name = "Zaldy Jeg Piraman",
                            Age = 34,
                            BirthDate = DateTime.Parse("06/19/1990", new CultureInfo("en-US")),
                            Height = 150,
                            Weight = 79, 
                            UserId = 0,
                            RunningActivities = new List<RunningActivity>() {
                                 new RunningActivity()
                                 {
                                    DateTimeEnded =  DateTime.ParseExact("11/12/2009 02:30:00.000", "dd/MM/yyyy HH:mm:ss.fff",  new CultureInfo("en-US")),
                                    DateTimeStarted =  DateTime.ParseExact("11/12/2009 01:30:00.000", "dd/MM/yyyy HH:mm:ss.fff",  new CultureInfo("en-US")),
                                    Distance = 50,
                                    Location = "Metro Manila"
                                 },
                                  new RunningActivity()
                                 {
                                    DateTimeEnded =  DateTime.ParseExact("11/12/2024 12:30:00.000", "dd/MM/yyyy HH:mm:ss.fff",  new CultureInfo("en-US")),
                                    DateTimeStarted =  DateTime.ParseExact("11/12/2024 12:00:00.000", "dd/MM/yyyy HH:mm:ss.fff",  new CultureInfo("en-US")),
                                    Distance = 50,
                                    Location = "Cebu"
                                 },
                                 new RunningActivity()
                                 {
                                    DateTimeEnded =  DateTime.ParseExact("11/12/2023 13:40:00.000", "dd/MM/yyyy HH:mm:ss.fff",  new CultureInfo("en-US")),
                                    DateTimeStarted =  DateTime.ParseExact("11/12/2023 13:10:00.000", "dd/MM/yyyy HH:mm:ss.fff",  new CultureInfo("en-US")),
                                    Distance = 50,
                                    Location = "Mindanao"
                                 },
                            }
                         

                         },
                         new UserProfile()
                        {
                            Name = "Arnel Masiglat",
                            Age = 35,
                            BirthDate = DateTime.Parse("01/05/1989", new CultureInfo("en-US")),
                            Height = 130,
                            Weight = 57,
                            UserId = 0,
                            RunningActivities = new List<RunningActivity>() {
                                 new RunningActivity()
                                 {
                                    DateTimeEnded =  DateTime.ParseExact("11/12/2019 02:30:00.000", "dd/MM/yyyy HH:mm:ss.fff",  new CultureInfo("en-US")),
                                    DateTimeStarted =  DateTime.ParseExact("11/12/2019 01:30:00.000", "dd/MM/yyyy HH:mm:ss.fff",  new CultureInfo("en-US")),
                                    Distance = 60,
                                    Location = "Baguio City"
                                 },
                                  new RunningActivity()
                                 {
                                    DateTimeEnded =  DateTime.ParseExact("11/12/2021 12:30:00.000", "dd/MM/yyyy HH:mm:ss.fff",  new CultureInfo("en-US")),
                                    DateTimeStarted =  DateTime.ParseExact("11/12/2021 12:00:00.000", "dd/MM/yyyy HH:mm:ss.fff",  new CultureInfo("en-US")),
                                    Distance = 30,
                                    Location = "Boracay"
                                 },

                            }


                         }

                    });
                    context.SaveChanges();
                }
                

            }
        }


    }
}
