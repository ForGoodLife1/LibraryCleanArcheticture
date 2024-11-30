using Library.Core.Features.UserCQRS.UserCommands.UserCommandModels;
using Library.Infrustructure.Entities;

namespace Library.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void EditUserCQRSMapping()
        {

            CreateMap<EditUserCQRSCommand, User>();


        }
    }
}
