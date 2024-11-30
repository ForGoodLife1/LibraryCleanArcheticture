using Library.Core.Bases;
using MediatR;

namespace Library.Core.Features.Books.Commands.Models
{
    public class DeleteBookCommand : IRequest<Response<string>>
    {
        public DeleteBookCommand(int bookId)
        {
            BookId=bookId;
        }

        public int BookId { get; set; }
    }
}
