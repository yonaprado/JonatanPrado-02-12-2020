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
    public partial class Photos : Page
    {
        HttpClient httpClient = new HttpClient();
        List<Photo> _photos = new List<Photo>();
        List<Comment> _comments = new List<Comment>();

        void GetPhotos(bool Load = false)
        {
            string BaseURL;

            BaseURL = ConfigurationManager.AppSettings["API_Photos"];

            httpClient = new HttpClient();

            try
            {
                httpClient.BaseAddress = new Uri(@BaseURL);

                // Add an Accept header for JSON format.
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Formar cadena de busqueda
                string buscar = string.Empty;
                buscar = "?albumId=" + Request.QueryString["Id"].ToString();

                HttpResponseMessage response = httpClient.GetAsync(buscar).Result;

                if (!response.IsSuccessStatusCode)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Alert", "<script>alert('" + response.RequestMessage.ToString() + "');</script>", false);
                    httpClient.Dispose();
                    return;
                }

                //Recupero y valido el contenido del JSON
                _photos = new List<Photo>();

                var contenido = response.Content.ReadAsStringAsync();
                _photos = JsonConvert.DeserializeObject<List<Photo>>(contenido.Result);


                gdv_Photos.DataSource = _photos;
                gdv_Photos.DataBind();
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

        void GetComments(string photoId)
        {
            string BaseURL;
            gdv_Comments.DataSource = null;

            BaseURL = ConfigurationManager.AppSettings["API_Comments"];

            httpClient = new HttpClient();

            try
            {
                httpClient.BaseAddress = new Uri(@BaseURL);

                // Add an Accept header for JSON format.
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Formar cadena de busqueda
                string buscar = string.Empty;
                buscar = "?postId=" + photoId;

                HttpResponseMessage response = httpClient.GetAsync(buscar).Result;

                if (!response.IsSuccessStatusCode)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Alert", "<script>alert('" + response.RequestMessage.ToString() + "');</script>", false);
                    httpClient.Dispose();
                    return;
                }

                //Recupero y valido el contenido del JSON
                _comments = new List<Comment>();

                var contenido = response.Content.ReadAsStringAsync();
                _comments = JsonConvert.DeserializeObject<List<Comment>>(contenido.Result);

                gdv_Comments.DataSource = _comments;
                gdv_Comments.DataBind();
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
                string name = Request.QueryString["name"].ToString();
                lbl_Titulo.Text = "Album: " + name;
                GetPhotos(Load: true);
            }
        }

        protected void gdv_Photos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = gdv_Photos.Rows[index];
                TableCell photoId = selectedRow.Cells[1];

                GetComments(photoId.Text);
            }
        }
    }
}