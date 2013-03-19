
namespace PSS.WebWithAuth.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;
    using GeoCoding;
    using GeoCoding.Google;

    /// <summary>
    /// Address location marker on map (not used yet)
    /// </summary>
    public class Marker
    {
        public string Title { get; set; }
        public Address GeocodingAddress
        {
            get
            {
                if (this.GeocodingOutput.Count == 0)
                {
                    this.ResolverMessage = "Address resolving failed";
                    return null;
                }
                else if (this.GeocodingOutput.Count() == 1)
                {
                    this.ResolverMessage = "";
                }
                else
                {
                    this.ResolverMessage = "Multiple entries returned";
                }

                if (this.GeocodingOutput.Count > 0)
                {
                    return this.GeocodingOutput.First();
                }

                return null;
            }
        }

        public string IconUri
        {
            get
            {
                return "~/Content/Images/home_icon.png";
            }
        }

        public string ResolverMessage { get; private set; }

        public IList<Address> GeocodingOutput { get; private set; }

        public Marker(string title, CityStateZip csz, string address)
        {
            this.CreateMarker(title, csz, address);
        }

        private Marker()
        {
        }

        public string ToJsonMarker()
        {
            this.Title = this.Title ?? "";
            // todo: handle null address
            return string.Format(@"{
                    title: ""{0}"",
                    position: new google.maps.LatLng({1}, {2}),
                    icon: ""{3}""
                }", 
              this.Title, 
              this.GeocodingAddress.Coordinates.Latitude, 
              this.GeocodingAddress.Coordinates.Longitude,
              this.IconUri
           );
        }

        private void CreateMarker(string title, CityStateZip csz, string address)
        {
            this.Title = title;
            IGeoCoder geocoder = new GoogleGeoCoder();
            this.GeocodingOutput = geocoder.GeoCode(address, csz.City, csz.State, csz.ZipCode, "").ToList();
        }
    }
}