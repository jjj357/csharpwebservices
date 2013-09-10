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
    public class CoursesController : ApiController
    {
        private ICTGWSContext db = new ICTGWSContext();

        private RepoCourse r = new RepoCourse();

        // GET api/Courses
        [Authorize(Roles = "Public,Student,Faculty,Coordinator")]
        public IEnumerable<Course> GetCourses()
        {
            return db.Courses.AsEnumerable();
        }

        // GET api/Courses/5
        [Authorize(Roles = "Public,Student,Faculty,Coordinator")]
        public Course GetCourse(int id)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return course;
        }

        // PUT api/Courses/5
        [Authorize(Roles = "Faculty,Coordinator")]
        public HttpResponseMessage PutCourse(int id, ICTGWS.ViewModels.CourseUpdate course)
        {
            if (ModelState.IsValid && id == course.Id)
            {             /*
                db.Entry(course).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);   */
                // Attempt to update the item
                var updatedCourse = r.UpdateCourse(course);
                return (updatedCourse == null) ?
                    Request.CreateResponse(HttpStatusCode.BadRequest) :
                    Request.CreateResponse<ICTGWS.ViewModels.CourseUpdate>(HttpStatusCode.OK, updatedCourse);

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Courses
        [Authorize(Roles = "Faculty,Coordinator")]
        public HttpResponseMessage PostCourse(ICTGWS.ViewModels.CourseAdd course)
        {
            if (ModelState.IsValid)
            {    /*
                db.Courses.Add(course);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, course);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = course.Id }));
                return response;   */
                var c = r.AddCourse(course);                   //<====
                // Prepare the response
                HttpResponseMessage response =
                    Request.CreateResponse<Course>(HttpStatusCode.Created, c);
                response.Headers.Location =
                    new Uri(Url.Link("DefaultApi", new { id = c.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Courses/5
        [Authorize(Roles = "Faculty,Coordinator")]
        public HttpResponseMessage DeleteCourse(int id)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Courses.Remove(course);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, course);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}