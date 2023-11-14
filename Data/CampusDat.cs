using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class CampusDat
    {

        //
        Persistence objPer = new Persistence();

        //Metodo para mostrar todas las sedes
        public DataSet showCampus()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            //guarda las tablas dentro de ese elemento
            MySqlCommand objSelecCmd = new MySqlCommand();

            //abrir la conexiòn
            objSelecCmd.Connection = objPer.openConnection();

            //ya se puede indicarle que se va a ejecutar comandos
            objSelecCmd.CommandText = "spSelectCampus";

            //se especifica de que tipo es ese comando
            objSelecCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelecCmd;

            //para guardarlo
            objAdapter.Fill(objData);

            //se cierra la conexion
            objPer.closeConnection();

            return objData;

        }
        //StockDDL Sede
        public DataSet showStockDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            //guarda las tablas dentro de ese elemento
            MySqlCommand objSelecCmd = new MySqlCommand();

            //abrir la conexiòn
            objSelecCmd.Connection = objPer.openConnection();

            //ya se puede indicarle que se va a ejecutar comandos
            objSelecCmd.CommandText = "spSelectStockDDL";

            //se especifica de que tipo es ese comando
            objSelecCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelecCmd;

            //para guardarlo
            objAdapter.Fill(objData);

            //se cierra la conexion
            objPer.closeConnection();

            return objData;

        }
        //fin

        //Metodo para insertar una sedes
        public bool saveCampus( string _sed_name, string _sed_city, decimal _sed_phone , string _sed_address, int _stock_stock_id)
        {
            bool executed = false;
            int row;

            //guarda las tablas dentro de ese elemento
            MySqlCommand objSelecCmd = new MySqlCommand();

            //abrir la conexiòn
            objSelecCmd.Connection = objPer.openConnection();

            //ya se puede indicarle que se va a ejecutar comandos
            objSelecCmd.CommandText = "spInsertCampus";

            //se especifica de que tipo es ese comando
            objSelecCmd.CommandType = CommandType.StoredProcedure;

            //Add agrega el nombre del parametro y el tipo de dato
            objSelecCmd.Parameters.Add("e_sed_name", MySqlDbType.VarString).Value = _sed_name;
            objSelecCmd.Parameters.Add("e_sed_city", MySqlDbType.VarString).Value = _sed_city;
            objSelecCmd.Parameters.Add("e_sed_phone", MySqlDbType.Decimal).Value = _sed_phone;
            objSelecCmd.Parameters.Add("e_sed_address", MySqlDbType.VarString).Value = _sed_address;
            objSelecCmd.Parameters.Add("e_stock_stock_id", MySqlDbType.Int32).Value = _stock_stock_id;

            try
            {
                row = objSelecCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Error" + e.ToString());
            }

            //se cierra la conexion
            objPer.closeConnection();

            return executed;
        }

        //Metodo para actualizar una sede
        public bool updateCampus(int _id, string _nombre, string _ciudad, decimal _telefono, string _direccion, int _fkStock)
        {
            bool executed = false;
            int row;

            //guarda las tablas dentro de ese elemento
            MySqlCommand objSelecCmd = new MySqlCommand();

            //abrir la conexiòn
            objSelecCmd.Connection = objPer.openConnection();

            //ya se puede indicarle que se va a ejecutar comandos
            objSelecCmd.CommandText = "spUpdateCampus";

            //se especifica de que tipo es ese comando
            objSelecCmd.CommandType = CommandType.StoredProcedure;

            //Add agrega el nombre del parametro y el tipo de dato
            objSelecCmd.Parameters.Add("p_sed_id", MySqlDbType.Int32).Value = _id;
            objSelecCmd.Parameters.Add("p_sed_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelecCmd.Parameters.Add("p_sed_ciudad", MySqlDbType.VarString).Value = _ciudad;
            objSelecCmd.Parameters.Add("P_sed_telefono", MySqlDbType.Decimal).Value = _telefono;
            objSelecCmd.Parameters.Add("p_sed_address", MySqlDbType.VarString).Value = _direccion;
            objSelecCmd.Parameters.Add("p_stock_stock_id", MySqlDbType.Int32).Value = _fkStock;

            try
            {
                row = objSelecCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Error" + e.ToString());
            }

            //se cierra la conexion
            objPer.closeConnection();

            return executed;

        }

        //Metodo para eliminar una sede
        public bool deleteCampus(int _sed_id)
        {
            bool executed = false;
            int row;

            //guarda las tablas dentro de ese elemento
            MySqlCommand objSelecCmd = new MySqlCommand();

            //abrir la conexiòn
            objSelecCmd.Connection = objPer.openConnection();

            //ya se puede indicarle que se va a ejecutar comandos
            objSelecCmd.CommandText = "spDeleteCampus";

            //se especifica de que tipo es ese comando
            objSelecCmd.CommandType = CommandType.StoredProcedure;

            //Add agrega el nombre del parametro y el tipo de dato
            objSelecCmd.Parameters.Add("p_sed_id", MySqlDbType.Int32).Value = _sed_id;

            try
            {
                row = objSelecCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Error" + e.ToString());
            }

            //se cierra la conexion
            objPer.closeConnection();

            return executed;

        }


    }
}