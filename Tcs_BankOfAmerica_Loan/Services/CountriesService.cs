using System.Collections.Generic;
using Tcs_BankOfAmerica_Loan.DTOS;
using Tcs_BankOfAmerica_Loan.Entities;
using Tcs_BankOfAmerica_Loan.interfaces;

namespace Tcs_BankOfAmerica_Loan.Services
{
    public class CountriesService : ICountriesService
    { 
        ICountriesRepository _countriesRepository;
        public CountriesService(ICountriesRepository countriesRepository)
        {
           this. _countriesRepository = countriesRepository;
        }
        public async Task<List<CountriesDto>> GetAllCountriesDetails()
        {//method body starts
            List<CountriesDto> objCountriesDto = new List<CountriesDto>();
          var result = await _countriesRepository.GetAllCountriesDetails();
            foreach (Countries countriesObj in result)
            {
                CountriesDto obj = new CountriesDto();
                obj.id = countriesObj.id;
                obj.countryName = countriesObj.countryName;
                objCountriesDto.Add(obj);
            }
            return objCountriesDto;
        }//method body ends here
    }
}
