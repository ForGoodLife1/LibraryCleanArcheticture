using AutoMapper;
using Library.Core.Bases;
using Library.Core.Features.UserCQRS.UserQueries.UserQueryModels;
using Library.Core.Features.UserCQRS.UserQueries.UserQueryResponses;
using Library.Core.Resources;
using Library.Core.Wrappers;
using Library.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Library.Core.Features.UserCQRS.UserQueries.UserQueryHandlers
{
    public class UserCQRSQueryHandler : ResponseHandler,
                                       IRequestHandler<GetUserCQRSListQuery, Response<List<GetUserCQRSListResponse>>>,
                                       IRequestHandler<GetUserCQRSByIDQuery, Response<GetUserCQRSByIDResponse>>,
                                       IRequestHandler<GetUserCQRSPaginatedListQuery, PaginatedResult<GetUserCQRSPaginatedListResponse>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;


        public UserCQRSQueryHandler(IUserService userService,
                                   IMapper mapper,
                                   IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _userService= userService;
            _mapper=mapper;
            _stringLocalizer=stringLocalizer;
        }

        public async Task<Response<List<GetUserCQRSListResponse>>> Handle(GetUserCQRSListQuery request, CancellationToken cancellationToken)
        {
            var userList = await _userService.GetListAsync();
            var userListMapper = _mapper.Map<List<GetUserCQRSListResponse>>(userList);
            var result = Success(userListMapper);
            result.Meta=new { Count = userListMapper.Count() };
            return result;
        }

        public async Task<Response<GetUserCQRSByIDResponse>> Handle(GetUserCQRSByIDQuery request, CancellationToken cancellationToken)
        {
            var response = _userService.GetByIDAsync(request.Id);
            if (response==null) return NotFound<GetUserCQRSByIDResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            var mapper = _mapper.Map<GetUserCQRSByIDResponse>(request);
            return Success(mapper);
        }

        public async Task<PaginatedResult<GetUserCQRSPaginatedListResponse>> Handle(GetUserCQRSPaginatedListQuery request, CancellationToken cancellationToken)
        {
            //Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.StudID, e.Localize(e.NameAr, e.NameEn), e.Address, e.Department.Localize(e.Department.DNameAr, e.Department.DNameEn));
            var FilterQuery = _userService.FilterUserPaginatedQuerable(request.OrderBy, request.Search);
            var PaginatedList = await _mapper.ProjectTo<GetUserCQRSPaginatedListResponse>(FilterQuery).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            PaginatedList.Meta=new { Count = PaginatedList.Data.Count() };
            return PaginatedList;
        }
    }
}
