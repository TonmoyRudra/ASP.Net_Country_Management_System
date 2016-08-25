using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CountryAndCityAPP.BLL;
using CountryAndCityAPP.DAL.Model;
using CountryAndCityAPP.DAL.Model.ViewModel;

namespace CountryAndCityAPP.UI
{
    public partial class ViewCountriesUI : System.Web.UI.Page
    {
        CountryManager aCountryManager = new CountryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewCountryAll();
                
            }
          
        }


      
        protected void searchButton_Click(object sender, EventArgs e)
        {
            if (countrySearchTextBox.Text != "")
            {
                ViewCountryTotalSearch();
                messageLabel.Text = String.Empty;
            }
            else
            {
                messageLabel.Text = "Enter A Country Name";
                ViewCountryAll();
            }
            



        }
        protected void viewCitiesGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            viewCountriesGridView.PageIndex = e.NewPageIndex;
            ViewCountryTotalSearch();

        }


        public void ViewCountryAll()
        {
            List<ViewCountriesViewModel> countries = aCountryManager.GetViewCountryListWithTotal("");
            viewCountriesGridView.DataSource = countries;
            viewCountriesGridView.DataBind();
        }

        public void ViewCountryTotalSearch()
        {
            string countryName = countrySearchTextBox.Text;

            List<ViewCountriesViewModel> countries = aCountryManager.GetViewCountryListWithTotal(countryName);
            viewCountriesGridView.DataSource = countries;
            viewCountriesGridView.DataBind();
        }
    }
}