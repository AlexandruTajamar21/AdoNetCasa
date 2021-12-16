using AdoNet.Context;
using AdoNet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNet
{
    public partial class Form99PracticaExamen : Form
    {
        PruebaExamenContext context;
        public Form99PracticaExamen()
        {
            InitializeComponent();
            this.context = new PruebaExamenContext();
            this.dibujaEmpleados();
            this.dibujarDepartamentos();
        }

        private void Rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if (radio.Checked)
            {
                this.lstVeiwEmpleados.Items.Clear();
                int hospitalcod = int.Parse(radio.Tag.ToString());
                List<Empleado> empleados = this.context.getEmpleados(hospitalcod);
                foreach (Empleado emp in empleados)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = emp.IdEmpleado;
                    item.Text = emp.IdEmpleado.ToString();
                    item.SubItems.Add(emp.Apellido.ToString());
                    item.SubItems.Add(emp.Oficio.ToString());
                    item.SubItems.Add(emp.Salario.ToString());
                    item.SubItems.Add(emp.Departamento.ToString());
                    this.lstVeiwEmpleados.Items.Add(item);
                }
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtId.Text.ToString());
            string apellido = this.txtApellido.Text.ToString();
            string oficio = this.txtOficio.Text.ToString();
            int salario = int.Parse(this.txtSalario.Text.ToString());
            int comision = int.Parse(this.txtComision.Text.ToString());
            int departamento = int.Parse(this.txtDepartamento.Text.ToString());
            Empleado empleado = new Empleado();
            empleado.IdEmpleado = id;
            empleado.Apellido = apellido;
            empleado.Oficio = oficio;
            empleado.Salario = salario;
            empleado.Comision = comision;
            empleado.Departamento = departamento;
            context.insertarEmpleado(empleado);
        }

        private void dibujarDepartamentos()
        {
            List<Departamento> departamentos = context.getDepartamentos();
            int Y = 40;
            foreach (Departamento dpt in departamentos)
            {
                RadioButton rb = new RadioButton();
                rb.Text = dpt.DNOMBRE;
                rb.Tag = dpt.DEPT_NO;
                rb.Location = new System.Drawing.Point(10, Y);
                Y += 30;
                rb.CheckedChanged += Rb_CheckedChanged; ;
                this.pnlDepartamentos.Controls.Add(rb);
            }
        }

        private void dibujaEmpleados()
        {
            List<Empleado> empleados = this.context.getAllEmpleados();
            foreach (Empleado emp in empleados)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = emp.IdEmpleado;
                item.Text = emp.IdEmpleado.ToString();
                item.SubItems.Add(emp.Apellido.ToString());
                item.SubItems.Add(emp.Oficio.ToString());
                item.SubItems.Add(emp.Salario.ToString());
                item.SubItems.Add(emp.Departamento.ToString());
                this.lstVeiwEmpleados.Items.Add(item);
            }
        }

        private void lstVeiwEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.lstVeiwEmpleados.SelectedItems.Count != 0)
            {
                ListViewItem item = new ListViewItem();
                item = this.lstVeiwEmpleados.SelectedItems[0];
                Empleado emp = context.getEmpleadoID(int.Parse(item.Tag.ToString()));
                this.txtId.Text = emp.IdEmpleado.ToString();
                this.txtApellido.Text = emp.Apellido.ToString();
                this.txtOficio.Text = emp.Oficio.ToString();
                this.txtSalario.Text = emp.Salario.ToString();
                this.txtComision.Text = emp.Comision.ToString();
                this.txtDepartamento.Text = emp.Departamento.ToString();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtId.Text.ToString());
            string apellido = this.txtApellido.Text.ToString();
            string oficio = this.txtOficio.Text.ToString();
            int salario = int.Parse(this.txtSalario.Text.ToString());
            int comision = int.Parse(this.txtComision.Text.ToString());
            int departamento = int.Parse(this.txtDepartamento.Text.ToString());
            Empleado empleado = new Empleado();
            empleado.IdEmpleado = id;
            empleado.Apellido = apellido;
            empleado.Oficio = oficio;
            empleado.Salario = salario;
            empleado.Comision = comision;
            empleado.Departamento = departamento;
            context.modificarEmpleado(empleado);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtId.Text.ToString());
            context.eliminarEmpleado(id);
        }
    }
}
