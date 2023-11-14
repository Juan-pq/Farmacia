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
    public class MedicineLog
    {
        MedicineDat objMed = new MedicineDat();

        //Metodo para mostrar todos los medicamentos
        public DataSet showMedicine()
        {           
            return objMed.showMedicine();
        }

        //Metodo para insertar un medicamento
        public bool saveMedicine(string _nombre, decimal _precio, string _descripcion, string _composicion,
                                  string _precauciones, int _cantidad, int _fkAccionterapeuta, int _fkPresentacion, int _fkStock)
        {
            return objMed.saveMedicine( _nombre,  _precio,  _descripcion,  _composicion,
                                   _precauciones, _cantidad,  _fkAccionterapeuta,  _fkPresentacion,  _fkStock);
        }

        //Metodo para actualizar medicamento
        public bool updateMedicine(int _idMedicine, string _nombre, decimal _precio,
                                    string _descripcion, string _composicion, string _precauciones, int _cantidad,
                                    int _fkAccionterapeuta, int _fkPresentacion, int _fkStock)
        {
            return objMed.updateMedicine(_idMedicine, _nombre, _precio,
                                     _descripcion, _composicion, _precauciones, _cantidad,
                                     _fkAccionterapeuta, _fkPresentacion, _fkStock);
        }

        //Metodo para eliminar un medicamento
        public bool deleteMedicine(int _idMedicine)
        {
            return objMed.deleteMedicine( _idMedicine);
        }

        //MetodoDDL
        public DataSet showMedicineDDL()
        {
            return objMed.showMedicineDDL();
        }


    }
}