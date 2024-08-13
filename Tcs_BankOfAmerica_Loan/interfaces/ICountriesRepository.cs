using Tcs_BankOfAmerica_Loan.Entities;

namespace Tcs_BankOfAmerica_Loan.interfaces
{
    public interface ICountriesRepository
    {
        Task<List<Countries>> GetAllCountriesDetails();
        Task<Countries> GetCountriesDetailsById(int id);
        Task<bool> AddCountryDetails(Countries countryDetail);
        Task<bool> UpdateCountryDetils(Countries countryDetail);
        Task<bool> DeleteCountryDetilsById(int id);
    }
}
