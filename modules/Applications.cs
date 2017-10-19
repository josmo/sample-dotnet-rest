using System.Linq;
using Nancy;
using Nancy.ModelBinding;
using sample_dotnet_rest.contexts;
using sample_dotnet_rest.helpers;
using sample_dotnet_rest.models;
using HttpStatusCode = Nancy.HttpStatusCode;

namespace NancyService.modules
{
    public class Applications : NancyModule
    {

        public Applications(AppDbContext db): base("/applications")
        {
            
            Get("/", MiddlewareWrapper.intercept(this, args =>
            {
                var applications = db.Applications;  
                return Response.AsJson(applications);
            }));
           
            Get("/{id}", MiddlewareWrapper.intercept(this, args =>
            {
                int valueId = args.id;
                var application = db.Applications.FirstOrDefault(value => value.ApplicationID == valueId);
                if (application == null)
                {
                    return HttpStatusCode.NotFound;
                }
                return Response.AsJson(application);
            }));
            
            Delete("/{id}", MiddlewareWrapper.intercept(this, args =>
            {
                int valueId = args.id;
                var application = db.Applications.FirstOrDefault(value => value.ApplicationID == valueId);
                application.IsActive = false;
                db.SaveChanges();
                return HttpStatusCode.OK;
            }));
            
            Post("/new", MiddlewareWrapper.intercept(this, args =>
            {
                var application = this.Bind<Application>();
                application.IsActive = true;
                db.Applications.Add(application);
                db.SaveChanges();
                return Response.AsJson(application);
            }));
            
        }

    }
}