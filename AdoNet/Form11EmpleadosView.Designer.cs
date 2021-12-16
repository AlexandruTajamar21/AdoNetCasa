
namespace AdoNet
{
    partial class Form11EmpleadosView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMostrar = new System.Windows.Forms.Button();
            this.lstEmpleados = new System.Windows.Forms.ListBox();
            this.lblPersonas = new System.Windows.Forms.Label();
            this.lblMedia = new System.Windows.Forms.Label();
            this.lblSuma = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbHospitales = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(295, 77);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(202, 43);
            this.btnMostrar.TabIndex = 15;
            this.btnMostrar.Text = "Mostrar Datos";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // lstEmpleados
            // 
            this.lstEmpleados.FormattingEnabled = true;
            this.lstEmpleados.ItemHeight = 15;
            this.lstEmpleados.Location = new System.Drawing.Point(613, 77);
            this.lstEmpleados.Name = "lstEmpleados";
            this.lstEmpleados.Size = new System.Drawing.Size(313, 499);
            this.lstEmpleados.TabIndex = 14;
            // 
            // lblPersonas
            // 
            this.lblPersonas.AutoSize = true;
            this.lblPersonas.Location = new System.Drawing.Point(43, 424);
            this.lblPersonas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPersonas.Name = "lblPersonas";
            this.lblPersonas.Size = new System.Drawing.Size(67, 15);
            this.lblPersonas.TabIndex = 13;
            this.lblPersonas.Text = "lblPersonas";
            // 
            // lblMedia
            // 
            this.lblMedia.AutoSize = true;
            this.lblMedia.Location = new System.Drawing.Point(43, 371);
            this.lblMedia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMedia.Name = "lblMedia";
            this.lblMedia.Size = new System.Drawing.Size(53, 15);
            this.lblMedia.TabIndex = 12;
            this.lblMedia.Text = "lblMedia";
            // 
            // lblSuma
            // 
            this.lblSuma.AutoSize = true;
            this.lblSuma.Location = new System.Drawing.Point(43, 322);
            this.lblSuma.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSuma.Name = "lblSuma";
            this.lblSuma.Size = new System.Drawing.Size(50, 15);
            this.lblSuma.TabIndex = 11;
            this.lblSuma.Text = "lblSuma";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(613, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Empleados";
            // 
            // cbHospitales
            // 
            this.cbHospitales.FormattingEnabled = true;
            this.cbHospitales.Location = new System.Drawing.Point(43, 77);
            this.cbHospitales.Name = "cbHospitales";
            this.cbHospitales.Size = new System.Drawing.Size(202, 23);
            this.cbHospitales.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Hospitales";
            // 
            // Form11EmpleadosView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 677);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.lstEmpleados);
            this.Controls.Add(this.lblPersonas);
            this.Controls.Add(this.lblMedia);
            this.Controls.Add(this.lblSuma);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbHospitales);
            this.Controls.Add(this.label1);
            this.Name = "Form11EmpleadosView";
            this.Text = "Form11EmpleadosView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.ListBox lstEmpleados;
        private System.Windows.Forms.Label lblPersonas;
        private System.Windows.Forms.Label lblMedia;
        private System.Windows.Forms.Label lblSuma;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbHospitales;
        private System.Windows.Forms.Label label1;
    }
}