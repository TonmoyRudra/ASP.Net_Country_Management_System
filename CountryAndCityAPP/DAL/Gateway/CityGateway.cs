using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CountryAndCityAPP.DAL.Model;
using CountryAndCityAPP.DAL.Model.ViewModel;

namespace CountryAndCityAPP.DAL.Gateway
{
    public class CityGateway : Gateway
    {
        public int SaveCity(City aCity)
        {

            //Query = "INSERT INTO Citys VALUES('" + aCity.CityName + "','" + aCity.CityAbout + "','" + aCity.NoOfDwellers + "','" + aCity.Location + "','" + aCity.Weather + "','" + aCity.CountryId + "')";
            Query = "INSERT INTO Citys VALUES(@CityName, @CityAbout, @Dwellers, @Location, @Weather, @CountryId)";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Command.Parameters.AddWithValue("@CityName", aCity.CityName);
            Command.Parameters.AddWithValue("@CityAbout", aCity.CityAbout);
            Command.Parameters.AddWithValue("@Dwellers", aCity.NoOfDwellers);
            Command.Parameters.AddWithValue("@Location", aCity.Location);
            Command.Parameters.AddWithValue("@Weather", aCity.Weather);
            Command.Parameters.AddWithValue("@CountryId", aCity.CountryId);

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            //UpdateTotalCityAndCountry(aCity);




            return rowAffected;

        }

        //public void UpdateTotalCityAndCountry(City aCity)
        //{
        //    //string query2 = "UPDATE Countrys SET TotalCities = TotalCities + '" + 1 + "', TotalDwellers = TotalDwellers +'" + aCity.NoOfDwellers + "' where Id = '" +
        //    //          aCity.CountryId + "'";

        //    //Command = new SqlCommand(query2, Connection);
        //    //Connection.Open();
        //    //Command.ExecuteNonQuery();

        //    //Connection.Close();


        //    Query = "UPDATE Countrys SET TotalCities = TotalCities + '" + 1 + "', TotalDwellers = TotalDwellers +@TotalDwellers where Id = @CountryID";

        //    Command = new SqlCommand(Query, Connection);
        //    Connection.Open();
        //    Command.Parameters.AddWithValue("@TotalDwellers", aCity.NoOfDwellers);
        //    Command.Parameters.AddWithValue("@CountryID", aCity.CountryId);

        //    Command.ExecuteNonQuery();

        //    Connection.Close();
        //}

        public bool IsCityExist(string cityName)
        {
            Query = "SELECT * FROM Citys WHERE CityName = @CityName";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Command.Parameters.AddWithValue("@CityName", cityName);

            Reader = Command.ExecuteReader();

            bool hasRow = false;

            if (Reader.HasRows)
            {
                hasRow = true;
            }

            Reader.Close();
            Connection.Close();

            return hasRow;
        }

        public List<CityListWithCountry> GetAllCityData()
        {
            Query = "SELECT * FROM CityListWithCountryName ORDER BY CityName ASC";

            Command = new SqlCommand(Query, Connection);

            List<CityListWithCountry> cityListWithCountries = new List<CityListWithCountry>();

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                CityListWithCountry aCityListWithCountry = new CityListWithCountry();

                aCityListWithCountry.CityName = Reader["CityName"].ToString();
                aCityListWithCountry.NoOfDwellers = Convert.ToInt64(Reader["NoOfDwellers"]);
                aCityListWithCountry.CountryName = Reader["CountryName"].ToString();

                cityListWithCountries.Add(aCityListWithCountry);
            }

            Reader.Close();
            Connection.Close();

            return cityListWithCountries;

        }

        public List<ViewCitiesAllListCityAndCountryWise> GetViewCitiesDataByCityName(string searchKey)
        {
            Query = "SELECT * FROM ViewCitiesAllListCityAndCountryWise WHERE CityName LIKE '%" + searchKey + "%'  ORDER BY CityName ASC";



            // Query = "SELECT Citys.CityName, Citys.CityAbout, Citys.NoOfDwellers, Citys.Location,Citys.Weather,Countrys.CountryName, Countrys.CountryAbout FROM Countrys JOIN Citys ON Countrys.Id = Citys.CountryId WHERE Citys.CityName = '"+searchKey+"' ";
            Command = new SqlCommand(Query, Connection);

            List<ViewCitiesAllListCityAndCountryWise> viewCitiesAllListCityAndCountryWises = new List<ViewCitiesAllListCityAndCountryWise>();

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ViewCitiesAllListCityAndCountryWise aViewCitiesAllListCityAndCountryWise = new ViewCitiesAllListCityAndCountryWise();

                aViewCitiesAllListCityAndCountryWise.CityName = Reader["CityName"].ToString();
                aViewCitiesAllListCityAndCountryWise.CityAbout = Reader["CityAbout"].ToString();
                aViewCitiesAllListCityAndCountryWise.NoOfDwellers = Convert.ToInt64(Reader["NoOfDwellers"]);
                aViewCitiesAllListCityAndCountryWise.Location = Reader["Location"].ToString();

                aViewCitiesAllListCityAndCountryWise.Weather = Reader["Weather"].ToString();
                aViewCitiesAllListCityAndCountryWise.CountryName = Reader["CountryName"].ToString();
                aViewCitiesAllListCityAndCountryWise.CountryAbout = Reader["CountryAbout"].ToString();

                viewCitiesAllListCityAndCountryWises.Add(aViewCitiesAllListCityAndCountryWise);
            }

            Reader.Close();
            Connection.Close();

            return viewCitiesAllListCityAndCountryWises;
        }

        public List<ViewCitiesAllListCityAndCountryWise> GetViewCitiesDataByCountryName(int searchCountryId)
        {
            Query = "SELECT Citys.CityName, Citys.CityAbout, Citys.NoOfDwellers, Citys.Location,Citys.Weather,Countrys.CountryName, Countrys.CountryAbout FROM Countrys JOIN Citys ON Countrys.Id = Citys.CountryId WHERE Countrys.Id = '" + searchCountryId + "'  ORDER BY CityName ASC";
            Command = new SqlCommand(Query, Connection);

            List<ViewCitiesAllListCityAndCountryWise> viewCitiesAllListCityAndCountryWises = new List<ViewCitiesAllListCityAndCountryWise>();

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ViewCitiesAllListCityAndCountryWise aViewCitiesAllListCityAndCountryWise = new ViewCitiesAllListCityAndCountryWise();

                aViewCitiesAllListCityAndCountryWise.CityName = Reader["CityName"].ToString();
                aViewCitiesAllListCityAndCountryWise.CityAbout = Reader["CityAbout"].ToString();
                aViewCitiesAllListCityAndCountryWise.NoOfDwellers = Convert.ToInt64(Reader["NoOfDwellers"]);
                aViewCitiesAllListCityAndCountryWise.Location = Reader["Location"].ToString();

                aViewCitiesAllListCityAndCountryWise.Weather = Reader["Weather"].ToString();
                aViewCitiesAllListCityAndCountryWise.CountryName = Reader["CountryName"].ToString();
                aViewCitiesAllListCityAndCountryWise.CountryAbout = Reader["CountryAbout"].ToString();

                viewCitiesAllListCityAndCountryWises.Add(aViewCitiesAllListCityAndCountryWise);
            }

            Reader.Close();
            Connection.Close();

            return viewCitiesAllListCityAndCountryWises;
        }

        public List<ViewCitiesAllListCityAndCountryWise> GetViewCitiesDataAll()
        {
            Query = "SELECT * FROM ViewCitiesAllListCityAndCountryWise ORDER BY CityName ASC";

            // Query = "SELECT Citys.CityName, Citys.CityAbout, Citys.NoOfDwellers, Citys.Location,Citys.Weather,Countrys.CountryName, Countrys.CountryAbout FROM Countrys JOIN Citys ON Countrys.Id = Citys.CountryId";
            Command = new SqlCommand(Query, Connection);

            List<ViewCitiesAllListCityAndCountryWise> viewCitiesAllListCityAndCountryWises = new List<ViewCitiesAllListCityAndCountryWise>();

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ViewCitiesAllListCityAndCountryWise aViewCitiesAllListCityAndCountryWise = new ViewCitiesAllListCityAndCountryWise();

                aViewCitiesAllListCityAndCountryWise.CityName = Reader["CityName"].ToString();
                aViewCitiesAllListCityAndCountryWise.CityAbout = Reader["CityAbout"].ToString();
                aViewCitiesAllListCityAndCountryWise.NoOfDwellers = Convert.ToInt64(Reader["NoOfDwellers"]);
                aViewCitiesAllListCityAndCountryWise.Location = Reader["Location"].ToString();

                aViewCitiesAllListCityAndCountryWise.Weather = Reader["Weather"].ToString();
                aViewCitiesAllListCityAndCountryWise.CountryName = Reader["CountryName"].ToString();
                aViewCitiesAllListCityAndCountryWise.CountryAbout = Reader["CountryAbout"].ToString();

                viewCitiesAllListCityAndCountryWises.Add(aViewCitiesAllListCityAndCountryWise);
            }

            Reader.Close();
            Connection.Close();

            return viewCitiesAllListCityAndCountryWises;
        }
    }
}