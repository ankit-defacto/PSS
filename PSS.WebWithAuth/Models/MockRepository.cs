
namespace PSS.WebWithAuth.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using PSS.WebWithAuth.ViewModels;
    using ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;

    /// <summary>
    /// Temporary mock repository class
    /// </summary>
    public class MockRepository : IDisposable
    {
        public IQueryable<SearchResultViewModel> DoSearchQuery(SearchFilterViewModel filter)
        {
            return this.DoSearch(filter).AsQueryable();
        }

        public IList<SearchResultViewModel> DoSearch(SearchFilterViewModel filter)
        {
            CityStateZip csz = new CityStateZip
            {
                CityStateZipGuid = Guid.NewGuid(),
                City = "New York",
                State = "New York",
                ZipCode = "00501"
            };

            string facilityNameFormat = "Facility name {0}";
            string descriptionFormat = "Facility description {0}";
            var outList = new List<SearchResultViewModel>();

            for (int i = 0; i < 200; i++)
            {
                var resultItem = new SearchResultViewModel
                {
                    FacilityGuid = Guid.NewGuid(),
                    PhotoUri = "../../Content/Images/homeProfileDrawing.png",
                    FacilityName = string.Format(facilityNameFormat, i),
                    FacilityShortDescription = string.Format(descriptionFormat, i),
                    CityStateZip = csz
                };
                outList.Add(resultItem);
            }

            return outList;
        }

        public List<PhotoSliderViewModel> GetMockPhotos()
        {
            return new List<PhotoSliderViewModel>()
            {
                new PhotoSliderViewModel { Id = Guid.NewGuid(), Uri = "http://i.imgur.com/K1vOV.jpg", Alt = "Pic 1" },
                new PhotoSliderViewModel { Id = Guid.NewGuid(), Uri = "http://i.imgur.com/QMz45.jpg", Alt = "Pic 2" },
                new PhotoSliderViewModel { Id = Guid.NewGuid(), Uri = "http://i.imgur.com/UDzm2.jpg", Alt = "Pic 3" },
                new PhotoSliderViewModel { Id = Guid.NewGuid(), Uri = "http://i.imgur.com/ohK8g.jpg", Alt = "Pic 4" },
                new PhotoSliderViewModel { Id = Guid.NewGuid(), Uri = "http://i.imgur.com/gEEbE.jpg", Alt = "Pic 5" },
            };
        }

        public ListingDetailsViewModel ListingDetails(Guid facilityGuid)
        {
            return new ListingDetailsViewModel
            {
                FacilityGuid = Guid.NewGuid(),
                FacilityName = "Name 1",
                FacilityShortDescription = @"Lorem ipsum dolor sit amet, consectetuer adipiscing elit, 
sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. 
Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip 
ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie 
consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim 
qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi.",
                PhotoUri = "../../Content/Images/homeProfileDrawing.png",
                Photos = new List<PhotoSliderViewModel>()
                {
                    new PhotoSliderViewModel { Id = Guid.NewGuid(), Uri = "http://i.imgur.com/K1vOV.jpg", Alt = "Pic 1" },
                    new PhotoSliderViewModel { Id = Guid.NewGuid(), Uri = "http://i.imgur.com/QMz45.jpg", Alt = "Pic 2" },
                    new PhotoSliderViewModel { Id = Guid.NewGuid(), Uri = "http://i.imgur.com/UDzm2.jpg", Alt = "Pic 3" },
                    new PhotoSliderViewModel { Id = Guid.NewGuid(), Uri = "http://i.imgur.com/ohK8g.jpg", Alt = "Pic 4" },
                    new PhotoSliderViewModel { Id = Guid.NewGuid(), Uri = "http://i.imgur.com/gEEbE.jpg", Alt = "Pic 5" },
                },
                CityStateZip = new CityStateZip
                {
                    CityStateZipGuid = Guid.NewGuid(),
                    City = "New York",
                    State = "New York",
                    ZipCode = "00501"
                }
            };
        }

        public IList<ListingType> GetListingTypes
        {
            get
            {
                return new List<ListingType>()
                {
                    new ListingType { ListingTypeGuid = new Guid("37ba2196-27eb-432d-afd0-ba571cf5a420"), ListingTypeName = "Standard Listing $.99" },
                    new ListingType { ListingTypeGuid = new Guid("58e5aeea-84f1-4be6-a318-93cb99865de3"), ListingTypeName = "Premier Listing $2.50" }
                };
            }
        }

        public IList<TypeOfCareViewModel> TypesOfCare
        {
            get
            {
                var typeofcarelist = new List<TypeOfCareViewModel>();
                typeofcarelist.Add(
                    new TypeOfCareViewModel
                    {
                        TypeOfCareGuid = new Guid("1e8efc99-3e77-41ef-9c7c-38696d5ca269"),
                        TypeOfCareName = "Adult Family Home/ Residential Care",
                        Checked = false
                    }
                );
                typeofcarelist.Add(
                    new TypeOfCareViewModel
                    {
                        TypeOfCareGuid = new Guid("983af57b-9757-4a23-9a6b-11b4fbc0c870"),
                        TypeOfCareName = "Assisted Living Facility",
                        Checked = false
                    }
                );
                typeofcarelist.Add(
                    new TypeOfCareViewModel
                    {
                        TypeOfCareGuid = new Guid("d18f2067-a405-4ef3-bf71-336d5e82871b"),
                        TypeOfCareName = "Skilled Nursing Facility",
                        Checked = false
                    }
                );
                typeofcarelist.Add(
                    new TypeOfCareViewModel
                    {
                        TypeOfCareGuid = new Guid("46e51cc2-4683-4e53-93ae-deb09f2f9c51"),
                        TypeOfCareName = "Home Care",
                        Checked = false
                    }
                );
                typeofcarelist.Add(
                    new TypeOfCareViewModel
                    {
                        TypeOfCareGuid = new Guid("63a4fba1-8a8a-4bb1-9238-fcd65ee16073"),
                        TypeOfCareName = "Retirement Community",
                        Checked = false
                    }
                );
                typeofcarelist.Add(
                    new TypeOfCareViewModel
                    {
                        TypeOfCareGuid = new Guid("8d5463e4-a64b-4363-b8cb-6f3535bca099"),
                        TypeOfCareName = "Independent Living Facility",
                        Checked = false
                    }
                );
                typeofcarelist.Add(
                    new TypeOfCareViewModel
                    {
                        TypeOfCareGuid = new Guid("c6c47f13-cf2f-4132-9c22-ca2ee3776c22"),
                        TypeOfCareName = "Independent Caregivers",
                        Checked = false
                    }
                );
                return typeofcarelist;
            }
        }

        public void Dispose()
        {            
        }
    }
}