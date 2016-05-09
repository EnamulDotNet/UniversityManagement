using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UniversityManagementSystem.Models.ProjectDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UniversityManagementSystem.Models.ProjectDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //context.Semesters.AddOrUpdate(
            //    s=>s.SemesterName,
            //    new Semester { SemesterName = "1st"},
            //    new Semester { SemesterName = "2nd"},
            //    new Semester { SemesterName = "3rd"},
            //    new Semester { SemesterName = "4th"},
            //    new Semester { SemesterName = "5th"},
            //    new Semester { SemesterName = "6th"},
            //    new Semester { SemesterName = "7th"},
            //    new Semester { SemesterName = "8th"}
            //    );

            //context.Designations.AddOrUpdate(
            //    d=>d.DesignationName,

            //    new Designation { DesignationName = "Head"},
            //    new Designation { DesignationName = "Asst Head"},
            //    new Designation { DesignationName = "Professor" },
            //    new Designation { DesignationName = "Asst Professor" },
            //    new Designation { DesignationName = "Lecturer" }
                
                
            //    );

            //context.Rooms.AddOrUpdate(
                
            //    r=>r.RoomNo,
            //    new Room { RoomNo = "401"},
            //    new Room { RoomNo = "402"},
            //    new Room { RoomNo = "403"},
            //    new Room { RoomNo = "404"},
            //    new Room { RoomNo = "405"},
            //    new Room { RoomNo = "406"},
            //    new Room { RoomNo = "407"}


            //    );

            //context.Days.AddOrUpdate(
            //    d=>d.Name,
            //    new Day { Name = "Saturday"},
            //    new Day { Name = "Sunday"},
            //    new Day { Name = "Monday"},
            //    new Day { Name = "Tuesday"},
            //    new Day { Name = "Wednesday"},
            //    new Day { Name = "Thursday"},
            //    new Day { Name = "Friday"}

                
            //    );

            //context.Grades.AddOrUpdate(
            //    g=>g.Name,
            //    new Grade { Name = "A+"},
            //    new Grade { Name = "A"},
            //    new Grade { Name = "A-"},
            //    new Grade { Name = "B+"},
            //    new Grade { Name = "B-"},
            //    new Grade { Name = "B"},
            //    new Grade { Name = "C+"},
            //    new Grade { Name = "C-"},
            //    new Grade { Name = "C"},
            //    new Grade { Name = "D"},
            //    new Grade { Name = "D+" },
            //    new Grade { Name = "D-" },
            //    new Grade { Name = "F"}
                 
                
            //    );
        }
    }
}
