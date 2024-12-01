using Library.Core.Features.UserCQRS.UserQueries.UserQueryResponses;
using Library.Data.Entities;

namespace Library.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void GetUserCQRSByIDMapping()
        {

            CreateMap<User, GetUserCQRSByIDResponse>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));

            CreateMap<BorrowingRecord, BorrowingRecordRessponse>();
            CreateMap<Fine, FineRessponse>();
            CreateMap<Reservation, ReservationRessponse>();
        }



    }
}
