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
    public partial class WFMedicineUsu : System.Web.UI.Page
    {
        MedicineLog objMed = new MedicineLog();
        TherapeuticActionLog objThera = new TherapeuticActionLog();
        PresentationLog objPre = new PresentationLog();
        StockLog objStock = new StockLog();

        private int _idMedicine;
        private string _nombre;
        private decimal _precio;
        private string _descripcion;
        private string _composicion;
        private string _precauciones;
        private int _cantidad;
        private int _fkAccionterapeuta;
        private int _fkPresentacion;
        private int _fkStock;

        private bool _executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showMedicines();
                showTherapeuticactionDDL();
                showPresentationDDL();
                showStockDDL();
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

        private void limpiarCajas()
        {
            TBNombre.Text = string.Empty;
            TBPrecio.Text = string.Empty;
            TBDescripcion.Text = string.Empty;
            TBComposicion.Text = string.Empty;
            TBPrecauciones.Text = string.Empty;
            TBCantidad.Text = string.Empty;
            DDLTherapeuticaction.SelectedIndex = 0;
            DDLPresentation.SelectedIndex = 0;
            DDLStock.SelectedIndex = 0;
        }
        private void showMedicines()
        {
            DataSet objData = new DataSet();
            objData = objMed.showMedicine();
            GVMedicamentos.DataSource = objData;
            GVMedicamentos.DataBind();
        }



        protected void GVMedicamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //nombres que apareceran en los campos de los registros seleccionados
            TBid.Text = GVMedicamentos.SelectedRow.Cells[2].Text;
            TBNombre.Text = GVMedicamentos.SelectedRow.Cells[3].Text;
            TBPrecio.Text = GVMedicamentos.SelectedRow.Cells[4].Text;
            TBDescripcion.Text = GVMedicamentos.SelectedRow.Cells[5].Text;
            TBComposicion.Text = GVMedicamentos.SelectedRow.Cells[6].Text;
            TBPrecauciones.Text = GVMedicamentos.SelectedRow.Cells[7].Text;
            TBCantidad.Text = GVMedicamentos.SelectedRow.Cells[8].Text;
            DDLTherapeuticaction.Text = GVMedicamentos.SelectedRow.Cells[9].Text;
            DDLPresentation.Text = GVMedicamentos.SelectedRow.Cells[11].Text;
            DDLStock.Text = GVMedicamentos.SelectedRow.Cells[13].Text;

        }

        //eliminacion desde la GV de los Presentacion
        protected void GVMedicamentos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _idMedicine = int.Parse(GVMedicamentos.Rows[e.RowIndex].Cells[2].Text);
            _executed = objMed.deleteMedicine(_idMedicine);

            if (_executed)
            {
                LblMensaje.Text = " Medicamento eliminado exitosamente";
                GVMedicamentos.EditIndex = 1;
                this.showMedicines();
            }

            else
            {
                LblMensaje.Text = "Error al eliminar el Medicamento";
            }

        }

        protected void BtnGuardar_Click1(object sender, EventArgs e)
        {
            _nombre = TBNombre.Text;
            _precio = Convert.ToDecimal(TBPrecio.Text);
            _descripcion = TBDescripcion.Text;
            _composicion = TBComposicion.Text;
            _precauciones = TBPrecauciones.Text;
            _cantidad = Convert.ToInt32(TBCantidad.Text);
            _fkAccionterapeuta = Convert.ToInt32(DDLTherapeuticaction.SelectedValue);
            _fkPresentacion = Convert.ToInt32(DDLPresentation.SelectedValue);
            _fkStock = Convert.ToInt32(DDLStock.SelectedValue);

            _executed = objMed.saveMedicine(_nombre, _precio, _descripcion, _composicion,
                                   _precauciones, _cantidad, _fkAccionterapeuta, _fkPresentacion, _fkStock);
            if (_executed)
            {
                LblMensaje.Text = "Se guardo exitosamente";
                this.showMedicines();
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
            _nombre = TBNombre.Text;
            _precio = Convert.ToDecimal(TBPrecio.Text);
            _descripcion = TBDescripcion.Text;
            _composicion = TBComposicion.Text;
            _precauciones = TBPrecauciones.Text;
            _cantidad = Convert.ToInt32(TBCantidad.Text);
            _fkAccionterapeuta = Convert.ToInt32(DDLTherapeuticaction.SelectedValue);
            _fkPresentacion = Convert.ToInt32(DDLPresentation.SelectedValue);
            _fkStock = Convert.ToInt32(DDLStock.SelectedValue);


            _executed = objMed.updateMedicine(_idMedicine, _nombre, _precio, _descripcion, _composicion,
                               _precauciones, _cantidad, _fkAccionterapeuta, _fkPresentacion, _fkStock);
            if (_executed)
            {
                LblMensaje.Text = "Se actualizó exitosamente";
                this.showMedicines();
            }
            else
            {
                LblMensaje.Text = "Error al actualizar";
            }
        }

        protected void GVMedicamentos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[11].Visible = false;
                e.Row.Cells[13].Visible = false;

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[11].Visible = false;
                e.Row.Cells[13].Visible = false;

            }
        }
    }
}