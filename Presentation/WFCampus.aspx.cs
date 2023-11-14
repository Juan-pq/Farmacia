using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;

namespace Presentation
{
    public partial class WFCampu : System.Web.UI.Page
    {
        CampusLog objCamp = new CampusLog();
        private int _id;
        private string _nombre;
        private string _ciudad;
        private decimal _telefono;
        private string _direccion;
        private int _fkStock;
        private bool _executed;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showStockDDL();
                showCampus();
                TBid.Visible = false;
            }       
        }
        private void limpiarCajas()
        {
            TBNombre.Text = string.Empty;
            TBCiudad.Text = string.Empty;
            TBDireccion.Text = string.Empty;
            TBTelefono.Text = string.Empty;
            TBid.Text = string.Empty;
            DDLStock.SelectedIndex = 0;
        }
        private void showStockDDL()
        {
            DDLStock.DataSource = objCamp.showStockDDL();
            DDLStock.DataValueField = "stock_id";
            DDLStock.DataTextField = "stock_cantidad";
            DDLStock.DataBind();
            DDLStock.Items.Insert(0, "Seleccione");

        }
        private void showCampus()
        {
            DataSet objData = new DataSet();
            objData = objCamp.showCampus();
            GVCampu.DataSource = objData;
            GVCampu.DataBind();
        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            _nombre = TBNombre.Text;
            _ciudad = TBCiudad.Text;
            _telefono = Convert.ToDecimal(TBTelefono.Text);
            _direccion = TBDireccion.Text;
            _fkStock = Convert.ToInt32(DDLStock.SelectedValue);

            _executed = objCamp.saveCampus(_nombre, _ciudad, _telefono, _direccion, _fkStock);
            if (_executed)
            {
                LblMensaje.Text = "Se guardo exitosamente";
                showCampus();
                limpiarCajas();

            }
            else
            {
                LblMensaje.Text = "Error al guardar";
            }
        }
        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(TBid.Text);
            _nombre = TBNombre.Text;
            _ciudad = TBCiudad.Text;
            _telefono = Convert.ToDecimal(TBTelefono.Text);
            _direccion = TBDireccion.Text;
            _fkStock = Convert.ToInt32(DDLStock.SelectedValue);

            _executed = objCamp.updateCampus(_id, _nombre, _ciudad, _telefono, _direccion, _fkStock);
            if (_executed)
            {
                LblMensaje.Text = "Se actualizó exitosamente";
                showCampus();
            }
            else
            {
                LblMensaje.Text = "Error al actualizar";
            }
        }
        protected void GVCampu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //nombres que apareceran en los campos de los registros seleccionados
            TBid.Text = GVCampu.SelectedRow.Cells[2].Text;
            TBNombre.Text = GVCampu.SelectedRow.Cells[3].Text;
            TBCiudad.Text = GVCampu.SelectedRow.Cells[4].Text;
            TBTelefono.Text = GVCampu.SelectedRow.Cells[5].Text;
            TBDireccion.Text = GVCampu.SelectedRow.Cells[6].Text;
            DDLStock.SelectedValue = GVCampu.SelectedRow.Cells[7].Text;

        }
        protected void GVCampu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _idCampus = int.Parse(GVCampu.Rows[e.RowIndex].Cells[2].Text);
            _executed = objCamp.deleteCampus(_idCampus);

            if (_executed)
            {
                LblMensaje.Text = " sede eliminada exitosamente";
                GVCampu.EditIndex = 1;
                showCampus();
            }

            else
            {
                LblMensaje.Text = "Error al eliminar la sede";
            }

        }

        protected void GVCampu_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[3].Text = "Nombre";
                e.Row.Cells[4].Text = "Ciudad";
                e.Row.Cells[5].Text = "Telefono";
                e.Row.Cells[6].Text = "Direccion";

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[7].Visible = false;

            }

        }
    }
}