using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Inventario
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == " ")
            {
                Cerrar.Visible = false;
            }
            else
            {
                Iniciar.Visible = false;
            }
        }
    }
}