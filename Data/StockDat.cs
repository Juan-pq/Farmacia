using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class StockDat
    {
        Persistence objPer = new Persistence();

        public DataSet showStock()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelecCmd = new MySqlCommand();

            objSelecCmd.Connection = objPer.openConnection();

            objSelecCmd.CommandText = "spSelectStock";

            objSelecCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelecCmd;

            objAdapter.Fill(objData);

            objPer.closeConnection();

            return objData;

        }

        public bool saveStock(string nombre,int cantidad_stock)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelecCmd = new MySqlCommand();

            objSelecCmd.Connection = objPer.openConnection();

            objSelecCmd.CommandText = "spInsertStock";

            objSelecCmd.CommandType = CommandType.StoredProcedure;

            objSelecCmd.Parameters.Add("p_stock_nombre", MySqlDbType.String).Value = nombre;
            objSelecCmd.Parameters.Add("p_stock_cantidad", MySqlDbType.Int32).Value = cantidad_stock;


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

            objPer.closeConnection();

            return executed;
        }

        public bool updateStock(int i_stock_id,string nombre, int i_stock_amount)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelecCmd = new MySqlCommand();

            objSelecCmd.Connection = objPer.openConnection();

            objSelecCmd.CommandText = "spUpdateStock";

            objSelecCmd.CommandType = CommandType.StoredProcedure;

            objSelecCmd.Parameters.Add("p_stock_id", MySqlDbType.Int32).Value = i_stock_id;
            objSelecCmd.Parameters.Add("p_stock_nombre", MySqlDbType.String).Value = nombre;
            objSelecCmd.Parameters.Add("p_stock_cantidad", MySqlDbType.Int32).Value = i_stock_amount;


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

            objPer.closeConnection();

            return executed;

        }

        public bool deleteStock(int i_id)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelecCmd = new MySqlCommand();

            objSelecCmd.Connection = objPer.openConnection();

            objSelecCmd.CommandText = "spDeleteStock";

            objSelecCmd.CommandType = CommandType.StoredProcedure;

            objSelecCmd.Parameters.Add("p_stock_id", MySqlDbType.Int32).Value = i_id;
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


            objPer.closeConnection();

            return executed;

        }

        public DataSet showStockDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelecCmd = new MySqlCommand();

            objSelecCmd.Connection = objPer.openConnection();

            objSelecCmd.CommandText = "spSelectStockDDL";

            objSelecCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelecCmd;

            objAdapter.Fill(objData);

            objPer.closeConnection();

            return objData;

        }
    }
}