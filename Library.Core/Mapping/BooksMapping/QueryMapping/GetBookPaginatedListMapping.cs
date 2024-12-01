using Library.Core.Features.Books.Queries.Responses;
using Library.Data.Entities;

namespace Library.Core.Mapping.BooksMapping
{
    public partial class BookProfile
    {
        public void GetBookPaginatedListMapping()
        {

            CreateMap<Book, GetBookPaginatedListResponse>();
        }
    }
}
