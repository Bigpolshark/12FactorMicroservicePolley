using TwelveFactorMicroservicePolley.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace TwelveFactorMicroservicePolley.Data
{
    public class Repository12Factor : IRepository
    {

        private readonly DbContext12Factor context;

        public Repository12Factor(DbContext12Factor context)
        {
            this.context = context;
            //_logger = logger;
            //_logger.LogDebug("");
        }

        public RouteDataObject GetRouteDataDAL(string StartLocation, string EndLocation)
        {
            //return new RouteDataObject("test1", "test1", "test1");

            try
            {
                context.Database.EnsureCreated();

                var result = context.RouteDataDB
                    .Single(x => x.StartLocation == StartLocation && x.EndLocation == EndLocation);


                return result;
            }
            catch (System.InvalidOperationException ex)
            {

                return null;

            }
            catch (System.Exception ex)
            {

                throw new Exception("Error", ex);

            }
        }

        public void SaveRouteDAL(RouteDataObject routeData)
        {
            try
            {
                context.Database.EnsureCreated();
                context.Add(routeData);
                context.SaveChanges();
            }
            catch (System.Exception ex)
            {

            }
        }
    }
}
