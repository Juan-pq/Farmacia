using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Data
{
    public class Persistence
    {
        //Cadena de conexión
        MySqlConnection _connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);


        //Metodo para abrir la conexión
        public MySqlConnection openConnection()
        {
            try
            {
                _connection.Open(); //Abre la conexión 
                return _connection; //Retorna la conexión
            }
            catch (Exception e)
            {
                e.ToString(); //Para poder ver lo que paso en texto
                return null;
            }
        }

        //Metodo para cerrar la conexión
        public void closeConnection()
        {
            _connection.Close(); //Cierra la conexión
        }
    }
}