using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Inventario.Vistas
{
    public partial class CategoriasProductos : System.Web.UI.Page
    {
        Conexion Conect1 = new Conexion();
        Conexion Conect2 = new Conexion();
        Conexion Conect3 = new Conexion();
        Conexion Conect4 = new Conexion();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == " ")
            {
                Response.Redirect("Login.aspx");
            }
     

            if(IsPostBack == false)
            {
                string campos = "Id,Codigo,Producto,Precio,Categoria";
                GridView1.DataSource = Conect1.Consultar2(campos, "Productos");
                GridView1.DataBind();

            DropDownList1.DataSource = Conect2.Consultar2("*","Categorias");
            DropDownList1.DataTextField = "Categoria";
            DropDownList1.DataBind();
            } 




            Button_Actualizar.Visible = false;
            Button_Guardar.Visible = true;
            PlaceHolder_Producto.Visible = true;
            PlaceHolder_Categoria.Visible = false;
        }

        protected void Button_Tipo_Click(object sender, EventArgs e)
        {
            //Condicion que evalua si el Radio Button es seleccionado
            if(RadioButton_Producto.Checked)
            {
                string campos = "Codigo,Producto,Precio,Categoria";
                GridView1.DataSource = Conect3.Consultar2(campos, "Productos");
                GridView1.DataBind();

                Button_Actualizar.Visible = false;
                Button_Guardar.Visible = true;
                PlaceHolder_Producto.Visible = true;
                PlaceHolder_Categoria.Visible = false;
                TextBox_Buscar.Text = "";
                Label_Mensaje.Text = "";
                TextBox_Codigo.Text="";
                TextBox_Producto.Text = "";
                TextBox_Precio.Text = "";
            }
            if (RadioButton_Categoria.Checked)
            {
                string campos = "Id,Categoria";
                GridView1.DataSource = Conect4.Consultar2(campos, "Categorias");
                GridView1.DataBind();

                Button_Actualizar.Visible = false;
                Button_Guardar.Visible = true;
                PlaceHolder_Producto.Visible = false;
                PlaceHolder_Categoria.Visible = true;
                TextBox_Buscar.Text = "";
                Label_Mensaje.Text = "";
                TextBox_Categoria.Text = "";
            }
        }

        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoriasProductos.aspx");
        }
        //Metodo ParallelEnumerable insertar 
       
        private void GuardarDatos()
       {
            string sql1, sql2;
           //Condicin evalua si el RadioButton es seleccionado
           if(RadioButton_Producto.Checked)
           {
              string Codigo;
              Codigo = Convert.ToString(TextBox_Codigo.Text);
              bool Resultados = Conect3.Consultar3("Codigo","Productos","Codigo",Codigo);
              if (Resultados)
              {
                  TextBox_Codigo.Focus();
                  Label_Mensaje.Text = "La id " + Codigo + " del producto ya existe";
              }
             else
              { 
                  // Query  para insertar los datos a la tabla que esta en base de datoa 
                  sql1="INSERT INTO PRODUCTOS(Productos.Codigo,Productos.Producto,Productos.Precio,Productos.Categoria) VALUES('"+
                        TextBox_Codigo.Text +"','"+ TextBox_Producto.Text +"','" + TextBox_Precio.Text + "','"+ DropDownList1.Text +"')"; 
                  
                  
                  if(Conect1.Insertar(sql1)){
                      int IdProducto = 0;
                      foreach (DataRow row in Conect2.Consultar2("*", "Productos").Rows) 
                      {
                         IdProducto = Convert.ToInt16(row[0]);
                      }
                      sql2 = "INSERT INTO Bodega(Bodega.Codigo,Bodega.Actual,Bodega.Importe,Bodega.IdProducto) VALUES('" +
                       TextBox_Codigo.Text + "', '" + 0 + "', '" + 0 + "', '" + IdProducto + "')";

                      if (Conect2.Insertar(sql2))
                      {
                          Response.Redirect("CategoriasProductos.aspx");
                      }
                  
                  }

              }
 
           }
           if(RadioButton_Categoria.Checked)
           {
                string categoria = TextBox_Categoria.Text;
                //condicion que verifica que no exista producto en la base de datos
                bool Resultados = Conect1.Consultar3("Categoria", "Categorias", "Categoria", categoria);
                if (Resultados)
                {
                    TextBox_Categoria.Focus();
                    string campos = "Id,Categoria";
                    GridView1.DataSource = Conect2.Consultar2(campos, "Categorias");
                    GridView1.DataBind();
                    Label_Mensaje.Text = "La categoria "+ categoria + " ya existe";

                }
           
           }


        }

       protected void Button_Guardar_Click(object sender, EventArgs e)
       {
           if (RadioButton_Producto.Checked)
           {
               if (TextBox_Codigo.Text == "")
               {
                   TextBox_Codigo.Focus();
                   
               }
               else
               {
                   if (TextBox_Producto.Text == "")
                   {
                       TextBox_Producto.Focus();
                   }
                   else
                   {
                       if (TextBox_Precio.Text == "")
                       {
                           TextBox_Precio.Focus();
                       }
                       else
                       {
                           GuardarDatos();
                       }
                      
                   }

               }
           }
           

           if (RadioButton_Categoria.Checked)
           {
               PlaceHolder_Producto.Visible = false;
               PlaceHolder_Categoria.Visible = true;
               if (TextBox_Categoria.Text == "")
               {
                   TextBox_Categoria.Focus();
                   GridView1.DataSource = Conect1.Consultar2("*", "Categorias");
                   GridView1.DataBind();
               }
               else
               {
                   GuardarDatos();
               }
           }




       }

    
       protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
       {
           GridView1.PageIndex = e.NewPageIndex;
           if (RadioButton_Producto.Checked)
           {
               string campos = "Id,Codigo,Producto,Precio,Categoria";
               GridView1.DataSource = Conect1.Consultar2(campos, "Productos");
               GridView1.DataBind();
               PlaceHolder_Producto.Visible = true;
               PlaceHolder_Categoria.Visible = false;
               TextBox_Buscar.Text = "";

           }

           if (RadioButton_Categoria.Checked)
           {

               GridView1.DataSource = Conect2.Consultar2("*", "Categorias");
               GridView1.DataBind();
               PlaceHolder_Producto.Visible = false;
               PlaceHolder_Categoria.Visible = true;
               TextBox_Buscar.Text = "";
           }

       }
       protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
       {
           if (RadioButton_Producto.Checked)
           {
               PlaceHolder_Producto.Visible = true;
               PlaceHolder_Categoria.Visible = false;
               GridView1.Columns[1].Visible = false;
               TextBox_IdProducto.Text = GridView1.SelectedRow.Cells[2].Text;
               TextBox_Codigo.Text = GridView1.SelectedRow.Cells[3].Text;
               TextBox_Producto.Text = GridView1.SelectedRow.Cells[4].Text;
               TextBox_Precio.Text = GridView1.SelectedRow.Cells[5].Text;

               Label_Mensaje.Text = "";
               TextBox_Codigo.ReadOnly = true;
               Button_Guardar.Visible = false;
               Button_Actualizar.Visible = true;
               TextBox_Buscar.Text = "";
           }

           if (RadioButton_Categoria.Checked)
           {

               PlaceHolder_Producto.Visible = false;
               PlaceHolder_Categoria.Visible = true;
               GridView1.Columns[1].Visible = false;
               TextBox_IdCategoria.Text = GridView1.SelectedRow.Cells[2].Text;
               TextBox_Categoria.Text = GridView1.SelectedRow.Cells[3].Text;
               Button_Guardar.Visible = false;
               Button_Actualizar.Visible = true;
               TextBox_Buscar.Text = "";
             
           }

       }
        //Metodo para actualizar registros
       private void Actualizar()
       {

           if (RadioButton_Producto.Checked)
           {
               string campos = "Codigo='" + TextBox_Codigo.Text + "', Producto='" + TextBox_Producto.Text + "',Precio='"+ TextBox_Precio.Text + "',Categoria='"+DropDownList1.Text +"'";
               if (Conect1.Actualizar("Productos", campos, "Id='" + TextBox_IdProducto.Text + "'"))
               {
                   Response.Redirect("CategoriasProductos.aspx");
               }

           }

           if (RadioButton_Categoria.Checked)
           {
               string campos = "Categoria='" + TextBox_Categoria.Text + "'";
               if (Conect1.Actualizar("Categorias", campos, "Id='" + TextBox_IdCategoria.Text + "'"))
               {
                   TextBox_Categoria.Text = "";
                   PlaceHolder_Producto.Visible = false;
                   PlaceHolder_Categoria.Visible = true;
                   Button_Actualizar.Visible = false;
                   Button_Guardar.Visible = true;
                   GridView1.DataSource = Conect1.Consultar2("*","Categorias");
                   GridView1.DataBind();
               }

           }

       }


       protected void Button_Actualizar_Click(object sender, EventArgs e)
       {
           Actualizar();
       }

       protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
       {

           if (RadioButton_Producto.Checked)
           {
               string Id = GridView1.Rows[e.RowIndex].Cells[2].Text;
               if(Conect1.Eliminar("Bodega","IdProducto='"+ Id +"'"))
               {
                   if(Conect1.Eliminar("Productos","Id='" + Id + "'"))
                   {
                       Response.Redirect("CategoriasProductos.aspx");    
                   }
               }

           }

           if (RadioButton_Categoria.Checked)
           {
               string Id = GridView1.Rows[e.RowIndex].Cells[2].Text;
               //condicion que elimina los registros de la tabla categoria
               if (Conect1.Eliminar("Categorias", "Id='" + Id + "'"))
               {

                   TextBox_Categoria.Text = "";
                   PlaceHolder_Producto.Visible = false;
                   PlaceHolder_Categoria.Visible = true;
                   Button_Actualizar.Visible = false;
                   Button_Guardar.Visible = true;
                   GridView1.DataSource = Conect1.Consultar2("*", "Categorias");
                   GridView1.DataBind();
               }

           }
       }

       protected void TextBox_Buscar_TextChanged(object sender, EventArgs e)
       {

           if (RadioButton_Producto.Checked)
           {

               PlaceHolder_Producto.Visible = true;
               PlaceHolder_Categoria.Visible = false;
               GridView1.DataSource = Conect1.Consultar4("*", "Productos","Codigo",TextBox_Buscar.Text);
               GridView1.DataBind();

           }

           if (RadioButton_Categoria.Checked)
           {


               PlaceHolder_Producto.Visible = false;
               PlaceHolder_Categoria.Visible = true;
               GridView1.DataSource = Conect1.Consultar4("*", "Categorias", "Categoria", TextBox_Buscar.Text);
               GridView1.DataBind();


           }

       }

      
    

        
    }
}