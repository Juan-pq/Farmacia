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
    public partial class WFPresentacion : System.Web.UI.Page
    {
        PresentationLog objPre = new PresentationLog();
        //declaracion de variables aux para la tabla Presentacionn
        private int _id;
        private string _tipo;
        private int _cantidad;
        private decimal _preciounidad;
        private bool _executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            //showPresentacionDDL();
            showPresentacion();
            TBid.Visible = false;
        }


        //procedimiento para ver y seleccionar el nombre de un laboratorio desde DropDownList
        //private void showPresentacionDDL()
        //{
        //    DDLPresentacion.DataSource = objPre.showPresentationDDL();
        //    DDLPresentacion.DataValueField = "pre_id";
        //    DDLPresentacion.DataTextField = "pre_tipo";
        //    DDLPresentacion.DataBind();
        //    DDLPresentacion.Items.Insert(0, "Seleccione");
        //}


        //Procedimiento para limpiar cajas
        private void limpiarCajas()
        {
            TBTipo.Text = string.Empty;
            TBCantidad.Text = string.Empty;
            TBPreciounidad.Text = string.Empty;
        }


        //procedimiento para ver todos las PRESENTACIONES disponibles
        private void showPresentacion()
        {
            DataSet objData = new DataSet();
            objData = objPre.showPresentation();
            GVPresentacion.DataSource = objData;
            GVPresentacion.DataBind();
        }

        //procedimiento para guardar
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            _tipo = TBTipo.Text;
            _cantidad = Convert.ToInt32( TBCantidad.Text);
            _preciounidad = Convert.ToDecimal(TBPreciounidad.Text);

            _executed = objPre.savePresentation(_tipo, _cantidad, _preciounidad);
            if (_executed)
            {
                LblMsj.Text = "Se guardo exitosamente";
                this.showPresentacion();
                this.limpiarCajas();

            }
            else
            {
                LblMsj.Text = "Error al guardar";
            }
        }

        //procedimiento para Actualizar Presentacion
        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(TBid.Text);
            _tipo = TBTipo.Text;
            _cantidad = Convert.ToInt32(TBCantidad.Text);
            _preciounidad = Convert.ToDecimal(TBPreciounidad.Text);

            _executed = objPre.updatePresentation(_id, _tipo, _cantidad, _preciounidad);
            if (_executed)
            {
                LblMsj.Text = "Se actualizó exitosamente";
                this.showPresentacion();
            }
            else
            {
                LblMsj.Text = "Error al actualizar";
            }
        }

        //seleccion desde la GV de los Presentacion
        protected void GVPresentacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //nombres que apareceran en los campos de los registros seleccionados
            TBid.Text = GVPresentacion.SelectedRow.Cells[2].Text;
            TBTipo.Text = GVPresentacion.SelectedRow.Cells[3].Text;
            TBCantidad.Text = GVPresentacion.SelectedRow.Cells[4].Text;
            TBPreciounidad.Text = GVPresentacion.SelectedRow.Cells[5].Text;

        }

        //eliminacion desde la GV de los Presentacion
        protected void GVPresentacion_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _idPresentacion = int.Parse(GVPresentacion.Rows[e.RowIndex].Cells[2].Text);
            _executed = objPre.deletePresentation(_idPresentacion);

            if (_executed)
            {
                LblMsj.Text = " Presentacion eliminada exitosamente";
                GVPresentacion.EditIndex = 1;
                this.showPresentacion();
            }

            else
            {
                LblMsj.Text = "Error al eliminar la Presentacion";
            }

        }

        protected void GVPresentacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[3].Text = "Tipo";
                e.Row.Cells[4].Text = "Cantidad";
                e.Row.Cells[5].Text = "Precio unidad";

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Visible = false;

            }
        }
    }
}