using Logic;
using SimpleCrypto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFUsers : System.Web.UI.Page
    {
        UserLog objUse = new UserLog();
        private string _mail, _contrasena, _salt, _state, _encryptedPassword;
        private int _id;
        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TBid.Visible = false;//Se oculta el Id
                showUsers();
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            ICryptoService cryptoService = new PBKDF2();
            _mail = TBCorreo.Text;
            _contrasena = TBContrasena.Text;
            _state = DDLState.SelectedValue;
            _salt = cryptoService.GenerateSalt();
            _encryptedPassword = cryptoService.Compute(_contrasena);
            executed = objUse.saveUser(_mail, _encryptedPassword, _salt, _state);
            if (executed)
            {
                LblMsj.Text = "Se guardo exitosamente";
                showUsers();
            }
            else
            {
                LblMsj.Text = "Error al guardar";
            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {

        }

        protected void GVUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Metodo para mostrar todos los Usuarios
        private void showUsers()
        {
            DataSet objData = new DataSet();
            objData = objUse.showUser();
            GVUsers.DataSource = objData;
            GVUsers.DataBind();
        }
        //protected void BtnSave_Click(object sender, EventArgs e)
        //{
            
        //}
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            //Por implementar
        }
        protected void GVUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Por implementar
        }
    }
}