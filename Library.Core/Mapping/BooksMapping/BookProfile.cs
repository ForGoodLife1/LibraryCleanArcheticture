using AutoMapper;

namespace Library.Core.Mapping.BooksMapping
{
    public partial class BookProfile : Profile
    {
        public BookProfile()
        {
            AddBookMapping();
            EditBookMapping();
            GetBookByIDMapping();
            GetBookListDMapping();
            GetBookPaginatedListMapping();
        }
    }
}
