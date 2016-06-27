using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Sistema_Inventario
{
    public class Conexion
    {

        public SqlConnection con;
        public DataSet ds = new DataSet();
        public SqlDataAdapter da;
        public SqlCommand comando;
        public DataTable dt;
    
        public void Conectar()
        {
            String cadena = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            con = new SqlConnection(cadena);
        }
        public Conexion()
        {
            Conectar();
        }
        //consulta para inicar sesion
        public bool Consultar1(string tabla, string campo1, string campo2, string campo3, string campo4)
        {
            string sql = "Select *from " + tabla + " where " + campo1 + "='" + campo2 + "' AND " + campo3 + "='" + campo4 + "'";
            con.Open();
            da = new SqlDataAdapter(sql,con);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();

            if(dt.Rows.Count > 0 ){
               return true;
            }
            else{
               return false;
            }

        }
    
        public DataTable Consultar2(string campos,string tabla){
            con.Open();
            string sql = "Select "+ campos +" from " + tabla;
            da = new SqlDataAdapter(sql, con);// trae todo los datos de la base de datos.
            ds = new DataSet();//inicializo el Dataset
            da.Fill(ds, tabla);
            con.Close();
            dt = new DataTable();
            dt = ds.Tables[tabla];
            return dt;
        }
        public bool Insertar(string sql)
        {
            con.Open();
            comando = new SqlCommand(sql,con);
            int i = comando.ExecuteNonQuery();
            con.Close();
            if(i > 0)
            {
                return true;
            }
            else{
                return false;
            }
        }

        public bool Consultar3(string campo1, string tabla, string campo2, string campo3)
        {
            string sql = "Select "+ campo1 +" from " + tabla + " where " + campo2 + "='" + campo3 +"'";
            con.Open();
            da = new SqlDataAdapter(sql, con);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

         }


        public bool Actualizar(string tabla, string campos, string condicion)
        {
            string sql = "UPDATE " + tabla + " SET " + campos + " where " + condicion;
            con.Open();
            comando = new SqlCommand(sql, con);
            int i = comando.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Eliminar(string tabla, string condicion)
        {
            string sql = "DELETE FROM " + tabla + " WHERE " + condicion;
            con.Open();
            comando = new SqlCommand(sql, con);
            int i = comando.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public DataTable Consultar4(string campo1,string tabla,string campo2,string campo3)
        {
            string sql = "SELECT " + campo1 + " FROM " + tabla + " WHERE " + campo2 + " LIKE '%" + campo3 + "%'";
            con.Open();
            da = new SqlDataAdapter(sql,con);
            da.Fill(ds,tabla);
            dt=new DataTable();
            dt = ds.Tables[tabla];
            con.Close();

            return dt;
        }

    }

}