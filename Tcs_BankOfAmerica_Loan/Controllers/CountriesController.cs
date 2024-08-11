using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tcs_BankOfAmerica_Loan.interfaces;

namespace Tcs_BankOfAmerica_Loan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        ICountriesService _countriesService;
        public CountriesController(ICountriesService countriesService)
        { 
            this._countriesService = countriesService;
        }
        [HttpGet(Name ="GetCountries")]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var studentData = await _countriesService.GetAllCountriesDetails();
                //var employeeData = _EmployeeManager.GetAllEmployeeDetails();
                if (studentData != null)
                {
                    return StatusCode(StatusCodes.Status200OK, studentData);
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

        [HttpGet]
        [Route("currentdatetime")]//restful API method
        public string getdateandtime()
        {
            return DateTime.Now.ToString();
        }
    }
}
