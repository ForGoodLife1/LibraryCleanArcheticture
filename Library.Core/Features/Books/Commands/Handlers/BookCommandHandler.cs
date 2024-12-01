using AutoMapper;
using Library.Core.Bases;
using Library.Core.Features.Books.Commands.Models;
using Library.Core.Resources;
using Library.Data.Entities;
using Library.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Library.Core.Features.Books.Commands.Handlers
{
    public class BookCommandHandler : ResponseHandler,
                                       IRequestHandler<AddBookCommand, Response<string>>,
                                       IRequestHandler<EditBookCommand, Response<string>>,
                                       IRequestHandler<DeleteBookCommand, Response<string>>
    {
        #region Fields
        private readonly IBookService _BookService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructors
        public BookCommandHandler(IBookService BookService,
                                     IMapper mapper,
                                     IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _BookService= BookService;
            _mapper= mapper;
            _localizer= localizer;
        }
        #endregion
        #region Handle Functions

        public async Task<Response<string>> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            //mapping Between request and Book
            var Bookmapper = _mapper.Map<Book>(request);
            //add
            var result = await _BookService.AddAsync(Bookmapper);
            //return response
            if (result=="Success") return Created("");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditBookCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var Book = await _BookService.GetByIDAsync(request.BookId);
            //return NotFound
            if (Book==null) return NotFound<string>();
            //mapping Between request and Book
            var Bookmapper = _mapper.Map(request, Book);
            //Call service that make Edit
            var result = await _BookService.EditAsync(Bookmapper);
            //return response
            if (result=="Success") return Success((string)_localizer[SharedResourcesKeys.Updated]);
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var Book = await _BookService.GetByIDAsync(request.BookId);
            //return NotFound
            if (Book==null) return NotFound<string>();
            //Call service that make Delete
            var result = await _BookService.DeleteAsync(Book);
            if (result=="Success") return Deleted<string>();
            else return BadRequest<string>();
        }
        #endregion
    }
}
