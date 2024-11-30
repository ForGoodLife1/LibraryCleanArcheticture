using Library.Core.Bases;
using MediatR;

namespace Library.Core.Features.Books.Commands.Models
{
    public class AddBookCommand : IRequest<Response<string>>
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Isbn { get; set; }

        public DateOnly PublicationDate { get; set; }

        public string Genre { get; set; }

        public string? AdditionalDetails { get; set; }
    }
}
