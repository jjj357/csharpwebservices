using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using ICTGWS.ViewModels;

namespace ICTGWS.Models
{
    public class RepoCourse : RepositoryBase
    {
        // Get ALL items
        public IEnumerable<Course> GetCourses()
        {
            var Courses = ds.Courses.OrderBy(o => o.Id);
            // Map to DTO objects
            return Mapper.Map<IEnumerable<Course>>(Courses);
        }

        /*
        // Get all items that match a lookup criteria
        public IEnumerable<Course> GetCoursesByStudentId(int id)
        {
            // Attempt to locate the supplier...
            var student = ds.Students.Find(id);
            // Return null if the SupplierID is bad
            if (student == null) return null;
            // Otherwise...
            var Courses = ds.Courses.Where(s => s.Id == id).OrderBy(o => o.Id);
            return Mapper.Map<IEnumerable<Course>>(Courses);
            // Will return an empty collection if the SupplierID is OK, but there's no Courses
        }  

         
        // Get all items that match a lookup critereon
        public IEnumerable<Course> GetCoursesByCategoryId(int id)
        {
            // Attempt to locate the category...
            var category = ds.Suppliers.Find(id);
            // Return null if the CategoryID is bad
            if (category == null) return null;
            // Otherwise...
            var Courses = ds.Courses.Where(s => s.CategoryID == id).OrderBy(o => o.CourseName);
            return Mapper.Map<IEnumerable<Course>>(Courses);
            // Will return an empty collection if the CategoryID is OK, but there's no Courses
        }   

        // Get all items that match a lookup critereon
        public IEnumerable<Course> GetCoursesByName(string searchText)
        {
            var Courses = ds.Courses.Where
                (p => p.FullName.ToLower().Contains(searchText.Trim().ToLower()));
            return Mapper.Map<IEnumerable<Course>>(Courses);
        }    */

        // Get all items, but only values that are useful for a user interface control
        public IEnumerable<CourseForTimeList> GetCoursesForList()
        {
            // Not using AutoMapper here, because it's too easy
            var Courses = from p in ds.Courses
                            orderby p.Id
                          select new CourseForTimeList() { Id = p.Id, Section = p.Section, Day1 = p.Day1, Day2 = p.Day2, Duration1 = p.Duration1, Duration2 = p.Duration2, StartPeriod1 = p.StartPeriod1, StartPeriod2 = p.StartPeriod2 };
            return Courses;
        }




        // Get specific item
        public Course GetCourseById(int id)
        {
            var Course = ds.Courses.Find(id);
            // Map to DTO object
            return (Course == null) ? null : Mapper.Map<Course>(Course);
        }

        // Update specific item
        public CourseUpdate UpdateCourse(CourseUpdate updatedCourse)
        {
            var p = ds.Courses.Find(updatedCourse.Id);

            if (p == null)
            {
                return null;
            }
            else
            {
                // For the object fetched from the data store,
                // set its values to those provided
                // (the method ignores missing properties, and navigation properties)
                ds.Entry(p).CurrentValues.SetValues(updatedCourse);
                ds.SaveChanges();
                return updatedCourse;
            }
        }

        // Add new item
        public Course AddCourse(CourseAdd Course)
        {
            // Map from DTO object to domain (POCO) object
            var p = ds.Courses.Add(Mapper.Map<ICTGWS.Models.Course>(Course));
            ds.SaveChanges();
            // Map to DTO object
            return Mapper.Map<Course>(p);
        }

        // Delete specific item
        public Course DeleteCourse(int id)
        {
            var Course = ds.Courses.Find(id);

            if (Course == null)
            {
                return null;
            }
            else
            {
                ds.Courses.Remove(Course);
                ds.SaveChanges();
                return Mapper.Map<Course>(Course);
            }
        }
    }
}