namespace OpricaSurinV2.Pantallas
{
    partial class BuscarCliente
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarCliente));
            panelBusquedaCliente = new Panel();
            btnVerPedidos = new Button();
            btnBuscarCliente = new Button();
            btnCancelarBusqueda = new Button();
            panelColorTurBusqueda = new Panel();
            lblTituloBusqueda = new Label();
            TBoxNombreBusqueda = new TextBox();
            lblNombreBusqueda = new Label();
            btnVerRecetas = new Button();
            dGVBusquedaCliente = new DataGridView();
            IdCliente = new DataGridViewTextBoxColumn();
            NombreyApellido = new DataGridViewTextBoxColumn();
            dni = new DataGridViewTextBoxColumn();
            telefono = new DataGridViewTextBoxColumn();
            obraSocial = new DataGridViewTextBoxColumn();
            dGVRecetas = new DataGridView();
            IdReceta = new DataGridViewTextBoxColumn();
            tipoReceta = new DataGridViewTextBoxColumn();
            fechaReceta = new DataGridViewTextBoxColumn();
            panelRecetas = new Panel();
            btnAmpliarReceta = new Button();
            btnCerrar = new Button();
            panelNaranja = new Panel();
            lblRecetaTitulo = new Label();
            dGVPedidos = new DataGridView();
            panel1 = new Panel();
            lblTituloListaPedidos = new Label();
            btnAmpliarPedido = new Button();
            btnCerrarListadoPedidos = new Button();
            panelListadoPedidos = new Panel();
            btnRegistrarPago = new Button();
            IdPedido = new DataGridViewTextBoxColumn();
            NombreYApellidoLP = new DataGridViewTextBoxColumn();
            telefonoLP = new DataGridViewTextBoxColumn();
            saldoLP = new DataGridViewTextBoxColumn();
            TotalLP = new DataGridViewTextBoxColumn();
            TipoLP = new DataGridViewTextBoxColumn();
            panelBusquedaCliente.SuspendLayout();
            panelColorTurBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dGVBusquedaCliente).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dGVRecetas).BeginInit();
            panelRecetas.SuspendLayout();
            panelNaranja.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dGVPedidos).BeginInit();
            panel1.SuspendLayout();
            panelListadoPedidos.SuspendLayout();
            SuspendLayout();
            // 
            // panelBusquedaCliente
            // 
            panelBusquedaCliente.BackColor = Color.White;
            panelBusquedaCliente.BorderStyle = BorderStyle.FixedSingle;
            panelBusquedaCliente.Controls.Add(btnVerPedidos);
            panelBusquedaCliente.Controls.Add(btnBuscarCliente);
            panelBusquedaCliente.Controls.Add(btnCancelarBusqueda);
            panelBusquedaCliente.Controls.Add(panelColorTurBusqueda);
            panelBusquedaCliente.Controls.Add(TBoxNombreBusqueda);
            panelBusquedaCliente.Controls.Add(lblNombreBusqueda);
            panelBusquedaCliente.Controls.Add(btnVerRecetas);
            panelBusquedaCliente.Controls.Add(dGVBusquedaCliente);
            panelBusquedaCliente.Location = new Point(50, 50);
            panelBusquedaCliente.Name = "panelBusquedaCliente";
            panelBusquedaCliente.Size = new Size(556, 603);
            panelBusquedaCliente.TabIndex = 41;
            // 
            // btnVerPedidos
            // 
            btnVerPedidos.BackColor = Color.SeaGreen;
            btnVerPedidos.Cursor = Cursors.Hand;
            btnVerPedidos.FlatStyle = FlatStyle.Popup;
            btnVerPedidos.Location = new Point(361, 558);
            btnVerPedidos.Name = "btnVerPedidos";
            btnVerPedidos.Size = new Size(105, 25);
            btnVerPedidos.TabIndex = 49;
            btnVerPedidos.Text = "Ver Pedidos";
            btnVerPedidos.UseVisualStyleBackColor = false;
            btnVerPedidos.Click += btnVerPedidos_Click;
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.BackColor = Color.SeaGreen;
            btnBuscarCliente.Cursor = Cursors.Hand;
            btnBuscarCliente.FlatStyle = FlatStyle.Popup;
            btnBuscarCliente.Location = new Point(465, 38);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(82, 23);
            btnBuscarCliente.TabIndex = 41;
            btnBuscarCliente.Text = "Buscar";
            btnBuscarCliente.UseVisualStyleBackColor = false;
            btnBuscarCliente.Click += btnBuscarCliente_Click;
            // 
            // btnCancelarBusqueda
            // 
            btnCancelarBusqueda.BackColor = Color.FromArgb(220, 100, 100);
            btnCancelarBusqueda.Cursor = Cursors.Hand;
            btnCancelarBusqueda.FlatAppearance.BorderColor = Color.Black;
            btnCancelarBusqueda.FlatStyle = FlatStyle.Popup;
            btnCancelarBusqueda.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelarBusqueda.Location = new Point(91, 558);
            btnCancelarBusqueda.Name = "btnCancelarBusqueda";
            btnCancelarBusqueda.Size = new Size(105, 25);
            btnCancelarBusqueda.TabIndex = 41;
            btnCancelarBusqueda.Text = "Volver al inicio";
            btnCancelarBusqueda.UseVisualStyleBackColor = false;
            btnCancelarBusqueda.Click += btnCancelarBusqueda_Click;
            // 
            // panelColorTurBusqueda
            // 
            panelColorTurBusqueda.BackColor = Color.FromArgb(100, 200, 180);
            panelColorTurBusqueda.Controls.Add(lblTituloBusqueda);
            panelColorTurBusqueda.Location = new Point(7, 5);
            panelColorTurBusqueda.Name = "panelColorTurBusqueda";
            panelColorTurBusqueda.Size = new Size(540, 28);
            panelColorTurBusqueda.TabIndex = 39;
            // 
            // lblTituloBusqueda
            // 
            lblTituloBusqueda.AutoSize = true;
            lblTituloBusqueda.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloBusqueda.Location = new Point(171, 6);
            lblTituloBusqueda.Name = "lblTituloBusqueda";
            lblTituloBusqueda.Size = new Size(199, 17);
            lblTituloBusqueda.TabIndex = 0;
            lblTituloBusqueda.Text = "Busqueda de cliente registrado";
            // 
            // TBoxNombreBusqueda
            // 
            TBoxNombreBusqueda.BorderStyle = BorderStyle.FixedSingle;
            TBoxNombreBusqueda.Cursor = Cursors.IBeam;
            TBoxNombreBusqueda.Location = new Point(126, 37);
            TBoxNombreBusqueda.Name = "TBoxNombreBusqueda";
            TBoxNombreBusqueda.Size = new Size(333, 23);
            TBoxNombreBusqueda.TabIndex = 38;
            // 
            // lblNombreBusqueda
            // 
            lblNombreBusqueda.AutoSize = true;
            lblNombreBusqueda.BackColor = Color.White;
            lblNombreBusqueda.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreBusqueda.ForeColor = Color.Black;
            lblNombreBusqueda.Location = new Point(10, 40);
            lblNombreBusqueda.Name = "lblNombreBusqueda";
            lblNombreBusqueda.Size = new Size(110, 15);
            lblNombreBusqueda.TabIndex = 37;
            lblNombreBusqueda.Text = "Nombre y Apellido:";
            // 
            // btnVerRecetas
            // 
            btnVerRecetas.BackColor = Color.FromArgb(164, 198, 57);
            btnVerRecetas.Cursor = Cursors.Hand;
            btnVerRecetas.FlatStyle = FlatStyle.Popup;
            btnVerRecetas.Location = new Point(226, 558);
            btnVerRecetas.Name = "btnVerRecetas";
            btnVerRecetas.Size = new Size(105, 25);
            btnVerRecetas.TabIndex = 36;
            btnVerRecetas.Text = "Ver recetas";
            btnVerRecetas.UseVisualStyleBackColor = false;
            btnVerRecetas.Click += btnVerRecetas_Click;
            // 
            // dGVBusquedaCliente
            // 
            dGVBusquedaCliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGVBusquedaCliente.Columns.AddRange(new DataGridViewColumn[] { IdCliente, NombreyApellido, dni, telefono, obraSocial });
            dGVBusquedaCliente.Location = new Point(7, 67);
            dGVBusquedaCliente.Name = "dGVBusquedaCliente";
            dGVBusquedaCliente.Size = new Size(540, 479);
            dGVBusquedaCliente.TabIndex = 35;
            // 
            // IdCliente
            // 
            IdCliente.HeaderText = "ID";
            IdCliente.Name = "IdCliente";
            IdCliente.Width = 40;
            // 
            // NombreyApellido
            // 
            NombreyApellido.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            NombreyApellido.HeaderText = "Nombre y Apellido";
            NombreyApellido.Name = "NombreyApellido";
            NombreyApellido.Width = 165;
            // 
            // dni
            // 
            dni.HeaderText = "DNI";
            dni.Name = "dni";
            dni.Width = 85;
            // 
            // telefono
            // 
            telefono.HeaderText = "Telefono";
            telefono.Name = "telefono";
            telefono.Width = 85;
            // 
            // obraSocial
            // 
            obraSocial.HeaderText = "Obra Social";
            obraSocial.Name = "obraSocial";
            obraSocial.Width = 125;
            // 
            // dGVRecetas
            // 
            dGVRecetas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGVRecetas.Columns.AddRange(new DataGridViewColumn[] { IdReceta, tipoReceta, fechaReceta });
            dGVRecetas.Location = new Point(11, 53);
            dGVRecetas.Name = "dGVRecetas";
            dGVRecetas.Size = new Size(354, 319);
            dGVRecetas.TabIndex = 42;
            // 
            // IdReceta
            // 
            IdReceta.HeaderText = "ID";
            IdReceta.Name = "IdReceta";
            IdReceta.Width = 40;
            // 
            // tipoReceta
            // 
            tipoReceta.HeaderText = "Tipo Receta";
            tipoReceta.Name = "tipoReceta";
            tipoReceta.Width = 135;
            // 
            // fechaReceta
            // 
            fechaReceta.HeaderText = "Fecha";
            fechaReceta.Name = "fechaReceta";
            fechaReceta.Width = 137;
            // 
            // panelRecetas
            // 
            panelRecetas.BackColor = Color.WhiteSmoke;
            panelRecetas.BorderStyle = BorderStyle.FixedSingle;
            panelRecetas.Controls.Add(dGVRecetas);
            panelRecetas.Controls.Add(btnAmpliarReceta);
            panelRecetas.Controls.Add(btnCerrar);
            panelRecetas.Controls.Add(panelNaranja);
            panelRecetas.Location = new Point(833, 100);
            panelRecetas.Name = "panelRecetas";
            panelRecetas.Size = new Size(377, 411);
            panelRecetas.TabIndex = 43;
            // 
            // btnAmpliarReceta
            // 
            btnAmpliarReceta.BackColor = Color.FromArgb(164, 198, 57);
            btnAmpliarReceta.Cursor = Cursors.Hand;
            btnAmpliarReceta.FlatStyle = FlatStyle.Popup;
            btnAmpliarReceta.Location = new Point(204, 378);
            btnAmpliarReceta.Name = "btnAmpliarReceta";
            btnAmpliarReceta.Size = new Size(105, 25);
            btnAmpliarReceta.TabIndex = 44;
            btnAmpliarReceta.Text = "Ampliar Receta";
            btnAmpliarReceta.UseVisualStyleBackColor = false;
            btnAmpliarReceta.Click += btnAmpliarReceta_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.FromArgb(220, 100, 100);
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.FlatAppearance.BorderColor = Color.Black;
            btnCerrar.FlatStyle = FlatStyle.Popup;
            btnCerrar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCerrar.Location = new Point(68, 378);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(105, 25);
            btnCerrar.TabIndex = 54;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // panelNaranja
            // 
            panelNaranja.BackColor = Color.FromArgb(255, 192, 128);
            panelNaranja.Controls.Add(lblRecetaTitulo);
            panelNaranja.Location = new Point(11, 9);
            panelNaranja.Name = "panelNaranja";
            panelNaranja.Size = new Size(354, 38);
            panelNaranja.TabIndex = 0;
            // 
            // lblRecetaTitulo
            // 
            lblRecetaTitulo.AutoSize = true;
            lblRecetaTitulo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecetaTitulo.Location = new Point(116, 11);
            lblRecetaTitulo.Name = "lblRecetaTitulo";
            lblRecetaTitulo.Size = new Size(122, 17);
            lblRecetaTitulo.TabIndex = 44;
            lblRecetaTitulo.Text = "Recetas del cliente";
            // 
            // dGVPedidos
            // 
            dGVPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGVPedidos.Columns.AddRange(new DataGridViewColumn[] { IdPedido, NombreYApellidoLP, telefonoLP, saldoLP, TotalLP, TipoLP });
            dGVPedidos.Location = new Point(7, 52);
            dGVPedidos.Name = "dGVPedidos";
            dGVPedidos.Size = new Size(655, 493);
            dGVPedidos.TabIndex = 35;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.Controls.Add(lblTituloListaPedidos);
            panel1.Location = new Point(7, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(655, 41);
            panel1.TabIndex = 39;
            // 
            // lblTituloListaPedidos
            // 
            lblTituloListaPedidos.AutoSize = true;
            lblTituloListaPedidos.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloListaPedidos.Location = new Point(265, 12);
            lblTituloListaPedidos.Name = "lblTituloListaPedidos";
            lblTituloListaPedidos.Size = new Size(125, 17);
            lblTituloListaPedidos.TabIndex = 0;
            lblTituloListaPedidos.Text = "Listado de Pedidos";
            // 
            // btnAmpliarPedido
            // 
            btnAmpliarPedido.BackColor = Color.FromArgb(164, 198, 57);
            btnAmpliarPedido.Cursor = Cursors.Hand;
            btnAmpliarPedido.FlatStyle = FlatStyle.Popup;
            btnAmpliarPedido.Location = new Point(282, 558);
            btnAmpliarPedido.Name = "btnAmpliarPedido";
            btnAmpliarPedido.Size = new Size(105, 25);
            btnAmpliarPedido.TabIndex = 48;
            btnAmpliarPedido.Text = "Ampliar Pedido";
            btnAmpliarPedido.UseVisualStyleBackColor = false;
            btnAmpliarPedido.Click += btnAmpliarPedido_Click;
            // 
            // btnCerrarListadoPedidos
            // 
            btnCerrarListadoPedidos.BackColor = Color.FromArgb(220, 100, 100);
            btnCerrarListadoPedidos.Cursor = Cursors.Hand;
            btnCerrarListadoPedidos.FlatAppearance.BorderColor = Color.Black;
            btnCerrarListadoPedidos.FlatStyle = FlatStyle.Popup;
            btnCerrarListadoPedidos.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCerrarListadoPedidos.Location = new Point(146, 558);
            btnCerrarListadoPedidos.Name = "btnCerrarListadoPedidos";
            btnCerrarListadoPedidos.Size = new Size(105, 25);
            btnCerrarListadoPedidos.TabIndex = 55;
            btnCerrarListadoPedidos.Text = "Cerrar";
            btnCerrarListadoPedidos.UseVisualStyleBackColor = false;
            btnCerrarListadoPedidos.Click += btnCerrarListadoPedidos_Click;
            // 
            // panelListadoPedidos
            // 
            panelListadoPedidos.BackColor = Color.White;
            panelListadoPedidos.BorderStyle = BorderStyle.FixedSingle;
            panelListadoPedidos.Controls.Add(btnRegistrarPago);
            panelListadoPedidos.Controls.Add(btnCerrarListadoPedidos);
            panelListadoPedidos.Controls.Add(btnAmpliarPedido);
            panelListadoPedidos.Controls.Add(panel1);
            panelListadoPedidos.Controls.Add(dGVPedidos);
            panelListadoPedidos.Location = new Point(1237, 50);
            panelListadoPedidos.Name = "panelListadoPedidos";
            panelListadoPedidos.Size = new Size(670, 602);
            panelListadoPedidos.TabIndex = 44;
            // 
            // btnRegistrarPago
            // 
            btnRegistrarPago.BackColor = Color.FromArgb(249, 215, 93);
            btnRegistrarPago.Cursor = Cursors.Hand;
            btnRegistrarPago.FlatStyle = FlatStyle.Popup;
            btnRegistrarPago.Location = new Point(418, 558);
            btnRegistrarPago.Name = "btnRegistrarPago";
            btnRegistrarPago.Size = new Size(105, 25);
            btnRegistrarPago.TabIndex = 56;
            btnRegistrarPago.Text = "Registrar Pago";
            btnRegistrarPago.UseVisualStyleBackColor = false;
            btnRegistrarPago.Click += btnRegistrarPago_Click;
            // 
            // IdPedido
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopCenter;
            IdPedido.DefaultCellStyle = dataGridViewCellStyle1;
            IdPedido.HeaderText = "ID";
            IdPedido.Name = "IdPedido";
            IdPedido.Width = 40;
            // 
            // NombreYApellidoLP
            // 
            NombreYApellidoLP.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            NombreYApellidoLP.DefaultCellStyle = dataGridViewCellStyle2;
            NombreYApellidoLP.HeaderText = "Nombre y Apellido";
            NombreYApellidoLP.Name = "NombreYApellidoLP";
            NombreYApellidoLP.Width = 165;
            // 
            // telefonoLP
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.TopCenter;
            telefonoLP.DefaultCellStyle = dataGridViewCellStyle3;
            telefonoLP.HeaderText = "Telefono";
            telefonoLP.Name = "telefonoLP";
            telefonoLP.Width = 95;
            // 
            // saldoLP
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.TopCenter;
            saldoLP.DefaultCellStyle = dataGridViewCellStyle4;
            saldoLP.HeaderText = "Saldo Pendiente";
            saldoLP.Name = "saldoLP";
            // 
            // TotalLP
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.TopCenter;
            TotalLP.DefaultCellStyle = dataGridViewCellStyle5;
            TotalLP.HeaderText = "Total";
            TotalLP.Name = "TotalLP";
            // 
            // TipoLP
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.TopCenter;
            TipoLP.DefaultCellStyle = dataGridViewCellStyle6;
            TipoLP.HeaderText = "Tipo Pedido";
            TipoLP.Name = "TipoLP";
            TipoLP.Width = 115;
            // 
            // BuscarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            BackgroundImage = OpticaSurinV2.Properties.Resources.fotoOptica;
            ClientSize = new Size(1370, 714);
            Controls.Add(panelListadoPedidos);
            Controls.Add(panelBusquedaCliente);
            Controls.Add(panelRecetas);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "BuscarCliente";
            Text = "Consultar informacion del cliente";
            panelBusquedaCliente.ResumeLayout(false);
            panelBusquedaCliente.PerformLayout();
            panelColorTurBusqueda.ResumeLayout(false);
            panelColorTurBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dGVBusquedaCliente).EndInit();
            ((System.ComponentModel.ISupportInitialize)dGVRecetas).EndInit();
            panelRecetas.ResumeLayout(false);
            panelNaranja.ResumeLayout(false);
            panelNaranja.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dGVPedidos).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelListadoPedidos.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBusquedaCliente;
        private Button btnBuscarCliente;
        private Button btnCancelarBusqueda;
        private Panel panelColorTurBusqueda;
        private Label lblTituloBusqueda;
        private TextBox TBoxNombreBusqueda;
        private Label lblNombreBusqueda;
        private Button btnVerRecetas;
        private DataGridView dGVBusquedaCliente;
        private DataGridView dGVRecetas;
        private Panel panelRecetas;
        private Panel panelNaranja;
        private Label lblRecetaTitulo;
        private Button btnCerrar;
        private Button btnAmpliarReceta;
        private DataGridViewTextBoxColumn IdCliente;
        private DataGridViewTextBoxColumn NombreyApellido;
        private DataGridViewTextBoxColumn dni;
        private DataGridViewTextBoxColumn telefono;
        private DataGridViewTextBoxColumn obraSocial;
        private DataGridViewTextBoxColumn IdReceta;
        private DataGridViewTextBoxColumn tipoReceta;
        private DataGridViewTextBoxColumn fechaReceta;
        private Button btnRegistarPago;
        private Button button1;
        private Button btnVerPedidos;
        private DataGridView dGVPedidos;
        private Panel panel1;
        private Label lblTituloListaPedidos;
        private Button btnAmpliarPedido;
        private Button btnCerrarListadoPedidos;
        private Panel panelListadoPedidos;
        private Button btnRegistrarPago;
        private DataGridViewTextBoxColumn IdPedido;
        private DataGridViewTextBoxColumn NombreYApellidoLP;
        private DataGridViewTextBoxColumn telefonoLP;
        private DataGridViewTextBoxColumn saldoLP;
        private DataGridViewTextBoxColumn TotalLP;
        private DataGridViewTextBoxColumn TipoLP;
    }
}