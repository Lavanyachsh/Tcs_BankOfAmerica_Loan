using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tcs_BankOfAmerica_Loan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        [HttpGet]
        [Route("currentdatetime")]//restful API method
        public string getdateandtime()
        { 
            return DateTime.Now.ToString();
        }
        [HttpGet]
        [Route("sumcaluculations")]
        public int sumcaluculation(int a, int b)
        {
            return a + b;
        }
        [HttpGet("multiplication")]
       
        public int multiplication(int a, int b)
        {
           int res= addition(a, b);
            return res;
        }
        private int addition(int a, int b)
        {
            return a + b;
        }

    }
}
