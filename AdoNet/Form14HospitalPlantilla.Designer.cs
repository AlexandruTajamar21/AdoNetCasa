
namespace AdoNet
{
    partial class Form14HospitalPlantilla
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
            this.pnlHospitales = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lsvPlantillas = new System.Windows.Forms.ListView();
            this.HOSPITAL_COD = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // pnlHospitales
            // 
            this.pnlHospitales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pnlHospitales.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlHospitales.Location = new System.Drawing.Point(0, 0);
            this.pnlHospitales.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHospitales.Name = "pnlHospitales";
            this.pnlHospitales.Size = new System.Drawing.Size(397, 751);
            this.pnlHospitales.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(405, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Plantilla";
            // 
            // lsvPlantillas
            // 
            this.lsvPlantillas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.HOSPITAL_COD,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader4});
            this.lsvPlantillas.HideSelection = false;
            this.lsvPlantillas.Location = new System.Drawing.Point(405, 34);
            this.lsvPlantillas.Name = "lsvPlantillas";
            this.lsvPlantillas.Size = new System.Drawing.Size(897, 683);
            this.lsvPlantillas.TabIndex = 2;
            this.lsvPlantillas.UseCompatibleStateImageBehavior = false;
            this.lsvPlantillas.View = System.Windows.Forms.View.Details;
            // 
            // HOSPITAL_COD
            // 
            this.HOSPITAL_COD.Text = "HOSPITAL_COD";
            this.HOSPITAL_COD.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "NOMBRE";
            this.columnHeader2.Width = 160;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "DIRECCION";
            this.columnHeader3.Width = 160;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "TELEFONO";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "NUM_CAMA";
            this.columnHeader4.Width = 160;
            // 
            // Form14HospitalPlantilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 751);
            this.Controls.Add(this.lsvPlantillas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlHospitales);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form14HospitalPlantilla";
            this.Text = "Form14HospitalPlantilla";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHospitales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lsvPlantillas;
        private System.Windows.Forms.ColumnHeader HOSPITAL_COD;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}