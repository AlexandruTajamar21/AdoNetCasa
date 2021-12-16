using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using AdoNet.Models;

namespace AdoNet.Context
{
    public class PruebaExamenContext
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public PruebaExamenContext(){
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("config.json");
            IConfigurationRoot config = builder.Build();
            String cadenaconexion = config["CadenaHospitalCasa"];
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public List<Departamento> getDepartamentos()
        {

            /* 
            create procedure getDepartamentos
            as
                select * from DEPT
            go
             */
            this.com.CommandType = System.Data.CommandType.StoredProcedure;
            this.com.CommandText = "getDepartamentos";
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<Departamento> departamentos = new List<Departamento>();
            while (this.reader.Read())
            {
                Departamento dpt = new Departamento();
                dpt.DEPT_NO = int.Parse(this.reader["DEPT_NO"].ToString());
                dpt.DNOMBRE = this.reader["DNOMBRE"].ToString();
                dpt.LOC = this.reader["LOC"].ToString();
                departamentos.Add(dpt);
            }

            this.reader.Close();
            this.cn.Close();
            return departamentos;
        }

        public List<Empleado> getEmpleados(int id)
        {

            /* 
             create procedure getEmpleados
	            (@Id int)
            as
	
	            select * from EMP where DEPT_NO = @Id

            go
             */
            this.com.CommandType = System.Data.CommandType.StoredProcedure;
            this.com.CommandText = "getEmpleados";
            this.com.Parameters.AddWithValue("@Id", id);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<Empleado> empleados = new List<Empleado>();
            while (this.reader.Read())
            {
                Empleado emp = new Empleado();
                emp.IdEmpleado = int.Parse(this.reader["EMP_NO"].ToString());
                emp.Apellido = this.reader["APELLIDO"].ToString();
                emp.Oficio = this.reader["OFICIO"].ToString();
                emp.Salario = int.Parse(this.reader["SALARIO"].ToString());
                emp.Comision = int.Parse(this.reader["COMISION"].ToString());
                emp.Departamento = int.Parse(this.reader["DEPT_NO"].ToString());
                empleados.Add(emp);
            }

            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return empleados;
        }

        public List<Empleado> getAllEmpleados()
        {

            /* 
             create procedure getAllEmpleados
            as
	
	            select * from EMP

            go
            este esta por sql pero lo he creado por si lo quereis ver
             */
            string sql = "select* from emp";
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<Empleado> empleados = new List<Empleado>();
            while (this.reader.Read())
            {
                Empleado emp = new Empleado();
                emp.IdEmpleado = int.Parse(this.reader["EMP_NO"].ToString());
                emp.Apellido = this.reader["APELLIDO"].ToString();
                emp.Oficio = this.reader["OFICIO"].ToString();
                emp.Salario = int.Parse(this.reader["SALARIO"].ToString());
                emp.Comision = int.Parse(this.reader["COMISION"].ToString());
                emp.Departamento = int.Parse(this.reader["DEPT_NO"].ToString());
                empleados.Add(emp);
            }

            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return empleados;
        }

        public void insertarEmpleado(Empleado emp)
        {

            /* 
            create procedure insertarEmpleado
	            (@ID INT, @APELLIDO NVARCHAR(50),@OFICIO NVARCHAR(50),@SALARIO INT,@COMISION INT,@DEPARTAMENTO INT)
            AS
	            INSERT INTO EMP(EMP_NO, APELLIDO, OFICIO, SALARIO,COMISION,DEPT_NO)
	            VALUES (@ID, @APELLIDO, @OFICIO, @SALARIO,@COMISION,@DEPARTAMENTO);
            GO
             */
            this.com.CommandType = System.Data.CommandType.StoredProcedure;
            this.com.CommandText = "insertarEmpleado";
            this.com.Parameters.AddWithValue("@ID", emp.IdEmpleado);
            this.com.Parameters.AddWithValue("@APELLIDO", emp.Apellido);
            this.com.Parameters.AddWithValue("@OFICIO", emp.Oficio);
            this.com.Parameters.AddWithValue("@SALARIO", emp.Salario);
            this.com.Parameters.AddWithValue("@COMISION", emp.Comision);
            this.com.Parameters.AddWithValue("@DEPARTAMENTO", emp.Departamento);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

        public Empleado getEmpleadoID(int id)
        {
            /* 
             create procedure getEmpleadoId
	            (@ID INT)
            as
	            select * from EMP where EMP_NO = @ID
            go
             */
            this.com.CommandType = System.Data.CommandType.StoredProcedure;
            this.com.CommandText = "getEmpleadoId";
            this.com.Parameters.AddWithValue("@Id", id);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.reader.Read();

            Empleado emp = new Empleado();
            emp.IdEmpleado = int.Parse(this.reader["EMP_NO"].ToString());
            emp.Apellido = this.reader["APELLIDO"].ToString();
            emp.Oficio = this.reader["OFICIO"].ToString();
            emp.Salario = int.Parse(this.reader["SALARIO"].ToString());
            emp.Comision = int.Parse(this.reader["COMISION"].ToString());
            emp.Departamento = int.Parse(this.reader["DEPT_NO"].ToString());

            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return emp;
        }

        internal void eliminarEmpleado(int id)
        {
            /* 
             create procedure deleteEmpleado
	            (@ID INT)
            as
	            delete from EMP where EMP_NO = @ID
            go
             */
            this.com.CommandType = System.Data.CommandType.StoredProcedure;
            this.com.CommandText = "deleteEmpleado";
            this.com.Parameters.AddWithValue("@ID", id);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

        internal void modificarEmpleado(Empleado emp)
        {
            /* 
             create PROCEDURE UPDATEEMPLEADOS
	            (@IDEMPLEADO int, @APELLIDO nvarchar(50), @OFICIO nvarchar(50),@SALARIO int,@COMISION int,@IDDEPT int)
            AS
	            update EMP 
	            set APELLIDO = @APELLIDO, OFICIO = @OFICIO, SALARIO = @SALARIO, COMISION = @COMISION, DEPT_NO = @IDDEPT
	            where emp_no = @IDEMPLEADO
            GO
             */
            this.com.CommandType = System.Data.CommandType.StoredProcedure;
            this.com.CommandText = "UPDATEEMPLEADOS";
            this.com.Parameters.AddWithValue("@IDEMPLEADO", emp.IdEmpleado);
            this.com.Parameters.AddWithValue("@APELLIDO", emp.Apellido);
            this.com.Parameters.AddWithValue("@OFICIO", emp.Oficio);
            this.com.Parameters.AddWithValue("@SALARIO", emp.Salario);
            this.com.Parameters.AddWithValue("@COMISION", emp.Comision);
            this.com.Parameters.AddWithValue("@IDDEPT", emp.Departamento);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
        }
    }
}
