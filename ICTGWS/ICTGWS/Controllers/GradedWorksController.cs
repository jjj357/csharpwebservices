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
    public class GradedWorksController : ApiController
    {
        private ICTGWSContext db = new ICTGWSContext();

        private RepoGradedWork r = new RepoGradedWork();

        // GET api/GradedWorks
        [Authorize(Roles = "Student,Faculty,Coordinator")]
        public IEnumerable<GradedWork> GetGradedWorks()
        {
            return db.GradedWorks.AsEnumerable();
        }

        // GET api/GradedWorks/5
        [Authorize(Roles = "Public,Student,Faculty,Coordinator")]
        public GradedWork GetGradedWork(int id)
        {
            GradedWork gradedwork = db.GradedWorks.Find(id);
            if (gradedwork == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return gradedwork;
        }

        // PUT api/GradedWorks/5
        [Authorize(Roles = "Faculty,Coordinator")]
        public HttpResponseMessage PutGradedWork(int id, ICTGWS.ViewModels.GradedWorkUpdate gradedwork)
        {
            if (ModelState.IsValid && id == gradedwork.Id)
            {   /*
                db.Entry(gradedwork).State = EntityState.Modified;

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
                var updatedGradedWork = r.UpdateGradedWork(gradedwork);
                return (updatedGradedWork == null) ?
                    Request.CreateResponse(HttpStatusCode.BadRequest) :
                    Request.CreateResponse<ICTGWS.ViewModels.GradedWorkUpdate>(HttpStatusCode.OK, updatedGradedWork);

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/GradedWorks
        [Authorize(Roles = "Faculty,Coordinator")]
        public HttpResponseMessage PostGradedWork(ICTGWS.ViewModels.GradedWorkAdd gradedwork)
        {
            if (ModelState.IsValid)
            {    /*
                db.GradedWorks.Add(gradedwork);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, gradedwork);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = gradedwork.Id }));
                return response;     */
                var c = r.AddGradedWork(gradedwork);                   //<====
                // Prepare the response
                HttpResponseMessage response =
                    Request.CreateResponse<GradedWork>(HttpStatusCode.Created, c);
                response.Headers.Location =
                    new Uri(Url.Link("DefaultApi", new { id = c.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/GradedWorks/5
        [Authorize(Roles = "Faculty,Coordinator")]
        public HttpResponseMessage DeleteGradedWork(int id)
        {
            GradedWork gradedwork = db.GradedWorks.Find(id);
            if (gradedwork == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.GradedWorks.Remove(gradedwork);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, gradedwork);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}