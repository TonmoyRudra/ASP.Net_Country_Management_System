using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CountryAndCityAPP.DAL.Model;
using CountryAndCityAPP.DAL.Model.ViewModel;

namespace CountryAndCityAPP.DAL.Gateway
{
    public class CountryGateway:Gateway
    {
        public int SaveCountry(Country aCountry)
        {
            //Query = "INSERT INTO Countrys VALUES('" + aCountry.CountryName + "','" + aCountry.CountryAbout + "','"+0+"','"+0+"')";
            //Command = new SqlCommand(Query, Connection);

            //Connection.Open();

            //int rowAffected = Command.ExecuteNonQuery();
            //Connection.Close();

            //return rowAffected;

            Query = "INSERT INTO Countrys VALUES(@name, @about)";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Command.Parameters.AddWithValue("@name", aCountry.CountryName);
          
            Command.Parameters.AddWithValue("@about", aCountry.CountryAbout);
           


            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffected;

        }

        public List<Country> GetAllCountryData()
        {
            Query = "SELECT * FROM Countrys ORDER BY CountryName ASC";

            Command = new SqlCommand(Query, Connection);

            List<Country> countries = new List<Country>();

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Country aCountry = new Country();
                aCountry.Id = Convert.ToInt32(Reader["Id"]);
                aCountry.CountryName = Reader["CountryName"].ToString();
                aCountry.CountryAbout = Reader["CountryAbout"].ToString();

                countries.Add(aCountry);
            }

            Reader.Close();
            Connection.Close();

            return countries;
        }


        public bool IsCountryExist(string countryName)
        {
            Query = "SELECT * FROM Countrys WHERE CountryName = @CountryName";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();


            Command.Parameters.AddWithValue("@CountryName", countryName);
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



        public List<ViewCountriesViewModel> GetViewCountryListTotal(string countryName)
        {
            Query = "SELECT * FROM Countrys WHERE CountryName LIKE @data1";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@data1", "%" + countryName+ "%");
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ViewCountriesViewModel> countries = new List<ViewCountriesViewModel>();
            while (Reader.Read())
            {
                ViewCountriesViewModel aCountry = new ViewCountriesViewModel();
                aCountry.Id = Convert.ToInt32(Reader["Id"]);
                aCountry.CountryAbout = Reader["CountryAbout"].ToString();
                aCountry.CountryName = Reader["CountryName"].ToString();
                countries.Add(aCountry);
            }
            Reader.Close();
            Connection.Close();

            foreach (ViewCountriesViewModel aCountry in countries)
            {
                int id = aCountry.Id;
                Query = "SELECT COUNT(Citys.Id) AS TotalCities, SUM(Citys.NoOfDwellers) AS Dwellers FROM Citys WHERE CountryId = " + id;
                Command = new SqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    Reader.Read();
                    if (Reader["Dwellers"].GetType() != typeof(DBNull))
                        aCountry.TotalDwellers = Convert.ToInt64(Reader["Dwellers"]);
                    else
                    {
                        aCountry.TotalDwellers = 0;
                    }
                    //ViewCountiesUI.message = Reader["TotalCities"].ToString();
                    aCountry.TotalCity = Convert.ToInt32(Reader["TotalCities"]);
                }

                Reader.Close();
                Connection.Close();
            }

            return countries.OrderBy(o => o.CountryName).ToList();

           
        }

        //public List<Country> GetViewCountryListAll()
        //{
        //    Query = "SELECT CountryName, CountryAbout, TotalCities, TotalDwellers FROM Countrys";
        //    Command = new SqlCommand(Query, Connection);

        //    List<Country> countries = new List<Country>();

        //    Connection.Open();
        //    Reader = Command.ExecuteReader();
        //    while (Reader.Read())
        //    {
        //        Country aCountry = new Country();

        //        //aCountry.Id = Convert.ToInt32(Reader["Id"]);
        //        aCountry.CountryName = Reader["CountryName"].ToString();
        //        aCountry.CountryAbout = Reader["CountryAbout"].ToString();
               

        //        countries.Add(aCountry);
        //    }

        //    Reader.Close();
        //    Connection.Close();

        //    return countries.OrderBy(o => o.CountryName).ToList();
        //}
    }
}