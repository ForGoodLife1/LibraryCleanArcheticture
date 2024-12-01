using Library.Api.Base;
using Library.Core.Features.Books.Commands.Models;
using Library.Core.Features.Books.Queries.Models;
using Library.Core.Filters;
using Library.Data.AppMetaData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{

    [ApiController]
    public class BookController : AppControllerBase
    {
        [HttpGet(Router.BookRouting.List)]
        [Authorize(Roles = "Book")]
        [ServiceFilter(typeof(AuthFilter))]
        public async Task<IActionResult> GetBookList()
        {
            var response = await Mediator.Send(new GetBookListQuery());
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpGet(Router.BookRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetBookPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.BookRouting.GetByID)]
        public async Task<IActionResult> GetBookByID([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetBookByIDQuery(id)));
        }
        [Authorize(Policy = "Create Book")]
        [HttpPost(Router.BookRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddBookCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [Authorize(Policy = "Edit Book")]
        [HttpPut(Router.BookRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditBookCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [Authorize(Policy = "Delete Book")]
        [HttpDelete(Router.BookRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int BookId)
        {
            return NewResult(await Mediator.Send(new DeleteBookCommand(BookId)));
        }
    }
}
