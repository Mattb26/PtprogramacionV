using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
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

        //Le paso a la grilla la Lista generada con los campos.
        //GridView1.DataSource = lstU;
        ////Muestro los datos en la Grilla.
        //GridView1.DataBind();
    }
}