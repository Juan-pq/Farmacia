using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFLaboratorio : System.Web.UI.Page
    {
        LaboratoryLog objLab = new LaboratoryLog();
        //declaracion de variables aux para la tabla Laboratorio
        private int _id;
        private string _nombre;
        private string _direccion;
        private decimal _telefono;
        private bool _executed = false;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showLaboratorio();
                TBid.Visible = false;
            }           

        }
        
        //Procedimiento para limpiar cajas
        private void limpiarCajas()
        {
            TBid.Text = string.Empty;
            TBNombre.Text = string.Empty;
            TBDireccion.Text = string.Empty;
            TBTelefono.Text = string.Empty;
        }


        //procedimiento para ver todos los laboratorios disponibles
        private void showLaboratorio()
        {
            DataSet objData = new DataSet();
            objData = objLab.showLaboratory();
            GVLaboratorios.DataSource = objData;
            GVLaboratorios.DataBind();
        }

        //seleccion desde la GV de los laboratorios
        protected void GVLaboratorios_SelectedIndexChanged(object sender, EventArgs e)
        {
            //nombres que apareceran en los campos de los registros seleccionados
            TBid.Text = GVLaboratorios.SelectedRow.Cells[2].Text;
            TBNombre.Text = GVLaboratorios.SelectedRow.Cells[3].Text;
            TBDireccion.Text = GVLaboratorios.SelectedRow.Cells[4].Text;
            TBTelefono.Text = GVLaboratorios.SelectedRow.Cells[5].Text;


        }


        //procedimiento para guardar
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            _nombre = TBNombre.Text;
            _direccion = TBDireccion.Text;
            _telefono = Convert.ToDecimal( TBTelefono.Text);

            _executed = objLab.saveLaboratory(_nombre, _direccion, _telefono);
            if (_executed)
            {
                LblMsj.Text = "Se guardo exitosamente";
                this.showLaboratorio();
                this.limpiarCajas();

            }
            else
            {
                LblMsj.Text = "Error al guardar";
            }

        }

        //procedimiento para Actualizar laboratorio
        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(TBid.Text);
            _nombre = TBNombre.Text;
            _direccion= TBDireccion.Text;
            _telefono = Convert.ToDecimal(TBTelefono.Text);

            _executed = objLab.updateLaboratory(_id,_nombre,_direccion, _telefono);
            if ( _executed )
            {
                LblMsj.Text = "Se actualizó exitosamente";
                this.showLaboratorio();
            }
            else
            {
                LblMsj.Text = "Error al actualizar";
            }
        }

        //eliminar desde la GV para Eliminar un laboratorio
        protected void GVLaboratorios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _idLaboratorio = int.Parse(GVLaboratorios.Rows[e.RowIndex].Cells[2].Text);
            _executed = objLab.deleteLaboratory(_idLaboratorio);

            if ( _executed )
            {
                LblMsj.Text = " Laboratorio eliminado exitosamente";
                GVLaboratorios.EditIndex = 1;
                this.showLaboratorio();
            }

            else
            {
                LblMsj.Text = "Error al eliminar Laboratorio";
            }

        }

        protected void GVLaboratorios_RowDataBound(object sender, GridViewRowEventArgs e)
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