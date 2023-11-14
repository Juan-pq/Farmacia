using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic
{
    public class Medicines_has_laboratoriesLog
    {
        Medicines_has_laboratoriesDat objMed_has_lab = new Medicines_has_laboratoriesDat();

        //Metodo para mostrar Medicamentos_has_laboratorios
        public DataSet showMedicines_has_laboratories()
        {
            return objMed_has_lab.showMedicines_has_laboratories();

        }

        //Metodo para insertar Medicamentos_has_laboratorios
        public bool saveMedicines_has_laboratories( string _hora_creacion, int id_acciontera, int id_presentacion, int id_stock, int id_lab, int id_med)
        {
            return objMed_has_lab.saveMedicines_has_laboratories( _hora_creacion, id_acciontera, id_presentacion, id_stock, id_lab, id_med);
        }

        //Metodo para actualizar Medicamentos_has_laboratorios
        public bool updateMedicines_has_laboratories(int _medicamentos_med_id,  string _hora_creacion,int id_acciontera,int id_presentacion,int id_stock,int id_lab,int id_med)
        {
            return objMed_has_lab.updateMedicines_has_laboratories(_medicamentos_med_id, _hora_creacion, id_acciontera, id_presentacion, id_stock, id_lab, id_med);
        }

        //Metodo para eliminar Medicamentos_has_laboratorios
        public bool deleteMedicines_has_laboratories(int _medicamentos_med_id)
        {
            return objMed_has_lab.deleteMedicines_has_laboratories(_medicamentos_med_id);
        }
    }
}