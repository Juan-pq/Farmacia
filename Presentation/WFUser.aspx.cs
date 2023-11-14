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
    public partial class WFUser : System.Web.UI.Page
    {
        UserLog objUsu = new UserLog();
        //declaracion de variables aux para la tabla Laboratorio
        private int _id;
        private string _correo;
        private string _contrasena;
        private string _salt;
        private string _estado;
        private bool _executed = false;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showUser();
                TBid.Visible = false;
            }

        }

        //Procedimiento para limpiar cajas
        private void limpiarCajas()
        {
            TBid.Text = string.Empty;
            TBCorreo.Text = string.Empty;
            TBContrasena.Text = string.Empty;
            TBSalt.Text = string.Empty;
            TBEstado.Text = string.Empty;
        }


        //procedimiento para ver todos los laboratorios disponibles
        private void showUser()
        {
            DataSet objData = new DataSet();
            objData = objUsu.showUser();
            GVUser.DataSource = objData;
            GVUser.DataBind();
        }

        protected void GVUser_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void GVUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _idusuario = int.Parse(GVUser.Rows[e.RowIndex].Cells[2].Text);
            _executed = objUsu.deleteUser(_idusuario);

            if (_executed)
            {
                LblMsj.Text = " Laboratorio eliminado exitosamente";
                GVUser.EditIndex = 1;
                this.showUser();
            }

            else
            {
                LblMsj.Text = "Error al eliminar Laboratorio";
            }
        }

        protected void GVUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBid.Text = GVUser.SelectedRow.Cells[2].Text;
            TBCorreo.Text = GVUser.SelectedRow.Cells[3].Text;
            TBContrasena.Text = GVUser.SelectedRow.Cells[4].Text;
            TBSalt.Text = GVUser.SelectedRow.Cells[5].Text;
            TBEstado.Text = GVUser.SelectedRow.Cells[5].Text;
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            _correo = TBCorreo.Text;
            _contrasena = TBContrasena.Text;           
            _salt = TBSalt.Text;
            _estado = TBEstado.Text;

            _executed = objUsu.saveUser(_correo, _contrasena, _salt,_estado);
            if (_executed)
            {
                LblMsj.Text = "Se guardo exitosamente";
                this.showUser();
                this.limpiarCajas();

            }
            else
            {
                LblMsj.Text = "Error al guardar";
            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(TBid.Text);
            _correo = TBCorreo.Text;
            _contrasena = TBContrasena.Text;
            _salt = TBSalt.Text;
            _estado = TBEstado.Text;

            _executed = objUsu.updateUser(_id, _correo, _contrasena, _salt, _estado);
            if (_executed)
            {
                LblMsj.Text = "Se actualizó exitosamente";
                this.showUser();
            }
            else
            {
                LblMsj.Text = "Error al actualizar";
            }
        }
    }
}