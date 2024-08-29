namespace OpricaSurinV2.Pantallas
{
    partial class MuestraReceta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MuestraReceta));
            panelReceta = new Panel();
            TBoxNombre = new TextBox();
            lblFechaRecetaCompletar = new Label();
            lblNombre = new Label();
            TBoxObservaciones = new TextBox();
            lblObservaciones = new Label();
            lblFecha = new Label();
            TBoxDoctorReceta = new TextBox();
            label1 = new Label();
            panelCerca = new Panel();
            checkBoxCerca = new CheckBox();
            TBoxDNPICerca = new TextBox();
            label8 = new Label();
            TBoxGradosIzqCerca = new TextBox();
            label9 = new Label();
            TBoxCilIzqCerca = new TextBox();
            label10 = new Label();
            TBoxOIzqEsfericoCerca = new TextBox();
            label11 = new Label();
            TBoxDNPDCerca = new TextBox();
            label12 = new Label();
            TBoxGradosDerCerca = new TextBox();
            label13 = new Label();
            TBoxCilDerCerca = new TextBox();
            label14 = new Label();
            TBoxODerEsfericoCerca = new TextBox();
            label15 = new Label();
            lblCerca = new Label();
            panelLejos = new Panel();
            checkBoxLejos = new CheckBox();
            lblLejos = new Label();
            TBoxDNPILejos = new TextBox();
            label4 = new Label();
            TBoxGradosIzqLejos = new TextBox();
            label5 = new Label();
            TBoxCilIzqLejos = new TextBox();
            label6 = new Label();
            TBoxOIzqEsfericoLejos = new TextBox();
            label7 = new Label();
            TBoxDNPDLejos = new TextBox();
            label3 = new Label();
            TBoxGradosDerLejos = new TextBox();
            label2 = new Label();
            TBoxCilDerLejos = new TextBox();
            lblCilODL = new Label();
            TBoxODerEsfericoLejos = new TextBox();
            lblODEsf = new Label();
            btnSeleccionarReceta = new Button();
            btnEditarReceta = new Button();
            btnCancelar = new Button();
            btnConfirmarEdicion = new Button();
            panelReceta.SuspendLayout();
            panelCerca.SuspendLayout();
            panelLejos.SuspendLayout();
            SuspendLayout();
            // 
            // panelReceta
            // 
            panelReceta.BackColor = Color.White;
            panelReceta.BorderStyle = BorderStyle.FixedSingle;
            panelReceta.Controls.Add(TBoxNombre);
            panelReceta.Controls.Add(lblFechaRecetaCompletar);
            panelReceta.Controls.Add(lblNombre);
            panelReceta.Controls.Add(TBoxObservaciones);
            panelReceta.Controls.Add(lblObservaciones);
            panelReceta.Controls.Add(lblFecha);
            panelReceta.Controls.Add(TBoxDoctorReceta);
            panelReceta.Controls.Add(label1);
            panelReceta.Controls.Add(panelCerca);
            panelReceta.Controls.Add(panelLejos);
            panelReceta.Location = new Point(12, 12);
            panelReceta.Name = "panelReceta";
            panelReceta.Size = new Size(609, 303);
            panelReceta.TabIndex = 48;
            // 
            // TBoxNombre
            // 
            TBoxNombre.BorderStyle = BorderStyle.FixedSingle;
            TBoxNombre.Cursor = Cursors.IBeam;
            TBoxNombre.Enabled = false;
            TBoxNombre.Location = new Point(134, 21);
            TBoxNombre.Name = "TBoxNombre";
            TBoxNombre.Size = new Size(309, 23);
            TBoxNombre.TabIndex = 50;
            // 
            // lblFechaRecetaCompletar
            // 
            lblFechaRecetaCompletar.AutoSize = true;
            lblFechaRecetaCompletar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFechaRecetaCompletar.Location = new Point(473, 24);
            lblFechaRecetaCompletar.Name = "lblFechaRecetaCompletar";
            lblFechaRecetaCompletar.Size = new Size(74, 17);
            lblFechaRecetaCompletar.TabIndex = 51;
            lblFechaRecetaCompletar.Text = "dd/mm/aa";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.BackColor = Color.White;
            lblNombre.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.ForeColor = Color.Black;
            lblNombre.Location = new Point(18, 24);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(110, 15);
            lblNombre.TabIndex = 49;
            lblNombre.Text = "Nombre y Apellido:";
            // 
            // TBoxObservaciones
            // 
            TBoxObservaciones.BorderStyle = BorderStyle.FixedSingle;
            TBoxObservaciones.Cursor = Cursors.IBeam;
            TBoxObservaciones.Enabled = false;
            TBoxObservaciones.Location = new Point(112, 241);
            TBoxObservaciones.Name = "TBoxObservaciones";
            TBoxObservaciones.Size = new Size(465, 23);
            TBoxObservaciones.TabIndex = 24;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.BackColor = Color.White;
            lblObservaciones.Location = new Point(18, 244);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(87, 15);
            lblObservaciones.TabIndex = 23;
            lblObservaciones.Text = "Observaciones:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.BackColor = Color.White;
            lblFecha.Location = new Point(460, 7);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(107, 15);
            lblFecha.TabIndex = 21;
            lblFecha.Text = "Fecha de la Receta:";
            // 
            // TBoxDoctorReceta
            // 
            TBoxDoctorReceta.BorderStyle = BorderStyle.FixedSingle;
            TBoxDoctorReceta.Cursor = Cursors.IBeam;
            TBoxDoctorReceta.Enabled = false;
            TBoxDoctorReceta.Location = new Point(112, 270);
            TBoxDoctorReceta.Name = "TBoxDoctorReceta";
            TBoxDoctorReceta.Size = new Size(234, 23);
            TBoxDoctorReceta.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Location = new Point(18, 274);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 19;
            label1.Text = "Receta Dr:";
            // 
            // panelCerca
            // 
            panelCerca.BackColor = Color.White;
            panelCerca.BorderStyle = BorderStyle.FixedSingle;
            panelCerca.Controls.Add(checkBoxCerca);
            panelCerca.Controls.Add(TBoxDNPICerca);
            panelCerca.Controls.Add(label8);
            panelCerca.Controls.Add(TBoxGradosIzqCerca);
            panelCerca.Controls.Add(label9);
            panelCerca.Controls.Add(TBoxCilIzqCerca);
            panelCerca.Controls.Add(label10);
            panelCerca.Controls.Add(TBoxOIzqEsfericoCerca);
            panelCerca.Controls.Add(label11);
            panelCerca.Controls.Add(TBoxDNPDCerca);
            panelCerca.Controls.Add(label12);
            panelCerca.Controls.Add(TBoxGradosDerCerca);
            panelCerca.Controls.Add(label13);
            panelCerca.Controls.Add(TBoxCilDerCerca);
            panelCerca.Controls.Add(label14);
            panelCerca.Controls.Add(TBoxODerEsfericoCerca);
            panelCerca.Controls.Add(label15);
            panelCerca.Controls.Add(lblCerca);
            panelCerca.Location = new Point(18, 144);
            panelCerca.Name = "panelCerca";
            panelCerca.Size = new Size(574, 87);
            panelCerca.TabIndex = 1;
            // 
            // checkBoxCerca
            // 
            checkBoxCerca.AutoSize = true;
            checkBoxCerca.Enabled = false;
            checkBoxCerca.Location = new Point(80, 4);
            checkBoxCerca.Name = "checkBoxCerca";
            checkBoxCerca.Size = new Size(99, 19);
            checkBoxCerca.TabIndex = 56;
            checkBoxCerca.Text = "No completar";
            checkBoxCerca.UseVisualStyleBackColor = true;
            // 
            // TBoxDNPICerca
            // 
            TBoxDNPICerca.BorderStyle = BorderStyle.FixedSingle;
            TBoxDNPICerca.Cursor = Cursors.IBeam;
            TBoxDNPICerca.Enabled = false;
            TBoxDNPICerca.Location = new Point(488, 55);
            TBoxDNPICerca.Name = "TBoxDNPICerca";
            TBoxDNPICerca.Size = new Size(75, 23);
            TBoxDNPICerca.TabIndex = 52;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(438, 58);
            label8.Name = "label8";
            label8.Size = new Size(37, 15);
            label8.TabIndex = 51;
            label8.Text = "DNPI:";
            // 
            // TBoxGradosIzqCerca
            // 
            TBoxGradosIzqCerca.BorderStyle = BorderStyle.FixedSingle;
            TBoxGradosIzqCerca.Cursor = Cursors.IBeam;
            TBoxGradosIzqCerca.Enabled = false;
            TBoxGradosIzqCerca.Location = new Point(368, 55);
            TBoxGradosIzqCerca.Name = "TBoxGradosIzqCerca";
            TBoxGradosIzqCerca.Size = new Size(57, 23);
            TBoxGradosIzqCerca.TabIndex = 50;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(343, 58);
            label9.Name = "label9";
            label9.Size = new Size(20, 15);
            label9.TabIndex = 49;
            label9.Text = "en";
            // 
            // TBoxCilIzqCerca
            // 
            TBoxCilIzqCerca.BorderStyle = BorderStyle.FixedSingle;
            TBoxCilIzqCerca.Cursor = Cursors.IBeam;
            TBoxCilIzqCerca.Enabled = false;
            TBoxCilIzqCerca.Location = new Point(261, 55);
            TBoxCilIzqCerca.Name = "TBoxCilIzqCerca";
            TBoxCilIzqCerca.Size = new Size(67, 23);
            TBoxCilIzqCerca.TabIndex = 48;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(223, 58);
            label10.Name = "label10";
            label10.Size = new Size(24, 15);
            label10.TabIndex = 47;
            label10.Text = "Cil.";
            // 
            // TBoxOIzqEsfericoCerca
            // 
            TBoxOIzqEsfericoCerca.BorderStyle = BorderStyle.FixedSingle;
            TBoxOIzqEsfericoCerca.Cursor = Cursors.IBeam;
            TBoxOIzqEsfericoCerca.Enabled = false;
            TBoxOIzqEsfericoCerca.Location = new Point(80, 55);
            TBoxOIzqEsfericoCerca.Name = "TBoxOIzqEsfericoCerca";
            TBoxOIzqEsfericoCerca.Size = new Size(131, 23);
            TBoxOIzqEsfericoCerca.TabIndex = 46;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(23, 58);
            label11.Name = "label11";
            label11.Size = new Size(47, 21);
            label11.TabIndex = 45;
            label11.Text = "O. I. Esf.";
            label11.UseCompatibleTextRendering = true;
            // 
            // TBoxDNPDCerca
            // 
            TBoxDNPDCerca.BorderStyle = BorderStyle.FixedSingle;
            TBoxDNPDCerca.Cursor = Cursors.IBeam;
            TBoxDNPDCerca.Enabled = false;
            TBoxDNPDCerca.Location = new Point(488, 29);
            TBoxDNPDCerca.Name = "TBoxDNPDCerca";
            TBoxDNPDCerca.Size = new Size(75, 23);
            TBoxDNPDCerca.TabIndex = 44;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(438, 31);
            label12.Name = "label12";
            label12.Size = new Size(42, 15);
            label12.TabIndex = 43;
            label12.Text = "DNPD:";
            // 
            // TBoxGradosDerCerca
            // 
            TBoxGradosDerCerca.BorderStyle = BorderStyle.FixedSingle;
            TBoxGradosDerCerca.Cursor = Cursors.IBeam;
            TBoxGradosDerCerca.Enabled = false;
            TBoxGradosDerCerca.Location = new Point(368, 28);
            TBoxGradosDerCerca.Name = "TBoxGradosDerCerca";
            TBoxGradosDerCerca.Size = new Size(57, 23);
            TBoxGradosDerCerca.TabIndex = 42;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(343, 31);
            label13.Name = "label13";
            label13.Size = new Size(20, 15);
            label13.TabIndex = 41;
            label13.Text = "en";
            // 
            // TBoxCilDerCerca
            // 
            TBoxCilDerCerca.BorderStyle = BorderStyle.FixedSingle;
            TBoxCilDerCerca.Cursor = Cursors.IBeam;
            TBoxCilDerCerca.Enabled = false;
            TBoxCilDerCerca.Location = new Point(261, 28);
            TBoxCilDerCerca.Name = "TBoxCilDerCerca";
            TBoxCilDerCerca.Size = new Size(67, 23);
            TBoxCilDerCerca.TabIndex = 40;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(223, 31);
            label14.Name = "label14";
            label14.Size = new Size(24, 15);
            label14.TabIndex = 39;
            label14.Text = "Cil.";
            // 
            // TBoxODerEsfericoCerca
            // 
            TBoxODerEsfericoCerca.BorderStyle = BorderStyle.FixedSingle;
            TBoxODerEsfericoCerca.Cursor = Cursors.IBeam;
            TBoxODerEsfericoCerca.Enabled = false;
            TBoxODerEsfericoCerca.Location = new Point(80, 28);
            TBoxODerEsfericoCerca.Name = "TBoxODerEsfericoCerca";
            TBoxODerEsfericoCerca.Size = new Size(131, 23);
            TBoxODerEsfericoCerca.TabIndex = 38;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(23, 31);
            label15.Name = "label15";
            label15.Size = new Size(53, 21);
            label15.TabIndex = 37;
            label15.Text = "O. D. Esf.";
            label15.UseCompatibleTextRendering = true;
            // 
            // lblCerca
            // 
            lblCerca.AutoSize = true;
            lblCerca.BackColor = SystemColors.ActiveCaptionText;
            lblCerca.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCerca.ForeColor = SystemColors.ButtonFace;
            lblCerca.Location = new Point(6, 4);
            lblCerca.Name = "lblCerca";
            lblCerca.Size = new Size(52, 17);
            lblCerca.TabIndex = 23;
            lblCerca.Text = "CERCA:";
            // 
            // panelLejos
            // 
            panelLejos.BackColor = Color.White;
            panelLejos.BorderStyle = BorderStyle.FixedSingle;
            panelLejos.Controls.Add(checkBoxLejos);
            panelLejos.Controls.Add(lblLejos);
            panelLejos.Controls.Add(TBoxDNPILejos);
            panelLejos.Controls.Add(label4);
            panelLejos.Controls.Add(TBoxGradosIzqLejos);
            panelLejos.Controls.Add(label5);
            panelLejos.Controls.Add(TBoxCilIzqLejos);
            panelLejos.Controls.Add(label6);
            panelLejos.Controls.Add(TBoxOIzqEsfericoLejos);
            panelLejos.Controls.Add(label7);
            panelLejos.Controls.Add(TBoxDNPDLejos);
            panelLejos.Controls.Add(label3);
            panelLejos.Controls.Add(TBoxGradosDerLejos);
            panelLejos.Controls.Add(label2);
            panelLejos.Controls.Add(TBoxCilDerLejos);
            panelLejos.Controls.Add(lblCilODL);
            panelLejos.Controls.Add(TBoxODerEsfericoLejos);
            panelLejos.Controls.Add(lblODEsf);
            panelLejos.Location = new Point(18, 52);
            panelLejos.Name = "panelLejos";
            panelLejos.Size = new Size(574, 87);
            panelLejos.TabIndex = 0;
            // 
            // checkBoxLejos
            // 
            checkBoxLejos.AutoSize = true;
            checkBoxLejos.Enabled = false;
            checkBoxLejos.Location = new Point(80, 4);
            checkBoxLejos.Name = "checkBoxLejos";
            checkBoxLejos.Size = new Size(99, 19);
            checkBoxLejos.TabIndex = 55;
            checkBoxLejos.Text = "No completar";
            checkBoxLejos.UseVisualStyleBackColor = true;
            // 
            // lblLejos
            // 
            lblLejos.AutoSize = true;
            lblLejos.BackColor = SystemColors.ActiveCaptionText;
            lblLejos.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLejos.ForeColor = SystemColors.ButtonFace;
            lblLejos.Location = new Point(6, 4);
            lblLejos.Name = "lblLejos";
            lblLejos.Size = new Size(49, 17);
            lblLejos.TabIndex = 21;
            lblLejos.Text = "LEJOS:";
            // 
            // TBoxDNPILejos
            // 
            TBoxDNPILejos.BorderStyle = BorderStyle.FixedSingle;
            TBoxDNPILejos.Cursor = Cursors.IBeam;
            TBoxDNPILejos.Enabled = false;
            TBoxDNPILejos.Location = new Point(488, 55);
            TBoxDNPILejos.Name = "TBoxDNPILejos";
            TBoxDNPILejos.Size = new Size(75, 23);
            TBoxDNPILejos.TabIndex = 36;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(438, 58);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 35;
            label4.Text = "DNPI:";
            // 
            // TBoxGradosIzqLejos
            // 
            TBoxGradosIzqLejos.BorderStyle = BorderStyle.FixedSingle;
            TBoxGradosIzqLejos.Cursor = Cursors.IBeam;
            TBoxGradosIzqLejos.Enabled = false;
            TBoxGradosIzqLejos.Location = new Point(368, 55);
            TBoxGradosIzqLejos.Name = "TBoxGradosIzqLejos";
            TBoxGradosIzqLejos.Size = new Size(57, 23);
            TBoxGradosIzqLejos.TabIndex = 34;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(343, 58);
            label5.Name = "label5";
            label5.Size = new Size(20, 15);
            label5.TabIndex = 33;
            label5.Text = "en";
            // 
            // TBoxCilIzqLejos
            // 
            TBoxCilIzqLejos.BorderStyle = BorderStyle.FixedSingle;
            TBoxCilIzqLejos.Cursor = Cursors.IBeam;
            TBoxCilIzqLejos.Enabled = false;
            TBoxCilIzqLejos.Location = new Point(261, 55);
            TBoxCilIzqLejos.Name = "TBoxCilIzqLejos";
            TBoxCilIzqLejos.Size = new Size(67, 23);
            TBoxCilIzqLejos.TabIndex = 32;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(223, 58);
            label6.Name = "label6";
            label6.Size = new Size(24, 15);
            label6.TabIndex = 31;
            label6.Text = "Cil.";
            // 
            // TBoxOIzqEsfericoLejos
            // 
            TBoxOIzqEsfericoLejos.BorderStyle = BorderStyle.FixedSingle;
            TBoxOIzqEsfericoLejos.Cursor = Cursors.IBeam;
            TBoxOIzqEsfericoLejos.Enabled = false;
            TBoxOIzqEsfericoLejos.Location = new Point(80, 55);
            TBoxOIzqEsfericoLejos.Name = "TBoxOIzqEsfericoLejos";
            TBoxOIzqEsfericoLejos.Size = new Size(131, 23);
            TBoxOIzqEsfericoLejos.TabIndex = 30;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(23, 58);
            label7.Name = "label7";
            label7.Size = new Size(47, 21);
            label7.TabIndex = 29;
            label7.Text = "O. I. Esf.";
            label7.UseCompatibleTextRendering = true;
            // 
            // TBoxDNPDLejos
            // 
            TBoxDNPDLejos.BorderStyle = BorderStyle.FixedSingle;
            TBoxDNPDLejos.Cursor = Cursors.IBeam;
            TBoxDNPDLejos.Enabled = false;
            TBoxDNPDLejos.Location = new Point(488, 28);
            TBoxDNPDLejos.Name = "TBoxDNPDLejos";
            TBoxDNPDLejos.Size = new Size(75, 23);
            TBoxDNPDLejos.TabIndex = 28;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(438, 31);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 27;
            label3.Text = "DNPD:";
            // 
            // TBoxGradosDerLejos
            // 
            TBoxGradosDerLejos.BorderStyle = BorderStyle.FixedSingle;
            TBoxGradosDerLejos.Cursor = Cursors.IBeam;
            TBoxGradosDerLejos.Enabled = false;
            TBoxGradosDerLejos.Location = new Point(368, 28);
            TBoxGradosDerLejos.Name = "TBoxGradosDerLejos";
            TBoxGradosDerLejos.Size = new Size(57, 23);
            TBoxGradosDerLejos.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(343, 31);
            label2.Name = "label2";
            label2.Size = new Size(20, 15);
            label2.TabIndex = 25;
            label2.Text = "en";
            // 
            // TBoxCilDerLejos
            // 
            TBoxCilDerLejos.BorderStyle = BorderStyle.FixedSingle;
            TBoxCilDerLejos.Cursor = Cursors.IBeam;
            TBoxCilDerLejos.Enabled = false;
            TBoxCilDerLejos.Location = new Point(261, 28);
            TBoxCilDerLejos.Name = "TBoxCilDerLejos";
            TBoxCilDerLejos.Size = new Size(67, 23);
            TBoxCilDerLejos.TabIndex = 24;
            // 
            // lblCilODL
            // 
            lblCilODL.AutoSize = true;
            lblCilODL.Location = new Point(223, 31);
            lblCilODL.Name = "lblCilODL";
            lblCilODL.Size = new Size(24, 15);
            lblCilODL.TabIndex = 23;
            lblCilODL.Text = "Cil.";
            // 
            // TBoxODerEsfericoLejos
            // 
            TBoxODerEsfericoLejos.BorderStyle = BorderStyle.FixedSingle;
            TBoxODerEsfericoLejos.Cursor = Cursors.IBeam;
            TBoxODerEsfericoLejos.Enabled = false;
            TBoxODerEsfericoLejos.Location = new Point(80, 28);
            TBoxODerEsfericoLejos.Name = "TBoxODerEsfericoLejos";
            TBoxODerEsfericoLejos.Size = new Size(131, 23);
            TBoxODerEsfericoLejos.TabIndex = 22;
            // 
            // lblODEsf
            // 
            lblODEsf.AutoSize = true;
            lblODEsf.Location = new Point(23, 31);
            lblODEsf.Name = "lblODEsf";
            lblODEsf.Size = new Size(53, 21);
            lblODEsf.TabIndex = 21;
            lblODEsf.Text = "O. D. Esf.";
            lblODEsf.UseCompatibleTextRendering = true;
            // 
            // btnSeleccionarReceta
            // 
            btnSeleccionarReceta.BackColor = Color.FromArgb(164, 198, 57);
            btnSeleccionarReceta.Cursor = Cursors.Hand;
            btnSeleccionarReceta.FlatStyle = FlatStyle.Popup;
            btnSeleccionarReceta.Location = new Point(264, 321);
            btnSeleccionarReceta.Name = "btnSeleccionarReceta";
            btnSeleccionarReceta.Size = new Size(105, 25);
            btnSeleccionarReceta.TabIndex = 49;
            btnSeleccionarReceta.Text = "Seleccionar";
            btnSeleccionarReceta.UseVisualStyleBackColor = false;
            btnSeleccionarReceta.Click += btnSeleccionarReceta_Click;
            // 
            // btnEditarReceta
            // 
            btnEditarReceta.BackColor = Color.SeaGreen;
            btnEditarReceta.Cursor = Cursors.Hand;
            btnEditarReceta.FlatStyle = FlatStyle.Popup;
            btnEditarReceta.Location = new Point(391, 321);
            btnEditarReceta.Name = "btnEditarReceta";
            btnEditarReceta.Size = new Size(105, 25);
            btnEditarReceta.TabIndex = 52;
            btnEditarReceta.Text = "Editar receta";
            btnEditarReceta.UseVisualStyleBackColor = false;
            btnEditarReceta.Click += btnEditarReceta_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(220, 100, 100);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderColor = Color.Black;
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(137, 321);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 25);
            btnCancelar.TabIndex = 53;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnConfirmarEdicion
            // 
            btnConfirmarEdicion.BackColor = Color.FromArgb(164, 198, 57);
            btnConfirmarEdicion.Cursor = Cursors.Hand;
            btnConfirmarEdicion.FlatStyle = FlatStyle.Popup;
            btnConfirmarEdicion.Location = new Point(502, 321);
            btnConfirmarEdicion.Name = "btnConfirmarEdicion";
            btnConfirmarEdicion.Size = new Size(120, 25);
            btnConfirmarEdicion.TabIndex = 54;
            btnConfirmarEdicion.Text = "Confirmar edición";
            btnConfirmarEdicion.UseVisualStyleBackColor = false;
            btnConfirmarEdicion.Click += btnConfirmarEdicion_Click;
            // 
            // MuestraReceta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = OpticaSurinV2.Properties.Resources.fotoOptica;
            ClientSize = new Size(634, 362);
            Controls.Add(btnConfirmarEdicion);
            Controls.Add(btnEditarReceta);
            Controls.Add(btnCancelar);
            Controls.Add(btnSeleccionarReceta);
            Controls.Add(panelReceta);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MuestraReceta";
            Text = "Receta";
            panelReceta.ResumeLayout(false);
            panelReceta.PerformLayout();
            panelCerca.ResumeLayout(false);
            panelCerca.PerformLayout();
            panelLejos.ResumeLayout(false);
            panelLejos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelReceta;
        private Label lblFechaRecetaCompletar;
        private TextBox TBoxObservaciones;
        private Label lblObservaciones;
        private Label lblFecha;
        private TextBox TBoxDoctorReceta;
        private Label label1;
        private Panel panelCerca;
        private TextBox TBoxDNPICerca;
        private Label label8;
        private TextBox TBoxGradosIzqCerca;
        private Label label9;
        private TextBox TBoxCilIzqCerca;
        private Label label10;
        private TextBox TBoxOIzqEsfericoCerca;
        private Label label11;
        private TextBox TBoxDNPDCerca;
        private Label label12;
        private TextBox TBoxGradosDerCerca;
        private Label label13;
        private TextBox TBoxCilDerCerca;
        private Label label14;
        private TextBox TBoxODerEsfericoCerca;
        private Label label15;
        private Label lblCerca;
        private Panel panelLejos;
        private Label lblLejos;
        private TextBox TBoxDNPILejos;
        private Label label4;
        private TextBox TBoxGradosIzqLejos;
        private Label label5;
        private TextBox TBoxCilIzqLejos;
        private Label label6;
        private TextBox TBoxOIzqEsfericoLejos;
        private Label label7;
        private TextBox TBoxDNPDLejos;
        private Label label3;
        private TextBox TBoxGradosDerLejos;
        private Label label2;
        private TextBox TBoxCilDerLejos;
        private Label lblCilODL;
        private TextBox TBoxODerEsfericoLejos;
        private Label lblODEsf;
        private TextBox TBoxNombre;
        private Label lblNombre;
        private Button btnSeleccionarReceta;
        private Button btnEditarReceta;
        private Button btnCancelar;
        private Button btnConfirmarEdicion;
        private CheckBox checkBoxLejos;
        private CheckBox checkBoxCerca;
    }
}