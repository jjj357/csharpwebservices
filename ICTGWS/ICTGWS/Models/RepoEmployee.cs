using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using ICTGWS.ViewModels;

namespace ICTGWS.Models
{
    public class RepoEmployee : RepositoryBase
    {
        // Get ALL items
        public IEnumerable<Employee> GetEmployees()
        {
            var Employees = ds.Employees.OrderBy(o => o.Id);
            // Map to DTO objects
            return Mapper.Map<IEnumerable<Employee>>(Employees);
        }

        /*
        // Get all items that match a lookup criteria
        public IEnumerable<Employee> GetEmployeesByStudentId(int id)
        {
            // Attempt to locate the supplier...
            var student = ds.Students.Find(id);
            // Return null if the SupplierID is bad
            if (student == null) return null;
            // Otherwise...
            var Employees = ds.Employees.Where(s => s.Id == id).OrderBy(o => o.Id);
            return Mapper.Map<IEnumerable<Employee>>(Employees);
            // Will return an empty collection if the SupplierID is OK, but there's no Employees
        }  

         
        // Get all items that match a lookup critereon
        public IEnumerable<Employee> GetEmployeesByCategoryId(int id)
        {
            // Attempt to locate the category...
            var category = ds.Suppliers.Find(id);
            // Return null if the CategoryID is bad
            if (category == null) return null;
            // Otherwise...
            var Employees = ds.Employees.Where(s => s.CategoryID == id).OrderBy(o => o.EmployeeName);
            return Mapper.Map<IEnumerable<Employee>>(Employees);
            // Will return an empty collection if the CategoryID is OK, but there's no Employees
        }   */

        // Get all items that match a lookup critereon
        public IEnumerable<Employee> GetEmployeesByName(string searchText)
        {
            var Employees = ds.Employees.Where
                (p => p.FullName.ToLower().Contains(searchText.Trim().ToLower()));
            return Mapper.Map<IEnumerable<Employee>>(Employees);
        }

        // Get all items, but only values that are useful for a user interface control
        public IEnumerable<EmployeeForList> GetEmployeesForList()
        {
            // Not using AutoMapper here, because it's too easy
            var Employees = from p in ds.Employees
                           orderby p.FullName
                            select new EmployeeForList() { Id = p.Id, FullName = p.FullName, Telephone = p.Telephone, Email = p.Email };
            return Employees;
        }

        // Get specific item
        public Employee GetEmployeeById(int id)
        {
            var Employee = ds.Employees.Find(id);
            // Map to DTO object
            return (Employee == null) ? null : Mapper.Map<Employee>(Employee);
        }

        // Update specific item
        public EmployeeUpdate UpdateEmployee(EmployeeUpdate updatedEmployee)
        {
            var p = ds.Employees.Find(updatedEmployee.Id);

            if (p == null)
            {
                return null;
            }
            else
            {
                // For the object fetched from the data store,
                // set its values to those provided
                // (the method ignores missing properties, and navigation properties)
                ds.Entry(p).CurrentValues.SetValues(updatedEmployee);
                ds.SaveChanges();
                return updatedEmployee;
            }
        }

        // Add new item
        public Employee AddEmployee(EmployeeAdd Employee)
        {
            // Map from DTO object to domain (POCO) object
            var p = ds.Employees.Add(Mapper.Map<ICTGWS.Models.Employee>(Employee));  //<=====
            ds.SaveChanges();
            // Map to DTO object
            return Mapper.Map<Employee>(p);
        }

        // Delete specific item
        public Employee DeleteEmployee(int id)
        {
            var Employee = ds.Employees.Find(id);

            if (Employee == null)
            {
                return null;
            }
            else
            {
                ds.Employees.Remove(Employee);
                ds.SaveChanges();
                return Mapper.Map<Employee>(Employee);
            }
        }
    }
}