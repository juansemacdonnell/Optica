namespace OpticaSurinV2.Pantallas
{
    partial class SelectorFecha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectorFecha));
            comboBoxMes = new ComboBox();
            comboBoxAnio = new ComboBox();
            panel2 = new Panel();
            label2 = new Label();
            label1 = new Label();
            lblAvisoMontoMal = new Label();
            btnAceptar = new Button();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxMes
            // 
            comboBoxMes.FormattingEnabled = true;
            comboBoxMes.Location = new Point(189, 65);
            comboBoxMes.Name = "comboBoxMes";
            comboBoxMes.Size = new Size(121, 23);
            comboBoxMes.TabIndex = 0;
            // 
            // comboBoxAnio
            // 
            comboBoxAnio.FormattingEnabled = true;
            comboBoxAnio.Location = new Point(189, 35);
            comboBoxAnio.Name = "comboBoxAnio";
            comboBoxAnio.Size = new Size(121, 23);
            comboBoxAnio.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(lblAvisoMontoMal);
            panel2.Controls.Add(btnAceptar);
            panel2.Controls.Add(comboBoxMes);
            panel2.Controls.Add(comboBoxAnio);
            panel2.Location = new Point(20, 20);
            panel2.Name = "panel2";
            panel2.Size = new Size(360, 140);
            panel2.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(51, 64);
            label2.Name = "label2";
            label2.Size = new Size(134, 20);
            label2.TabIndex = 10;
            label2.Text = "Seleccione un mes:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(51, 35);
            label1.Name = "label1";
            label1.Size = new Size(132, 20);
            label1.TabIndex = 9;
            label1.Text = "Seleccione un año:";
            // 
            // lblAvisoMontoMal
            // 
            lblAvisoMontoMal.AutoSize = true;
            lblAvisoMontoMal.BackColor = Color.Transparent;
            lblAvisoMontoMal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAvisoMontoMal.ForeColor = Color.Black;
            lblAvisoMontoMal.Location = new Point(150, 7);
            lblAvisoMontoMal.Margin = new Padding(5);
            lblAvisoMontoMal.Name = "lblAvisoMontoMal";
            lblAvisoMontoMal.Size = new Size(60, 21);
            lblAvisoMontoMal.TabIndex = 8;
            lblAvisoMontoMal.Text = "FECHA";
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
            // SelectorFecha
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Óptica_SurinBlanco;
            ClientSize = new Size(404, 181);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SelectorFecha";
            Text = "Seleccione mes y año ";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBoxMes;
        private ComboBox comboBoxAnio;
        private Panel panel2;
        private Button btnAceptar;
        private Label lblAvisoMontoMal;
        private Label label2;
        private Label label1;
    }
}