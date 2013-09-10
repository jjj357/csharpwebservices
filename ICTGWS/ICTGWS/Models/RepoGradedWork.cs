using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using ICTGWS.ViewModels;

namespace ICTGWS.Models
{
    public class RepoGradedWork : RepositoryBase
    {
        // Get ALL items
        public IEnumerable<GradedWork> GetGradedWorks()
        {
            var GradedWorks = ds.GradedWorks.OrderBy(o => o.Id);
            // Map to DTO objects
            return Mapper.Map<IEnumerable<GradedWork>>(GradedWorks);
        }

        /*
        // Get all items that match a lookup criteria
        public IEnumerable<GradedWork> GetGradedWorksByStudentId(int id)
        {
            // Attempt to locate the supplier...
            var student = ds.Students.Find(id);
            // Return null if the SupplierID is bad
            if (student == null) return null;
            // Otherwise...
            var GradedWorks = ds.GradedWorks.Where(s => s.Id == id).OrderBy(o => o.Id);
            return Mapper.Map<IEnumerable<GradedWork>>(GradedWorks);
            // Will return an empty collection if the SupplierID is OK, but there's no GradedWorks
        }  

         
        // Get all items that match a lookup critereon
        public IEnumerable<GradedWork> GetGradedWorksByCategoryId(int id)
        {
            // Attempt to locate the category...
            var category = ds.Suppliers.Find(id);
            // Return null if the CategoryID is bad
            if (category == null) return null;
            // Otherwise...
            var GradedWorks = ds.GradedWorks.Where(s => s.CategoryID == id).OrderBy(o => o.GradedWorkName);
            return Mapper.Map<IEnumerable<GradedWork>>(GradedWorks);
            // Will return an empty collection if the CategoryID is OK, but there's no GradedWorks
        }   

        // Get all items that match a lookup critereon
        public IEnumerable<GradedWork> GetGradedWorksByName(string searchText)
        {
            var GradedWorks = ds.GradedWorks.Where
                (p => p.FullName.ToLower().Contains(searchText.Trim().ToLower()));
            return Mapper.Map<IEnumerable<GradedWork>>(GradedWorks);
        }    */

        // Get all items, but only values that are useful for a user interface control
        public IEnumerable<GradedWorkForList> GetGradedWorksForList()
        {
            // Not using AutoMapper here, because it's too easy
            var GradedWorks = from p in ds.GradedWorks
                          orderby p.Id
                              select new GradedWorkForList() { Category = p.Category, DateAssigned = p.DateAssigned, DateDue = p.DateDue, Description = p.Description, Title = p.Title, Value = p.Value };
            return GradedWorks;
        }

        // Get all items that match a lookup critereon
        public IEnumerable<GradedWork> GetGradedWorksByName(string searchText)
        {
            var GradedWorks = ds.GradedWorks.Where
                (p => p.Title.ToLower().Contains(searchText.Trim().ToLower()));
            return Mapper.Map<IEnumerable<GradedWork>>(GradedWorks);
        }



        // Get specific item
        public GradedWork GetGradedWorkById(int id)
        {
            var GradedWork = ds.GradedWorks.Find(id);
            // Map to DTO object
            return (GradedWork == null) ? null : Mapper.Map<GradedWork>(GradedWork);
        }

        // Update specific item
        public GradedWorkUpdate UpdateGradedWork(GradedWorkUpdate updatedGradedWork)
        {
            var p = ds.GradedWorks.Find(updatedGradedWork.Id);

            if (p == null)
            {
                return null;
            }
            else
            {
                // For the object fetched from the data store,
                // set its values to those provided
                // (the method ignores missing properties, and navigation properties)
                ds.Entry(p).CurrentValues.SetValues(updatedGradedWork);
                ds.SaveChanges();
                return updatedGradedWork;
            }
        }

        // Add new item
        public GradedWork AddGradedWork(GradedWorkAdd GradedWork)
        {
            // Map from DTO object to domain (POCO) object
            var p = ds.GradedWorks.Add(Mapper.Map<ICTGWS.Models.GradedWork>(GradedWork));
            ds.SaveChanges();
            // Map to DTO object
            return Mapper.Map<GradedWork>(p);
        }

        // Delete specific item
        public GradedWork DeleteGradedWork(int id)
        {
            var GradedWork = ds.GradedWorks.Find(id);

            if (GradedWork == null)
            {
                return null;
            }
            else
            {
                ds.GradedWorks.Remove(GradedWork);
                ds.SaveChanges();
                return Mapper.Map<GradedWork>(GradedWork);
            }
        }
    }
}