using TwelveFactorMicroservicePolley.Models;

namespace TwelveFactorMicroservicePolley.Data
{
    public interface IRepository
    {
        public void SaveRouteDAL(RouteDataObject routeData);
        public RouteDataObject GetRouteDataDAL(string StartLocation, string EndLocation);
    }
}
