namespace OpticaSurinV2.Pantallas
{
    partial class ListadosDePedidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadosDePedidos));
            panelListadoPedidos = new Panel();
            btnUltimosPedidos = new Button();
            btnPedidosDelMes = new Button();
            btnVerPedido = new Button();
            btnPedidoXMes = new Button();
            btnPedidosConDeudas = new Button();
            btnRegistarPago = new Button();
            btnCancelarBusqueda = new Button();
            panelColorTurBusqueda = new Panel();
            lblTitulo = new Label();
            dGVPedidos = new DataGridView();
            IdPedido = new DataGridViewTextBoxColumn();
            NombreyApellido = new DataGridViewTextBoxColumn();
            telefono = new DataGridViewTextBoxColumn();
            Saldo = new DataGridViewTextBoxColumn();
            Total = new DataGridViewTextBoxColumn();
            Tipo = new DataGridViewTextBoxColumn();
            panelListadoPedidos.SuspendLayout();
            panelColorTurBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dGVPedidos).BeginInit();
            SuspendLayout();
            // 
            // panelListadoPedidos
            // 
            panelListadoPedidos.BackColor = Color.White;
            panelListadoPedidos.BorderStyle = BorderStyle.FixedSingle;
            panelListadoPedidos.Controls.Add(btnUltimosPedidos);
            panelListadoPedidos.Controls.Add(btnPedidosDelMes);
            panelListadoPedidos.Controls.Add(btnVerPedido);
            panelListadoPedidos.Controls.Add(btnPedidoXMes);
            panelListadoPedidos.Controls.Add(btnPedidosConDeudas);
            panelListadoPedidos.Controls.Add(btnRegistarPago);
            panelListadoPedidos.Controls.Add(btnCancelarBusqueda);
            panelListadoPedidos.Controls.Add(panelColorTurBusqueda);
            panelListadoPedidos.Controls.Add(dGVPedidos);
            panelListadoPedidos.Location = new Point(30, 30);
            panelListadoPedidos.Name = "panelListadoPedidos";
            panelListadoPedidos.Size = new Size(670, 610);
            panelListadoPedidos.TabIndex = 42;
            // 
            // btnUltimosPedidos
            // 
            btnUltimosPedidos.BackColor = Color.FromArgb(108, 166, 205);
            btnUltimosPedidos.Cursor = Cursors.Hand;
            btnUltimosPedidos.FlatStyle = FlatStyle.Popup;
            btnUltimosPedidos.Location = new Point(503, 42);
            btnUltimosPedidos.Name = "btnUltimosPedidos";
            btnUltimosPedidos.Size = new Size(159, 32);
            btnUltimosPedidos.TabIndex = 50;
            btnUltimosPedidos.Text = "Ultimos 10 pedidos";
            btnUltimosPedidos.UseVisualStyleBackColor = false;
            btnUltimosPedidos.Click += btnUltimosPedidos_Click;
            // 
            // btnPedidosDelMes
            // 
            btnPedidosDelMes.BackColor = Color.Aquamarine;
            btnPedidosDelMes.Cursor = Cursors.Hand;
            btnPedidosDelMes.FlatStyle = FlatStyle.Popup;
            btnPedidosDelMes.Location = new Point(171, 42);
            btnPedidosDelMes.Name = "btnPedidosDelMes";
            btnPedidosDelMes.Size = new Size(158, 32);
            btnPedidosDelMes.TabIndex = 49;
            btnPedidosDelMes.Text = "Pedidos del mes";
            btnPedidosDelMes.UseVisualStyleBackColor = false;
            btnPedidosDelMes.Click += btnPedidosDelMes_Click;
            // 
            // btnVerPedido
            // 
            btnVerPedido.BackColor = Color.FromArgb(164, 198, 57);
            btnVerPedido.Cursor = Cursors.Hand;
            btnVerPedido.FlatStyle = FlatStyle.Popup;
            btnVerPedido.Location = new Point(282, 573);
            btnVerPedido.Name = "btnVerPedido";
            btnVerPedido.Size = new Size(105, 25);
            btnVerPedido.TabIndex = 48;
            btnVerPedido.Text = "Ampliar Pedido";
            btnVerPedido.UseVisualStyleBackColor = false;
            btnVerPedido.Click += btnVerPedido_Click;
            // 
            // btnPedidoXMes
            // 
            btnPedidoXMes.BackColor = Color.SkyBlue;
            btnPedidoXMes.Cursor = Cursors.Hand;
            btnPedidoXMes.FlatStyle = FlatStyle.Popup;
            btnPedidoXMes.Location = new Point(336, 42);
            btnPedidoXMes.Name = "btnPedidoXMes";
            btnPedidoXMes.Size = new Size(159, 32);
            btnPedidoXMes.TabIndex = 46;
            btnPedidoXMes.Text = "Pedidos de \"X\" mes";
            btnPedidoXMes.UseVisualStyleBackColor = false;
            btnPedidoXMes.Click += btnPedidoXMes_Click;
            // 
            // btnPedidosConDeudas
            // 
            btnPedidosConDeudas.BackColor = Color.FromArgb(180, 225, 255);
            btnPedidosConDeudas.Cursor = Cursors.Hand;
            btnPedidosConDeudas.FlatStyle = FlatStyle.Popup;
            btnPedidosConDeudas.Location = new Point(7, 42);
            btnPedidosConDeudas.Name = "btnPedidosConDeudas";
            btnPedidosConDeudas.Size = new Size(158, 32);
            btnPedidosConDeudas.TabIndex = 44;
            btnPedidosConDeudas.Text = "Pedidos con deudas";
            btnPedidosConDeudas.UseVisualStyleBackColor = false;
            btnPedidosConDeudas.Click += btnPedidosConDeudas_Click;
            // 
            // btnRegistarPago
            // 
            btnRegistarPago.BackColor = Color.FromArgb(249, 215, 93);
            btnRegistarPago.Cursor = Cursors.Hand;
            btnRegistarPago.FlatStyle = FlatStyle.Popup;
            btnRegistarPago.Location = new Point(417, 573);
            btnRegistarPago.Name = "btnRegistarPago";
            btnRegistarPago.Size = new Size(105, 25);
            btnRegistarPago.TabIndex = 42;
            btnRegistarPago.Text = "Registrar Pago";
            btnRegistarPago.UseVisualStyleBackColor = false;
            btnRegistarPago.Click += btnRegistarPago_Click;
            // 
            // btnCancelarBusqueda
            // 
            btnCancelarBusqueda.BackColor = Color.FromArgb(220, 100, 100);
            btnCancelarBusqueda.Cursor = Cursors.Hand;
            btnCancelarBusqueda.FlatAppearance.BorderColor = Color.Black;
            btnCancelarBusqueda.FlatStyle = FlatStyle.Popup;
            btnCancelarBusqueda.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelarBusqueda.Location = new Point(147, 573);
            btnCancelarBusqueda.Name = "btnCancelarBusqueda";
            btnCancelarBusqueda.Size = new Size(105, 25);
            btnCancelarBusqueda.TabIndex = 41;
            btnCancelarBusqueda.Text = "Volver al inicio";
            btnCancelarBusqueda.UseVisualStyleBackColor = false;
            btnCancelarBusqueda.Click += btnCancelarBusqueda_Click;
            // 
            // panelColorTurBusqueda
            // 
            panelColorTurBusqueda.BackColor = Color.Gray;
            panelColorTurBusqueda.Controls.Add(lblTitulo);
            panelColorTurBusqueda.Location = new Point(7, 5);
            panelColorTurBusqueda.Name = "panelColorTurBusqueda";
            panelColorTurBusqueda.Size = new Size(655, 28);
            panelColorTurBusqueda.TabIndex = 39;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(265, 7);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(125, 17);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Listado de Pedidos";
            // 
            // dGVPedidos
            // 
            dGVPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGVPedidos.Columns.AddRange(new DataGridViewColumn[] { IdPedido, NombreyApellido, telefono, Saldo, Total, Tipo });
            dGVPedidos.Location = new Point(7, 82);
            dGVPedidos.Name = "dGVPedidos";
            dGVPedidos.Size = new Size(655, 483);
            dGVPedidos.TabIndex = 35;
            // 
            // IdPedido
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopCenter;
            IdPedido.DefaultCellStyle = dataGridViewCellStyle1;
            IdPedido.HeaderText = "ID";
            IdPedido.Name = "IdPedido";
            IdPedido.Width = 40;
            // 
            // NombreyApellido
            // 
            NombreyApellido.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            NombreyApellido.DefaultCellStyle = dataGridViewCellStyle2;
            NombreyApellido.HeaderText = "Nombre y Apellido";
            NombreyApellido.Name = "NombreyApellido";
            NombreyApellido.Width = 165;
            // 
            // telefono
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.TopCenter;
            telefono.DefaultCellStyle = dataGridViewCellStyle3;
            telefono.HeaderText = "Telefono";
            telefono.Name = "telefono";
            telefono.Width = 95;
            // 
            // Saldo
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.TopCenter;
            Saldo.DefaultCellStyle = dataGridViewCellStyle4;
            Saldo.HeaderText = "Saldo Pendiente";
            Saldo.Name = "Saldo";
            // 
            // Total
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.TopCenter;
            Total.DefaultCellStyle = dataGridViewCellStyle5;
            Total.HeaderText = "Total";
            Total.Name = "Total";
            // 
            // Tipo
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.TopCenter;
            Tipo.DefaultCellStyle = dataGridViewCellStyle6;
            Tipo.HeaderText = "Tipo Pedido";
            Tipo.Name = "Tipo";
            Tipo.Width = 115;
            // 
            // ListadosDePedidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fotoOptica;
            ClientSize = new Size(1261, 711);
            Controls.Add(panelListadoPedidos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ListadosDePedidos";
            Text = "Ultimos Pedidos";
            panelListadoPedidos.ResumeLayout(false);
            panelColorTurBusqueda.ResumeLayout(false);
            panelColorTurBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dGVPedidos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelListadoPedidos;
        private Button btnCancelarBusqueda;
        private Panel panelColorTurBusqueda;
        private Label lblTitulo;
        private DataGridView dGVPedidos;
        private Button btnRegistarPago;
        private Button button4;
        private Button btnPedidoXMes;
        private Button button2;
        private Button btnPedidosConDeudas;
        private Button btnVerPedido;
        private Button btnUltimosPedidos;
        private Button btnPedidosDelMes;
        private DataGridViewTextBoxColumn IdPedido;
        private DataGridViewTextBoxColumn NombreyApellido;
        private DataGridViewTextBoxColumn telefono;
        private DataGridViewTextBoxColumn Saldo;
        private DataGridViewTextBoxColumn Total;
        private DataGridViewTextBoxColumn Tipo;
    }
}