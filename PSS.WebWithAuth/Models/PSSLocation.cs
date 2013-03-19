
namespace PSS.WebWithAuth.Models
{
    using PSS.WebWithAuth.Infrastructure;

    /// <summary>
    /// Geolocation storage unit class
    /// </summary>
    public class PSSLocation
    {
        /// <summary>
        /// Gets or sets latitude
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets longitude
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets geolocation status
        /// </summary>
        public Enums.GeolocationStates GeolocationStatus { get; set; }
    }
}