namespace Library.Core.Features.UserCQRS.UserQueries.UserQueryResponses
{
    public class GetUserCQRSByIDResponse
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string ContactInformation { get; set; }
        public string LibraryCardNumber { get; set; }
        public List<BorrowingRecordRessponse>? BorrowingRecordList { get; set; }

        public List<FineRessponse>? FineList { get; set; }

        public List<ReservationRessponse>? ReservationList { get; set; }
    }
    public class BorrowingRecordRessponse
    {
        public int BorrowingRecordId { get; set; }

    }
    public class FineRessponse
    {
        public int FineId { get; set; }

    }
    public class ReservationRessponse
    {
        public int ReservationId { get; set; }

    }
}
