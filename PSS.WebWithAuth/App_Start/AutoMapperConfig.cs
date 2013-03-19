
namespace PSS.WebWithAuth.App_Start
{
    using AutoMapper;
    using ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;
    using PSS.WebWithAuth.ViewModels;

    /// <summary>
    /// Automapper configuration
    /// </summary>
    public class AutoMapperConfig
    {
        /// <summary>
        /// Configure method
        /// </summary>
        public static void Configure()
        {
            //// ListingViewModel BE to MVC view model
            Mapper.CreateMap<ListingViewModel, ListingViewModelEdit>()
                //// ignores
                .ForMember(dest => dest.ActionName, opt => opt.Ignore())
                .ForMember(dest => dest.SaveButtonText, opt => opt.Ignore())
                .ForMember(dest => dest.ListingTypeSelectList, opt => opt.Ignore())
                .ForMember(dest => dest.TypeOfCareList, opt => opt.Ignore())
                .ForMember(dest => dest.FacilityPhotos, opt => opt.Ignore())                              
                ;

            //// Copy account properties to listing
            Mapper.CreateMap<AccountViewModel, ListingViewModelEdit>()
                //// ignores
                .ForMember(dest => dest.ActionName, opt => opt.Ignore())
                .ForMember(dest => dest.SaveButtonText, opt => opt.Ignore())
                .ForMember(dest => dest.ListingTypeSelectList, opt => opt.Ignore())
                .ForMember(dest => dest.TypeOfCareList, opt => opt.Ignore())
                .ForMember(dest => dest.Latitude, opt => opt.Ignore())
                .ForMember(dest => dest.Longitude, opt => opt.Ignore())

                .ForMember(dest => dest.Website, opt => opt.Ignore())
                .ForMember(dest => dest.PublicPhotoFileUri, opt => opt.Ignore())
                .ForMember(dest => dest.ListingTypeGuid, opt => opt.Ignore())
                .ForMember(dest => dest.ListingTypeName, opt => opt.Ignore())
                .ForMember(dest => dest.FacilityGuid, opt => opt.Ignore())
                .ForMember(dest => dest.FacilityID, opt => opt.Ignore())
                .ForMember(dest => dest.FacilityName, opt => opt.Ignore())
                .ForMember(dest => dest.Exerpt, opt => opt.Ignore())
                .ForMember(dest => dest.Description, opt => opt.Ignore())
                .ForMember(dest => dest.FacilityPhotos, opt => opt.Ignore())

                .ForSourceMember(src => src.AmazonToken, opt => opt.Ignore())
                .ForSourceMember(src => src.ClientID, opt => opt.Ignore())
                .ForSourceMember(src => src.FederatedID, opt => opt.Ignore())
                .ForSourceMember(src => src.FederatedIDProvider, opt => opt.Ignore())
                .ForSourceMember(src => src.FederatedKey, opt => opt.Ignore())
                .ForSourceMember(src => src.PaymentInfoGuid, opt => opt.Ignore())
                .ForSourceMember(src => src.PaymentInfoID, opt => opt.Ignore())
                
                .ForMember(dest => dest.Price, opt => opt.Ignore());

            //// listing to facility
            Mapper.CreateMap<ListingViewModelEdit, Facility>()
                //// ignores
                .ForSourceMember(src => src.ActionName, opt => opt.Ignore())
                .ForSourceMember(src => src.SaveButtonText, opt => opt.Ignore())
                .ForSourceMember(src => src.ListingTypeSelectList, opt => opt.Ignore())
                .ForSourceMember(src => src.TypeOfCareList, opt => opt.Ignore())
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(m => m.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(m => m.Longitude))
                ;

            Mapper.CreateMap<AccountViewModel, AccountWithListingsViewModel>()
                .ForMember(dest => dest.AccountListings, opt => opt.Ignore())
                .ForMember(dest => dest.clientCardInfoVM, opt => opt.Ignore())
                ;

            //// facility to facility photo
            Mapper.CreateMap<FacilityPhoto, FacilityPhotoViewModel>()
                .ForMember(dest => dest.CssStyle, opt => opt.Ignore())
                .ForMember(dest => dest.Uid, opt => opt.Ignore());
            Mapper.CreateMap<FacilityPhotoViewModel, FacilityPhoto>()
                .ForSourceMember(src => src.Uid, opt => opt.Ignore())
                .ForSourceMember(src => src.CssStyle, opt => opt.Ignore());

            //// searchfilter to searchfilter with facility
            Mapper.CreateMap<SearchFilterViewModel, SearchFilterWithFacilityViewModel>()
                .ForMember(dest => dest.FacilityGuid, opt => opt.Ignore());
            Mapper.CreateMap<SearchFilterWithFacilityViewModel, SearchFilterViewModel>()
                .ForSourceMember(src => src.FacilityGuid, opt => opt.Ignore());
        }
    }
}