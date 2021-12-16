using AdoNet.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet.Context
{
    class PlantillasContext
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public PlantillasContext()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("config.json");
            IConfigurationRoot config = builder.Build();
            String cadenaconexion = config["CadenaHospitalCasa"];
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }
        public List<Hospital> getHospitales()
        {
            string sql = "select * from hospital";
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<Hospital> hospitales = new List<Hospital>();
            while (this.reader.Read())
            {
                Hospital hosp = new Hospital();
                hosp.HOSPITAL_COD = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                hosp.NOMBRE = this.reader["NOMBRE"].ToString();
                hosp.DIRECCION = this.reader["DIRECCION"].ToString();
                hosp.TELEFONO = this.reader["TELEFONO"].ToString();
                hosp.NUM_CAMA = int.Parse(this.reader["NUM_CAMA"].ToString());
                hospitales.Add(hosp);
            }

            this.reader.Close();
            this.cn.Close();
            return hospitales;
        }
        public List<Plantilla> getPlantilla(int id)
        {
            string sql = "select * from PLANTILLA where HOSPITAL_COD = @id";
            this.com.Parameters.AddWithValue("@id", id);
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<Plantilla> plantillas = new List<Plantilla>();
            while (this.reader.Read())
            {
                Plantilla plantilla = new Plantilla();
                plantilla.HOSPITAL_COD = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                plantilla.SALA_COD = int.Parse(this.reader["SALA_COD"].ToString());
                plantilla.EMPLEADO_NO = int.Parse(this.reader["EMPLEADO_NO"].ToString());
                plantilla.APELLIDO = this.reader["APELLIDO"].ToString();
                plantilla.FUNCION = this.reader["FUNCION"].ToString();
                plantilla.T = this.reader["T"].ToString();
                plantilla.SALARIO = int.Parse(this.reader["SALARIO"].ToString());
                plantillas.Add(plantilla);
            }

            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return plantillas;
        }
    }
}
