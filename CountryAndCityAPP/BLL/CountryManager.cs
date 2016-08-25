using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CountryAndCityAPP.DAL.Gateway;
using CountryAndCityAPP.DAL.Model;
using CountryAndCityAPP.DAL.Model.ViewModel;

namespace CountryAndCityAPP.BLL
{
    public class CountryManager
    {
        CountryGateway aCountryGateway = new CountryGateway();
        public string SaveCountry(Country aCountry)
        {
            
                if (aCountryGateway.IsCountryExist(aCountry.CountryName))
                {
                    return "Country Name Already Exist In Country List";
                }
                else
                {
                    if (aCountryGateway.SaveCountry(aCountry) > 0)
                    {
                        return "Country Added Successfully";
                    }
                    else
                    {
                        return "Country Added Failed";
                    }
                }
            
           

           
        }

        public List<Country> GetAllCountryData()
        {
            return aCountryGateway.GetAllCountryData();
        }

        public List<Country> GetCountryName()
        {
            return aCountryGateway.GetAllCountryData();
        }

        //public void UpdateTotalCityAndDwellers(City aCity)
        //{
        //     aCountryGateway.UpdateTotalCityAndDwellers(aCity);
        //}

        public List<ViewCountriesViewModel> GetViewCountryListWithTotal(string countryName)
        {
            return aCountryGateway.GetViewCountryListTotal(countryName);
        }

       
    }
}