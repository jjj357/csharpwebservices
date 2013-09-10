using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//new
using ICTGWS.Models;

namespace ICTGWS.Models
{
    public class RepositoryBase
    {
        
        // Declare and initialize a data store context
        protected ICTGWSContext ds = new ICTGWSContext();

        // Default constructor
        public RepositoryBase()
        {
            ds = new ICTGWSContext();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We do NOT want the serializer to dereference navigation properties
            // (because that would cause loops/cycles) 
            ds.Configuration.LazyLoadingEnabled = false;
        }


    }
}