using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyTest.Entities;
using Newtonsoft.Json;

namespace MyTest
{
    public partial class _Default : Page
    {
        HttpClient httpClient = new HttpClient();
        List<Album> _albums = new List<Album>();

        void GetAlbums(bool Load = false)
        {
            string BaseURL;

            BaseURL = ConfigurationManager.AppSettings["API_Albums"];

            httpClient = new HttpClient();

            try
            {
                httpClient.BaseAddress = new Uri(@BaseURL);

                // Add an Accept header for JSON format.
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Formar cadena de busqueda
                string buscar = string.Empty;

                HttpResponseMessage response = httpClient.GetAsync(buscar).Result;

                if (!response.IsSuccessStatusCode)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Alert", "<script>alert('" + response.RequestMessage.ToString() + "');</script>", false);
                    httpClient.Dispose();
                    return;
                }

                //Recupero y valido el contenido del JSON
                _albums = new List<Album>();

                var contenido = response.Content.ReadAsStringAsync();
                _albums = JsonConvert.DeserializeObject<List<Album>>(contenido.Result);


                gdv_Album.DataSource = _albums;
                gdv_Album.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Alert", "<script>alert('" + ex.Message.ToString() + "');</script>", false);
            }
            finally
            {
                httpClient.Dispose();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAlbums(Load: true);
            }
        }

        protected void gdv_Album_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = gdv_Album.Rows[index];
                TableCell albumName = selectedRow.Cells[2];
                TableCell albumId = selectedRow.Cells[1];

                Response.Redirect("~/Pages/Photos.aspx?name=" + albumName.Text + "&Id=" + albumId.Text);
            }
        }
    }
}