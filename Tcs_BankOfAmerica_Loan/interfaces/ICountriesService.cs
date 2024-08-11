using Tcs_BankOfAmerica_Loan.DTOS;
using Tcs_BankOfAmerica_Loan.Entities;

namespace Tcs_BankOfAmerica_Loan.interfaces
{
    public interface ICountriesService
    {
        Task<List<CountriesDto>> GetAllCountriesDetails();
        Task<CountriesDto> GetCountriesDetailsById(int id);
        Task<bool> AddCountryDetails(CountriesDto countryDetail);
        Task<bool> UpdateCountryDetils(CountriesDto countryDetail);
        Task<bool> DeleteCountryDetilsById(int id);
    }
}
