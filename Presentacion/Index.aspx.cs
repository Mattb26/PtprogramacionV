using System;

namespace WebApplication1
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Negocio.Conectado conectado = new Negocio.Conectado();
            //Muestro los datos en la Grilla.
            GridView1.DataSource = conectado.Mododesconectado();
            GridView1.DataBind();


            GridView2.DataSource = conectado.ModoConectado();
            GridView2.DataBind();
        }
    }
}