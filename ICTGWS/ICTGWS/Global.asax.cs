using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
// new...
using AutoMapper;

namespace ICTGWS
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Store initializer
            System.Data.Entity.Database.SetInitializer(new ICTGWS.Models.StoreInitializer());

            // AutoMapper maps
            Mapper.CreateMap<ViewModels.ProgramAdd, Models.Program>();
            Mapper.CreateMap<ViewModels.SubjectAdd, Models.Subject>();
            Mapper.CreateMap<ViewModels.EmployeeAdd, Models.Employee>();

            Mapper.CreateMap<ViewModels.CourseAdd, Models.Course>();
            Mapper.CreateMap<ViewModels.GradedWorkAdd, Models.GradedWork>();
            Mapper.CreateMap<ViewModels.SemesterAdd, Models.Semester>();
            Mapper.CreateMap<ViewModels.StudentAdd, Models.Student>();

            // Add the authorization handler to the app
            GlobalConfiguration.Configuration.MessageHandlers.Add
                (new ICTGWS.Handlers.OAuth2MessageHandler());


            //routes.IgnoreRoute("favicon.ico");


        }
    }
}