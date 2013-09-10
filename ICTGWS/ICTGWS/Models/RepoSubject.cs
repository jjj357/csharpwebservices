using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using ICTGWS.ViewModels;

namespace ICTGWS.Models
{
    public class RepoSubject : RepositoryBase
    {
        // Get ALL items
        public IEnumerable<Subject> GetSubjects()
        {
            var Subjects = ds.Subjects.OrderBy(o => o.Id);
            // Map to DTO objects
            return Mapper.Map<IEnumerable<Subject>>(Subjects);
        }

        /*
        // Get all items that match a lookup criteria
        public IEnumerable<Subject> GetSubjectsByStudentId(int id)
        {
            // Attempt to locate the supplier...
            var student = ds.Students.Find(id);
            // Return null if the SupplierID is bad
            if (student == null) return null;
            // Otherwise...
            var Subjects = ds.Subjects.Where(s => s.Id == id).OrderBy(o => o.Id);
            return Mapper.Map<IEnumerable<Subject>>(Subjects);
            // Will return an empty collection if the SupplierID is OK, but there's no Subjects
        }  

         
        // Get all items that match a lookup critereon
        public IEnumerable<Subject> GetSubjectsByCategoryId(int id)
        {
            // Attempt to locate the category...
            var category = ds.Suppliers.Find(id);
            // Return null if the CategoryID is bad
            if (category == null) return null;
            // Otherwise...
            var Subjects = ds.Subjects.Where(s => s.CategoryID == id).OrderBy(o => o.SubjectName);
            return Mapper.Map<IEnumerable<Subject>>(Subjects);
            // Will return an empty collection if the CategoryID is OK, but there's no Subjects
        }   */

        // Get all items that match a lookup critereon
        public IEnumerable<Subject> GetSubjectsByName(string searchText)
        {
            var Subjects = ds.Subjects.Where
                (p => p.Name.ToLower().Contains(searchText.Trim().ToLower()));
            return Mapper.Map<IEnumerable<Subject>>(Subjects);
        }

        // Get all items, but only values that are useful for a user interface control
        public IEnumerable<SubjectForList> GetSubjectsForList()
        {
            // Not using AutoMapper here, because it's too easy
            var Subjects = from p in ds.Subjects
                           orderby p.Name
                           select new SubjectForList() { Id = p.Id, Code = p.Code, Name = p.Name };
            return Subjects;
        }

        // Get specific item
        public Subject GetSubjectById(int id)
        {
            var Subject = ds.Subjects.Find(id);
            // Map to DTO object
            return (Subject == null) ? null : Mapper.Map<Subject>(Subject);
        }

        // Update specific item
        public SubjectUpdate UpdateSubject(SubjectUpdate updatedSubject)
        {
            var p = ds.Subjects.Find(updatedSubject.Id);

            if (p == null)
            {
                return null;
            }
            else
            {
                // For the object fetched from the data store,
                // set its values to those provided
                // (the method ignores missing properties, and navigation properties)
                ds.Entry(p).CurrentValues.SetValues(updatedSubject);
                ds.SaveChanges();
                return updatedSubject;
            }
        }

        // Add new item
        public Subject AddSubject(SubjectAdd Subject)
        {
            // Map from DTO object to domain (POCO) object
            var p = ds.Subjects.Add(Mapper.Map<ICTGWS.Models.Subject>(Subject));
            ds.SaveChanges();
            // Map to DTO object
            return Mapper.Map<Subject>(p);
        }

        // Delete specific item
        public Subject DeleteSubject(int id)
        {
            var Subject = ds.Subjects.Find(id);

            if (Subject == null)
            {
                return null;
            }
            else
            {
                ds.Subjects.Remove(Subject);
                ds.SaveChanges();
                return Mapper.Map<Subject>(Subject);
            }
        }
    }
}