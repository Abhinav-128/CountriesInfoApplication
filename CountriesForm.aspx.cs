using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CountryInfo
{
    public partial class Countries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DataSet dsContinents = ReadDataSet("regions.xml");
                if(dsContinents!=null)
                {
                    ListingDropdown(Continents, dsContinents);
                }
                
                ListItem liContinents = new ListItem("Select Continent", "-1");
                Continents.Items.Insert(0, liContinents);

                ListItem liCountry = new ListItem("Select Country", "-1");
                Countries1.Items.Insert(0, liCountry);

                ListItem liCity = new ListItem("Select City", "-1");
                DropDownList3.Items.Insert(0, liCity);

                Countries1.Enabled = false;
                DropDownList3.Enabled = false;
                SearchCity.Enabled = false;
                DetailsView1.Visible = false;
                Label2.Visible = false;
                MoreInfo.Enabled = false;
                Run.Visible = false;
                CityInfo.Visible = false;
                lblCityInfo.Visible = false;
            }
        }
        protected DataSet ReadDataSet(string xmlFile)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath($"~/Files/{xmlFile}"));
            if(ds == null || ds.Tables.Count==0)
            {
                Response.Write("No data");
                return null;
            }
            return ds;
        }

        protected void ListingDropdown(DropDownList ddl,DataSet dt,string tableName = null, string dtFilter = null)
        {
            if(dt==null)
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("No data", "-1"));
                return;
            }
            DataTable dataTable;
            if (tableName != null && dtFilter != null)
            {
                dataTable = dt.Tables[tableName];
                DataView dv = dataTable.DefaultView;
                dv.RowFilter = dtFilter;
                ddl.DataSource = dv.ToTable();
                ddl.DataTextField = "name";
                ddl.DataValueField = "id";
                ddl.DataBind();
            }
            else
            {
                ddl.DataSource = dt;
                ddl.DataTextField = "name";
                ddl.DataValueField = "id";
                ddl.DataBind();
            }
        }
        protected void Run_Click(object sender, EventArgs e)
        {
            CityInfo.Visible = true;
            lblCityInfo.Visible = true;
            DataSet dsCities = Session["cities"] as DataSet;
            DataTable dt = dsCities.Tables["city"];
            DataView dv = dt.DefaultView;
            dv.RowFilter = $"id = {DropDownList3.SelectedValue}";
            CityInfo.DataSource = dv;
            CityInfo.DataBind();
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownList3.SelectedIndex==0)
            {
                Run.Visible = false;
                Run.Enabled = false;
            }
            else
            {
                Run.Visible = true;
                Run.Enabled = true;
            }
        }

        protected void Continents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Continents.SelectedIndex == 0)
            {
                Countries1.Enabled = false;
                DropDownList3.Enabled = false;
                SearchCity.Enabled = false;
                SearchCity.Text = string.Empty;
                SearchCity.Visible = false;
                DetailsView1.Visible = false;
                Label2.Visible = false;
                MoreInfo.Visible = false;
                Run.Visible = false;
                CityInfo.Visible = false;
            }
            else
            {

                Countries1.Enabled = true;
                MoreInfo.Visible = true; 
                DataSet dsCountries = ReadDataSet("countries.xml");
                if(dsCountries!=null)
                {
                    ListingDropdown(Countries1,dsCountries,"Country",$"region_id =  '{Continents.SelectedValue}'");
                }
                ListItem liCountry = new ListItem("Select Country", "-1");
                Countries1.Items.Insert(0, liCountry);
            }

        }

        protected void Countries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Countries1.SelectedIndex==0)
            {
                DropDownList3.Enabled = false;
                SearchCity.Enabled = false;
                SearchCity.Text = string.Empty;
                DetailsView1.Visible = false;
                Label2.Visible = false;
                MoreInfo.Visible = true;
                Run.Visible = false;
                CityInfo.Visible = false;
                lblCityInfo.Visible = false;
            }
            else
            {
                MoreInfo.Enabled = true;
                Response.Write("Reading cities.xml");
                DropDownList3.Enabled = true;
                SearchCity.Enabled = true;
                SearchCity.Visible = true;

                if (Session["cities"]==null)
                {
                    Session["cities"] = ReadDataSet("cities.xml");
                }

                DataSet dsCities = Session["cities"] as DataSet;
                if(dsCities!=null)
                {
                    ListingDropdown(DropDownList3, dsCities, "city", $"country_id = '{Countries1.SelectedValue}'");
                }
                ListItem liCity = new ListItem("Select City", "-1");
                DropDownList3.Items.Insert(0, liCity);

            }
        }

        protected void MoreInfo_Click(object sender, EventArgs e)
        {
            Label2.Visible = true;
            DetailsView1.Visible=true;

            DataSet dsCountries;

            if (Session["countries"]==null)
            {
                dsCountries = ReadDataSet("countries.xml");
                Session["countries"] = dsCountries;
            }
            else
            {
                dsCountries = Session["countries"] as DataSet;
            }

            DataTable dt = dsCountries.Tables["country"];

            DataView dv = dt.DefaultView;

            dv.RowFilter = $"id = '{Countries1.SelectedValue}'";
            DetailsView1.DataSource = dv;
            DetailsView1.DataBind();
        }

        protected void SearchCity_TextChanged(object sender, EventArgs e)
        {
            Run.Visible = true;
            Run.Enabled = true;
            DropDownList3.ClearSelection();
            foreach(ListItem item in DropDownList3.Items)
            {
                if(item.Text.Trim().ToLower().Contains(SearchCity.Text.Trim().ToLower()))
                {
                    item.Selected = true;
                    break;
                    
                }
            }
        }

        protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {

        }

        protected void CityInfo_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {

        }
    }
} 