using Microsoft.Extensions.Configuration;
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
    public partial class Form09InsertarModificarDoctor : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form09InsertarModificarDoctor()
        {
            InitializeComponent();

            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("config.json",true,true);
            IConfigurationRoot config = builder.Build();
            string cadenaconexion = config["CadenaHospitalTajamar"];

            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.leerDoctores();
        }

        private void leerDoctores()
        {
            string sql = "select * from DOCTOR";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.lstDoctores.Items.Clear();
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                int hospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                int numero = int.Parse(this.reader["DOCTOR_NO"].ToString());
                string apellido = this.reader["APELLIDO"].ToString();
                string especialidad = this.reader["ESPECIALIDAD"].ToString();
                int salario = int.Parse(this.reader["SALARIO"].ToString());
                string cadena = hospital + "-" + numero + "-" + apellido + "-" + especialidad + "-" + salario;

                this.lstDoctores.Items.Add(cadena);
            }
            this.reader.Close();
            this.cn.Close();
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            this.lblMensaje.Text = "";
            int hospital = int.Parse(this.txtHospital.Text);
            int numero = int.Parse(this.txtDoctor.Text);
            string apellido = this.txtApellido.Text;
            string especialidad = this.txtEspecialidad.Text;
            int salario = int.Parse(this.txtSalario.Text);
            SqlParameter paramHosp = new SqlParameter("@cod_Hospital", hospital);
            SqlParameter paramDoc = new SqlParameter("@doctor_no", numero);
            SqlParameter paramApell = new SqlParameter("@apellido", apellido);
            SqlParameter paramEspec = new SqlParameter("@especialidad", especialidad);
            SqlParameter paramSal = new SqlParameter("@salario", salario);
            this.com.Parameters.Add(paramHosp);
            this.com.Parameters.Add(paramDoc);
            this.com.Parameters.Add(paramApell);
            this.com.Parameters.Add(paramEspec);
            this.com.Parameters.Add(paramSal);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "updateinsertdoctor";
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.cn.Close();
            this.reader.Close();
            this.com.Parameters.Clear();
            this.leerDoctores();
        }
    }
}
