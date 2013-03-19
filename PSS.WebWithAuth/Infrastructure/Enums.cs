
namespace PSS.WebWithAuth.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// MVC application enums class
    /// </summary>
    public class Enums
    {
        public enum MenuItemViewModes
        {
            Anonymous = 1,
            Authenticated = 2,
            All = 3
        }

        /// <summary>
        /// Search type enumeration
        /// </summary>
        public enum SearchTypes
        {
            /// <summary>
            /// Unknown value
            /// </summary>
            Undefined = 0,

            /// <summary>
            /// Filtered search (based on full filter criteria)
            /// </summary>
            Filtered = 1,

            /// <summary>
            /// Distance search (based only on distance criteria)
            /// </summary>
            Distance = 2,

            /// <summary>
            /// Combined search (filter for types of care + distance search)
            /// </summary>
            FilteredDistance = 3
        }

        /// <summary>
        /// Geolocation status enumeration
        /// </summary>
        public enum GeolocationStates
        {
            /// <summary>
            /// Unknown value
            /// </summary>
            Undefined = 0,

            /// <summary>
            /// Waiting to resolve - on first page open
            /// </summary>
            WaitingForResolve = 1,

            /// <summary>
            /// Location resolved successfully
            /// </summary>
            Resolved = 2,

            /// <summary>
            /// Resolving failed due to some reason
            /// </summary>
            ResolveNotPossible = 3
        }
    }
}