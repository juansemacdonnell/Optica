namespace OpticaSurinV2.Pantallas
{
    partial class PantallaInformeFinal
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaInformeFinal));
            panel1 = new Panel();
            btnCambiarAnio = new Button();
            btnAtras = new Button();
            panel3 = new Panel();
            label8 = new Label();
            panel8 = new Panel();
            label1 = new Label();
            TBoxArregloTotal = new TextBox();
            TBoxSolTotal = new TextBox();
            panel29 = new Panel();
            label21 = new Label();
            TBoxRecetaTotal = new TextBox();
            panel31 = new Panel();
            label22 = new Label();
            panel33 = new Panel();
            label23 = new Label();
            TBoxCantidadTotalPedidos = new TextBox();
            panel2 = new Panel();
            label7 = new Label();
            TBoxTransferenciaCompletar = new TextBox();
            TBoxTarjetaCompletar = new TextBox();
            panel7 = new Panel();
            label4 = new Label();
            TBoxEfectivoCompletar = new TextBox();
            panel6 = new Panel();
            label3 = new Label();
            panel5 = new Panel();
            label2 = new Label();
            TBoxTotalCompletar = new TextBox();
            panel4 = new Panel();
            lblIngresosTotales = new Label();
            panelDatosGenerales = new Panel();
            TBoxIngresoPromedioMensualCompletar = new TextBox();
            panel12 = new Panel();
            label11 = new Label();
            TBoxMesMenosVendidoCompletar = new TextBox();
            panel11 = new Panel();
            lblMesMenosVendidoCompletar = new Label();
            label10 = new Label();
            TBoxMesMasVendidoCompletar = new TextBox();
            panel10 = new Panel();
            lblMesMasVendidoCompletar = new Label();
            label6 = new Label();
            TBoxTotalFacturadoAuto = new TextBox();
            panel9 = new Panel();
            label5 = new Label();
            lblNumeroMes = new Label();
            lblTotalVentas = new Label();
            lblTituloGrafico = new Label();
            histogramaFrecuencias = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel8.SuspendLayout();
            panel29.SuspendLayout();
            panel31.SuspendLayout();
            panel33.SuspendLayout();
            panel2.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panelDatosGenerales.SuspendLayout();
            panel12.SuspendLayout();
            panel11.SuspendLayout();
            panel10.SuspendLayout();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)histogramaFrecuencias).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnCambiarAnio);
            panel1.Controls.Add(btnAtras);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panelDatosGenerales);
            panel1.Controls.Add(lblNumeroMes);
            panel1.Controls.Add(lblTotalVentas);
            panel1.Controls.Add(lblTituloGrafico);
            panel1.Controls.Add(histogramaFrecuencias);
            panel1.Location = new Point(88, 60);
            panel1.Name = "panel1";
            panel1.Size = new Size(1200, 594);
            panel1.TabIndex = 0;
            // 
            // btnCambiarAnio
            // 
            btnCambiarAnio.BackColor = Color.FromArgb(108, 166, 205);
            btnCambiarAnio.Cursor = Cursors.Hand;
            btnCambiarAnio.FlatStyle = FlatStyle.Popup;
            btnCambiarAnio.Location = new Point(1026, 9);
            btnCambiarAnio.Name = "btnCambiarAnio";
            btnCambiarAnio.Size = new Size(160, 40);
            btnCambiarAnio.TabIndex = 60;
            btnCambiarAnio.Text = "Cambiar Año";
            btnCambiarAnio.UseVisualStyleBackColor = false;
            btnCambiarAnio.Click += btnCambiarAnio_Click;
            // 
            // btnAtras
            // 
            btnAtras.BackColor = Color.FromArgb(220, 100, 100);
            btnAtras.Cursor = Cursors.Hand;
            btnAtras.FlatAppearance.BorderColor = Color.Black;
            btnAtras.FlatStyle = FlatStyle.Popup;
            btnAtras.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAtras.Location = new Point(520, 545);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new Size(160, 40);
            btnAtras.TabIndex = 35;
            btnAtras.Text = "Cerrar";
            btnAtras.UseVisualStyleBackColor = false;
            btnAtras.Click += btnAtras_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(108, 166, 205);
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label8);
            panel3.Controls.Add(panel8);
            panel3.Controls.Add(TBoxArregloTotal);
            panel3.Controls.Add(TBoxSolTotal);
            panel3.Controls.Add(panel29);
            panel3.Controls.Add(TBoxRecetaTotal);
            panel3.Controls.Add(panel31);
            panel3.Controls.Add(panel33);
            panel3.Controls.Add(TBoxCantidadTotalPedidos);
            panel3.Location = new Point(885, 337);
            panel3.Name = "panel3";
            panel3.Size = new Size(285, 199);
            panel3.TabIndex = 33;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(51, 81);
            label8.Name = "label8";
            label8.Size = new Size(182, 17);
            label8.TabIndex = 49;
            label8.Text = "INGRESOS POR PRODUCTOS";
            // 
            // panel8
            // 
            panel8.BackColor = Color.White;
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(label1);
            panel8.Location = new Point(26, 9);
            panel8.Name = "panel8";
            panel8.Size = new Size(231, 36);
            panel8.TabIndex = 48;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(28, 5);
            label1.Name = "label1";
            label1.Size = new Size(175, 25);
            label1.TabIndex = 2;
            label1.Text = "PEDIDOS TOTALES";
            // 
            // TBoxArregloTotal
            // 
            TBoxArregloTotal.BorderStyle = BorderStyle.FixedSingle;
            TBoxArregloTotal.Enabled = false;
            TBoxArregloTotal.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TBoxArregloTotal.Location = new Point(149, 166);
            TBoxArregloTotal.Name = "TBoxArregloTotal";
            TBoxArregloTotal.Size = new Size(83, 27);
            TBoxArregloTotal.TabIndex = 45;
            TBoxArregloTotal.Text = "$ 20000";
            TBoxArregloTotal.TextAlign = HorizontalAlignment.Center;
            // 
            // TBoxSolTotal
            // 
            TBoxSolTotal.BorderStyle = BorderStyle.FixedSingle;
            TBoxSolTotal.Enabled = false;
            TBoxSolTotal.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TBoxSolTotal.Location = new Point(149, 134);
            TBoxSolTotal.Name = "TBoxSolTotal";
            TBoxSolTotal.Size = new Size(83, 27);
            TBoxSolTotal.TabIndex = 46;
            TBoxSolTotal.Text = "$ 20000";
            TBoxSolTotal.TextAlign = HorizontalAlignment.Center;
            // 
            // panel29
            // 
            panel29.BackColor = Color.White;
            panel29.Controls.Add(label21);
            panel29.Location = new Point(51, 166);
            panel29.Name = "panel29";
            panel29.Size = new Size(79, 26);
            panel29.TabIndex = 43;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label21.Location = new Point(9, 3);
            label21.Name = "label21";
            label21.Size = new Size(62, 20);
            label21.TabIndex = 37;
            label21.Text = "Arreglo";
            // 
            // TBoxRecetaTotal
            // 
            TBoxRecetaTotal.BorderStyle = BorderStyle.FixedSingle;
            TBoxRecetaTotal.Enabled = false;
            TBoxRecetaTotal.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TBoxRecetaTotal.Location = new Point(149, 102);
            TBoxRecetaTotal.Name = "TBoxRecetaTotal";
            TBoxRecetaTotal.Size = new Size(83, 27);
            TBoxRecetaTotal.TabIndex = 42;
            TBoxRecetaTotal.Text = "$ 20000";
            TBoxRecetaTotal.TextAlign = HorizontalAlignment.Center;
            // 
            // panel31
            // 
            panel31.BackColor = Color.White;
            panel31.Controls.Add(label22);
            panel31.Location = new Point(51, 134);
            panel31.Name = "panel31";
            panel31.Size = new Size(79, 26);
            panel31.TabIndex = 44;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label22.Location = new Point(24, 3);
            label22.Name = "label22";
            label22.Size = new Size(46, 20);
            label22.TabIndex = 37;
            label22.Text = "Sol    ";
            // 
            // panel33
            // 
            panel33.BackColor = Color.White;
            panel33.Controls.Add(label23);
            panel33.Location = new Point(51, 102);
            panel33.Name = "panel33";
            panel33.Size = new Size(79, 26);
            panel33.TabIndex = 41;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label23.Location = new Point(12, 3);
            label23.Name = "label23";
            label23.Size = new Size(56, 20);
            label23.TabIndex = 36;
            label23.Text = "Receta";
            // 
            // TBoxCantidadTotalPedidos
            // 
            TBoxCantidadTotalPedidos.BorderStyle = BorderStyle.FixedSingle;
            TBoxCantidadTotalPedidos.Enabled = false;
            TBoxCantidadTotalPedidos.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TBoxCantidadTotalPedidos.Location = new Point(75, 51);
            TBoxCantidadTotalPedidos.Name = "TBoxCantidadTotalPedidos";
            TBoxCantidadTotalPedidos.Size = new Size(140, 27);
            TBoxCantidadTotalPedidos.TabIndex = 40;
            TBoxCantidadTotalPedidos.Text = "$ 20000";
            TBoxCantidadTotalPedidos.TextAlign = HorizontalAlignment.Center;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(164, 198, 57);
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label7);
            panel2.Controls.Add(TBoxTransferenciaCompletar);
            panel2.Controls.Add(TBoxTarjetaCompletar);
            panel2.Controls.Add(panel7);
            panel2.Controls.Add(TBoxEfectivoCompletar);
            panel2.Controls.Add(panel6);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(TBoxTotalCompletar);
            panel2.Controls.Add(panel4);
            panel2.Location = new Point(595, 337);
            panel2.Name = "panel2";
            panel2.Size = new Size(285, 199);
            panel2.TabIndex = 32;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(34, 81);
            label7.Name = "label7";
            label7.Size = new Size(214, 17);
            label7.TabIndex = 54;
            label7.Text = "INGRESOS POR MEDIOS DE PAGO";
            // 
            // TBoxTransferenciaCompletar
            // 
            TBoxTransferenciaCompletar.BorderStyle = BorderStyle.FixedSingle;
            TBoxTransferenciaCompletar.Enabled = false;
            TBoxTransferenciaCompletar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TBoxTransferenciaCompletar.Location = new Point(166, 165);
            TBoxTransferenciaCompletar.Name = "TBoxTransferenciaCompletar";
            TBoxTransferenciaCompletar.Size = new Size(83, 27);
            TBoxTransferenciaCompletar.TabIndex = 52;
            TBoxTransferenciaCompletar.Text = "$ 20000";
            TBoxTransferenciaCompletar.TextAlign = HorizontalAlignment.Center;
            // 
            // TBoxTarjetaCompletar
            // 
            TBoxTarjetaCompletar.BorderStyle = BorderStyle.FixedSingle;
            TBoxTarjetaCompletar.Enabled = false;
            TBoxTarjetaCompletar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TBoxTarjetaCompletar.Location = new Point(166, 133);
            TBoxTarjetaCompletar.Name = "TBoxTarjetaCompletar";
            TBoxTarjetaCompletar.Size = new Size(83, 27);
            TBoxTarjetaCompletar.TabIndex = 53;
            TBoxTarjetaCompletar.Text = "$ 20000";
            TBoxTarjetaCompletar.TextAlign = HorizontalAlignment.Center;
            // 
            // panel7
            // 
            panel7.BackColor = Color.White;
            panel7.Controls.Add(label4);
            panel7.Location = new Point(34, 165);
            panel7.Name = "panel7";
            panel7.Size = new Size(112, 26);
            panel7.TabIndex = 50;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(5, 2);
            label4.Name = "label4";
            label4.Size = new Size(103, 20);
            label4.TabIndex = 37;
            label4.Text = "Transferencia";
            // 
            // TBoxEfectivoCompletar
            // 
            TBoxEfectivoCompletar.BorderStyle = BorderStyle.FixedSingle;
            TBoxEfectivoCompletar.Enabled = false;
            TBoxEfectivoCompletar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TBoxEfectivoCompletar.Location = new Point(166, 101);
            TBoxEfectivoCompletar.Name = "TBoxEfectivoCompletar";
            TBoxEfectivoCompletar.Size = new Size(83, 27);
            TBoxEfectivoCompletar.TabIndex = 49;
            TBoxEfectivoCompletar.Text = "$ 20000";
            TBoxEfectivoCompletar.TextAlign = HorizontalAlignment.Center;
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.Controls.Add(label3);
            panel6.Location = new Point(34, 133);
            panel6.Name = "panel6";
            panel6.Size = new Size(112, 26);
            panel6.TabIndex = 51;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(27, 2);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 37;
            label3.Text = "Tarjeta    ";
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(label2);
            panel5.Location = new Point(34, 101);
            panel5.Name = "panel5";
            panel5.Size = new Size(112, 26);
            panel5.TabIndex = 48;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(24, 2);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 36;
            label2.Text = "Efectivo  ";
            // 
            // TBoxTotalCompletar
            // 
            TBoxTotalCompletar.BorderStyle = BorderStyle.FixedSingle;
            TBoxTotalCompletar.Enabled = false;
            TBoxTotalCompletar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TBoxTotalCompletar.Location = new Point(75, 51);
            TBoxTotalCompletar.Name = "TBoxTotalCompletar";
            TBoxTotalCompletar.Size = new Size(140, 27);
            TBoxTotalCompletar.TabIndex = 47;
            TBoxTotalCompletar.Text = "$ 20000";
            TBoxTotalCompletar.TextAlign = HorizontalAlignment.Center;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(lblIngresosTotales);
            panel4.Location = new Point(26, 9);
            panel4.Name = "panel4";
            panel4.Size = new Size(231, 36);
            panel4.TabIndex = 46;
            // 
            // lblIngresosTotales
            // 
            lblIngresosTotales.AutoSize = true;
            lblIngresosTotales.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIngresosTotales.Location = new Point(22, 5);
            lblIngresosTotales.Name = "lblIngresosTotales";
            lblIngresosTotales.Size = new Size(187, 25);
            lblIngresosTotales.TabIndex = 2;
            lblIngresosTotales.Text = "INGRESOS TOTALES";
            // 
            // panelDatosGenerales
            // 
            panelDatosGenerales.BackColor = Color.FromArgb(180, 225, 255);
            panelDatosGenerales.BorderStyle = BorderStyle.FixedSingle;
            panelDatosGenerales.Controls.Add(TBoxIngresoPromedioMensualCompletar);
            panelDatosGenerales.Controls.Add(panel12);
            panelDatosGenerales.Controls.Add(TBoxMesMenosVendidoCompletar);
            panelDatosGenerales.Controls.Add(panel11);
            panelDatosGenerales.Controls.Add(TBoxMesMasVendidoCompletar);
            panelDatosGenerales.Controls.Add(panel10);
            panelDatosGenerales.Controls.Add(TBoxTotalFacturadoAuto);
            panelDatosGenerales.Controls.Add(panel9);
            panelDatosGenerales.Location = new Point(30, 337);
            panelDatosGenerales.Name = "panelDatosGenerales";
            panelDatosGenerales.Size = new Size(560, 199);
            panelDatosGenerales.TabIndex = 31;
            // 
            // TBoxIngresoPromedioMensualCompletar
            // 
            TBoxIngresoPromedioMensualCompletar.BorderStyle = BorderStyle.FixedSingle;
            TBoxIngresoPromedioMensualCompletar.Enabled = false;
            TBoxIngresoPromedioMensualCompletar.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TBoxIngresoPromedioMensualCompletar.Location = new Point(427, 146);
            TBoxIngresoPromedioMensualCompletar.Name = "TBoxIngresoPromedioMensualCompletar";
            TBoxIngresoPromedioMensualCompletar.Size = new Size(120, 35);
            TBoxIngresoPromedioMensualCompletar.TabIndex = 54;
            TBoxIngresoPromedioMensualCompletar.Text = "$ 20000";
            TBoxIngresoPromedioMensualCompletar.TextAlign = HorizontalAlignment.Center;
            // 
            // panel12
            // 
            panel12.BackColor = Color.White;
            panel12.BorderStyle = BorderStyle.FixedSingle;
            panel12.Controls.Add(label11);
            panel12.Location = new Point(19, 146);
            panel12.Name = "panel12";
            panel12.Size = new Size(402, 35);
            panel12.TabIndex = 53;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(9, 4);
            label11.Name = "label11";
            label11.Size = new Size(300, 25);
            label11.TabIndex = 2;
            label11.Text = "INGRESO MENSUAL PROMEDIO:";
            // 
            // TBoxMesMenosVendidoCompletar
            // 
            TBoxMesMenosVendidoCompletar.BorderStyle = BorderStyle.FixedSingle;
            TBoxMesMenosVendidoCompletar.Enabled = false;
            TBoxMesMenosVendidoCompletar.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TBoxMesMenosVendidoCompletar.Location = new Point(427, 103);
            TBoxMesMenosVendidoCompletar.Name = "TBoxMesMenosVendidoCompletar";
            TBoxMesMenosVendidoCompletar.Size = new Size(120, 35);
            TBoxMesMenosVendidoCompletar.TabIndex = 52;
            TBoxMesMenosVendidoCompletar.Text = "$ 20000";
            TBoxMesMenosVendidoCompletar.TextAlign = HorizontalAlignment.Center;
            // 
            // panel11
            // 
            panel11.BackColor = Color.White;
            panel11.BorderStyle = BorderStyle.FixedSingle;
            panel11.Controls.Add(lblMesMenosVendidoCompletar);
            panel11.Controls.Add(label10);
            panel11.Location = new Point(19, 103);
            panel11.Name = "panel11";
            panel11.Size = new Size(402, 35);
            panel11.TabIndex = 51;
            // 
            // lblMesMenosVendidoCompletar
            // 
            lblMesMenosVendidoCompletar.AutoSize = true;
            lblMesMenosVendidoCompletar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMesMenosVendidoCompletar.Location = new Point(248, 4);
            lblMesMenosVendidoCompletar.Name = "lblMesMenosVendidoCompletar";
            lblMesMenosVendidoCompletar.Size = new Size(123, 25);
            lblMesMenosVendidoCompletar.TabIndex = 31;
            lblMesMenosVendidoCompletar.Text = "COMPLETAR";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(9, 4);
            label10.Name = "label10";
            label10.Size = new Size(220, 25);
            label10.TabIndex = 2;
            label10.Text = "MES MENOS VENDIDO:";
            // 
            // TBoxMesMasVendidoCompletar
            // 
            TBoxMesMasVendidoCompletar.BorderStyle = BorderStyle.FixedSingle;
            TBoxMesMasVendidoCompletar.Enabled = false;
            TBoxMesMasVendidoCompletar.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TBoxMesMasVendidoCompletar.Location = new Point(427, 60);
            TBoxMesMasVendidoCompletar.Name = "TBoxMesMasVendidoCompletar";
            TBoxMesMasVendidoCompletar.Size = new Size(120, 35);
            TBoxMesMasVendidoCompletar.TabIndex = 50;
            TBoxMesMasVendidoCompletar.Text = "$ 20000";
            TBoxMesMasVendidoCompletar.TextAlign = HorizontalAlignment.Center;
            // 
            // panel10
            // 
            panel10.BackColor = Color.White;
            panel10.BorderStyle = BorderStyle.FixedSingle;
            panel10.Controls.Add(lblMesMasVendidoCompletar);
            panel10.Controls.Add(label6);
            panel10.Location = new Point(19, 60);
            panel10.Name = "panel10";
            panel10.Size = new Size(402, 35);
            panel10.TabIndex = 49;
            // 
            // lblMesMasVendidoCompletar
            // 
            lblMesMasVendidoCompletar.AutoSize = true;
            lblMesMasVendidoCompletar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMesMasVendidoCompletar.Location = new Point(209, 4);
            lblMesMasVendidoCompletar.Name = "lblMesMasVendidoCompletar";
            lblMesMasVendidoCompletar.Size = new Size(123, 25);
            lblMesMasVendidoCompletar.TabIndex = 31;
            lblMesMasVendidoCompletar.Text = "COMPLETAR";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(9, 4);
            label6.Name = "label6";
            label6.Size = new Size(194, 25);
            label6.TabIndex = 2;
            label6.Text = "MES MAS VENDIDO:";
            // 
            // TBoxTotalFacturadoAuto
            // 
            TBoxTotalFacturadoAuto.BorderStyle = BorderStyle.FixedSingle;
            TBoxTotalFacturadoAuto.Enabled = false;
            TBoxTotalFacturadoAuto.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TBoxTotalFacturadoAuto.Location = new Point(427, 18);
            TBoxTotalFacturadoAuto.Name = "TBoxTotalFacturadoAuto";
            TBoxTotalFacturadoAuto.Size = new Size(120, 35);
            TBoxTotalFacturadoAuto.TabIndex = 48;
            TBoxTotalFacturadoAuto.Text = "$ 20000";
            TBoxTotalFacturadoAuto.TextAlign = HorizontalAlignment.Center;
            // 
            // panel9
            // 
            panel9.BackColor = Color.White;
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Controls.Add(label5);
            panel9.Location = new Point(19, 18);
            panel9.Name = "panel9";
            panel9.Size = new Size(402, 35);
            panel9.TabIndex = 47;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(9, 4);
            label5.Name = "label5";
            label5.Size = new Size(382, 25);
            label5.TabIndex = 2;
            label5.Text = "TOTAL FACTURADO AUTOMATICAMENTE:";
            // 
            // lblNumeroMes
            // 
            lblNumeroMes.AutoSize = true;
            lblNumeroMes.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNumeroMes.Location = new Point(1049, 297);
            lblNumeroMes.Name = "lblNumeroMes";
            lblNumeroMes.Size = new Size(106, 17);
            lblNumeroMes.TabIndex = 30;
            lblNumeroMes.Text = "Número de mes";
            // 
            // lblTotalVentas
            // 
            lblTotalVentas.AutoSize = true;
            lblTotalVentas.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalVentas.Location = new Point(30, 35);
            lblTotalVentas.Name = "lblTotalVentas";
            lblTotalVentas.Size = new Size(83, 17);
            lblTotalVentas.TabIndex = 29;
            lblTotalVentas.Text = "Total ventas";
            // 
            // lblTituloGrafico
            // 
            lblTituloGrafico.AutoSize = true;
            lblTituloGrafico.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloGrafico.Location = new Point(530, 13);
            lblTituloGrafico.Name = "lblTituloGrafico";
            lblTituloGrafico.Size = new Size(140, 37);
            lblTituloGrafico.TabIndex = 28;
            lblTituloGrafico.Text = "Año 2024";
            // 
            // histogramaFrecuencias
            // 
            histogramaFrecuencias.BackColor = Color.Transparent;
            chartArea1.Name = "ChartArea1";
            histogramaFrecuencias.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            histogramaFrecuencias.Legends.Add(legend1);
            histogramaFrecuencias.Location = new Point(30, 55);
            histogramaFrecuencias.Margin = new Padding(4, 3, 4, 3);
            histogramaFrecuencias.Name = "histogramaFrecuencias";
            histogramaFrecuencias.Padding = new Padding(0, 0, 12, 0);
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Fo";
            histogramaFrecuencias.Series.Add(series1);
            histogramaFrecuencias.Size = new Size(1140, 277);
            histogramaFrecuencias.TabIndex = 27;
            histogramaFrecuencias.Text = "Histograma de Frecuencias";
            // 
            // PantallaInformeFinal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fotoOptica;
            ClientSize = new Size(1284, 646);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PantallaInformeFinal";
            Text = "Informe Anual";
            Load += PantallaInformeFinal_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel29.ResumeLayout(false);
            panel29.PerformLayout();
            panel31.ResumeLayout(false);
            panel31.PerformLayout();
            panel33.ResumeLayout(false);
            panel33.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panelDatosGenerales.ResumeLayout(false);
            panelDatosGenerales.PerformLayout();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)histogramaFrecuencias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblNumeroMes;
        private Label lblTotalVentas;
        private Label lblTituloGrafico;
        private System.Windows.Forms.DataVisualization.Charting.Chart histogramaFrecuencias;
        private Panel panel3;
        private Panel panel2;
        private Panel panelDatosGenerales;
        private Button btnAtras;
        private Button btnCambiarAnio;
        private TextBox TBoxTransferenciaCompletar;
        private TextBox TBoxTarjetaCompletar;
        private Panel panel7;
        private Label label4;
        private TextBox TBoxEfectivoCompletar;
        private Panel panel6;
        private Label label3;
        private Panel panel5;
        private Label label2;
        private TextBox TBoxTotalCompletar;
        private Panel panel4;
        private Label lblIngresosTotales;
        private Panel panel8;
        private Label label1;
        private TextBox TBoxArregloTotal;
        private TextBox TBoxSolTotal;
        private Panel panel29;
        private Label label21;
        private TextBox TBoxRecetaTotal;
        private Panel panel31;
        private Label label22;
        private Panel panel33;
        private Label label23;
        private TextBox TBoxCantidadTotalPedidos;
        private Label label7;
        private TextBox TBoxMesMasVendidoCompletar;
        private Panel panel10;
        private Label label6;
        private TextBox TBoxTotalFacturadoAuto;
        private Panel panel9;
        private Label label5;
        private Label label8;
        private Label lblMesMasVendidoCompletar;
        private TextBox TBoxIngresoPromedioMensualCompletar;
        private Panel panel12;
        private Label label11;
        private TextBox TBoxMesMenosVendidoCompletar;
        private Panel panel11;
        private Label lblMesMenosVendidoCompletar;
        private Label label10;
    }
}