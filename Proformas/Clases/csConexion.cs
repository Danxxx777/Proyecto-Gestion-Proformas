using System;
using System.Data;

using System.Windows.Forms;
using System.Data.SqlClient;

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
        //Data Source=DESKTOP-VK5KHQR;Initial Catalog=BDProformas;Integrated Security=True;Trust Server Certificate=True
        //Data Source=DESKTOP-VK5KHQR;Initial Catalog=BDProformas;Integrated Security=True

        //Data Source=Ryzen7\\SQLEXPRESS;Initial Catalog=BDProformas;Integrated Security=True;Encrypt=False;Trust Server Certificate=True
        //Data Source=Ryzen7\\SQLEXPRESS;Initial Catalog=BDProformas;Integrated Security=True
        //private string _connectionString = "Data Source=DESKTOP-VK5KHQR;Initial Catalog=BDProformas;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
        private string _connectionString = "Data Source=Ryzen7\\SQLEXPRESS;Initial Catalog=BDProformas;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";





        public Conexion()
        {
           
            //Conectar = new SqlConnection("Data Source=DESKTOP-VK5KHQR;Initial Catalog=BDProformas;Integrated Security=True");
            Conectar = new SqlConnection("Data Source=Ryzen7\\SQLEXPRESS;Initial Catalog=BDProformas;Integrated Security=True;Encrypt=False");
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
        public bool ValidarLogin(string usuario, string contraseña)
        {
            bool esValido = false;

            try
            {
                using (SqlConnection conexion = new SqlConnection(_connectionString))
                {
                    conexion.Open();
                    string query = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario AND Contraseña = @Contraseña";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        cmd.Parameters.AddWithValue("@Contraseña", contraseña);

                        int count = (int)cmd.ExecuteScalar();
                        esValido = (count > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
            }

            return esValido;
        }



    }
}
