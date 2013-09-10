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
using ICTGWS.Models;
using System.ComponentModel.DataAnnotations;

namespace ICTGWS.Controllers
{
    public class ProgramsController : ApiController
    {
        private ICTGWSContext db = new ICTGWSContext();
        // Declare and initialize the repository
        private RepoProgram r = new RepoProgram();

        // GET api/Programs
        [Authorize(Roles = "Public,Student,Faculty,Coordinator")]
        public IEnumerable<Program> GetPrograms()
        {
            return db.Programs.AsEnumerable();
        }

        // GET api/Programs/5
        [Authorize(Roles="Public,Student,Faculty,Coordinator")]
        public Program GetProgram(int id)
        {
            Program program = db.Programs.Find(id);
            if (program == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return program;
        }

        // PUT api/Programs/5
        [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage PutProgram(int id, ICTGWS.ViewModels.ProgramUpdate program)
        {
            if (ModelState.IsValid && id == program.Id)
            {
                /*
                db.Entry(program).State = EntityState.Modified;

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
                var updatedProgram = r.UpdateProgram(program);
                return (updatedProgram == null) ?
                    Request.CreateResponse(HttpStatusCode.BadRequest) :
                    Request.CreateResponse<ICTGWS.ViewModels.ProgramUpdate>(HttpStatusCode.OK, updatedProgram);

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Programs
        [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage PostProgram(ICTGWS.ViewModels.ProgramAdd program)   //Program program)
        {
            if (ModelState.IsValid)
            {
               // r.AddProgram(program);
                //db.Programs.Add(r.AddProgram(program));
                //db.SaveChanges();

                //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, program);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = program.Id }));
                //return response;
                // Add the new item
                var c = r.AddProgram(program);
                // Prepare the response
                HttpResponseMessage response =
                    Request.CreateResponse<Program>(HttpStatusCode.Created, c);
                response.Headers.Location =
                    new Uri(Url.Link("DefaultApi", new { id = c.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Programs/5
        [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage DeleteProgram(int id)
        {
            Program program = db.Programs.Find(id);
            if (program == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Programs.Remove(program);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, program);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}