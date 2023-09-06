using InfrastructureLayer.DbModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer
{
    public class InfrastructureDbContext : IdentityDbContext<IdentityUser>
    //public class InfrastructureDbContext : DbContext
    {
        public InfrastructureDbContext(DbContextOptions<InfrastructureDbContext> options)
            : base(options)
        {
        }

        public DbSet<StudentDbModel> Students { get; set; }
        public DbSet<InstructorDbModel> Instructors { get; set; }
        public DbSet<SessionDbModel> Sessions { get; set; }
        public DbSet<AvailabilityDbModel> Availabilities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<InstructorDbModel>()
                .HasData(new InstructorDbModel[]
                {
                    new InstructorDbModel
                    {
                        Id = "1",
                        Name = "Ali",
                        Email = "ali@test.com",                       
                    },
                    new InstructorDbModel
                    {
                        Id = "2",
                        Name = "Sam",
                        Email = "sam@test.com"
                    },
                    new InstructorDbModel
                    {
                        Id = "3",
                        Name = "Zak",
                        Email = "zak@test.com"
                     },

                }
                );

            modelBuilder.Entity<AvailabilityDbModel>()
                .HasData(new AvailabilityDbModel[] {
                    // the first instuctor
                            new AvailabilityDbModel
                            {
                                Id = 1,
                                DayOfWeek = 0,//sunday
                                StartTimeHours = 11,
                                StartTimeMinutes = 0,
                                EndTimeHours = 21,
                                EndTimeMinutes = 0,
                                InstructorId = "1",
                            },
                             new AvailabilityDbModel
                             {
                                 Id = 2,
                                DayOfWeek = 1,//monday
                                StartTimeHours = 11,
                                StartTimeMinutes = 0,
                                EndTimeHours = 21,
                                EndTimeMinutes = 0,
                                InstructorId = "1",
                             },
                            new AvailabilityDbModel
                            {
                                Id = 3,
                                DayOfWeek = 2,//tuesday
                                StartTimeHours = 11,
                                StartTimeMinutes = 0,
                                EndTimeHours = 21,
                                EndTimeMinutes = 0,
                                InstructorId = "1",
                            },
                             new AvailabilityDbModel
                             {
                                 Id = 4,
                                DayOfWeek = 3,//wednesday
                                StartTimeHours = 11,
                                StartTimeMinutes = 0,
                                EndTimeHours = 21,
                                EndTimeMinutes = 0,
                                InstructorId = "1",
                             },
                            new AvailabilityDbModel
                             {
                                Id = 5,
                                DayOfWeek = 4,//thursday
                                StartTimeHours = 11,
                                StartTimeMinutes = 0,
                                EndTimeHours = 21,
                                EndTimeMinutes = 0,
                                InstructorId = "1",
                             },
                             new AvailabilityDbModel
                             {
                                 Id = 6,
                                DayOfWeek = 6,//saturday
                                StartTimeHours = 11,
                                StartTimeMinutes = 0,
                                EndTimeHours = 21,
                                EndTimeMinutes = 0,
                                InstructorId = "1",
                             },

                             //the second instuctore
                            new AvailabilityDbModel
                            {
                                Id = 7,
                                DayOfWeek = 0,//sunday
                                StartTimeHours = 16,
                                StartTimeMinutes = 0,
                                EndTimeHours = 21,
                                EndTimeMinutes = 0,
                                InstructorId = "2",
                            },
                             new AvailabilityDbModel
                             {
                                 Id = 8,
                                DayOfWeek = 1,//monday
                                StartTimeHours = 16,
                                StartTimeMinutes = 0,
                                EndTimeHours = 21,
                                EndTimeMinutes = 0,
                                InstructorId = "2",
                             },
                            new AvailabilityDbModel
                            {
                                Id = 9,
                                DayOfWeek = 2,//tuesday
                                StartTimeHours = 16,
                                StartTimeMinutes = 0,
                                EndTimeHours = 21,
                                EndTimeMinutes = 0,
                                InstructorId = "2",
                            },
                             new AvailabilityDbModel
                             {
                                 Id = 10,
                                DayOfWeek = 3,//wednesday
                                StartTimeHours = 16,
                                StartTimeMinutes = 0,
                                EndTimeHours = 21,
                                EndTimeMinutes = 0,
                                InstructorId = "2",
                             },
                            new AvailabilityDbModel
                             {
                                Id = 11,
                                DayOfWeek = 4,//thursday
                                StartTimeHours = 16,
                                StartTimeMinutes = 0,
                                EndTimeHours = 21,
                                EndTimeMinutes = 0,
                                InstructorId = "2",
                             },
                             new AvailabilityDbModel
                             {
                                  Id = 12,
                                DayOfWeek = 6,//saturday
                                StartTimeHours = 16,
                                StartTimeMinutes = 0,
                                EndTimeHours = 21,
                                EndTimeMinutes = 0,
                                InstructorId = "2",
                             },

                             // the third instructor
                             new AvailabilityDbModel
                             {
                                  Id = 13,
                                DayOfWeek = 1,//monday
                                StartTimeHours = 17,
                                StartTimeMinutes = 0,
                                EndTimeHours = 23,
                                EndTimeMinutes = 0,
                                InstructorId = "3",
                             },
                            new AvailabilityDbModel
                            {
                                 Id = 14,
                                DayOfWeek = 2,//tuesday
                                StartTimeHours = 17,
                                StartTimeMinutes = 0,
                                EndTimeHours = 23,
                                EndTimeMinutes = 0,
                                InstructorId = "3",
                            },
                             new AvailabilityDbModel
                             {
                                  Id = 15,
                                DayOfWeek = 3,//wednesday
                                StartTimeHours = 17,
                                StartTimeMinutes = 0,
                                EndTimeHours = 23,
                                EndTimeMinutes = 0,
                                InstructorId = "3",
                             },
                             new AvailabilityDbModel
                             {
                                  Id = 16,
                                DayOfWeek = 6,//saturday
                                StartTimeHours = 10,
                                StartTimeMinutes = 0,
                                EndTimeHours = 22,
                                EndTimeMinutes = 0,
                                InstructorId = "3",
                             },
                     });

            base.OnModelCreating(modelBuilder);
        }

    }



}
