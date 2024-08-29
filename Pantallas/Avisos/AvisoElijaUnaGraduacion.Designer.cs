namespace OpricaSurinV2.Pantallas
{
    partial class AvisoElijaUnaGraduacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AvisoElijaUnaGraduacion));
            btnAceptar = new Button();
            panel2 = new Panel();
            lblLetraChica1 = new Label();
            lblAvisoMontoMal = new Label();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.White;
            btnAceptar.Cursor = Cursors.Hand;
            btnAceptar.FlatAppearance.BorderColor = Color.Black;
            btnAceptar.FlatAppearance.MouseDownBackColor = Color.Black;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAceptar.ForeColor = SystemColors.ActiveCaptionText;
            btnAceptar.Location = new Point(134, 95);
            btnAceptar.Margin = new Padding(5);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(92, 32);
            btnAceptar.TabIndex = 7;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lblLetraChica1);
            panel2.Controls.Add(btnAceptar);
            panel2.Controls.Add(lblAvisoMontoMal);
            panel2.Location = new Point(20, 20);
            panel2.Name = "panel2";
            panel2.Size = new Size(360, 140);
            panel2.TabIndex = 0;
            // 
            // lblLetraChica1
            // 
            lblLetraChica1.AutoSize = true;
            lblLetraChica1.BackColor = Color.Transparent;
            lblLetraChica1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLetraChica1.ForeColor = Color.Black;
            lblLetraChica1.Location = new Point(48, 59);
            lblLetraChica1.Margin = new Padding(5);
            lblLetraChica1.Name = "lblLetraChica1";
            lblLetraChica1.Size = new Size(276, 15);
            lblLetraChica1.TabIndex = 1;
            lblLetraChica1.Text = "- Esta registrando una nueva receta, ingrese datos -";
            // 
            // lblAvisoMontoMal
            // 
            lblAvisoMontoMal.AutoSize = true;
            lblAvisoMontoMal.BackColor = Color.Transparent;
            lblAvisoMontoMal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAvisoMontoMal.ForeColor = Color.Black;
            lblAvisoMontoMal.Location = new Point(29, 28);
            lblAvisoMontoMal.Margin = new Padding(5);
            lblAvisoMontoMal.Name = "lblAvisoMontoMal";
            lblAvisoMontoMal.Size = new Size(313, 21);
            lblAvisoMontoMal.TabIndex = 0;
            lblAvisoMontoMal.Text = "Falta elegir (al menos) un tipo de receta";
            // 
            // AvisoElijaUnaGraduacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = OpticaSurinV2.Properties.Resources.Óptica_SurinBlanco;
            ClientSize = new Size(404, 181);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AvisoElijaUnaGraduacion";
            Text = "¡AVISO!";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAceptar;
        private Panel panel2;
        private Label lblLetraChica1;
        private Label lblAvisoMontoMal;
    }
}