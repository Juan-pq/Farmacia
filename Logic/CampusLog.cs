using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;

namespace Logic
{
    public class CampusLog
    {
        CampusDat objCamp = new CampusDat();

        //Metodo para mostrar todas las sedes
        public DataSet showCampus()
        {            
            return objCamp.showCampus();
        }
        public DataSet showStockDDL()
        {
            return objCamp.showStockDDL();
        }

        //Metodo para insertar una sedes
        public bool saveCampus(string _nombre, string _ciudad, decimal _telefono, string _direccion, int _fkStock)
        {
            return objCamp.saveCampus(_nombre, _ciudad, _telefono, _direccion, _fkStock);
        }

        //Metodo para actualizar una sede
        public bool updateCampus(int _id, string _nombre, string _ciudad, decimal _telefono, string _direccion,int _fkStock)
        {
            return objCamp.updateCampus(_id,  _nombre,  _ciudad,  _telefono,  _direccion,  _fkStock);
        }

        //Metodo para eliminar una sede
        public bool deleteCampus(int _idCampus)
        {
            return objCamp.deleteCampus( _idCampus );
        }


    }
}