using Library.Core.Features.Books.Commands.Models;
using Library.Data.Entities;

namespace Library.Core.Mapping.BooksMapping
{
    public partial class BookProfile
    {
        public void AddBookMapping()
        {

            CreateMap<AddBookCommand, Book>();


        }
    }
}
