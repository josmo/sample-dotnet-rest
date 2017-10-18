using System;
using System.Collections.Generic;
using Nancy;
using sample_dotnet_rest.models;

namespace NancyService.modules
{
    public class Applications : NancyModule
    {
        static List<String> sampleClaims = new List<string>();
        
        public Applications(): base("/applications")
        {
            
     
            Get("/",args =>
            {
                var applications = new List<Application>();
                var application = new Application{ ApplicationID = 123, ApplicationName = "testing"};
                applications.Add(application);
                return Response.AsJson(applications);
            });
           
            Get("/{id}", args =>
            {
                var application = new Application{ ApplicationID = 123, ApplicationName = "testing"};
                return Response.AsJson(application);
            });
            
            
        }

    }
}