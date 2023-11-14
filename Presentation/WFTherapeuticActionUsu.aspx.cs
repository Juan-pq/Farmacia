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
    public partial class WFTherapeuticActionUsu : System.Web.UI.Page
    {
        TherapeuticActionLog objAccterap = new TherapeuticActionLog();
        //declaracion de variables aux para la tabla Accionterapeuta
        private int _id;
        private string _nombre;
        private string _descripcion;
        private bool _executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showAccionterapeuta();
                TBid.Visible = false;
            }
        }

        //Procedimiento para limpiar cajas
        private void limpiarCajas()
        {
            TBid.Text = string.Empty;
            TBNombre.Text = string.Empty;
            TBDescripcion.Text = string.Empty;
        }


        //procedimiento para ver todos los Accionterapeuta disponibles
        private void showAccionterapeuta()
        {
            DataSet objData = new DataSet();
            objData = objAccterap.showTherapeuticAction();
            GVAccionterapeuta.DataSource = objData;
            GVAccionterapeuta.DataBind();
        }

        //seleccion desde la GV de los Accionterapeuta
        protected void GVAccionterapeuta_SelectedIndexChanged(object sender, EventArgs e)
        {
            //nombres que apareceran en los campos de los registros seleccionados
            TBid.Text = GVAccionterapeuta.SelectedRow.Cells[2].Text;
            TBNombre.Text = GVAccionterapeuta.SelectedRow.Cells[3].Text;
            TBDescripcion.Text = GVAccionterapeuta.SelectedRow.Cells[4].Text;


        }


        //procedimiento para guardar Accionterapeuta
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            _nombre = TBNombre.Text;
            _descripcion = TBDescripcion.Text;

            _executed = objAccterap.saveTherapeuticAction(_nombre, _descripcion);
            if (_executed)
            {
                LblMsj.Text = "Se guardo exitosamente";
                this.showAccionterapeuta();
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
            _nombre = TBNombre.Text;
            _descripcion = TBDescripcion.Text;

            _executed = objAccterap.updateTherapeuticAction(_id, _nombre, _descripcion);
            if (_executed)
            {
                LblMsj.Text = "Se actualizó exitosamente";
                this.showAccionterapeuta();
            }
            else
            {
                LblMsj.Text = "Error al actualizar";
            }
        }

        //eliminar desde la GV para Eliminar un Accionterapeuta
        protected void GVAccionterapeuta_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _idLaboratorio = int.Parse(GVAccionterapeuta.Rows[e.RowIndex].Cells[2].Text);
            _executed = objAccterap.deleteTherapeuticAction(_idLaboratorio);

            if (_executed)
            {
                LblMsj.Text = " Laboratorio eliminado exitosamente";
                GVAccionterapeuta.EditIndex = 1;
                this.showAccionterapeuta();
            }

            else
            {
                LblMsj.Text = "Error al eliminar Laboratorio";
            }

        }

        protected void GVAccionterapeuta_RowDataBound(object sender, GridViewRowEventArgs e)
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