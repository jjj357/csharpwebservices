using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using ICTGWS.ViewModels;

namespace ICTGWS.Models
{
    public class RepoSemester : RepositoryBase
    {
        // Get ALL items
        public IEnumerable<Semester> GetSemesters()
        {
            var Semesters = ds.Semesters.OrderBy(o => o.Id);
            // Map to DTO objects
            return Mapper.Map<IEnumerable<Semester>>(Semesters);
        }

        /*
        // Get all items that match a lookup criteria
        public IEnumerable<Semester> GetSemestersByStudentId(int id)
        {
            // Attempt to locate the supplier...
            var student = ds.Students.Find(id);
            // Return null if the SupplierID is bad
            if (student == null) return null;
            // Otherwise...
            var Semesters = ds.Semesters.Where(s => s.Id == id).OrderBy(o => o.Id);
            return Mapper.Map<IEnumerable<Semester>>(Semesters);
            // Will return an empty collection if the SupplierID is OK, but there's no Semesters
        }  

         
        // Get all items that match a lookup critereon
        public IEnumerable<Semester> GetSemestersByCategoryId(int id)
        {
            // Attempt to locate the category...
            var category = ds.Suppliers.Find(id);
            // Return null if the CategoryID is bad
            if (category == null) return null;
            // Otherwise...
            var Semesters = ds.Semesters.Where(s => s.CategoryID == id).OrderBy(o => o.SemesterName);
            return Mapper.Map<IEnumerable<Semester>>(Semesters);
            // Will return an empty collection if the CategoryID is OK, but there's no Semesters
        }   */

        // Get all items that match a lookup critereon
        public IEnumerable<Semester> GetSemestersByName(string searchText)
        {
            var Semesters = ds.Semesters.Where
                (p => p.SemesterName.ToLower().Contains(searchText.Trim().ToLower()));
            return Mapper.Map<IEnumerable<Semester>>(Semesters);
        }

        // Get all items, but only values that are useful for a user interface control
        public IEnumerable<SemesterForList> GetSemestersForList()
        {
            // Not using AutoMapper here, because it's too easy
            var Semesters = from p in ds.Semesters
                            orderby p.SemesterName
                            select new SemesterForList() { SemesterName = p.SemesterName, SemesterNumber = p.SemesterNumber, Year = p.Year };
            return Semesters;
        }

        // Get specific item
        public Semester GetSemesterById(int id)
        {
            var Semester = ds.Semesters.Find(id);
            // Map to DTO object
            return (Semester == null) ? null : Mapper.Map<Semester>(Semester);
        }

        // Update specific item
        public SemesterUpdate UpdateSemester(SemesterUpdate updatedSemester)
        {
            var p = ds.Semesters.Find(updatedSemester.Id);

            if (p == null)
            {
                return null;
            }
            else
            {
                // For the object fetched from the data store,
                // set its values to those provided
                // (the method ignores missing properties, and navigation properties)
                ds.Entry(p).CurrentValues.SetValues(updatedSemester);
                ds.SaveChanges();
                return updatedSemester;
            }
        }

        // Add new item
        public Semester AddSemester(SemesterAdd Semester)
        {
            // Map from DTO object to domain (POCO) object
            var p = ds.Semesters.Add(Mapper.Map<ICTGWS.Models.Semester>(Semester));
            ds.SaveChanges();
            // Map to DTO object
            return Mapper.Map<Semester>(p);
        }

        // Delete specific item
        public Semester DeleteSemester(int id)
        {
            var Semester = ds.Semesters.Find(id);

            if (Semester == null)
            {
                return null;
            }
            else
            {
                ds.Semesters.Remove(Semester);
                ds.SaveChanges();
                return Mapper.Map<Semester>(Semester);
            }
        }
    }
}