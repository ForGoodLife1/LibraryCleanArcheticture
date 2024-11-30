using AutoMapper;
using Library.Core.Bases;
using Library.Core.Resources;
using Library.Core.Wrappers;
using Library.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Library.Core.Features.Books.Queries.Handlers
{
    public class BookQueryHandler : ResponseHandler,
                                       IRequestHandler<GetBookListQuery, Response<List<GetBookListResponse>>>,
                                       IRequestHandler<GetBookByIDQuery, Response<GetBookByIDResponse>>,
                                       IRequestHandler<GetBookPaginatedListQuery, PaginatedResult<GetBookPaginatedListResponse>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;


        public BookQueryHandler(IUserService userService,
                                   IMapper mapper,
                                   IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _userService= userService;
            _mapper=mapper;
            _stringLocalizer=stringLocalizer;
        }

        public async Task<Response<List<GetBookListResponse>>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            var userList = await _userService.GetListAsync();
            var userListMapper = _mapper.Map<List<GetBookListResponse>>(userList);
            var result = Success(userListMapper);
            result.Meta=new { Count = userListMapper.Count() };
            return result;
        }

        public async Task<Response<GetBookByIDResponse>> Handle(GetBookByIDQuery request, CancellationToken cancellationToken)
        {
            var response = _userService.GetByIDAsync(request.Id);
            if (response==null) return NotFound<GetBookByIDResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            var mapper = _mapper.Map<GetBookByIDResponse>(request);
            return Success(mapper);
        }

        public async Task<PaginatedResult<GetBookPaginatedListResponse>> Handle(GetBookPaginatedListQuery request, CancellationToken cancellationToken)
        {
            //Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.StudID, e.Localize(e.NameAr, e.NameEn), e.Address, e.Department.Localize(e.Department.DNameAr, e.Department.DNameEn));
            var FilterQuery = _userService.FilterUserPaginatedQuerable(request.OrderBy, request.Search);
            var PaginatedList = await _mapper.ProjectTo<GetBookPaginatedListResponse>(FilterQuery).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            PaginatedList.Meta=new { Count = PaginatedList.Data.Count() };
            return PaginatedList;
        }
    }
}
