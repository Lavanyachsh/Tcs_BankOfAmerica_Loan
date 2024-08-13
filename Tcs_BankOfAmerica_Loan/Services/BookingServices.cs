using Tcs_BankOfAmerica_Loan.DTOS;
using Tcs_BankOfAmerica_Loan.Entities;
using Tcs_BankOfAmerica_Loan.interfaces;
using Tcs_BankOfAmerica_Loan.Repositories;

namespace Tcs_BankOfAmerica_Loan.Services
{
    public class BookingServices : IBookingServices
    {
        IBookingRepository _bookingRepository;
        public BookingServices(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;

        }
        public async Task<bool> AddBookingDetails(BookingDto bookingDetail)
        {
            Booking obj = new Booking();
           // obj.id = bookingDetail.id;
            obj.CustomerName = bookingDetail.CustomerName;
            obj.Country = bookingDetail.Country;
            obj.City= bookingDetail.City;
            obj.Email= bookingDetail.Email;


            await _bookingRepository.AddBookingDetails(obj);
            return true;
        }

        public async Task<bool> DeleteBookingDetilsById(int id)
        {
            await _bookingRepository.DeleteBookingDetilsById(id);
            return true;
        }

        public async Task<List<BookingDto>> GetAllBookingDetails()
        {
            List<BookingDto> objBookingDto = new List<BookingDto>();
            var result = await _bookingRepository.GetAllBookingDetails();
            foreach (Booking bookingobj in result)
            {
                BookingDto obj = new BookingDto();
                obj.id = bookingobj.id;
                obj.CustomerName = bookingobj.CustomerName;
                obj.Country = bookingobj.Country;
                obj.City = bookingobj.City;
                obj.Email = bookingobj.Email;
                objBookingDto.Add(obj);
            }
            return objBookingDto;
        }

        public async Task<BookingDto> GetBookingsDetailsById(int id)
        {
            var bookingobj = await _bookingRepository.GetBookingDetailsById(id);

            BookingDto bookingdtoobj = new BookingDto();
            bookingdtoobj.id = bookingobj.id;
            bookingdtoobj.CustomerName = bookingobj.CustomerName;
            bookingdtoobj.Email = bookingobj.Email;
            bookingdtoobj.City = bookingobj.City;
            bookingdtoobj.Country = bookingobj.Country;

            return bookingdtoobj;
        }

        public async Task<bool> UpdateBookingDetils(BookingDto bookingDetail)
        {
            Booking obj = new Booking();
            obj.id = bookingDetail.id;
            obj.CustomerName = bookingDetail.CustomerName;
            obj.City= bookingDetail.City;
            obj.Country = bookingDetail.Country;
            obj.Email= bookingDetail.Email;

            await _bookingRepository.UpdateBookingDetils(obj);
            return true;
        }
    }
}
