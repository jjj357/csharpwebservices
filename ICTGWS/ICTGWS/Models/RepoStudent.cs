using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using ICTGWS.ViewModels;

namespace ICTGWS.Models
{
    public class RepoStudent : RepositoryBase
    {
        // Get ALL items
        public IEnumerable<Student> GetStudents()
        {
            var Students = ds.Students.OrderBy(o => o.Id);
            // Map to DTO objects
            return Mapper.Map<IEnumerable<Student>>(Students);
        }

        /*
        // Get all items that match a lookup criteria
        public IEnumerable<Student> GetStudentsByStudentId(int id)
        {
            // Attempt to locate the supplier...
            var student = ds.Students.Find(id);
            // Return null if the SupplierID is bad
            if (student == null) return null;
            // Otherwise...
            var Students = ds.Students.Where(s => s.Id == id).OrderBy(o => o.Id);
            return Mapper.Map<IEnumerable<Student>>(Students);
            // Will return an empty collection if the SupplierID is OK, but there's no Students
        }  

         
        // Get all items that match a lookup critereon
        public IEnumerable<Student> GetStudentsByCategoryId(int id)
        {
            // Attempt to locate the category...
            var category = ds.Suppliers.Find(id);
            // Return null if the CategoryID is bad
            if (category == null) return null;
            // Otherwise...
            var Students = ds.Students.Where(s => s.CategoryID == id).OrderBy(o => o.StudentName);
            return Mapper.Map<IEnumerable<Student>>(Students);
            // Will return an empty collection if the CategoryID is OK, but there's no Students
        }   */

        // Get all items that match a lookup critereon
        public IEnumerable<Student> GetStudentsByName(string searchText)
        {
            var Students = ds.Students.Where
                (p => p.DisplayName.ToLower().Contains(searchText.Trim().ToLower()));
            return Mapper.Map<IEnumerable<Student>>(Students);
        }

        // Get all items, but only values that are useful for a user interface control
        public IEnumerable<StudentForList> GetStudentsForList()
        {
            // Not using AutoMapper here, because it's too easy
            var Students = from p in ds.Students
                            orderby p.DisplayName
                           select new StudentForList() { DisplayName = p.DisplayName, StudentId = p.StudentId, UserName = p.UserName };
            return Students;
        }

        // Get specific item
        public Student GetStudentById(int id)
        {
            var Student = ds.Students.Find(id);
            // Map to DTO object
            return (Student == null) ? null : Mapper.Map<Student>(Student);
        }

        // Update specific item
        public StudentUpdate UpdateStudent(StudentUpdate updatedStudent)
        {
            var p = ds.Students.Find(updatedStudent.Id);

            if (p == null)
            {
                return null;
            }
            else
            {
                // For the object fetched from the data store,
                // set its values to those provided
                // (the method ignores missing properties, and navigation properties)
                ds.Entry(p).CurrentValues.SetValues(updatedStudent);
                ds.SaveChanges();
                return updatedStudent;
            }
        }

        // Add new item
        public Student AddStudent(StudentAdd Student)
        {
            // Map from DTO object to domain (POCO) object
            var p = ds.Students.Add(Mapper.Map<ICTGWS.Models.Student>(Student));  //<===
            ds.SaveChanges();
            // Map to DTO object
            return Mapper.Map<Student>(p);
        }

        // Delete specific item
        public Student DeleteStudent(int id)
        {
            var Student = ds.Students.Find(id);

            if (Student == null)
            {
                return null;
            }
            else
            {
                ds.Students.Remove(Student);
                ds.SaveChanges();
                return Mapper.Map<Student>(Student);
            }
        }
    }
}