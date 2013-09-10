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
    public class SubjectsController : ApiController
    {
        private ICTGWSContext db = new ICTGWSContext();

        private RepoSubject r = new RepoSubject();

        // GET api/Subjects
        [Authorize(Roles = "Public,Student,Faculty,Coordinator")]
        public IEnumerable<Subject> GetSubjects()
        {
            return db.Subjects.AsEnumerable();
        }

        // GET api/Subjects/5
        [Authorize(Roles = "Public,Student,Faculty,Coordinator")]
        public Subject GetSubject(int id)
        {
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return subject;
        }

        // PUT api/Subjects/5
        [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage PutSubject(int id,  ICTGWS.ViewModels.SubjectUpdate subject)
        {
            if (ModelState.IsValid && id == subject.Id)
            {  /*
                db.Entry(subject).State = EntityState.Modified;

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
                var updatedSubject = r.UpdateSubject(subject);
                return (updatedSubject == null) ?
                    Request.CreateResponse(HttpStatusCode.BadRequest) :
                    Request.CreateResponse<ICTGWS.ViewModels.SubjectUpdate>(HttpStatusCode.OK, updatedSubject);


            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Subjects
        [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage PostSubject(ICTGWS.ViewModels.SubjectAdd subject)
        {
            if (ModelState.IsValid)
            {/*
                db.Subjects.Add(subject);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, subject);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = subject.Id }));
                return response;   */
                var c = r.AddSubject(subject);                   //<====
                // Prepare the response
                HttpResponseMessage response =
                    Request.CreateResponse<Subject>(HttpStatusCode.Created, c);
                response.Headers.Location =
                    new Uri(Url.Link("DefaultApi", new { id = c.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Subjects/5
        [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage DeleteSubject(int id)
        {
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Subjects.Remove(subject);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, subject);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}