using Tcs_BankOfAmerica_Loan.DTOS;
using Tcs_BankOfAmerica_Loan.Entities;

namespace Tcs_BankOfAmerica_Loan.interfaces
{
    public interface ICountriesService
    {
        Task<List<CountriesDto>> GetAllCountriesDetails();
    }
}
