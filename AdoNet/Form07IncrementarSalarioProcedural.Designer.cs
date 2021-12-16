
namespace AdoNet
{
    partial class Form07IncrementarSalarioProcedural
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
            this.label1 = new System.Windows.Forms.Label();
            this.lstElementos = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnModificarSalarios = new System.Windows.Forms.Button();
            this.cbHospitales = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hospitales";
            // 
            // lstElementos
            // 
            this.lstElementos.FormattingEnabled = true;
            this.lstElementos.ItemHeight = 15;
            this.lstElementos.Location = new System.Drawing.Point(52, 72);
            this.lstElementos.Name = "lstElementos";
            this.lstElementos.Size = new System.Drawing.Size(281, 499);
            this.lstElementos.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(438, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hospitales";
            // 
            // btnModificarSalarios
            // 
            this.btnModificarSalarios.Location = new System.Drawing.Point(689, 72);
            this.btnModificarSalarios.Name = "btnModificarSalarios";
            this.btnModificarSalarios.Size = new System.Drawing.Size(245, 57);
            this.btnModificarSalarios.TabIndex = 4;
            this.btnModificarSalarios.Text = "Modificar Salarios";
            this.btnModificarSalarios.UseVisualStyleBackColor = true;
            this.btnModificarSalarios.Click += new System.EventHandler(this.btnModificarSalarios_Click);
            // 
            // cbHospitales
            // 
            this.cbHospitales.FormattingEnabled = true;
            this.cbHospitales.Location = new System.Drawing.Point(438, 72);
            this.cbHospitales.Name = "cbHospitales";
            this.cbHospitales.Size = new System.Drawing.Size(206, 23);
            this.cbHospitales.TabIndex = 5;
            // 
            // Form07IncrementarSalarioProcedural
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 618);
            this.Controls.Add(this.cbHospitales);
            this.Controls.Add(this.btnModificarSalarios);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstElementos);
            this.Controls.Add(this.label1);
            this.Name = "Form07IncrementarSalarioProcedural";
            this.Text = "Form07IncrementarSalarioProcedural";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstElementos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnModificarSalarios;
        private System.Windows.Forms.ComboBox cbHospitales;
    }
}