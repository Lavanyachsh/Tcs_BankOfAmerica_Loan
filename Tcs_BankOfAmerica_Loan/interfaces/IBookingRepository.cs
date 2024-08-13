using Tcs_BankOfAmerica_Loan.Entities;

namespace Tcs_BankOfAmerica_Loan.interfaces
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllBookingDetails();
        Task<Booking> GetBookingDetailsById(int id);
        Task<bool> AddBookingDetails(Booking bookingDetail);
        Task<bool> UpdateBookingDetils(Booking bookingDetail);
        Task<bool> DeleteBookingDetilsById(int id);
    }
}
