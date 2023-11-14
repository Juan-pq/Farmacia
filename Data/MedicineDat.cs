using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class MedicineDat
    {
        //
        Persistence objPer = new Persistence();

        //Metodo para mostrar todos los medicamentos
        public DataSet showMedicine()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            //guarda las tablas dentro de ese elemento
            MySqlCommand objSelecCmd = new MySqlCommand();

            //abrir la conexiòn
            objSelecCmd.Connection = objPer.openConnection();

            //ya se puede indicarle que se va a ejecutar comandos
            objSelecCmd.CommandText = "spSelectMedicamentosDDLjoin";

            //se especifica de que tipo es ese comando
            objSelecCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelecCmd;

            //para guardarlo
            objAdapter.Fill(objData);

            //se cierra la conexion
            objPer.closeConnection();

            return objData;

        }

        //Metodo para insertar un medicamento
        public bool saveMedicine(string _nombre, decimal _precio, string _descripcion, string _composicion,
                                  string _precauciones, int _cantidad, int _fkAccionterapeuta, int _fkPresentacion, int _fkStock)
        {
            bool executed = false;
            int row;

            //guarda las tablas dentro de ese elemento
            MySqlCommand objSelecCmd = new MySqlCommand();

            //abrir la conexiòn
            objSelecCmd.Connection = objPer.openConnection();

            //ya se puede indicarle que se va a ejecutar comandos
            objSelecCmd.CommandText = "spInsertMedicine";

            //se especifica de que tipo es ese comando
            objSelecCmd.CommandType = CommandType.StoredProcedure;

            //Add agrega el nombre del parametro y el tipo de dato
            objSelecCmd.Parameters.Add("p_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelecCmd.Parameters.Add("p_precio", MySqlDbType.Decimal).Value = _precio;
            objSelecCmd.Parameters.Add("p_descripcion", MySqlDbType.Text).Value = _descripcion;
            objSelecCmd.Parameters.Add("p_composicion", MySqlDbType.VarString).Value = _composicion;
            objSelecCmd.Parameters.Add("p_precauciones", MySqlDbType.Text).Value = _precauciones;
            objSelecCmd.Parameters.Add("p_cantidad", MySqlDbType.Int32).Value = _cantidad;
            objSelecCmd.Parameters.Add("p_accionterapeutica_acte_id", MySqlDbType.Int32).Value = _fkAccionterapeuta;
            objSelecCmd.Parameters.Add("p_presentacion_pre_id", MySqlDbType.Int32).Value = _fkPresentacion;
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

        //Metodo para actualizar medicamento
        public bool updateMedicine(int _idMedicine, string _nombre, decimal _precio,
                                    string _descripcion, string _composicion, string _precauciones, int _cantidad,
                                    int _fkAccionterapeuta, int _fkPresentacion, int _fkStock)
        {
            bool executed = false;
            int row;

            //guarda las tablas dentro de ese elemento
            MySqlCommand objSelecCmd = new MySqlCommand();

            //abrir la conexiòn
            objSelecCmd.Connection = objPer.openConnection();

            //ya se puede indicarle que se va a ejecutar comandos
            objSelecCmd.CommandText = "spUpdateMedicines"; 

            //se especifica de que tipo es ese comando
            objSelecCmd.CommandType = CommandType.StoredProcedure;

            //Add agrega el nombre del parametro y el tipo de dato
            objSelecCmd.Parameters.Add("p_med_id", MySqlDbType.Int32).Value = _idMedicine;
            objSelecCmd.Parameters.Add("p_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelecCmd.Parameters.Add("p_precio", MySqlDbType.Decimal).Value = _precio;
            objSelecCmd.Parameters.Add("p_descripcion", MySqlDbType.Text).Value = _descripcion;
            objSelecCmd.Parameters.Add("p_composicion", MySqlDbType.VarString).Value = _composicion;
            objSelecCmd.Parameters.Add("p_precauciones", MySqlDbType.Text).Value = _precauciones;
            objSelecCmd.Parameters.Add("p_cantidad", MySqlDbType.Int32).Value = _cantidad;
            objSelecCmd.Parameters.Add("p_accionterapeutica_acte_id", MySqlDbType.Int32).Value = _fkAccionterapeuta;
            objSelecCmd.Parameters.Add("p_presentacion_pre_id", MySqlDbType.Int32).Value = _fkPresentacion;
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

        //Metodo para eliminar un medicamento
        public bool deleteMedicine(int _idMedicine)
        {
            bool executed = false;
            int row;

            //guarda las tablas dentro de ese elemento
            MySqlCommand objSelecCmd = new MySqlCommand();

            //abrir la conexiòn
            objSelecCmd.Connection = objPer.openConnection();

            //ya se puede indicarle que se va a ejecutar comandos
            objSelecCmd.CommandText = "spDeleteMedicines";

            //se especifica de que tipo es ese comando
            objSelecCmd.CommandType = CommandType.StoredProcedure;

            //Add agrega el nombre del parametro y el tipo de dato
            objSelecCmd.Parameters.Add("p_med_id", MySqlDbType.Int32).Value = _idMedicine;

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

        public DataSet showMedicineDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            //guarda las tablas dentro de ese elemento
            MySqlCommand objSelecCmd = new MySqlCommand();

            //abrir la conexiòn
            objSelecCmd.Connection = objPer.openConnection();

            //ya se puede indicarle que se va a ejecutar comandos
            objSelecCmd.CommandText = "spSelectMedicinesDDL";

            //se especifica de que tipo es ese comando
            objSelecCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelecCmd;

            //para guardarlo
            objAdapter.Fill(objData);

            //se cierra la conexion
            objPer.closeConnection();

            return objData;

        }

    }
}