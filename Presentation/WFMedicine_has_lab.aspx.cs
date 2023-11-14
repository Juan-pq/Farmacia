using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFMedicine_has_lab : System.Web.UI.Page
    {
        Medicines_has_laboratoriesLog objMedHas = new Medicines_has_laboratoriesLog();
        MedicineLog objMed = new MedicineLog();
        TherapeuticActionLog objThera = new TherapeuticActionLog();
        PresentationLog objPre = new PresentationLog();
        StockLog objStock = new StockLog();
        LaboratoryLog objLab = new LaboratoryLog();

        private int _idMedicine;
        private string _time;
        private int _fkAccionterapeuta;
        private int _fkPresentacion;
        private int _fkStock;
        private int _fkmedic;
        private int _fklab;

        private bool _executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showMedicinesHasLab();
                showTherapeuticactionDDL();
                showPresentationDDL();
                showStockDDL();
                showLaboratorioDDL();
                showMedicamentoDDL();
                TBid.Visible = false;
            }

        }
        private void showTherapeuticactionDDL()
        {
            DDLTherapeuticaction.DataSource = objThera.showTherapeuticActionDDL();
            DDLTherapeuticaction.DataValueField = "acte_id";
            DDLTherapeuticaction.DataTextField = "acte_nombre";
            DDLTherapeuticaction.DataBind();
            DDLTherapeuticaction.Items.Insert(0, "Seleccione");
        }
        private void showPresentationDDL()
        {
            DDLPresentation.DataSource = objPre.showPresentationDDL();
            DDLPresentation.DataValueField = "pre_id";
            DDLPresentation.DataTextField = "pre_tipo";
            DDLPresentation.DataBind();
            DDLPresentation.Items.Insert(0, "Seleccione");
        }
        private void showStockDDL()
        {
            DDLStock.DataSource = objStock.showStockDDL();
            DDLStock.DataValueField = "stock_id";
            DDLStock.DataTextField = "stock_cantidad";
            DDLStock.DataBind();
            DDLStock.Items.Insert(0, "Seleccione");
        }

        private void showLaboratorioDDL()
        {
            DDLLaboratorio.DataSource = objLab.showLaboratoryDDL();
            DDLLaboratorio.DataValueField = "lab_id";
            DDLLaboratorio.DataTextField = "lab_nombre";
            DDLLaboratorio.DataBind();
            DDLLaboratorio.Items.Insert(0, "Seleccione");
        }
        private void showMedicamentoDDL()
        {
            DDLMedicamentos.DataSource = objMed.showMedicineDDL();
            DDLMedicamentos.DataValueField = "med_id";
            DDLMedicamentos.DataTextField = "med_nombre";
            DDLMedicamentos.DataBind();
            DDLMedicamentos.Items.Insert(0, "Seleccione");
        }

        private void limpiarCajas()
        {
            TBHoracreacion.Text = string.Empty;          
            DDLTherapeuticaction.SelectedIndex = 0;
            DDLPresentation.SelectedIndex = 0;
            DDLStock.SelectedIndex = 0;
            DDLLaboratorio.SelectedIndex = 0;
            DDLMedicamentos.SelectedIndex = 0;
        }
        private void showMedicinesHasLab()
        {
            DataSet objData = new DataSet();
            objData = objMedHas.showMedicines_has_laboratories();
            GVMedicamentosHasLab.DataSource = objData;
            GVMedicamentosHasLab.DataBind();
        }

        protected void GVMedicamentosHasLab_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            


            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[3].Text = "Hora";
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[8].Visible = false;

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[8].Visible = false;

            }
        }

        protected void GVMedicamentosHasLab_SelectedIndexChanged(object sender, EventArgs e)
        {
            //nombres que apareceran en los campos de los registros seleccionados
            TBid.Text = GVMedicamentosHasLab.SelectedRow.Cells[2].Text;
            TBHoracreacion.Text = GVMedicamentosHasLab.SelectedRow.Cells[3].Text;
            DDLTherapeuticaction.Text = GVMedicamentosHasLab.SelectedRow.Cells[4].Text;
            DDLPresentation.Text = GVMedicamentosHasLab.SelectedRow.Cells[5].Text;
            DDLStock.Text = GVMedicamentosHasLab.SelectedRow.Cells[6].Text;
            DDLLaboratorio.Text = GVMedicamentosHasLab.SelectedRow.Cells[7].Text;
            DDLMedicamentos.Text = GVMedicamentosHasLab.SelectedRow.Cells[8].Text;
        }

        protected void GVMedicamentosHasLab_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _idMedicine = int.Parse(GVMedicamentosHasLab.Rows[e.RowIndex].Cells[2].Text);
            _executed = objMedHas.deleteMedicines_has_laboratories(_idMedicine);

            if (_executed)
            {
                LblMensaje.Text = " MedicamentoHasLab eliminado exitosamente";
                GVMedicamentosHasLab.EditIndex = 1;
                showMedicinesHasLab();
            }

            else
            {
                LblMensaje.Text = "Error al eliminar el MedicamentoHasLab";
            }
        }

        protected void BtnGuardar_Click1(object sender, EventArgs e)
        {
           
            _time = TBHoracreacion.Text;
            _fkAccionterapeuta = Convert.ToInt32(DDLTherapeuticaction.SelectedValue);
            _fkPresentacion = Convert.ToInt32(DDLPresentation.SelectedValue);
            _fkStock = Convert.ToInt32(DDLStock.SelectedValue);
            _fklab = Convert.ToInt32(DDLLaboratorio.SelectedValue);
            _fkmedic = Convert.ToInt32(DDLMedicamentos.SelectedValue);

            _executed = objMedHas.saveMedicines_has_laboratories(_time, _fkAccionterapeuta, _fkPresentacion, _fkStock, _fklab, _fkmedic);
            if (_executed)
            {
                LblMensaje.Text = "Se guardo exitosamente";
                this.showMedicinesHasLab();
                this.limpiarCajas();

            }
            else
            {
                LblMensaje.Text = "Error al guardar";
            }
        }

        protected void BtnActualizar_Click1(object sender, EventArgs e)
        {
            _idMedicine = Convert.ToInt32(TBid.Text);
            _time = TBHoracreacion.Text;
            _fkAccionterapeuta = Convert.ToInt32(DDLTherapeuticaction.SelectedValue);
            _fkPresentacion = Convert.ToInt32(DDLPresentation.SelectedValue);
            _fkStock = Convert.ToInt32(DDLStock.SelectedValue);
            _fklab = Convert.ToInt32(DDLLaboratorio.SelectedValue);
            _fkmedic = Convert.ToInt32(DDLMedicamentos.SelectedValue);




            _executed = objMedHas.updateMedicines_has_laboratories(_idMedicine, _time, _fkAccionterapeuta, _fkPresentacion, _fkStock, _fklab, _fkmedic);
            if (_executed)
            {
                LblMensaje.Text = "Se actualizó exitosamente";
                this.showMedicinesHasLab();
            }
            else
            {
                LblMensaje.Text = "Error al actualizar";
            }
        }

        
    }
}