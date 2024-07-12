using Microsoft.EntityFrameworkCore;
using RunningApp.Data;
using RunningApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningApp.Tests.Repository
{
    public class UserProfileRepositoryTest
    {
        public RunningAppDbContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<RunningAppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .EnableSensitiveDataLogging()
                .Options;

   
            var context = new RunningAppDbContext(options);
            context.Database.EnsureCreated();

            if(context.UserProfiles.Count() <= 0)
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

            return context;
        }
    }
}
