using AutoMapper;

namespace Library.Core.Mapping.Users
{
    public partial class UserProfile : Profile
    {
        public UserProfile()
        {
            AddUserCQRSMapping();
            EditUserCQRSMapping();
            GetUserCQRSByIDMapping();
            GetUserCQRSListDMapping();
            GetUserCQRSPaginatedListMapping();
        }
    }
}
