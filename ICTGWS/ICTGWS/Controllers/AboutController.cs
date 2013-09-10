using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ICTGWS.Controllers
{
    public class AboutController : ApiController
    {
        // GET api/about
        /*
        public string Get()
        {
            using (var context = new ICTGWS.Models.ICTGWSContext())
            {
                string countPrograms = context.Programs.Count().ToString();
                string countSubjects = context.Subjects.Count().ToString();
                string countEmployees = context.Employees.Count().ToString();

                return string.Format("The database has been initialized with... {0} Programs, {1} Subjects, and {2} Employees", countPrograms, countSubjects, countEmployees);
            }
        }
        */

        public string Get()
        {
            return User.Identity.Name;
        }
    
    
    }
}
