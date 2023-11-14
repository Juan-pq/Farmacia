using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using Model;

namespace Logic

{
    public class UserLog
    {
        UserDat objUsu = new UserDat();
        public DataSet showUser()
        {
            return objUsu.showUser();
        }
        public bool saveUser(string _correo, String _contrasena, string _salt, string _estado)
        {
            return objUsu.saveUser(_correo, _contrasena, _salt, _estado);
        }
        public bool updateUser(int _id, string _correo, string _contrasena, string _salt, string _estado)
        {
            return objUsu.updateUser(_id, _correo, _contrasena, _salt, _estado);
        }

        //Metodo para mostrar el Usuarios pasandole el correo
        public User showUsersMail(string mail)
        {
            return objUsu.showUsersMail(mail);
        }
        public bool deleteUser(int _id)
        {
            return objUsu.deleteUser(_id);
        }

    }
}