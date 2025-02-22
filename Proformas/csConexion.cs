using System;
using System.Data;

using System.Windows.Forms;
using Microsoft.Data.SqlClient;



namespace Proformas
{
    public class Conexion
    {
        private SqlCommand comando = new SqlCommand();
        public SqlConnection Conectar;
        public SqlConnection cn;
        private SqlCommandBuilder cmb;
        public DataSet ds = new DataSet();
        public SqlDataAdapter da;
        //Data Source=DESKTOP-VK5KHQR;Initial Catalog=BDProformas;Integrated Security=True;Encrypt=False;Trust Server Certificate=True
        private string _connectionString = "Data Source=DESKTOP-VK5KHQR;Initial Catalog=BDProformas;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";





        public Conexion()
        {
            Conectar = new SqlConnection("Data Source=DESKTOP-VK5KHQR;Initial Catalog=BDProformas;Integrated Security=True");
            Conectar = new SqlConnection(_connectionString);
            Conectar.Open();

        }
        public string ConnectionString
        {
            get { return _connectionString; }
        }

        public DataTable MostrarTabla(string sentencia)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sentencia, Conectar);
            adapter.Fill(dt);
            return dt;

        }


        
    }
}
