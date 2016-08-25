using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CountryAndCityAPP.DAL.Gateway;
using CountryAndCityAPP.DAL.Model;
using CountryAndCityAPP.DAL.Model.ViewModel;

namespace CountryAndCityAPP.BLL
{
    public class CityManager
    {
        CityGateway aCityGateway = new CityGateway();
        public string SaveCity(City aCity)
        {
            //if (aCity.CityName == "" || aCity.CityAbout == "" || aCity.NoOfDwellers == null || aCity.Location == "" || aCity.Weather == "")
            //{

            //    return "Please Fillup All Field";
            //}
            //else
            //{
                if (aCityGateway.IsCityExist(aCity.CityName))
                {
                    return "This City Already Exist In City List";
                }
                else
                {
                    
                        if (aCityGateway.SaveCity(aCity) > 0)
                            {
                                return "City Added Successfully";
                            }
                        else
                            {
                                return "City Save Failed";
                            }
                    
                         
                }
            //}
        }

        public List<CityListWithCountry>  GetAllCityData()
        {
            return aCityGateway.GetAllCityData();
        }

        public List<ViewCitiesAllListCityAndCountryWise> GetViewCitiesDataByCityName( string searchKey)
        {
            return aCityGateway.GetViewCitiesDataByCityName(searchKey);
        }

        public List<ViewCitiesAllListCityAndCountryWise> GetViewCitiesDataByCountryName(int searchCountryId)
        {
            return aCityGateway.GetViewCitiesDataByCountryName(searchCountryId);
        }

        public List<ViewCitiesAllListCityAndCountryWise> GetViewCitiesDataAll()
        {
            return aCityGateway.GetViewCitiesDataAll();
        }
    }
}