using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Data
{
    public class LaboratoryDat
    {

        Persistence objPer = new Persistence();

        public DataSet showLaboratory()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelecCmd = new MySqlCommand();
            objSelecCmd.Connection = objPer.openConnection();
            objSelecCmd.CommandText = "spSelectLaboratory";
            objSelecCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelecCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        public bool saveLaboratory(string _lab_nombre, string _lab_address, decimal _lab_phone)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelecCmd = new MySqlCommand();
            objSelecCmd.Connection = objPer.openConnection();
            objSelecCmd.CommandText = "spInserLaboratory";
            objSelecCmd.CommandType = CommandType.StoredProcedure;
            objSelecCmd.Parameters.Add("p_lab_name", MySqlDbType.VarString).Value = _lab_nombre;
            objSelecCmd.Parameters.Add("p_lab_address", MySqlDbType.VarString).Value = _lab_address;
            objSelecCmd.Parameters.Add("p_lab_phone", MySqlDbType.Decimal).Value = _lab_phone;

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

        public bool updateLaboratory(int _lab_id, string _lab_nombre, string _lab_address, decimal _lab_phone)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelecCmd = new MySqlCommand();
            objSelecCmd.Connection = objPer.openConnection();
            objSelecCmd.CommandText = "spUpdateLaboratory";
            objSelecCmd.CommandType = CommandType.StoredProcedure;
            objSelecCmd.Parameters.Add("p_lab_id", MySqlDbType.Int32).Value = _lab_id;
            objSelecCmd.Parameters.Add("p_lab_name", MySqlDbType.VarString).Value = _lab_nombre;
            objSelecCmd.Parameters.Add("p_lab_address", MySqlDbType.VarString).Value = _lab_address;
            objSelecCmd.Parameters.Add("p_lab_phone", MySqlDbType.Decimal).Value = _lab_phone;
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

        public bool deleteLaboratory(int _lab_id)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelecCmd = new MySqlCommand();
            objSelecCmd.Connection = objPer.openConnection();
            objSelecCmd.CommandText = "spDeleteLaboratory";
            objSelecCmd.CommandType = CommandType.StoredProcedure;
            objSelecCmd.Parameters.Add("p_lab_id", MySqlDbType.Int32).Value = _lab_id;
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

    }
}