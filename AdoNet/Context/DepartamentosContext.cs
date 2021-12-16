using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNet.Models;

namespace AdoNet.Context
{
    class DepartamentosContext
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public DepartamentosContext()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("config.json");
            IConfigurationRoot config = builder.Build();
            String cadenaconexion = config["CadenaHospitalCasa"];
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }


        public List<Departamento> getOficios()
        {
            string sql = "select * from DEPT";
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<Departamento> oficios = new List<Departamento>();
            while (this.reader.Read())
            {
                Departamento dep = new Departamento();
                dep.DEPT_NO = int.Parse(this.reader["DEPT_NO"].ToString());
                dep.DNOMBRE = this.reader["DNOMBRE"].ToString();
                dep.LOC = this.reader["LOC"].ToString();
                oficios.Add(dep);
            }

            this.reader.Close();
            this.cn.Close();
            return oficios;
        }
        public int insertEmpleado(int num ,String nombre, String loc)
        {
            string sql = "insert into DEPT(DEPT_NO,DNOMBRE,LOC) values (@DEPT_NO,@DNOMBRE,@LOC)";
            this.com.Parameters.AddWithValue("@DEPT_NO", num);
            this.com.Parameters.AddWithValue("@DNOMBRE", nombre);
            this.com.Parameters.AddWithValue("@LOC", loc);
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;

            this.cn.Open();

            int insertados = this.com.ExecuteNonQuery();

            this.cn.Close();
            this.com.Parameters.Clear();
            return insertados;
        }

        public int updateDepartamento(int num, String nombre, String loc)
        {
            string sql = "update DEPT set DNOMBRE = @DNOMBRE, LOC = @LOC where DEPT_NO = @DEPT_NO";
            this.com.Parameters.AddWithValue("@DEPT_NO", num);
            this.com.Parameters.AddWithValue("@DNOMBRE", nombre);
            this.com.Parameters.AddWithValue("@LOC", loc);
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();

            int modificiados = this.com.ExecuteNonQuery();

            this.cn.Close();
            this.com.Parameters.Clear();
            return modificiados;
        }
        public Departamento getDepartamento(int id)
        {
            string sql = "select * from DEPT where DEPT_NO = @DEPT_NO";
            this.com.Parameters.AddWithValue("@DEPT_NO", id);
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<Departamento> oficios = new List<Departamento>();
            while (this.reader.Read())
            {
                Departamento dep = new Departamento();
                dep.DEPT_NO = int.Parse(this.reader["DEPT_NO"].ToString());
                dep.DNOMBRE = this.reader["DNOMBRE"].ToString();
                dep.LOC = this.reader["LOC"].ToString();
                oficios.Add(dep);
            }

            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return oficios[0];
        }
        public int deleteDepartamento(int id)
        {
            string sql = "delete from DEPT where DEPT_NO = @DEPT_NO";
            this.com.Parameters.AddWithValue("DEPT_NO", id);
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();

            int eliminados = this.com.ExecuteNonQuery();

            this.cn.Close();
            this.com.Parameters.Clear();
            return eliminados;
        }
    }
}
