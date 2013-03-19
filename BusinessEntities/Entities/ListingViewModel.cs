using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities
{
	public class ListingViewModel
	{
		/// <summary>
		/// Gets or sets the City State Zip Guid.
		/// </summary>
        [Required]
		public Guid CityStateZipGuid
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the City.
		/// </summary>
        [Required]
        [StringLength(50)]
        [Display(Name = "City", Prompt = "City")]
		public string City
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the State.
		/// </summary>
        [Required]
        [StringLength(50)]
        [Display(Name = "State", Prompt = "State")]
		public string State
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the Zip Code.
		/// </summary>
        [Required]
        [StringLength(5)]
        [RegularExpression(@"\d{5}")]
        [Display(Name = "Zip code", Prompt = "Zip code")]
		public string ZipCode
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the Listing Type Guid.
		/// </summary>
        [Required]
		public virtual Guid ListingTypeGuid
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the Listing Type Name.
		/// </summary>
        [StringLength(50)]
		public string ListingTypeName
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the Facility Guid.
		/// </summary>
        [Required]
		public Guid FacilityGuid
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the Facility ID.
		/// </summary>
		public int FacilityID
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the Facility Name.
		/// </summary>
        [Required]
        [StringLength(50)]
        [Display(Name = "Facility name", Prompt = "Facility name")]
		public string FacilityName
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the Exerpt.
		/// </summary>
        [DataType(DataType.MultilineText)]
        [Required]
        [StringLength(200)]
        [Display(Name = "Summary Description", Prompt = "Summary")]
		public string Exerpt
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the Description.
		/// </summary>
        [DataType(DataType.MultilineText)]
        [Required]
        [StringLength(500)]
        [Display(Name = "Description", Prompt = "Description")]
		public string Description
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the Address.
		/// </summary>
        [Required]
        [StringLength(100)]
        [Display(Name = "Address", Prompt = "Address")]
		public string Address
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the Phone Number.
		/// </summary>
        [Required]
        [StringLength(10)]
        [RegularExpression(@"\d{10}")]
        [Display(Name = "Phone number", Prompt = "Phone number")]
		public string PhoneNumber
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the Email.
		/// </summary>
        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email", Prompt = "Email")]
		public string Email
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the Website.
		/// </summary>
        [Required]
        [StringLength(100)]
        [Display(Name = "Website", Prompt = "Website")]
		public string Website
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the Client Guid.
		/// </summary>
        [Required]
		public Guid ClientGuid
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the Public Photo File Uri.
		/// </summary>
        [Required]
        [StringLength(200)]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Profile Photo URL", Prompt = "URL here")]
		public string PublicPhotoFileUri
		{
			get;
			set;
		}

        /// <summary>
        /// Gets or sets latitude
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets longitude
        /// </summary>
        public double Longitude { get; set; }

        [Required]
        public decimal Price { get; set; }
	}
}