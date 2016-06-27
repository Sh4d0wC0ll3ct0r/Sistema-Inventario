using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Inventario.Vistas
{
    public partial class Login : System.Web.UI.Page
    {
        Conexion Connect = new Conexion();
        bool Usuarios;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Entrar_Click(object sender, EventArgs e)
        {
            if (TextBox_User.Text == "")
            {
                TextBox_User.Focus();
            }
            else
            {
                if (TextBox_Password.Text == "")
                {
                    TextBox_Password.Focus();
                }
                else
                {
                    Usuarios = Connect.Consultar1("Login","UserName",TextBox_User.Text,"Password",TextBox_Password.Text);
                    if (Usuarios)
                    {
                        Session["usuario"] = Usuarios;
                        Response.Redirect("Inventario.aspx");
                    }
                    else {
                        Label_Mensaje.Text = "Usuario o contraseña incorrecta";
                    }
                }
            }

        }
    }
}