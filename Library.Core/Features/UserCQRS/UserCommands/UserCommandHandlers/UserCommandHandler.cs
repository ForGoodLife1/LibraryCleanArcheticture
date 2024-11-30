using AutoMapper;
using Library.Core.Bases;
using Library.Core.Features.ApplicationUser.Commands.Models;
using Library.Core.Resources;
using Library.Data.Entities;
using Library.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Library.Core.Features.UserCQRS.UserCommands.UserCommandHandlers
{
    public class UserCommandHandler : ResponseHandler,
                                       IRequestHandler<AddUserCommand, Response<string>>,
                                       IRequestHandler<EditUserCommand, Response<string>>,
                                       IRequestHandler<DeleteUserCommand, Response<string>>
    {
        #region Fields
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructors
        public UserCommandHandler(IUserService userService,
                                     IMapper mapper,
                                     IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _userService= userService;
            _mapper= mapper;
            _localizer= localizer;
        }
        #endregion
        #region Handle Functions

        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            //mapping Between request and User
            var usermapper = _mapper.Map<User>(request);
            //add
            var result = await _userService.AddAsync(usermapper);
            //return response
            if (result=="Success") return Created("");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var user = await _userService.GetByIDAsync(request.Id);
            //return NotFound
            if (user==null) return NotFound<string>();
            //mapping Between request and User
            var usermapper = _mapper.Map(request, user);
            //Call service that make Edit
            var result = await _userService.EditAsync(usermapper);
            //return response
            if (result=="Success") return Success((string)_localizer[SharedResourcesKeys.Updated]);
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var user = await _userService.GetByIDAsync(request.Id);
            //return NotFound
            if (user==null) return NotFound<string>();
            //Call service that make Delete
            var result = await _userService.DeleteAsync(user);
            if (result=="Success") return Deleted<string>();
            else return BadRequest<string>();
        }
        #endregion
    }
}
