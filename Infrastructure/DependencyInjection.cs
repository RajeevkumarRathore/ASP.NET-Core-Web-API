using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using Application.ExternalAPI;
using ExternalAPI.Email;
using Infrastructure.Implementation.Common;
using Infrastructure.Implementation.Repositories;
using Infrastructure.Implementation.Services;
using Microsoft.Extensions.DependencyInjection;



namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            #region Service   
            
            services.AddTransient<ISendGridEmail, SendGridEmail>();  
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IShiftScheduleService, ShiftScheduleService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IHospitalService, HospitalService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IReportService, ReportService>();          
            services.AddTransient<IExpertisesServices, ExpertisesServices>();
            services.AddTransient<IImportantNumberCategoriesService, ImportantNumberCategoriesService>();
            services.AddTransient<IPhoneService, PhoneService>();
            services.AddTransient<IChatMessageHistoryService, ChatMessageHistoryService>();
            services.AddTransient<IDispatchBooksServices, DispatchBooksServices>();
            services.AddTransient<IDispatcherNotificationsServices, DispatcherNotificationsServices>();
            services.AddTransient<IHelpUsersServices, HelpUsersServices>();
            services.AddTransient<IUserHeartbeatsServices, UserHeartbeatsServices>();
            services.AddTransient<IAgencyPermissionService, AgencyPermissionService>();
            services.AddTransient<IImportantNumberService, ImportantNumberService>();
            services.AddTransient<IStatusInfoService, StatusInfoService>();
            services.AddTransient<IUrgencyInfoService, UrgencyInfoService>();
            services.AddTransient<IPlaceService, PlaceService>();
            services.AddTransient<IShortTextMessageService, ShortTextMessageService>();
            services.AddTransient<ICitiesService, CitiesService>();
            services.AddTransient<IDispatchLocationService, DispatchLocationService>();
            services.AddTransient<IAreasService, AreasService>();
            services.AddTransient<IStreetAreaService, StreetAreaService>();
            services.AddTransient<IDailyReportRecipientService, DailyReportRecipientService>();
            services.AddTransient<ICallStatusService, CallStatusService>();
            services.AddTransient<IAccessesServices, AccessesServices>();
            services.AddTransient<IContactPersonService, ContactPersonService>();
            services.AddTransient<IHighwayMappingService, HighwayMappingService>();
            services.AddTransient<IBusSectionService, BusSectionService>();
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<IShiftTypeService, ShiftTypeService>();
            services.AddTransient<IUrgentNumberService, UrgentNumberService>();
            services.AddTransient<IGridOptionService, GridOptionService>();
            services.AddTransient<IUserLoginsService, UserLoginsService>();
            services.AddTransient<IUrgencyInfoCategoriesService, UrgencyInfoCategoriesService>();




            #endregion

            #region Repository

            services.AddTransient<IRequestBuilder, RequestBuilder>();  
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IShiftScheduleRepository, ShiftScheduleRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IHospitalRepository, HospitalRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddTransient<IExpertisesRepository, ExpertisesRepository>();
            services.AddTransient<IImportantNumberCategoriesRepository, ImportantNumberCategoriesRepository>();
            services.AddTransient<IPhoneRepository, PhoneRepository>();
            services.AddTransient<IChatMessageRepository, ChatMessageRepository>();
            services.AddTransient<IDispatchBooksRepository, DispatchBooksRepository>();
            services.AddTransient<IDispatcherNotificationsRepository, DispatcherNotificationsRepository>();
            services.AddTransient<IHelpUsersRepository, HelpUsersRepository>();
            services.AddTransient<IUserHeartbeatsRepository, UserHeartbeatsRepository>();
            services.AddTransient<IApplicationLogErrorRepository, ApplicationLogErrorRepository>();
            services.AddTransient<IAgencyPermissionRepository, AgencyPermissionRepository>();
            services.AddTransient<IImportantNumberRepository, ImportantNumberRepository>();
            services.AddTransient<IStatusInfoRepository, StatusInfoRepository>();
            services.AddTransient<IUrgencyInfoRepository, UrgencyInfoRepository>();
            services.AddTransient<IPlaceRepository, PlaceRepository>();
            services.AddTransient<IShortTextMessageRepository, ShortTextMessageRepository>();
            services.AddTransient<ICitiesRepository, CitiesRepository>();
            services.AddTransient<IDispatchLocationRepository, DispatchLocationRepository>();
            services.AddTransient<IAreasRepository, AreasRepository>();
            services.AddTransient<IStreetAreaRepository, StreetAreaRepository>();
            services.AddTransient<IDailyReportRecipientRepository, DailyReportRecipientRepository>();
            services.AddTransient<ICallStatusRepository, CallStatusRepository>();
            services.AddTransient<IAccessesRepository, AccessesRepository>();
            services.AddTransient<IContactPersonRepository, ContactPersonRepository>();
            services.AddTransient<IHighwayMappingRepository, HighwayMappingRepository>();
            services.AddTransient<IBusSectionRepository, BusSectionRepository>();
            services.AddTransient<ISettingsRepository, SettingsRepository>();
            services.AddTransient<IShiftTypeRepository, ShiftTypeRepository>();
            services.AddTransient<IUrgentNumberRepository, UrgentNumberRepository>();
            services.AddTransient<IGridOptionRepository, GridOptionRepository>();
            services.AddTransient<IUserLoginsRepository, UserLoginsRepository>();
            services.AddTransient<IUrgencyInfoCategoriesRepository, UrgencyInfoCategoriesRepository>();



            #endregion
        }

    }
}
