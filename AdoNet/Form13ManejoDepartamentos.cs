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
    public partial class Form13ManejoDepartamentos : Form
    {
        DepartamentosContext context;
        public Form13ManejoDepartamentos()
        {
            InitializeComponent();
            this.context = new DepartamentosContext();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            this.cargaDepartamentos();
        }
        private void cargaDepartamentos()
        {
            List<Departamento> oficios = context.getOficios();
            this.lsvDepartamentos.Items.Clear();
            foreach (Departamento ofi in oficios)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = ofi.DEPT_NO;
                item.Text = ofi.DEPT_NO.ToString();
                item.SubItems.Add(ofi.DNOMBRE);
                item.SubItems.Add(ofi.LOC);
                this.lsvDepartamentos.Items.Add(item);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if(this.txtNombre.Text!= "" && this.txtLocalidad.Text != "" && this.txtNum.Text != "")
            {
                int num = int.Parse(txtNum.Text);
                string nombre = txtNombre.Text;
                string loc = txtLocalidad.Text;
                context.insertEmpleado(num, nombre, loc);
                this.cargaDepartamentos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.txtNombre.Text != "" && this.txtLocalidad.Text != "" && this.txtNum.Text != "")
            {
                int num = int.Parse(txtNum.Text);
                string nombre = txtNombre.Text;
                string loc = txtLocalidad.Text;
                context.updateDepartamento(num, nombre, loc);
                this.cargaDepartamentos();
            }
        }

        private void lsvDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            item = this.lsvDepartamentos.SelectedItems[0];
            Departamento dep = context.getDepartamento(int.Parse(item.Tag.ToString()));
            this.txtNum.Text = dep.DEPT_NO.ToString();
            this.txtNombre.Text = dep.DNOMBRE.ToString();
            this.txtLocalidad.Text = dep.LOC.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            item = this.lsvDepartamentos.SelectedItems[0];
            context.deleteDepartamento(int.Parse(item.Tag.ToString()));
            this.cargaDepartamentos();
        }
    }
}
