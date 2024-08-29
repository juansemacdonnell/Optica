namespace OpricaSurinV2.Pantallas
{
    partial class AvisoNoHayRecetasDelCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AvisoNoHayRecetasDelCliente));
            btnAceptar = new Button();
            panel2 = new Panel();
            lblAvisoNoHayRecetas = new Label();
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
            btnAceptar.TabIndex = 9;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lblAvisoNoHayRecetas);
            panel2.Controls.Add(btnAceptar);
            panel2.Location = new Point(25, 22);
            panel2.Name = "panel2";
            panel2.Size = new Size(360, 140);
            panel2.TabIndex = 0;
            // 
            // lblAvisoNoHayRecetas
            // 
            lblAvisoNoHayRecetas.AutoSize = true;
            lblAvisoNoHayRecetas.BackColor = Color.Transparent;
            lblAvisoNoHayRecetas.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAvisoNoHayRecetas.ForeColor = Color.Black;
            lblAvisoNoHayRecetas.Location = new Point(40, 47);
            lblAvisoNoHayRecetas.Margin = new Padding(5);
            lblAvisoNoHayRecetas.Name = "lblAvisoNoHayRecetas";
            lblAvisoNoHayRecetas.Size = new Size(283, 21);
            lblAvisoNoHayRecetas.TabIndex = 0;
            lblAvisoNoHayRecetas.Text = "No hay recetas vinculadas al cliente";
            // 
            // AvisoNoHayRecetasDelCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = OpticaSurinV2.Properties.Resources.Óptica_SurinBlanco;
            ClientSize = new Size(404, 181);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AvisoNoHayRecetasDelCliente";
            Text = "¡AVISO!";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAceptar;
        private Panel panel2;
        private Label lblAvisoNoHayRecetas;
    }
}