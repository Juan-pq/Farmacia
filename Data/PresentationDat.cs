using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Data
{
    public class PresentationDat
    {
        Persistence objPer = new Persistence();
        public DataSet showPresentation()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spSelectPresentation";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        public bool savePresentation(string _tipo, int _cantidad, decimal _preciounidad)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelecCmd = new MySqlCommand();

            objSelecCmd.Connection = objPer.openConnection();

            objSelecCmd.CommandText = "spInsertPresentation";

            objSelecCmd.CommandType = CommandType.StoredProcedure;

            objSelecCmd.Parameters.Add("p_tipe", MySqlDbType.VarString).Value = _tipo;
            objSelecCmd.Parameters.Add("p_amount", MySqlDbType.Int32).Value = _cantidad;
            objSelecCmd.Parameters.Add("p_unitPrice", MySqlDbType.Decimal).Value = _preciounidad;

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
        public bool updatePresentation(int _id, string _tipo,int _cantidad, decimal _preciounidad)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spUpdatePresentation";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_pre_id", MySqlDbType.Int32).Value = _id;
            objSelectCmd.Parameters.Add("p_pre_type", MySqlDbType.VarString).Value = _tipo;
            objSelectCmd.Parameters.Add("p_pre_amount", MySqlDbType.Int32).Value = _cantidad;
            objSelectCmd.Parameters.Add("p_pre_unitPrice", MySqlDbType.Decimal).Value = _preciounidad;
            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());

            }

            objPer.closeConnection();
            return executed;
        }
        public bool deletePresentation(int _pre_id)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelecCmd = new MySqlCommand();

            objSelecCmd.Connection = objPer.openConnection();

            objSelecCmd.CommandText = "spDeletePresentation";

            objSelecCmd.CommandType = CommandType.StoredProcedure;

            objSelecCmd.Parameters.Add("p_pre_id", MySqlDbType.Int32).Value = _pre_id;

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


        //metodos DDL
        public DataSet showPresentationDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spSelectPresentationDDL";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }
    }
}



