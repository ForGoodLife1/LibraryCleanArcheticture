using Library.Core.Features.UserCQRS.UserCommands.UserCommandModels;
using Library.Data.Entities;

namespace Library.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void AddUserCQRSMapping()
        {

            CreateMap<AddUserCQRSCommand, User>();


        }
    }
}
