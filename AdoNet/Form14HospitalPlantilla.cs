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
    public partial class Form14HospitalPlantilla : Form
    {
        PlantillasContext context;
        public Form14HospitalPlantilla()
        {
            InitializeComponent();
            this.context = new PlantillasContext();
            this.dibujaHospitales();
            
        }
        private void dibujaHospitales()
        {
            List<Hospital> hospitales = this.context.getHospitales();
            int Y = 30;
            foreach(Hospital hospital in hospitales)
            {
                RadioButton rb = new RadioButton();
                rb.Tag = hospital.HOSPITAL_COD.ToString();
                rb.Text = hospital.NOMBRE;
                rb.AutoSize = true;
                rb.Location = new System.Drawing.Point(41, Y);
                Y += 30;
                rb.CheckedChanged += Rb_CheckedChanged;
                this.pnlHospitales.Controls.Add(rb);
            }
        }

        private void Rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if (radio.Checked)
            {
                this.lsvPlantillas.Items.Clear();
                int hospitalcod = int.Parse(radio.Tag.ToString());
                List<Plantilla> plantillas = this.context.getPlantilla(hospitalcod);
                foreach(Plantilla plan in plantillas)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = plan.APELLIDO;
                    item.Text = plan.HOSPITAL_COD.ToString();
                    item.SubItems.Add(plan.SALA_COD.ToString());
                    item.SubItems.Add(plan.EMPLEADO_NO.ToString());
                    item.SubItems.Add(plan.APELLIDO.ToString());
                    item.SubItems.Add(plan.FUNCION.ToString());
                    item.SubItems.Add(plan.T.ToString());
                    item.SubItems.Add(plan.SALARIO.ToString());
                    this.lsvPlantillas.Items.Add(item);
                }
            }
        }
    }
}
