using OpricaSurinV2.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpricaSurinV2.Clases;
using OpticaSurinV2.Pantallas;

namespace OpricaSurinV2.Pantallas
{
    public partial class BuscarCliente : Form
    {
        // Atributos
        Gestor gestor;

        // Constructor
        public BuscarCliente(Gestor gestor)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.gestor = gestor;

            // Ocultamos objetos de recetas:
            this.OcultarPanelRecetas();

            // Ocultamos el panel de listado de pedidos
            this.OcultarPanelPedidos();
        }

        // REGIONES:
        // BUSCAR CLIENTE GENERAL
        #region BuscarGeneral
        // Boton que INICIA la busqueda de clientes por nombre:
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            // Aca conecta el metodo de busqueda por nombre de la BD.
            List<Cliente> clientesEncontrados = gestor.clienteService.GetClientesXNombre(TBoxNombreBusqueda.Text);
            dGVBusquedaCliente.Rows.Clear();

            if (clientesEncontrados.Count > 0)
            {
                foreach (Cliente clienteEncontrado in clientesEncontrados)
                {
                    AgregarCliente(clienteEncontrado);
                }
            }
            else
            {
                // La lista está vacía
                // Realiza alguna acción
                AvisoNoHayCLientes ventanaAvisoNoHayCLientes = new AvisoNoHayCLientes();
                ventanaAvisoNoHayCLientes.Show();
            }

            // Ocultamos objetos de recetas:
            this.OcultarPanelRecetas();

        }

        // Metodo para agregar los clientes al data grid view:
        private void AgregarCliente(Cliente clienteEncontrado)
        {
            DataGridViewRow fila = new DataGridViewRow();

            DataGridViewTextBoxCell IdCliente = new DataGridViewTextBoxCell();
            IdCliente.Value = clienteEncontrado.GetIdCliente();

            DataGridViewTextBoxCell NombreYApellido = new DataGridViewTextBoxCell();
            NombreYApellido.Value = clienteEncontrado.nombre;

            DataGridViewTextBoxCell dni = new DataGridViewTextBoxCell();
            dni.Value = clienteEncontrado.dni;

            DataGridViewTextBoxCell telefono = new DataGridViewTextBoxCell();
            telefono.Value = clienteEncontrado.telefono;

            DataGridViewTextBoxCell obraSocial = new DataGridViewTextBoxCell();
            obraSocial.Value = clienteEncontrado.obraSocial;

            fila.Cells.Add(IdCliente);
            fila.Cells.Add(NombreYApellido);
            fila.Cells.Add(dni);
            fila.Cells.Add(telefono);
            fila.Cells.Add(obraSocial);

            dGVBusquedaCliente.Rows.Add(fila);
        }

        // Boton para cancelar la busqueda de cliente y volver a la ventana de inicio:
        private void btnCancelarBusqueda_Click(object sender, EventArgs e)
        {
            // Restablece valores del clienteactual y recetadelpedido
            gestor.clienteActual = null;
            gestor.recetaDelPedido = null;
            gestor.pedidoSeleccionado = null;
            gestor.facturaDelCobro = null;
            gestor.cobroDelPedido = null;

            this.Close();
        }

        // Boton para ver las recetas del cliente, habilita el DGV y inicia la busqueda de recetas:
        private void btnVerRecetas_Click(object sender, EventArgs e)
        {
            // Habilitamos objetos de recetas:
            this.HabilitarPanelRecetas();

            // Deshabilitamos panel Listado pedidos
            this.OcultarPanelPedidos();
            gestor.pedidoSeleccionado = null;

            // Validacion si hay cliente seleccionado
            this.ValidarClienteSeleccionado();
            
            // Inicio de la busqueda de recetas:
            if (gestor.clienteActual != null)
            {
                if (gestor.clienteActual.recetas.Count > 0)
                {
                    foreach (Receta recetaDelCLiente in gestor.clienteActual.recetas)
                    {
                        AgregarRecetas(recetaDelCLiente);
                    }
                }
                else
                {
                    // La lista está vacía
                    // Realiza alguna acción
                    AvisoNoHayRecetasDelCliente ventanaAvisoNoHayRecetas = new AvisoNoHayRecetasDelCliente();
                    ventanaAvisoNoHayRecetas.Show();
                }
            }
        }

        // Boton para ver los pedidos del cliente seleccionado
        private void btnVerPedidos_Click(object sender, EventArgs e)
        {
            // Deshabilitamos todo el panel de recetas
            this.OcultarPanelRecetas();
            gestor.recetaDelPedido = null;

            this.ValidarClienteSeleccionado();

            if (gestor.clienteActual != null)
            {
                // Habilita panel pedidos y lo reubica
                this.HabilitarPanelPedidos();
                // Busca y carga pedidos del cliente
                this.CargarPedidosDelCliente();
            }
        }
        void ValidarClienteSeleccionado()
        {
            if (dGVBusquedaCliente.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dGVBusquedaCliente.SelectedRows[0];

                int IdClienteSelec = Convert.ToInt32(filaSeleccionada.Cells["IdCliente"].Value);

                // Debe indicar cual es el objeto cliente seleccionado
                gestor.SetClienteActualYaRegistrado(IdClienteSelec);
            }
            else
            {
                AvisoNoHayCLienteSeleccionado ventanaAviso = new AvisoNoHayCLienteSeleccionado();
                ventanaAviso.Show();
            }
        }

        void CargarPedidosDelCliente()
        {
            // Agregamos pedidos del cliente al dgv
            List<Pedido> pedidosDelCliente = gestor.pedidoService.GetPedidosXCliente(gestor.clienteActual);

            dGVPedidos.Rows.Clear();

            if (pedidosDelCliente.Count > 0)
            {
                foreach (Pedido ped in pedidosDelCliente)
                {
                    AgregarPedido(ped);
                }
            }
            else
            {
                // Mostrar mensaje de confirmación
                MessageBox.Show("No hay pedidos de este cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        // PARTE PANEL RECETA
        #region PanelBusquedaReceta

        // Boton para cerrar la ventana que muestra las recetas
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // Restablece valores del clienteactual y recetadelpedido
            gestor.recetaDelPedido = null;
            this.OcultarPanelRecetas();
        }

        // Metodo para agregar recetas al dgv:
        private void AgregarRecetas(Receta recetaDelCLiente)
        {
            DataGridViewRow fila = new DataGridViewRow();

            DataGridViewTextBoxCell IdReceta = new DataGridViewTextBoxCell();
            IdReceta.Value = recetaDelCLiente.IdReceta;

            DataGridViewTextBoxCell tipoReceta = new DataGridViewTextBoxCell();
            tipoReceta.Value = recetaDelCLiente.tipo;

            DataGridViewTextBoxCell fechaReceta = new DataGridViewTextBoxCell();
            fechaReceta.Value = recetaDelCLiente.fechaReceta.Date.ToString("dd/MM/yy");

            fila.Cells.Add(IdReceta);
            fila.Cells.Add(tipoReceta);
            fila.Cells.Add(fechaReceta);

            dGVRecetas.Rows.Add(fila);
        }

        // Boton para ver la receta como en formulario
        private void btnAmpliarReceta_Click(object sender, EventArgs e)
        {
            if (dGVRecetas.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dGVRecetas.SelectedRows[0];

                int IdRecetaSelec = Convert.ToInt32(filaSeleccionada.Cells["IdReceta"].Value);

                // Debe indicar cual es el objeto cliente seleccionado
                gestor.recetaDelPedido = gestor.recetaService.GetReceta(IdRecetaSelec);

                MuestraReceta ventanaMuestraReceta = new MuestraReceta(gestor);
                ventanaMuestraReceta.ShowDialog();

                if (ventanaMuestraReceta.DialogResult == DialogResult.OK)
                {
                    // Se actualiza la receta
                    gestor.recetaService.ActualizarReceta(gestor.recetaDelPedido);

                    // volver a cargar DGV recetas
                    dGVRecetas.Rows.Clear();

                    if (gestor.clienteActual.recetas.Count > 0)
                    {
                        foreach (Receta recetaDelCLiente in gestor.clienteActual.recetas)
                        {
                            AgregarRecetas(recetaDelCLiente);
                        }
                    }
                }
            }
            else
            {
                AvisoNoHayRecetaSeleccionada ventanaAviso = new AvisoNoHayRecetaSeleccionada();
                ventanaAviso.Show();
            }
        }

        void OcultarPanelRecetas()
        {
            dGVRecetas.Rows.Clear();
            panelRecetas.Visible = false;
        }
        void HabilitarPanelRecetas()
        {
            panelRecetas.Visible = true;
        }
        #endregion

        // PARTE PANEL PEDIDOS
        #region PanelBusquedaPedidos

        // Boton para cerrar el panel de listado de pedidos
        private void btnCerrarListadoPedidos_Click(object sender, EventArgs e)
        {
            // Restablece valores del clienteactual y recetadelpedido
            gestor.pedidoSeleccionado = null;
            this.OcultarPanelPedidos();
        }

        // Boton para ampliar el pedido seleccionado
        private void btnAmpliarPedido_Click(object sender, EventArgs e)
        {
            this.ValidarPedidoSeleccionado();

            if (gestor.pedidoSeleccionado != null)
            {
                if(gestor.pedidoSeleccionado.tipo == "RECETA" || gestor.pedidoSeleccionado.tipo == "Receta")
                {
                    Comprobante ventanaComprobante = new Comprobante(gestor, 1);
                    ventanaComprobante.Show();
                }
                else
                {
                    Comprobante ventanaComprobante = new Comprobante(gestor, "nada" ,1);
                    ventanaComprobante.Show();
                }
            }
            else
            {
                AvisoNoHayPedidoSeleccionado ventanaAviso = new AvisoNoHayPedidoSeleccionado();
                ventanaAviso.Show();
            }

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
        private void btnRegistrarPago_Click(object sender, EventArgs e)
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
                    VentanaRegistrarPago ventanaRegistrarPago = new VentanaRegistrarPago(gestor);
                    ventanaRegistrarPago.ShowDialog();

                    if (ventanaRegistrarPago.DialogResult == DialogResult.OK)
                    {
                        // Busca y carga pedidos del cliente
                        this.CargarPedidosDelCliente();

                    }
                    else
                    {
                        // Busca y carga pedidos del cliente
                        this.CargarPedidosDelCliente();
                    }
                }
            }
            else
            {
                AvisoNoHayPedidoSeleccionado ventanaAviso = new AvisoNoHayPedidoSeleccionado();
                ventanaAviso.Show();
            }
        }
        void OcultarPanelPedidos()
        {
            panelListadoPedidos.Visible = false;
            dGVPedidos.Rows.Clear();
        }
        void HabilitarPanelPedidos()
        {
            panelListadoPedidos.Visible = true;
            panelListadoPedidos.Location = new Point(650, 50);
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
        #endregion

    }
}
