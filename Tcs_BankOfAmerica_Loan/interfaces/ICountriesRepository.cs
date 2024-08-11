using Tcs_BankOfAmerica_Loan.Entities;

namespace Tcs_BankOfAmerica_Loan.interfaces
{
    public interface ICountriesRepository
    {
        Task<List<Countries>> GetAllCountriesDetails();
    }
}
