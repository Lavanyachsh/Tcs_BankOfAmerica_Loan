using System.Data;
using System.Data.SqlClient;//by using statement we can import namespace
using Tcs_BankOfAmerica_Loan.Entities;
using Tcs_BankOfAmerica_Loan.interfaces;
namespace Tcs_BankOfAmerica_Loan.Repositories
{
    public class CountriesRepository : ICountriesRepository
    {
        //windows authentication connection string
        string connectionString = "data source=DESKTOP-OLCB1UC; integrated security=yes; initial catalog=hotelmanagement";
        //sqlserver authentication connectionstring
        // string connectionString = "data source=DESKTOP-OLCB1UC; user id=sa; password=S@12345; initial catalog=hotelmanagement";

        public CountriesRepository() { }


        public async Task<List<Countries>> GetAllCountriesDetails()
        {
            List<Countries> lstcountries = new List<Countries>();
            //1. in sqlconnection object creation time we must pass the connectionString variable
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //2.open the connection here
                con.Open();
                //3.in sqlcommand object creation time we must pass the sqlquery/stored procedure along with sqlconnection object
                SqlCommand cmd = new SqlCommand("Usp_GetCountries", con);
                cmd.CommandType = CommandType.StoredProcedure;
               //to execute the storedprocedure and results stored in the sqldatareader object by using excutereaderasnc()
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();

                while (rdr.Read())
                {
                    Countries objCountries = new Countries();
                    objCountries.id = Convert.ToInt32(rdr["id"]);
                    objCountries.countryName = Convert.ToString(rdr["countryName"]);

                    //id int,countryName Usp_GetCountries
                    lstcountries.Add(objCountries);
                }
                con.Close();
            }
            return lstcountries;
        }
    }
}
