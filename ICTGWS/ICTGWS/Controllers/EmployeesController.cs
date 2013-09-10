using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ICTGWS.Models;
using System.ComponentModel.DataAnnotations;

namespace ICTGWS.Controllers
{
    public class EmployeesController : ApiController
    {
        private ICTGWSContext db = new ICTGWSContext();

        private RepoEmployee r = new RepoEmployee();

        // GET api/Employees
        [Authorize(Roles = "Public,Student,Faculty,Coordinator")]
        public IEnumerable<Employee> GetEmployees()
        {
            return db.Employees.AsEnumerable();
        }

        // GET api/Employees/5
        [Authorize(Roles = "Public,Student,Faculty,Coordinator")]
        public Employee GetEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return employee;
        }

        // PUT api/Employees/5
        [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage PutEmployee(int id, ICTGWS.ViewModels.EmployeeUpdate employee)
        {
            if (ModelState.IsValid && id == employee.Id)
            {/*
                db.Entry(employee).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);  */
                var updatedEmployee = r.UpdateEmployee(employee);
                return (updatedEmployee == null) ?
                    Request.CreateResponse(HttpStatusCode.BadRequest) :
                    Request.CreateResponse<ICTGWS.ViewModels.EmployeeUpdate>(HttpStatusCode.OK, updatedEmployee);

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Employees
        [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage PostEmployee(ICTGWS.ViewModels.EmployeeAdd employee)
        {
            if (ModelState.IsValid)
            {/*
                db.Employees.Add(employee);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, employee);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = employee.Id }));
                return response;  */
                var c = r.AddEmployee(employee);                   //<====
                // Prepare the response
                HttpResponseMessage response =
                    Request.CreateResponse<Employee>(HttpStatusCode.Created, c);
                response.Headers.Location =
                    new Uri(Url.Link("DefaultApi", new { id = c.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Employees/5
        [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage DeleteEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Employees.Remove(employee);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, employee);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}