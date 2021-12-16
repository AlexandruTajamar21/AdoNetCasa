using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNet
{
    public partial class Form08MensajeServidor : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public Form08MensajeServidor()
        {
            InitializeComponent();
            String cadenaconexion = @"Data Source=LOCALHOST;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2021";
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.LeerDepartamentos();
            this.cn.InfoMessage += Cn_InfoMessage;
        }

        private void Cn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            this.lblMensaje.Text = e.Message;
        }

        private void btnNuevoDepartamento_Click(object sender, EventArgs e)
        {
            this.lblMensaje.Text = "";
            string nombre = this.txtNombre.Text;
            int numero = int.Parse(this.txtNumero.Text);
            string local = this.txtLocalidad.Text;
            SqlParameter paramNumero = new SqlParameter("@numero", numero);
            SqlParameter paramNombre = new SqlParameter("@nombre", nombre);
            SqlParameter paramLocal = new SqlParameter("@localidad", local);
            this.com.Parameters.Add(paramNumero);
            this.com.Parameters.Add(paramNombre);
            this.com.Parameters.Add(paramLocal);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "insertardepartamento";
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.cn.Close();
            this.reader.Close();
            this.com.Parameters.Clear();
            this.LeerDepartamentos();
        }

        private void LeerDepartamentos()
        {
            string sql = "select * from DEPT";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.lstDepartamentos.Items.Clear();
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                int numero = int.Parse(this.reader["DEPT_NO"].ToString());
                string nombre = this.reader["DNOMBRE"].ToString();
                string localidad = this.reader["LOC"].ToString();
                string cadena = numero + "-" + nombre + "-" + localidad;

                this.lstDepartamentos.Items.Add(cadena);
            }
            this.reader.Close();
            this.cn.Close();
        }
    }
}
