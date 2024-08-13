using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tcs_BankOfAmerica_Loan.DTOS;
using Tcs_BankOfAmerica_Loan.interfaces;
using Tcs_BankOfAmerica_Loan.Services;

namespace Tcs_BankOfAmerica_Loan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        IBookingServices _bookingservice;
        public BookingController(IBookingServices bookingservice) 
        {
            _bookingservice = bookingservice;
        }
        [HttpGet(Name = "GetBookings")]
        public async Task<IActionResult> GetBookings()
        {
            try
            {
                var bookingData = await _bookingservice.GetAllBookingDetails();
                if (bookingData != null)
                {
                    return StatusCode(StatusCodes.Status200OK, bookingData);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
        [HttpPost]
        [Route("AddBookingDetails")]
        public async Task<IActionResult> Post([FromBody] BookingDto bookingdtoobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var bookingData = await _bookingservice.AddBookingDetails(bookingdtoobj);
                return StatusCode(StatusCodes.Status201Created, "Booking  Added Succesfully");
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

        [HttpGet]
        [Route("GetBookingDetailsById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
            }
            try
            {
                var bookingData = await _bookingservice.GetBookingsDetailsById(id);
                if (bookingData == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "BookingID Id not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, bookingData);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

        [HttpDelete]
        [Route("DeleteBookingDetilsById/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
            }

            try
            {
                var countryData = await _bookingservice.DeleteBookingDetilsById(id);
                if (countryData == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Booking Id not found");
                }
                else
                {
                   // var Data = await _bookingservice.DeleteBookingDetilsById(id);
                    return StatusCode(StatusCodes.Status204NoContent, "booking details deleted successfully");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

        [HttpPut]
        [Route("UpdateBookingDetils")]
        public async Task<IActionResult> PUT([FromBody] BookingDto bookingdtoobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var countryData = await _bookingservice.UpdateBookingDetils(bookingdtoobj);
                return StatusCode(StatusCodes.Status201Created, "booking Details Updated Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
    }
}


