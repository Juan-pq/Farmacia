using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class TherapeuticActionDat
    {
        Persistence objPer = new Persistence();

        public DataSet showTherapeuticAction()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelecCmd = new MySqlCommand();

            objSelecCmd.Connection = objPer.openConnection();

            objSelecCmd.CommandText = "spSelectTherapistAct";

            objSelecCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelecCmd;

            objAdapter.Fill(objData);

            objPer.closeConnection();

            return objData;

        }

        public bool saveTherapeuticAction(string _acte_name, string _acte_description)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelecCmd = new MySqlCommand();

            objSelecCmd.Connection = objPer.openConnection();

            objSelecCmd.CommandText = "spInsertTherapistAct";

            objSelecCmd.CommandType = CommandType.StoredProcedure;

            objSelecCmd.Parameters.Add("p_acte_name", MySqlDbType.VarString).Value = _acte_name;
            objSelecCmd.Parameters.Add("p_acte_description", MySqlDbType.Text).Value = _acte_description;

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

        public bool updateTherapeuticAction(int _acte_id, string _acte_name, string _acte_amount)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelecCmd = new MySqlCommand();

            objSelecCmd.Connection = objPer.openConnection();

            objSelecCmd.CommandText = "spUpdateTherapistAct";

            objSelecCmd.CommandType = CommandType.StoredProcedure;

            objSelecCmd.Parameters.Add("p_acte_id", MySqlDbType.Int32).Value = _acte_id;
            objSelecCmd.Parameters.Add("p_acte_name", MySqlDbType.VarString).Value = _acte_name;
            objSelecCmd.Parameters.Add("p_acte_description", MySqlDbType.VarString).Value = _acte_amount;


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

        public bool deleteTherapeuticAction(int _acte_id)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelecCmd = new MySqlCommand();

            objSelecCmd.Connection = objPer.openConnection();

            objSelecCmd.CommandText = "spDeleteTherapistAct";

            objSelecCmd.CommandType = CommandType.StoredProcedure;

            objSelecCmd.Parameters.Add("p_acte_id", MySqlDbType.Int32).Value = _acte_id;
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


        //procedimientos DDl

        public DataSet showTherapeuticActionDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelecCmd = new MySqlCommand();

            objSelecCmd.Connection = objPer.openConnection();

            objSelecCmd.CommandText = "spSelectTherapistActDDL";

            objSelecCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelecCmd;

            objAdapter.Fill(objData);

            objPer.closeConnection();

            return objData;

        }
    }
}