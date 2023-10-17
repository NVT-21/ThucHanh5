using Microsoft.EntityFrameworkCore;
using MyWebApp.Models;

namespace MyWebApp.Data
{
    public class DbInitialize
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SchoolContext(serviceProvider.GetRequiredService<DbContextOptions<SchoolContext>>()))
            {
                context.Database.EnsureCreated();
                if (context.Learners.Any()) { return; }
                var Majors = new Major[]
                {
                    new Major{MajorName = "IT"},
                    new Major{MajorName = "Economics"},
                    new Major{MajorName = "Mathematcs"}
                };
                foreach (var major in Majors) { context.Majors.Add(major); }
                context.SaveChanges();
                var Learners = new Learner[]
                {
                    new Learner{FirstMidName = "Carson", LastName = "Alexander",
                        EnrollmentDate = DateTime.Parse("2005-09-01"), MajorID=1},
                    new Learner{FirstMidName = "Meredith", LastName = "Alonso",
                        EnrollmentDate = DateTime.Parse("2002-09-01"), MajorID=2}
                };
                foreach (Learner l in Learners) { context.Learners.Add(l); }
                context.SaveChanges();
                var Enrollments = new Enrollment[]
                {
                    new Enrollment{LearnerID = 1, CourseID = 1050, Grade = 5.5f},
                    new Enrollment{LearnerID = 1, CourseID = 4022, Grade = 7.5f},
                    new Enrollment{LearnerID = 2, CourseID = 1050, Grade = 3.5f},
                    new Enrollment{LearnerID = 2, CourseID = 4041, Grade = 7f}
                };
                foreach (Enrollment e in Enrollments) { context.Enrollments.Add(e); }
                context.SaveChanges();
                var Courses = new Course[]
                {
                    new Course{CourseId = 1, Title = "Macroeconomics", Credits = 3},
                    new Course{CourseId = 2, Title = "Macroeconomics", Credits = 3},
                    new Course{CourseId = 3, Title = "Macroeconomics", Credits = 3}
                };
                foreach (Course c in Courses) { context.Courses.Add(c); }
                context.SaveChanges();

            }
        }
    }
}
