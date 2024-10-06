
using Library.Core.Bases;
using Library.Data.Results;
using MediatR;

namespace Library.Core.Features.Authentication.Commands.Models
{
    public class SignInCommand : IRequest<Response<JwtAuthResult>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
