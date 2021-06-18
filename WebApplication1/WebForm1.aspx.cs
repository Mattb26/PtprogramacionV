﻿using Entidades;
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

            Mododesconectado();
        }
        protected void Mododesconectado()
        {
            //Modo desconectado
            //Data Table necesario para dejar los datos en memoria.
            DataTable dt = new DataTable();
            //Tomamos el ConnectionsString desde la configuracion del sitio.
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

            //Generamos una variable de Conexion
            SqlConnection Variable_Connection = new SqlConnection();
            //Le pasamos el connection string al Conection.
            Variable_Connection.ConnectionString = connectionString;

            //Generamos el SQL command que va a ser el commando a ejecutar en la base.
            SqlCommand Variable_Command = new SqlCommand();
            //Seteo el SQL a ejecutar.
            Variable_Command.CommandText = "select * from [Usuarios]";
            //Seteo la conexion al command
            Variable_Command.Connection = Variable_Connection;

            //Puedo hacer todo en una sola linea.
            //SqlCommand Variable_Command = new SqlCommand("select * from [Usuarios]", Variable_Connection);
            //Le explico que tipo es la ejecucion en la base de datos.
            Variable_Command.CommandType = CommandType.Text;

            //Genero un DataAdapter
            SqlDataAdapter sda = new SqlDataAdapter();
            //Seteo al DataAdapter el command.
            sda.SelectCommand = Variable_Command;

            //Lleno el DataTable para trabajar en memoria
            sda.Fill(dt);

            //Lleno el GridView Con la tabla en memmoria.
            GridView1.DataSource = dt;

            //Muestro los datos en la Grilla.
            GridView1.DataBind();
        }
        protected void ModoConectado()
        {
            //Modo Conectado
            //Data Table necesario para dejar los datos en memoria.
            DataTable dt = new DataTable();
            //Tomamos el ConnectionsString desde la configuracion del sitio.
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

            //Generamos una variable de Conexion
            SqlConnection Variable_Connection = new SqlConnection();
            //Le pasamos el connection string al Conection.
            Variable_Connection.ConnectionString = connectionString;

            //Generamos el SQL command que va a ser el commando a ejecutar en la base.
            SqlCommand Variable_Command = new SqlCommand();
            //Seteo el SQL a ejecutar.
            Variable_Command.CommandText = "select * from [Usuarios]";
            //Seteo la conexion al command
            Variable_Command.Connection = Variable_Connection;

            //Puedo hacer todo en una sola linea.
            //SqlCommand Variable_Command = new SqlCommand("select * from [Usuarios]", Variable_Connection);
            //Le explico que tipo es la ejecucion en la base de datos.
            Variable_Command.CommandType = CommandType.Text;

            //Abro la conexoin!
            Variable_Connection.Open();

            //Ejecuto el command para que me de un DATAREADER
            SqlDataReader variable_dataReader = Variable_Command.ExecuteReader();

            //Genero una lista de un objeto para devolverla al GridView.
            List<UserApp> lstU = new List<UserApp>();

            //Recorro mi data READER (FORWARDONLY, READONLY)
            while (variable_dataReader.Read())
            {
                UserApp u = new UserApp();
                u.Id = int.Parse(variable_dataReader["UserId"].ToString());
                u.UserName = variable_dataReader["UserName"].ToString();
                u.LastName = variable_dataReader["LastName"].ToString();
                u.BirthDate = DateTime.Parse(variable_dataReader["BirthDate"].ToString());

                lstU.Add(u);
            }

            //Cierro la conexion
            Variable_Connection.Close();

            //Le paso a la grilla la Lista generada con los campos.
            GridView1.DataSource = lstU;
            //Muestro los datos en la Grilla.
            GridView1.DataBind();
        }
    }
}