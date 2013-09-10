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

namespace ICTGWS.Controllers
{
    public class StudentsController : ApiController
    {
        private ICTGWSContext db = new ICTGWSContext();

        private RepoStudent r = new RepoStudent();

        // GET api/Students
        [Authorize(Roles = "Student,Faculty,Coordinator")]
        public IEnumerable<Student> GetStudents()
        {
            return db.Students.AsEnumerable();
            //var students = db.Students.Include(c => c.Program);
            //return AutoMapper.Mapper.Map<IEnumerable<Course>, IEnumerable<CourseDTO>>(students);

        }

        // GET api/Students/5
        [Authorize(Roles = "Student,Faculty,Coordinator")]
        public Student GetStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return student;
        }

        // PUT api/Students/5
        [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage PutStudent(int id, ICTGWS.ViewModels.StudentUpdate student)
        {
            if (ModelState.IsValid && id == student.Id)
            {/*
                db.Entry(student).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);  */

                // Attempt to update the item
                var updatedStudent = r.UpdateStudent(student);
                return (updatedStudent == null) ?
                    Request.CreateResponse(HttpStatusCode.BadRequest) :
                    Request.CreateResponse<ICTGWS.ViewModels.StudentUpdate>(HttpStatusCode.OK, updatedStudent);

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Students
        [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage PostStudent(ICTGWS.ViewModels.StudentAdd student)
        {
            if (ModelState.IsValid)
            {/*
                db.Students.Add(student);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, student);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = student.Id }));
                return response;  */
                var c = r.AddStudent(student);                   //<====
                // Prepare the response
                HttpResponseMessage response =
                    Request.CreateResponse<Student>(HttpStatusCode.Created, c);
                response.Headers.Location =
                    new Uri(Url.Link("DefaultApi", new { id = c.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Students/5
        [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Students.Remove(student);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, student);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}