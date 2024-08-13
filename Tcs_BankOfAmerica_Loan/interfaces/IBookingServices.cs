using Tcs_BankOfAmerica_Loan.DTOS;

namespace Tcs_BankOfAmerica_Loan.interfaces
{
    public interface IBookingServices
    {
        Task<List<BookingDto>> GetAllBookingDetails();
        Task<BookingDto> GetBookingsDetailsById(int id);
        Task<bool> AddBookingDetails(BookingDto bookingDetail);
        Task<bool> UpdateBookingDetils(BookingDto bookingDetail);
        Task<bool> DeleteBookingDetilsById(int id);
    }
}
