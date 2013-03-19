
namespace ConcordMfg.PremierSeniorSolutions.WebService.DataAccess.DAEntities
{
    /// <summary>
    /// Coordinates holder
    /// </summary>
    public class LatLng
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
 
        private LatLng()
        {
        }
 
        public LatLng(double lat, double lng)
        {
            this.Latitude = lat;
            this.Longitude = lng;
        }
    }
}