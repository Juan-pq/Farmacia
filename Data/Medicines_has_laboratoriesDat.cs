using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Data
{
    public class Medicines_has_laboratoriesDat
    {

        Persistence objPer = new Persistence();

        //Metodo para mostrar Medicamentos_has_laboratorio
        public DataSet showMedicines_has_laboratories()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelecCmd = new MySqlCommand();
            objSelecCmd.Connection = objPer.openConnection();
            objSelecCmd.CommandText = "spSelectMedicines_has_laboratoriesDDLjoin";
            objSelecCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelecCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;

        }
        //Metodo para insertar Medicamentos_has_laboratorio
        public bool saveMedicines_has_laboratories(string _hora_creacion, int id_acciontera,
            int id_presentacion, int id_stock, int id_lab, int id_med)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelecCmd = new MySqlCommand();
            objSelecCmd.Connection = objPer.openConnection();
            objSelecCmd.CommandText = "spInsertMedicines_has_laboratories";
            objSelecCmd.CommandType = CommandType.StoredProcedure;
            objSelecCmd.Parameters.Add("p_hora_creacion", MySqlDbType.Int32).Value = _hora_creacion;
            objSelecCmd.Parameters.Add("p_medicamentos_accionterapeutica_acte_id", MySqlDbType.Int32).Value = id_acciontera;
            objSelecCmd.Parameters.Add("p_medicamentos_presentacion_pre_id", MySqlDbType.Int32).Value = id_presentacion;
            objSelecCmd.Parameters.Add("p_medicamentos_stock_stock_id", MySqlDbType.Int32).Value = id_stock;
            objSelecCmd.Parameters.Add("p_laboratorio_lab_id", MySqlDbType.Int32).Value = id_lab;
            objSelecCmd.Parameters.Add("p_medicamentos_med_id", MySqlDbType.Int32).Value = id_med;
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


        public bool updateMedicines_has_laboratories(int _medicamentos_med_id, string _hora_creacion, int id_acciontera, 
            int id_presentacion, int id_stock, int id_lab,int id_med)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelecCmd = new MySqlCommand();
            objSelecCmd.Connection = objPer.openConnection();
            objSelecCmd.CommandText = "spUpdateMedicines_has_laboratories";
            objSelecCmd.CommandType = CommandType.StoredProcedure;
            objSelecCmd.Parameters.Add("p_medlab_id", MySqlDbType.Int32).Value = _medicamentos_med_id;
            objSelecCmd.Parameters.Add("p_hora_creacion", MySqlDbType.Int32).Value = _hora_creacion;
            objSelecCmd.Parameters.Add("p_medicamentos_accionterapeutica_acte_id", MySqlDbType.Int32).Value = id_acciontera;
            objSelecCmd.Parameters.Add("p_medicamentos_presentacion_pre_id", MySqlDbType.Int32).Value = id_presentacion;
            objSelecCmd.Parameters.Add("p_medicamentos_stock_stock_id", MySqlDbType.Int32).Value = id_stock;
            objSelecCmd.Parameters.Add("p_laboratorio_lab_id", MySqlDbType.Int32).Value = id_lab;
            objSelecCmd.Parameters.Add("p_medicamentos_med_id", MySqlDbType.Int32).Value = id_med; 
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

        public bool deleteMedicines_has_laboratories(int _medicamentos_med_id)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelecCmd = new MySqlCommand();
            objSelecCmd.Connection = objPer.openConnection();
            objSelecCmd.CommandText = "spDeleteMedicines_has_laboratories";
            objSelecCmd.CommandType = CommandType.StoredProcedure;
            objSelecCmd.Parameters.Add("p_medicines_med_id", MySqlDbType.Int32).Value = _medicamentos_med_id;
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