﻿namespace Library.Core.Features.UserCQRS.UserQueries.UserQueryResponses
{
    public class GetUserCQRSPaginatedListResponse
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? ContactInformation { get; set; }
        public string? LibraryCardNumber { get; set; }
    }
}
