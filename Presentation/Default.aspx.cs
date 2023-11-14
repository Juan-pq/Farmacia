using Logic;
using Model;
using SimpleCrypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class Default : System.Web.UI.Page
    {
        UserLog objUserLog = new UserLog();
        User objUser = new User();
        User objUser2 = new User();
        private string correo;
        private string contrasena;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void BtIniciar_Click(object sender, EventArgs e)
        {
            ICryptoService cryptoService = new PBKDF2();
            correo = TBCorreo.Text;
            contrasena = TBContrasena.Text;
            objUser = objUserLog.showUsersMail(correo);//Busca el correo del usuario
            if (objUser != null)
            {
                //string passEncryp = cryptoService.Compute(contrasena, objUser.Salt);
                if (cryptoService.Compare(objUser.Contrasena, contrasena) & cryptoService.Compare(objUser.Correo, correo))
                {

                    if (correo == "admin" & contrasena=="admin")
                    {
                        FormsAuthentication.RedirectFromLoginPage("Index.aspx", true);
                    }
                    

                    else
                    {
                        Response.Redirect("IndexUsu.aspx");
                    }                

                    TBCorreo.Text = "";
                    TBContrasena.Text = "";
                }
                else
                {
                    LblMsg.Text = "Correo o Contraseña Incorrecto";
                }
            }
            else
            {
                LblMsg.Text = "Correo o Contraseña Incorrecto";
            }
        }








        //protected void BtIniciar_Click(object sender, EventArgs e)
        //{
        //    ICryptoService cryptoService = new SimpleCrypto.PBKDF2();
        //    correo = TBCorreo.Text;
        //    contrasena = TBContrasena.Text;
        //    objUser = objUserLog.showUsersMail(correo);//Busca el correo del usuario
        //    if (objUser != null)
        //    {
        //        string passEncryp = cryptoService.Compute(contrasena, objUser.Salt);
        //        if (cryptoService.Compare(objUser.Contrasena, passEncryp))
        //        {
        //            //if (
        //            //cryptoService.Compare(objUser.Contrasena, "admin"))
        //            //{
        //                //FormsAuthentication.RedirectFromLoginPage("WFUsers.aspx", true);
        //                Response.Redirect("Index.aspx",true);
        //                TBCorreo.Text = "";
        //                TBContrasena.Text = "";
        //        }

        //            else
        //            {
        //            LblMsg.Text = "Correo o Contraseña Incorrecto";
        //            //if (
        //            //cryptoService.Compare(objUser.Contrasena, contrasena))
        //            //{

        //            //FormsAuthentication.RedirectFromLoginPage("WFCampus.aspx", true);
        //            // Response.Redirect("IndexUsu.aspx",true);
        //            //TBCorreo.Text = "";
        //            //TBContrasena.Text = "";
        //            //}
        //            }
        //    }
        //    else
        //        {
        //            LblMsg.Text = "Correo o Contraseña Incorrecto";
        //        }
        //    //}
        //    //else
        //    //{
        //    //    LblMsg.Text = "Correo o Contraseña Incorrecto";
        //    //}
        //}
    }
}