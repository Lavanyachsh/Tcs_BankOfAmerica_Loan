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

        public async Task<bool> AddCountryDetails(CountriesDto countryDetail)
        {
            Countries obj = new Countries();
            obj.id= countryDetail.id;
            obj.countryName = countryDetail.countryName;
            

           await _countriesRepository.AddCountryDetails(obj);
            return true;
        }

        public async Task<bool> DeleteCountryDetilsById(int id)
        {
           await _countriesRepository.DeleteCountryDetilsById(id);
            return true;
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

        public async Task<CountriesDto> GetCountriesDetailsById(int id)
        {
            var countriesObj = await _countriesRepository.GetCountriesDetailsById(id);

            CountriesDto countriesdtoobj = new CountriesDto();
            countriesdtoobj.id = countriesObj.id;
            countriesdtoobj.countryName = countriesObj.countryName;            
            return countriesdtoobj;
        }

        public async Task<bool> UpdateCountryDetils(CountriesDto countryDetail)
        {
            Countries obj = new Countries();
            obj.id = countryDetail.id;
            obj.countryName = countryDetail.countryName;
           
           await _countriesRepository.UpdateCountryDetils(obj);
            return true;
        }
    }
}
