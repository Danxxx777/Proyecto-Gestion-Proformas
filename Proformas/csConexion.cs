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

        private string _connectionString = "Data Source=Ryzen7\\SQLEXPRESS;Initial Catalog=BDProformas;Integrated Security=True;TrustServerCertificate=True";





        public Conexion()
        {
            Conectar = new SqlConnection("Data Source=Ryzen7\\SQLEXPRESS;Initial Catalog=BDProformas;Integrated Security=True");
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
