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
    public partial class WFStock : System.Web.UI.Page
    {
        StockLog objStock = new StockLog();
        //declaracion de variables aux para la tabla Accionterapeuta
        private int _id;
        private string _nombre;
        private int _cantidad;
        private bool _executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showStock();
                TBid.Visible = false;
            }
        }

        //Procedimiento para limpiar cajas
        private void limpiarCajas()
        {
            TBid.Text = string.Empty;
            
            TBCantidad.Text = string.Empty;
        }


        //procedimiento para ver todos los Accionterapeuta disponibles
        private void showStock()
        {
            DataSet objData = new DataSet();
            objData = objStock.showStock();
            GVStock.DataSource = objData;
            GVStock.DataBind();
        }

        //seleccion desde la GV de los Accionterapeuta
        protected void GVStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            //nombres que apareceran en los campos de los registros seleccionados
            TBid.Text = GVStock.SelectedRow.Cells[2].Text;
           
            TBCantidad.Text = GVStock.SelectedRow.Cells[4].Text;


        }


        //procedimiento para guardar Accionterapeuta
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {            
            _cantidad = Convert.ToInt32(TBCantidad.Text);

            _executed = objStock.saveStock(_nombre, _cantidad);
            if (_executed)
            {
                LblMsj.Text = "Se guardo exitosamente";
                this.showStock();
                this.limpiarCajas();

            }
            else
            {
                LblMsj.Text = "Error al guardar";
            }

        }

        //procedimiento para Actualizar Accionterapeuta
        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(TBid.Text);
           
            _cantidad = Convert.ToInt32(TBCantidad.Text);

            _executed = objStock.updateStock(_id, _nombre, _cantidad);
            if (_executed)
            {
                LblMsj.Text = "Se actualizó exitosamente";
                this.showStock();
            }
            else
            {
                LblMsj.Text = "Error al actualizar";
            }
        }

        //eliminar desde la GV para Eliminar un Accionterapeuta
        protected void GVStock_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _idLaboratorio = int.Parse(GVStock.Rows[e.RowIndex].Cells[2].Text);
            _executed = objStock.deleteStock(_idLaboratorio);

            if (_executed)
            {
                LblMsj.Text = " Stock eliminado exitosamente";
                GVStock.EditIndex = 1;
                this.showStock();
            }

            else
            {
                LblMsj.Text = "Error al eliminar Stock";
            }

        }


        protected void GVStock_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].Visible = false;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Visible = false;
            }
        }
    }
}