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

#region Procedure
/*
create procedure EMPLEADOSDEPT_OUTPUT
(@NOMBRE NVARCHAR(50)
, @SUMA INT OUT
, @MEDIA INT OUT
, @PERSONAS INT OUT)
AS
    DECLARE @DEPTNO INT 
	SELECT @DEPTNO = DEPT_NO FROM DEPT
	WHERE DNOMBRE = @NOMBRE
	--CONSULTA PARA LOS PARAMETROS DE SALIDA
	SELECT @SUMA = SUM(SALARIO), @MEDIA = AVG(SALARIO), @PERSONAS = COUNT(EMP_NO) FROM EMP
	WHERE DEPT_NO = @DEPTNO
	--CONSULTA PARA DEVOLVER LOS EMPLEADOS (CURSOR)
	SELECT* FROM EMP WHERE DEPT_NO = @DEPTNO
GO
*/
#endregion

namespace AdoNet
{
    public partial class Form10ParametrosDeSalida : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form10ParametrosDeSalida()
        {
            InitializeComponent();
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("config.json", true, true);
            IConfigurationRoot config = builder.Build();
            string cadenaconexion = config["CadenaHospitalTajamar"];
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            string sql = "select * from dept";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.lstEmpleados.Items.Clear();
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                string nombre = this.reader["DNOMBRE"].ToString();

                this.cbDepatamentos.Items.Add(nombre);
            }
            this.reader.Close();
            this.cn.Close();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            string nombre = this.cbDepatamentos.SelectedItem.ToString();
            //No es necesario crear parametros para los de entrada
            this.com.Parameters.AddWithValue("@NOMBRE", nombre);
            SqlParameter pamSuma = new SqlParameter("@SUMA",0);
            pamSuma.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pamSuma);
            SqlParameter pamMedia = new SqlParameter("@MEDIA",0);
            pamMedia.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pamMedia);
            SqlParameter pamPersonas = new SqlParameter("@PERSONAS",0);
            pamPersonas.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pamPersonas);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "EMPLEADOSDEPT_OUTPUT";
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            this.lstEmpleados.Items.Clear();
            while (this.reader.Read())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                this.lstEmpleados.Items.Add(apellido);
            }

            this.reader.Close();

            this.lblMedia.Text = "Media: " + pamMedia.Value;
            this.lblPersonas.Text = "Personas: " + pamPersonas.Value;
            this.lblSuma.Text = "Suma: " + pamSuma.Value;

            this.cn.Close();
            this.com.Parameters.Clear();
        }
    }
}
