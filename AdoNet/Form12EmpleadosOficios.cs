using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdoNet.Context;
using AdoNet.Models;

namespace AdoNet
{
    public partial class Form12EmpleadosOficios : Form
    {
        EmpleadosContext context;
        public Form12EmpleadosOficios()
        {
            InitializeComponent();
            this.context = new EmpleadosContext();
            this.CargaOficios();
        }
        public void CargaOficios()
        {
            List<String> oficios = this.context.GetOficios();
            foreach(string oficio in oficios)
            {
                this.cbOficios.Items.Add(oficio);
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            string oficio = cbOficios.SelectedItem.ToString();
            this.cargaEmpleados(oficio);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string oficio = cbOficios.SelectedItem.ToString();
            int incremento = int.Parse(this.txtIncremento.Text);
            int modificados = this.context.UpdateEmpleadosOficio(oficio,incremento);
            this.cargaEmpleados(oficio);
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(this.lsvEmpleados.SelectedItems.Count != 0)
            {
                ListViewItem seleccionado = this.lsvEmpleados.SelectedItems[0];
                int idmpleado = int.Parse(seleccionado.Tag.ToString());
                int eliminado = this.context.deleteEmpleado(idmpleado);
                string oficio = cbOficios.SelectedItem.ToString();
                this.cargaEmpleados(oficio);
            }
        }

        private void cargaEmpleados(string oficio)
        {
            List<Empleado> empleados = this.context.GetEmpleadosOficio(oficio);
            this.lsvEmpleados.Items.Clear();
            foreach (Empleado empleado in empleados)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = empleado.IdEmpleado;
                item.Text = empleado.Apellido;
                item.SubItems.Add(empleado.Oficio);
                item.SubItems.Add(empleado.Salario.ToString());
                this.lsvEmpleados.Items.Add(item);
            }
        }
    }
}
