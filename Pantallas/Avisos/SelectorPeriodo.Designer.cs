namespace OpticaSurinV2.Pantallas
{
    partial class SelectorPeriodo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectorPeriodo));
            panel2 = new Panel();
            dTPFechaHasta = new DateTimePicker();
            dTPFechaDesde = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            lblAvisoMontoMal = new Label();
            btnAceptar = new Button();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(dTPFechaHasta);
            panel2.Controls.Add(dTPFechaDesde);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(lblAvisoMontoMal);
            panel2.Controls.Add(btnAceptar);
            panel2.Location = new Point(20, 20);
            panel2.Name = "panel2";
            panel2.Size = new Size(360, 140);
            panel2.TabIndex = 3;
            // 
            // dTPFechaHasta
            // 
            dTPFechaHasta.Format = DateTimePickerFormat.Short;
            dTPFechaHasta.Location = new Point(223, 65);
            dTPFechaHasta.Name = "dTPFechaHasta";
            dTPFechaHasta.Size = new Size(87, 23);
            dTPFechaHasta.TabIndex = 12;
            // 
            // dTPFechaDesde
            // 
            dTPFechaDesde.Format = DateTimePickerFormat.Short;
            dTPFechaDesde.Location = new Point(223, 34);
            dTPFechaDesde.Name = "dTPFechaDesde";
            dTPFechaDesde.Size = new Size(87, 23);
            dTPFechaDesde.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(50, 67);
            label2.Name = "label2";
            label2.Size = new Size(162, 20);
            label2.TabIndex = 10;
            label2.Text = "Seleccione fecha hasta:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(50, 36);
            label1.Name = "label1";
            label1.Size = new Size(167, 20);
            label1.TabIndex = 9;
            label1.Text = "Seleccione fecha desde:";
            // 
            // lblAvisoMontoMal
            // 
            lblAvisoMontoMal.AutoSize = true;
            lblAvisoMontoMal.BackColor = Color.Transparent;
            lblAvisoMontoMal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAvisoMontoMal.ForeColor = Color.Black;
            lblAvisoMontoMal.Location = new Point(93, 5);
            lblAvisoMontoMal.Margin = new Padding(5);
            lblAvisoMontoMal.Name = "lblAvisoMontoMal";
            lblAvisoMontoMal.Size = new Size(180, 21);
            lblAvisoMontoMal.TabIndex = 8;
            lblAvisoMontoMal.Text = "PERIODO DE ANALISIS";
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
            // SelectorPeriodo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Óptica_SurinBlanco;
            ClientSize = new Size(404, 181);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SelectorPeriodo";
            Text = "Selección período ";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private DateTimePicker dTPFechaHasta;
        private DateTimePicker dTPFechaDesde;
        private Label label2;
        private Label label1;
        private Label lblAvisoMontoMal;
        private Button btnAceptar;
    }
}