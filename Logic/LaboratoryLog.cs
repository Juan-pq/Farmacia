using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic
{
    public class LaboratoryLog
    {
        LaboratoryDat objLab = new LaboratoryDat();

        //Metodo para mostrar laboratorios
        public DataSet showLaboratory()
        {
            return objLab.showLaboratory();
        }

        //Metodo para insertar laboratorios
        public bool saveLaboratory(string _lab_nombre, string _lab_address, decimal _lab_phone)
        {
            return objLab.saveLaboratory(_lab_nombre, _lab_address, _lab_phone);
        }

        //Metodo para actualizar laboratorios
        public bool updateLaboratory(int _lab_id, string _lab_nombre, string _lab_address, decimal _lab_phone)
        {
            return objLab.updateLaboratory(_lab_id,_lab_nombre, _lab_address, _lab_phone);
        }

        //Metodo para eliminar laboratorios
        public bool deleteLaboratory(int _lab_id)
        {
            return objLab.deleteLaboratory(_lab_id);
        }



        //Metodo DDL para mostrar laboratorios
        public DataSet showLaboratoryDDL()
        {
            return objLab.showLaboratory();
        }
    }
}