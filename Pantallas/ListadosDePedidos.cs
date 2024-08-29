using OpricaSurinV2;
using OpricaSurinV2.Clases;
using OpricaSurinV2.Pantallas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpticaSurinV2.Pantallas
{
    public partial class ListadosDePedidos : Form
    {
        // Variables
        private Gestor gestor;

        // Banderas
        bool banderaBoton1 = false;
        bool banderaBoton2 = false; 
        bool banderaBoton3 = false;
        bool banderaBoton4 = false;

        // Constructor
        public ListadosDePedidos(Gestor gestor)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            this.gestor = gestor;
        }

        // Boton para cancelar y volver al menu
        private void btnCancelarBusqueda_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Boton para registrar un pago
        private void btnRegistarPago_Click(object sender, EventArgs e)
        {
            this.ValidarPedidoSeleccionado();

            if (gestor.pedidoSeleccionado != null)
            {
                if (gestor.pedidoSeleccionado.saldo == 0)
                {
                    MessageBox.Show("No se puede registrar un pago ya que no hay saldo pendiente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Habilitamos ventana de pago:
                    VentanaRegistrarPago ventanaRegistrarPago = new VentanaRegistrarPago(gestor, 1);
                    ventanaRegistrarPago.ShowDialog();

                    if (ventanaRegistrarPago.DialogResult == DialogResult.OK)
                    {
                        dGVPedidos.Rows.Clear();

                        // Segun que bandera este en true recargamos el DGV:
                        if (banderaBoton1)
                        {
                            this.CargarPedidosConDeudas();
                        }
                        else if (banderaBoton2)
                        {
                            this.CargarPedidosDelMesActual();
                        }
                        else if (banderaBoton3)
                        {
                            this.CargarPedidosDelMesSeleccionado();
                        }
                        else if (banderaBoton4)
                        {
                            this.CargarUltimosPedidos();
                        }
                    }
                    else
                    {
                        dGVPedidos.Rows.Clear();
                        // Segun que bandera este en true recargamos el DGV:
                        if (banderaBoton1)
                        {
                            this.CargarPedidosConDeudas();
                        }
                        else if (banderaBoton2)
                        {
                            this.CargarPedidosDelMesActual();
                        }
                        else if (banderaBoton3)
                        {
                            this.CargarPedidosDelMesSeleccionado();
                        }
                        else if (banderaBoton4)
                        {
                            this.CargarUltimosPedidos();
                        }
                    }
                }
            }
            else
            {
                AvisoNoHayPedidoSeleccionado ventanaAviso = new AvisoNoHayPedidoSeleccionado();
                ventanaAviso.Show();
            }
        }

        // Boton para ver un pedido seleccionado (forma comprobante)
        private void btnVerPedido_Click(object sender, EventArgs e)
        {
            this.ValidarPedidoSeleccionado();

            if (gestor.pedidoSeleccionado != null)
            {
                gestor.clienteActual = gestor.pedidoSeleccionado.cliente;
                
                if (gestor.pedidoSeleccionado.tipo == "RECETA" || gestor.pedidoSeleccionado.tipo == "Receta")
                {
                    gestor.recetaDelPedido = gestor.pedidoSeleccionado.receta;
                    Comprobante ventanaComprobante = new Comprobante(gestor, 1);
                    ventanaComprobante.Show();
                }
                else
                {
                    Comprobante ventanaComprobante = new Comprobante(gestor, "nada", 1);
                    ventanaComprobante.Show();
                }
            }
            else
            {
                AvisoNoHayPedidoSeleccionado ventanaAviso = new AvisoNoHayPedidoSeleccionado();
                ventanaAviso.Show();
            }
        }

        // Boton para ver pedidos con deudas
        private void btnPedidosConDeudas_Click(object sender, EventArgs e)
        {
            // banderas
            banderaBoton1 = true;
            banderaBoton2 = false;
            banderaBoton3 = false;
            banderaBoton4 = false;

            this.CargarPedidosConDeudas();
        }

        // Metodo para agregar un pedido al DGV
        private void AgregarPedido(Pedido pedidoAAgregar)
        {

            DataGridViewRow fila = new DataGridViewRow();

            DataGridViewTextBoxCell IdPedido = new DataGridViewTextBoxCell();
            IdPedido.Value = pedidoAAgregar.GetIdPedido();

            DataGridViewTextBoxCell NombreYApellido = new DataGridViewTextBoxCell();
            NombreYApellido.Value = pedidoAAgregar.cliente.nombre;

            DataGridViewTextBoxCell telefono = new DataGridViewTextBoxCell();
            telefono.Value = pedidoAAgregar.cliente.telefono;


            DataGridViewTextBoxCell Total = new DataGridViewTextBoxCell();
            Total.Value = pedidoAAgregar.total;

            DataGridViewTextBoxCell Tipo = new DataGridViewTextBoxCell();
            Tipo.Value = pedidoAAgregar.tipo;

            if (pedidoAAgregar.saldo == 0)
            {
                DataGridViewTextBoxCell Saldo = new DataGridViewTextBoxCell();
                Saldo.Value = "PAGO";

                fila.Cells.Add(IdPedido);
                fila.Cells.Add(NombreYApellido);
                fila.Cells.Add(telefono);
                fila.Cells.Add(Saldo);
                fila.Cells.Add(Total);
                fila.Cells.Add(Tipo);

                fila.DefaultCellStyle.BackColor = Color.Green;
                dGVPedidos.Rows.Add(fila);

            }
            else
            {
                DataGridViewTextBoxCell Saldo = new DataGridViewTextBoxCell();
                Saldo.Value = pedidoAAgregar.saldo;

                fila.Cells.Add(IdPedido);
                fila.Cells.Add(NombreYApellido);
                fila.Cells.Add(telefono);
                fila.Cells.Add(Saldo);
                fila.Cells.Add(Total);
                fila.Cells.Add(Tipo);

                fila.DefaultCellStyle.BackColor = Color.Yellow;
                dGVPedidos.Rows.Add(fila);
            }

        }

        // Boton para ver pedidos de este mes (actual)
        private void btnPedidosDelMes_Click(object sender, EventArgs e)
        {
            // banderas
            banderaBoton1 = false;
            banderaBoton2 = true;
            banderaBoton3 = false;
            banderaBoton4 = false;

            this.CargarPedidosDelMesActual();
        }

        // Boton para ver ultimos 10 pedidos
        private void btnUltimosPedidos_Click(object sender, EventArgs e)
        {
            // banderas
            banderaBoton1 = false;
            banderaBoton2 = false;
            banderaBoton3 = false;
            banderaBoton4 = true;

            this.CargarUltimosPedidos();
        }

        // Boton para ver pedidos de "X" mes:
        private void btnPedidoXMes_Click(object sender, EventArgs e)
        {
            // banderas
            banderaBoton1 = false;
            banderaBoton2 = false;
            banderaBoton3 = true;
            banderaBoton4 = false;

            SelectorFecha ventanaSelectorFecha = new SelectorFecha(gestor);
            ventanaSelectorFecha.ShowDialog();

            if (ventanaSelectorFecha.DialogResult == DialogResult.OK && gestor.anioSeleccionado != null && gestor.mesSeleccionado != null)
            {
                this.CargarPedidosDelMesSeleccionado();
            }
        }

        void ValidarPedidoSeleccionado()
        {
            if (dGVPedidos.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dGVPedidos.SelectedRows[0];

                int IdPedidoSelec = Convert.ToInt32(filaSeleccionada.Cells["IdPedido"].Value);

                // Debe indicar cual es el objeto cliente seleccionado
                gestor.SetPedidoSeleccionado(IdPedidoSelec);
            }
        }
        void CargarPedidosConDeudas()
        {
            List<Pedido> pedidosConDeudas = gestor.pedidoService.ObtenerPedidosConSaldoDistintoDeCero();

            dGVPedidos.Rows.Clear();

            if (pedidosConDeudas.Count > 0)
            {
                foreach (Pedido ped in pedidosConDeudas)
                {
                    AgregarPedido(ped);
                }
            }
            else
            {
                // Mostrar mensaje de confirmación
                MessageBox.Show("No hay pedidos con deudas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void CargarPedidosDelMesActual()
        {
            List<Pedido> pedidosDelMes = gestor.pedidoService.ObtenerPedidosDelMesActual();

            dGVPedidos.Rows.Clear();

            if (pedidosDelMes.Count > 0)
            {
                foreach (Pedido ped in pedidosDelMes)
                {
                    AgregarPedido(ped);
                }
            }
            else
            {
                // Mostrar mensaje de confirmación
                MessageBox.Show("No hay pedidos en el mes actual.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void CargarPedidosDelMesSeleccionado()
        {
            List<Pedido> pedidosDelMesSeleccionado = gestor.pedidoService.ObtenerPedidosDelMes(gestor.anioSeleccionado, gestor.mesSeleccionado);

            dGVPedidos.Rows.Clear();

            if (pedidosDelMesSeleccionado.Count > 0)
            {
                foreach (Pedido ped in pedidosDelMesSeleccionado)
                {
                    AgregarPedido(ped);
                }
            }
            else
            {
                // Mostrar mensaje de confirmación
                MessageBox.Show("No hay pedidos en el mes seleccionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void CargarUltimosPedidos()
        {
            List<Pedido> ultimos10 = gestor.pedidoService.ObtenerUltimos10PedidosConClienteYReceta();

            dGVPedidos.Rows.Clear();

            if (ultimos10.Count > 0)
            {
                foreach (Pedido ped in ultimos10)
                {
                    AgregarPedido(ped);
                }
            }
            else
            {
                // Mostrar mensaje de confirmación
                MessageBox.Show("No pudimos encontrar los ultimos 10 pedidos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
       
    }
}
