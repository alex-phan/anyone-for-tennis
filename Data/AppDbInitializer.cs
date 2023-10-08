
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyoneForTennis.Models; // Make sure to include the Schedules model

namespace AnyoneForTennis.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                // Schedules
                if (!context.Schedule.Any())
                {
                    context.Schedule.AddRange(new List<Schedule>()
                    {
                        new Schedule()
                        {
                            EventName = "Event 1",
                            EventDate = "2023-10-10", // Replace with your desired date
                            EventLocation = "Location 1",
                            EventDescription = "Description 1"
                        },
                        new Schedule()
                        {
                            EventName = "Event 2",
                            EventDate = "2023-10-13", // Replace with your desired date
                            EventLocation = "Location 2",
                            EventDescription = "Description 2"
                        },
                        new Schedule()
                        {
                            EventName = "Event 3",
                            EventDate = "2023-10-15", // Replace with your desired date
                            EventLocation = "Location 1",
                            EventDescription = "Description 1"
                        },
                        new Schedule()
                        {
                            EventName = "Event 4",
                            EventDate = "2023-10-15", // Replace with your desired date
                            EventLocation = "Location 2",
                            EventDescription = "Description 2"
                        },
                        new Schedule()
                        {
                            EventName = "Event 5",
                            EventDate = "2023-10-14", // Replace with your desired date
                            EventLocation = "Location 1",
                            EventDescription = "Description 1"
                        },
                        new Schedule()
                        {
                            EventName = "Event 6",
                            EventDate = "2023-10-16", // Replace with your desired date
                            EventLocation = "Location 2",
                            EventDescription = "Description 2"
                        },
                        new Schedule()
                        {
                            EventName = "Event 7",
                            EventDate = "2023-10-17", // Replace with your desired date
                            EventLocation = "Location 1",
                            EventDescription = "Description 1"
                        },
                        new Schedule()
                        {
                            EventName = "Event 8",
                            EventDate = "2023-10-18", // Replace with your desired date
                            EventLocation = "Location 2",
                            EventDescription = "Description 2"
                        },
                        new Schedule()
                        {
                            EventName = "Event 9",
                            EventDate = "2023-10-19", // Replace with your desired date
                            EventLocation = "Location 1",
                            EventDescription = "Description 1"
                        },
                        new Schedule()
                        {
                            EventName = "Event 10",
                            EventDate = "2023-10-20", // Replace with your desired date
                            EventLocation = "Location 2",
                            EventDescription = "Description 2"
                        },
                        new Schedule()
                        {
                            EventName = "Event 11",
                            EventDate = "2023-10-10", // Replace with your desired date
                            EventLocation = "Location 1",
                            EventDescription = "Description 1"
                        },
                        new Schedule()
                        {
                            EventName = "Event 12",
                            EventDate = "2023-10-13", // Replace with your desired date
                            EventLocation = "Location 2",
                            EventDescription = "Description 2"
                        },
                        new Schedule()
                        {
                            EventName = "Event 13",
                            EventDate = "2023-10-15", // Replace with your desired date
                            EventLocation = "Location 1",
                            EventDescription = "Description 1"
                        },
                        new Schedule()
                        {
                            EventName = "Event 14",
                            EventDate = "2023-10-15", // Replace with your desired date
                            EventLocation = "Location 2",
                            EventDescription = "Description 2"
                        },
                        new Schedule()
                        {
                            EventName = "Event 15",
                            EventDate = "2023-10-14", // Replace with your desired date
                            EventLocation = "Location 1",
                            EventDescription = "Description 1"
                        },
                        new Schedule()
                        {
                            EventName = "Event 16",
                            EventDate = "2023-10-16", // Replace with your desired date
                            EventLocation = "Location 2",
                            EventDescription = "Description 2"
                        },
                        new Schedule()
                        {
                            EventName = "Event 17",
                            EventDate = "2023-10-17", // Replace with your desired date
                            EventLocation = "Location 1",
                            EventDescription = "Description 1"
                        },
                        new Schedule()
                        {
                            EventName = "Event 18",
                            EventDate = "2023-10-18", // Replace with your desired date
                            EventLocation = "Location 2",
                            EventDescription = "Description 2"
                        },
                        new Schedule()
                        {
                            EventName = "Event 19",
                            EventDate = "2023-10-19", // Replace with your desired date
                            EventLocation = "Location 1",
                            EventDescription = "Description 1"
                        },
                        new Schedule()
                        {
                            EventName = "Event 20",
                            EventDate = "2023-10-20", // Replace with your desired date
                            EventLocation = "Location 2",
                            EventDescription = "Description 2"
                        },
                        new Schedule()
                        {
                            EventName = "Event 21",
                            EventDate = "2023-10-10", // Replace with your desired date
                            EventLocation = "Location 1",
                            EventDescription = "Description 1"
                        },
                        new Schedule()
                        {
                            EventName = "Event 22",
                            EventDate = "2023-10-13", // Replace with your desired date
                            EventLocation = "Location 2",
                            EventDescription = "Description 2"
                        },
                        new Schedule()
                        {
                            EventName = "Event 23",
                            EventDate = "2023-10-15", // Replace with your desired date
                            EventLocation = "Location 1",
                            EventDescription = "Description 1"
                        },
                        new Schedule()
                        {
                            EventName = "Event 24",
                            EventDate = "2023-10-15", // Replace with your desired date
                            EventLocation = "Location 2",
                            EventDescription = "Description 2"
                        },
                        new Schedule()
                        {
                            EventName = "Event 25",
                            EventDate = "2023-10-14", // Replace with your desired date
                            EventLocation = "Location 1",
                            EventDescription = "Description 1"
                        },
                        new Schedule()
                        {
                            EventName = "Event 26",
                            EventDate = "2023-10-16", // Replace with your desired date
                            EventLocation = "Location 2",
                            EventDescription = "Description 2"
                        },
                        new Schedule()
                        {
                            EventName = "Event 27",
                            EventDate = "2023-10-17", // Replace with your desired date
                            EventLocation = "Location 1",
                            EventDescription = "Description 1"
                        },
                        new Schedule()
                        {
                            EventName = "Event 28",
                            EventDate = "2023-10-18", // Replace with your desired date
                            EventLocation = "Location 2",
                            EventDescription = "Description 2"
                        },
                        new Schedule()
                        {
                            EventName = "Event 29",
                            EventDate = "2023-10-19", // Replace with your desired date
                            EventLocation = "Location 1",
                            EventDescription = "Description 1"
                        },
                        new Schedule()
                        {
                            EventName = "Event 30",
                            EventDate = "2023-10-20", // Replace with your desired date
                            EventLocation = "Location 2",
                            EventDescription = "Description 2"
                        }
                        // Add more events as needed
                    });
                    context.SaveChanges();
                }

            }
        }

        // Add code for SeedUsersAndRolesAsync method as shown in your code.

    }
}