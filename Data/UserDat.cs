using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Model;
using MySql.Data.MySqlClient;

namespace Data
{
    public class UserDat
    {

        Persistence objPer = new Persistence();

        public DataSet showUser()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelecCmd = new MySqlCommand();
            objSelecCmd.Connection = objPer.openConnection();
            objSelecCmd.CommandText = "spSelectUser";
            objSelecCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelecCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;

        }

        public bool saveUser(string _correo, String _contrasena, string _salt, string _estado)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelecCmd = new MySqlCommand();

            objSelecCmd.Connection = objPer.openConnection();

            objSelecCmd.CommandText = "spInsertUser";

            objSelecCmd.CommandType = CommandType.StoredProcedure;

            objSelecCmd.Parameters.Add("p_correo", MySqlDbType.VarString).Value = _correo;
            objSelecCmd.Parameters.Add("p_contrasena", MySqlDbType.Text).Value = _contrasena;
            objSelecCmd.Parameters.Add("p_salt", MySqlDbType.Text).Value = _salt;
            objSelecCmd.Parameters.Add("p_estado", MySqlDbType.VarString).Value = _estado;

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

        public bool updateUser(int _id, string _correo, string _contrasena, string _salt, string _estado)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelecCmd = new MySqlCommand();

            objSelecCmd.Connection = objPer.openConnection();

            objSelecCmd.CommandText = "spUpdateUser";

            objSelecCmd.CommandType = CommandType.StoredProcedure;

            objSelecCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = _id;
            objSelecCmd.Parameters.Add("p_correo", MySqlDbType.VarString).Value = _correo;
            objSelecCmd.Parameters.Add("p_contrasena", MySqlDbType.Text).Value = _contrasena;
            objSelecCmd.Parameters.Add("p_salt", MySqlDbType.Text).Value = _salt;
            objSelecCmd.Parameters.Add("p_estado", MySqlDbType.VarString).Value = _estado;
            

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

        //Metodo para mostrar el Usuarios por correo
        public User showUsersMail(string mail)
        {
            User objUser = null;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spSelectUsersMail";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_mail", MySqlDbType.VarString).Value = mail;
            MySqlDataReader reader = objSelectCmd.ExecuteReader();
            if (!reader.HasRows)
            {
                return objUser;
            }
            else
            {
                while (reader.Read())
                {
                    objUser = new User(reader["usu_correo"].ToString(), reader["usu_contrasena"].ToString(), reader["usu_salt"].ToString(), reader["usu_estado"].ToString());
                }
            }
            objPer.closeConnection();
            return objUser;
        }

        public bool deleteUser(int _id)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelecCmd = new MySqlCommand();

            objSelecCmd.Connection = objPer.openConnection();

            objSelecCmd.CommandText = "spDeleteUser";

            objSelecCmd.CommandType = CommandType.StoredProcedure;

            objSelecCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = _id;
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