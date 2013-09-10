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
    public class SemestersController : ApiController
    {
        private ICTGWSContext db = new ICTGWSContext();

        private RepoSemester r = new RepoSemester();

        // GET api/Semesters
        [Authorize(Roles = "Student,Faculty,Coordinator")]
        public IEnumerable<Semester> GetSemesters()
        {
            return db.Semesters.AsEnumerable();
        }

        // GET api/Semesters/5
        [Authorize(Roles = "Student,Faculty,Coordinator")]
        public Semester GetSemester(int id)
        {
            Semester semester = db.Semesters.Find(id);
            if (semester == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return semester;
        }

        // PUT api/Semesters/5
        [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage PutSemester(int id,  ICTGWS.ViewModels.SemesterUpdate semester)
        {
            if (ModelState.IsValid && id == semester.Id)
            {     /*
                db.Entry(semester).State = EntityState.Modified;

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
                var updatedSemester = r.UpdateSemester(semester);
                return (updatedSemester == null) ?
                    Request.CreateResponse(HttpStatusCode.BadRequest) :
                    Request.CreateResponse<ICTGWS.ViewModels.SemesterUpdate>(HttpStatusCode.OK, updatedSemester);

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Semesters
        [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage PostSemester(ICTGWS.ViewModels.SemesterAdd semester)
        {
            if (ModelState.IsValid)
            {  /*
                db.Semesters.Add(semester);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, semester);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = semester.Id }));
                return response;   */
                var c = r.AddSemester(semester);                   //<====
                // Prepare the response
                HttpResponseMessage response =
                    Request.CreateResponse<Semester>(HttpStatusCode.Created, c);
                response.Headers.Location =
                    new Uri(Url.Link("DefaultApi", new { id = c.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Semesters/5
        [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage DeleteSemester(int id)
        {
            Semester semester = db.Semesters.Find(id);
            if (semester == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Semesters.Remove(semester);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, semester);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}