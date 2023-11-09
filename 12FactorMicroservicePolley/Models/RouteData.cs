namespace TwelveFactorMicroservicePolley.Models
{
    public class RouteDataObject
    {
        public string? Id { get; set; }
        public string StartLocation { get; set; }

        public string EndLocation { get; set; }
        public string JSONString { get; set; }

        public RouteDataObject(string startLocation, string endLocation, string jSONString)
        {
            StartLocation = startLocation;
            EndLocation = endLocation;
            JSONString = jSONString;
        }
    }
}
