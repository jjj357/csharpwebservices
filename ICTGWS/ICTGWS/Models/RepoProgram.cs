using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using ICTGWS.ViewModels;
using System.Data.Entity;

namespace ICTGWS.Models
{
    public class RepoProgram : RepositoryBase
    {
        // Get ALL items
        public IEnumerable<Program> GetPrograms()
        {
            var Programs = ds.Programs.OrderBy(o => o.Id);
            // Map to DTO objects
            return Mapper.Map<IEnumerable<Program>>(Programs);
        }

        /*
        //it doens't work because it's M-M relationship
        // Get all items that match a lookup criteria
        public IEnumerable<Program> GetProgramsBySubjectId(int id)
        {
            // Attempt to locate the supplier...
            var subject = ds.Subjects.Find(id);
            // Return null if the SupplierID is bad
            if (subject == null) return null;
            // Otherwise...
            var Programs = ds.Programs.Where(s => s.Id == id).OrderBy(o => o.Id);
            return Mapper.Map<IEnumerable<Program>>(Programs);
            // Will return an empty collection if the SupplierID is OK, but there's no Programs
        }  

        
        // Get all items that match a lookup critereon
        public Program GetProgramByStudentId(int id)
        {
            // Attempt to locate the category...
            var student = ds.Students.Find(id);
            // Return null if the CategoryID is bad
            if (student == null) return null;
            // Otherwise...
            var Program = ds.Programs.Where(s => s.Id == id).FirstOrDefault();
            return Mapper.Map<Program>(Program);
            // Will return an empty collection if the CategoryID is OK, but there's no Programs
        }     */

        // Get all items that match a lookup critereon
        public IEnumerable<Program> GetProgramsByName(string searchText)
        {
            var Programs = ds.Programs.Where
                (p => p.Name.ToLower().Contains(searchText.Trim().ToLower()));
            return Mapper.Map<IEnumerable<Program>>(Programs);
        }

        // Get all items, but only values that are useful for a user interface control
        public IEnumerable<ProgramForList> GetProgramsForList()
        {
            // Not using AutoMapper here, because it's too easy
            var Programs = from p in ds.Programs
                           orderby p.Name
                           select new ProgramForList() { Id = p.Id, Code = p.Code, Name = p.Name };
            return Programs;
        }

        // Get specific item
        public Program GetProgramById(int id)
        {
            var Program = ds.Programs.Find(id);
            // Map to DTO object
            return (Program == null) ? null : Mapper.Map<Program>(Program);
        }

        // Update specific item
        public ProgramUpdate UpdateProgram(ProgramUpdate updatedProgram)
        {
            var p = ds.Programs.Find(updatedProgram.Id);

            if (p == null)
            {
                return null;
            }
            else
            {
                // For the object fetched from the data store,
                // set its values to those provided
                // (the method ignores missing properties, and navigation properties)
                ds.Entry(p).CurrentValues.SetValues(updatedProgram);
                ds.SaveChanges();
                return updatedProgram;
            }
        }

        // Add new item
        public Program AddProgram(ProgramAdd Program)
        {
            // Map from DTO object to domain (POCO) object
            var p = ds.Programs.Add(Mapper.Map<ICTGWS.Models.Program>(Program));
            ds.SaveChanges();
            // Map to DTO object
            return Mapper.Map<Program>(p);
        }

        // Delete specific item
        public Program DeleteProgram(int id)
        {
            var program = ds.Programs.Find(id);

            if (program == null)
            {
                return null;
            }
            else
            {
                ds.Programs.Remove(program);
                ds.SaveChanges();
                return Mapper.Map<Program>(program);
            }
        }


    }
}