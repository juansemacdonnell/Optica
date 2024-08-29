using OpricaSurinV2;
using OpricaSurinV2.Clases;
using OpricaSurinV2.Pantallas;
using OpticaSurinV2.Clases;
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
    public partial class ArreglosYSol : Form
    {
        Gestor gestor;
        public ArreglosYSol(Gestor gestor)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.gestor = gestor;

            // Inicializamos el dTP fecha prometido a 10 dias
            dTPFechaPrometido.Value = DateTime.Now.AddDays(10);

            // Ocultamos objetos de busqueda de cliente:
            this.OcultarPanelBusquedaCliente();

            // Validacion teclas total y seña:
            TBoxTotal.KeyPress += NumerosComa_KeyPress;

            // Agregamos items al cmb box de cliente registrado
            cmbBoxClienteRegistrado.Items.AddRange(new string[] { "SI", "NO" });
            cmbBoxClienteRegistrado.SelectedItem = cmbBoxClienteRegistrado.Items[1];

            // Agregamos items al cmb box Obra Social
            foreach (string obraSocial in gestor.obraSocialesLista)
            {
                cmbBoxObraSocial.Items.Add(obraSocial);
            }
            cmbBoxObraSocial.SelectedItem = cmbBoxObraSocial.Items[0];
        }

        // REGIONES:

        // REGISTRO GENERAL:
        #region RegistroGeneral
        // Boton parar limpiar todos los campos, restablece el formulario:
        private void btnLimpiarOK_Click(object sender, EventArgs e)
        {
            this.LimpiarPanelDeRegistro();
        }
        public void LimpiarPanelDeRegistro()
        {
            // Restablece fechas de los DTP
            dTPFechaRecibido.Value = DateTime.Now;
            dTPFechaPrometido.Value = DateTime.Now.AddDays(10);

            // DesHabilitar Boton editar datos
            btnEditarClienteCargado.Enabled = false;

            // Establecer opcion NO en cliente reg
            cmbBoxClienteRegistrado.SelectedItem = cmbBoxClienteRegistrado.Items[1];

            // Limpia los campos del cliente
            this.LimpiarPanelCliente();

            // Limpiamos panel sol y reparacion
            this.LimpiarPanelSol();
            this.LimpiarPanelReparacion();

            // Limpiar Total y observacion
            TBoxTotal.Text = "0";
            TBoxObservacionesPago.Text = "Ninguna";

            this.LimpiarDP();

            // Restablecemos cliente y receta
            gestor.clienteActual = null;
            gestor.cobroDelPedido = null;
            gestor.facturaDelCobro = null;

            gestor.banderaNuevoCliente = true;
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            // Restablecemos cliente y receta
            gestor.clienteActual = null;
            gestor.cobroDelPedido = null;
            gestor.facturaDelCobro = null;

            gestor.banderaNuevoCliente = false;
            this.Close();
        }
        private void btnDetalleDePago_Click(object sender, EventArgs e)
        {
            // Solo si el total se ingreso
            if (TBoxTotal.Text != null && float.TryParse(TBoxTotal.Text, out float total) && total > 0)
            {
                // Seteamos valor total del pedido:
                gestor.totalPedido = total;
                lblSaldoRestanteCompletar.Text = total.ToString();

                // Habilitamos las validaciones:
                TBoxTransferencia.KeyPress += NumerosComa_KeyPress;
                TBoxEfectivo.KeyPress += NumerosComa_KeyPress;
                TBoxMutual.KeyPress += NumerosComa_KeyPress;

                TBoxNumeroTar1.KeyPress += SoloNumeros_KeyPress;
                TBoxNumeroTar2.KeyPress += SoloNumeros_KeyPress;

                TBoxTarjeta1.KeyPress += NumerosComa_KeyPress;
                TBoxTarjeta2.KeyPress += NumerosComa_KeyPress;

                TBoxPrecioItemAgg.KeyPress += NumerosComa_KeyPress;

                // Ocultamos otros paneles:
                this.OcultarPanelBusquedaCliente();

                // Visibilizamos panel de DP
                panelDetallePago.Visible = true;
                panelDetallePago.Location = new Point(758, 60);

                // Cargamos cmb facturacion:
                cmbBoxFacturacion.Items.Clear();
                cmbBoxFacturacion.Items.AddRange(new string[] { "NO", "SI" });
                cmbBoxFacturacion.SelectedItem = cmbBoxFacturacion.Items[0];

                // Si NO habia un DP cargado:
                if (gestor.cobroDelPedido == null)
                {
                    gestor.cobroDelPedido = new Cobro();
                    gestor.facturaDelCobro = new Factura();
                }
                // Si ya habia un DP cargado:
                else
                {
                    // Panel efectivo
                    if (gestor.cobroDelPedido.dineroEfectivo != 0)
                    {
                        TBoxEfectivo.Text = gestor.cobroDelPedido.dineroEfectivo.ToString();
                        checkBoxEfectivo.Checked = true;
                    }

                    // Panel Mutual
                    if (gestor.cobroDelPedido.dineroObraSocial != 0)
                    {
                        TBoxMutual.Text = gestor.cobroDelPedido.dineroObraSocial.ToString();
                        checkBoxMutual.Checked = true;
                        gestor.cobroDelPedido.nombreObraSocial = cmbBoxObraSocial.SelectedItem.ToString();
                    }

                    // Panel transferencia
                    if (gestor.cobroDelPedido.dineroTransferencia != 0)
                    {
                        TBoxTransferencia.Text = gestor.cobroDelPedido.dineroTransferencia.ToString();
                        checkBoxTransferencia.Checked = true;
                    }

                    // Panel tarjetas
                    if (gestor.cobroDelPedido.dineroTarjeta1 != 0 || gestor.cobroDelPedido.dineroTarjeta2 != 0)
                    {
                        checkBoxTarjeta.Checked = true;

                        if (gestor.cobroDelPedido.dineroTarjeta1 != 0)
                        {
                            checkBoxTarjeta1.Checked = true;
                            TBoxTarjeta1.Text = gestor.cobroDelPedido.dineroTarjeta1.ToString();
                        }

                        if (gestor.cobroDelPedido.dineroTarjeta2 != 0)
                        {
                            checkBoxTarjeta2.Checked = true;
                            TBoxTarjeta2.Text = gestor.cobroDelPedido.dineroTarjeta2.ToString();
                        }
                    }

                    // Observaciones
                    TBoxObservacionesCobro.Text = gestor.cobroDelPedido.aclaracionesDeCobro.ToString();

                    // Panel facturacion:
                    if (gestor.cobroDelPedido.factura != null)
                    {
                        cmbBoxFacturacion.SelectedItem = "SI";

                        dGVItems.Rows.Clear();
                        gestor.facturaDelCobro.items = gestor.cobroDelPedido.factura.items;
                        gestor.facturaDelCobro.totalItems = gestor.cobroDelPedido.factura.totalItems;

                        float totalFacturadoAcumulador = 0;

                        for (int i = 0; i <= gestor.facturaDelCobro.items.Count - 1; i++)
                        {
                            this.AgregarItemDGVCicloFor(gestor.facturaDelCobro.items[i], gestor.facturaDelCobro.totalItems[i], i);

                            totalFacturadoAcumulador += gestor.facturaDelCobro.totalItems[i];
                        }

                        TBoxTotalItemsFacturados.Text = totalFacturadoAcumulador.ToString();
                        gestor.totalFacturado = totalFacturadoAcumulador;
                    }
                    else
                    {
                        gestor.facturaDelCobro = new Factura();
                    }
                }
            }
            else
            {
                // Mostrar mensaje de error
                MessageBox.Show("Por favor antes del detalle de pago ingrese el TOTAL del pedido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Banderas para el control de registro
        bool banderaValoresDinero = false;
        bool banderaDP = false;
        private void btnRegistrarPedido_Click(object sender, EventArgs e)
        {
            /*          CASO 1: cliente no registrado y sol               */
            if (gestor.banderaNuevoCliente == true && checkBoxSol.Checked == false && checkBoxReparacion.Checked)
            {
                // Toma datos del cliente y los asigna al cliente actual
                gestor.clienteActual = new Cliente();
                this.TomarDatosCliente();

                // Tomar detalle de anteojo de sol
                gestor.detalleSol = TBoxDetalleSol.Text;
                gestor.detalleReparacion = null;

                // Toma observaciones del pedido
                gestor.observacionesPago = TBoxObservacionesPago.Text.ToUpper();

                // Validaciones: CASO 1
                // Validacion de fechas:
                bool banderaFechas = false;
                if (gestor.ValidarFechas(dTPFechaPrometido.Value))
                {
                    gestor.fechaRecibido = dTPFechaRecibido.Value;
                    gestor.fechaPrometido = dTPFechaPrometido.Value;
                    banderaFechas = true;
                }
                else
                {
                    AvisoFechasMal ventanaAvisoFechasMal = new AvisoFechasMal();
                    ventanaAvisoFechasMal.Show();
                }

                // Validacion de detalle de pago
                if (banderaDP == false)
                {
                    // Mostrar mensaje de error
                    MessageBox.Show("Por favor ingrese un total y el detalle de pago antes de registrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                /*              Validacion Final CASO 1                  */

                // Si todas las validaciones estan bien:
                if (banderaValoresDinero && banderaFechas && this.ValidarDatosCliente() && banderaDP)
                {
                    this.MostrarComprobanteSolReparacion();
                }
            }
            /*          CASO 2: cliente no registrado y reparacion        */
            else if (gestor.banderaNuevoCliente == true && checkBoxSol.Checked && checkBoxReparacion.Checked == false)
            {
                // Toma datos del cliente y los asigna al cliente actual
                gestor.clienteActual = new Cliente();
                this.TomarDatosCliente();

                // Tomar detalle de anteojo de sol
                gestor.detalleSol = null;
                gestor.detalleReparacion = TBoxDetalleReparacion.Text;

                // Toma observaciones del pedido
                gestor.observacionesPago = TBoxObservacionesPago.Text.ToUpper();

                // Validaciones: CASO 2
                // Validacion de fechas:
                bool banderaFechas = false;
                if (gestor.ValidarFechas(dTPFechaPrometido.Value))
                {
                    gestor.fechaRecibido = dTPFechaRecibido.Value;
                    gestor.fechaPrometido = dTPFechaPrometido.Value;
                    banderaFechas = true;
                }
                else
                {
                    AvisoFechasMal ventanaAvisoFechasMal = new AvisoFechasMal();
                    ventanaAvisoFechasMal.Show();
                }

                // Validacion de detalle de pago
                if (banderaDP == false)
                {
                    // Mostrar mensaje de error
                    MessageBox.Show("Por favor ingrese un total y el detalle de pago antes de registrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                /*                  Validacion Final CASO 2              */
                // Si todas las validaciones estan bien:
                if (banderaValoresDinero && banderaFechas && this.ValidarDatosCliente() && banderaDP)
                {
                    this.MostrarComprobanteSolReparacion();
                }
            }
            /*          CASO 3: cliente registrado y sol                  */
            else if (gestor.banderaNuevoCliente == false && checkBoxSol.Checked == false && checkBoxReparacion.Checked)
            {
                // Tomar detalle de anteojo de sol
                gestor.detalleSol = TBoxDetalleSol.Text;
                gestor.detalleReparacion = null;

                // Tomamos la observaciones del pedido
                gestor.observacionesPago = TBoxObservacionesPago.Text.ToUpper();

                // Validaciones: CASO 3
                // Validacion de fechas:
                bool banderaFechas = false;
                if (gestor.ValidarFechas(dTPFechaPrometido.Value))
                {
                    gestor.fechaRecibido = dTPFechaRecibido.Value;
                    gestor.fechaPrometido = dTPFechaPrometido.Value;
                    banderaFechas = true;
                }
                else
                {
                    AvisoFechasMal ventanaAvisoFechasMal = new AvisoFechasMal();
                    ventanaAvisoFechasMal.Show();
                }

                // Si se habilita la opcion de editar 
                if (gestor.banderaClienteEditado)
                {
                    // Toma datos del cliente 
                    this.TomarDatosCliente();

                }

                // Validacion de detalle de pago
                if (banderaDP == false)
                {
                    // Mostrar mensaje de error
                    MessageBox.Show("Por favor ingrese un total y el detalle de pago antes de registrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                /*                 Validacion Final CASO 3                 */
                // Si todas las validaciones estan bien:
                if (banderaValoresDinero && banderaFechas && this.ValidarDatosCliente() && banderaDP)
                {
                    this.MostrarComprobanteSolReparacion();
                }
            }
            /*          CASO 4: cliente registrado y reparacion           */
            else if (gestor.banderaNuevoCliente == false && checkBoxSol.Checked && checkBoxReparacion.Checked == false)
            {
                // Tomar detalle de anteojo de sol
                gestor.detalleSol = null;
                gestor.detalleReparacion = TBoxDetalleReparacion.Text;

                // Tomamos la observaciones del pedido
                gestor.observacionesPago = TBoxObservacionesPago.Text.ToUpper();

                // Validaciones: CASO 4
                // Validacion de fechas:
                bool banderaFechas = false;
                if (gestor.ValidarFechas(dTPFechaPrometido.Value))
                {
                    gestor.fechaRecibido = dTPFechaRecibido.Value;
                    gestor.fechaPrometido = dTPFechaPrometido.Value;
                    banderaFechas = true;
                }
                else
                {
                    AvisoFechasMal ventanaAvisoFechasMal = new AvisoFechasMal();
                    ventanaAvisoFechasMal.Show();
                }

                // Si se habilita la opcion de editar 
                if (gestor.banderaClienteEditado)
                {
                    // Toma datos del cliente 
                    this.TomarDatosCliente();
                }

                // Validacion de detalle de pago
                if (banderaDP == false)
                {
                    // Mostrar mensaje de error
                    MessageBox.Show("Por favor ingrese un total y el detalle de pago antes de registrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                /*                  Validacion Final CASO 4                       */
                // Si todas las validaciones estan bien:
                if (banderaValoresDinero && banderaFechas && this.ValidarDatosCliente() && banderaDP)
                {
                    this.MostrarComprobanteSolReparacion();
                }
            }
            /*          CASO 5: sin seleccion                             */
            else if (checkBoxSol.Checked == false && checkBoxReparacion.Checked == false)
            {
                // Mostrar mensaje de error
                MessageBox.Show("Por favor seleccione una opcion de registro: Anteojo de sol o Reparación", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void MostrarComprobanteSolReparacion()
        {
            string tipo = "";
            Comprobante ventanaComprobante = new Comprobante(gestor, tipo);
            ventanaComprobante.ShowDialog();

            if (ventanaComprobante.DialogResult == DialogResult.OK)
            {
                // Limpiamos el panel
                this.LimpiarPanelDeRegistro();

                return;
            }
        }
        #endregion

        // PARTE CLIENTE:
        #region PanelCLiente
        public void LimpiarPanelCliente()
        {
            // Limpia los campos del cliente
            TBoxNombreApellido.Clear();
            TBoxDNI.Clear();
            TBoxTelefono.Clear();
            TBoxDireccion.Clear();

            cmbBoxObraSocial.Items.Clear();
            // Agregamos items al cmb box Obra Social
            foreach (string obraSocial in gestor.obraSocialesLista)
            {
                cmbBoxObraSocial.Items.Add(obraSocial);
            }
            cmbBoxObraSocial.SelectedItem = cmbBoxObraSocial.Items[0];
        }
        public void DeshabilitarPanelCliente()
        {
            // Deshabilita los TextBox
            TBoxNombreApellido.Enabled = false;
            TBoxDNI.Enabled = false;
            TBoxTelefono.Enabled = false;
            TBoxDireccion.Enabled = false;
            cmbBoxObraSocial.Enabled = false;
        }
        public void HabilitarCamposPanelCliente()
        {
            TBoxNombreApellido.Enabled = true;
            TBoxDNI.Enabled = true;
            TBoxTelefono.Enabled = true;
            TBoxDireccion.Enabled = true;
            cmbBoxObraSocial.Enabled = true;
        }
        private void cmbBoxClienteRegistrado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxClienteRegistrado.SelectedItem == "SI")
            {
                // Restablecemos cliente y receta
                gestor.clienteActual = null;

                // Deshabilita panel cliente
                this.DeshabilitarPanelCliente();

                // Limpia panel cliente
                this.LimpiarPanelCliente();
                cmbBoxObraSocial.SelectedItem = null;

                // Cambia el valor de bandera cliente (NO se registra nuevo cliente)
                gestor.banderaNuevoCliente = false;

                // Habilita objetos para la busqueda:
                this.VisibilizarPanelBusquedaCliente();
                panelBusquedaCliente.Location = new Point(758, 60);

                // Ocultamos otros paneles:
                panelDetallePago.Visible = false;
            }
            else if (cmbBoxClienteRegistrado.SelectedItem == "NO")
            {
                // Restablecemos cliente y receta
                gestor.clienteActual = null;

                // Ocultamos objetos de busqueda de cliente:
                this.OcultarPanelBusquedaCliente();

                // Limpia DGV
                dGVBusquedaCliente.Rows.Clear();

                // Limpia los tText Box
                this.LimpiarPanelCliente();

                // Habilita los TextBox
                this.HabilitarCamposPanelCliente();

                // Validacion de teclas
                TBoxNombreApellido.KeyPress += Nombres_KeyPress;
                TBoxDNI.KeyPress += NumerosComa_KeyPress;
                TBoxTelefono.KeyPress += NumeroTelefono_KeyPress;

                // Cambia valor de bandera cliente (se registra nuevo cliente)
                gestor.banderaNuevoCliente = true;
            }
        }
        private void cmbBoxObraSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            //gestor.clienteActual.obraSocial = cmbBoxObraSocial.SelectedItem.ToString().ToUpper();
        }
        public void TomarDatosCliente()
        {

            gestor.clienteActual.nombre = TBoxNombreApellido.Text.ToUpper();
            gestor.clienteActual.dni = TBoxDNI.Text.ToUpper();
            gestor.clienteActual.direccion = TBoxDireccion.Text.ToUpper();
            gestor.clienteActual.telefono = TBoxTelefono.Text.ToUpper();
            gestor.clienteActual.obraSocial = cmbBoxObraSocial.SelectedItem.ToString().ToUpper();

        }

        // Metodo de validacion de datos del cliente:
        public bool ValidarDatosCliente()
        {
            // Validacion Nombre, si esta bien llama al gestor para que cree el cliente:

            if (!Regex.IsMatch(gestor.clienteActual.nombre, @"\d") && !string.IsNullOrWhiteSpace(gestor.clienteActual.nombre))
            {
                if (!string.IsNullOrWhiteSpace(gestor.clienteActual.dni))
                {
                    if (!string.IsNullOrWhiteSpace(gestor.clienteActual.direccion))
                    {
                        return true;
                    }
                    else
                    {
                        // Mostrar mensaje de error
                        MessageBox.Show("Por favor ingrese una direccion, es un dato importante para la facturacion).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else
                {
                    // Mostrar mensaje de error
                    MessageBox.Show("Por favor ingrese el DNI del cliente, es un dato importante para la facturacion).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                AvisoNombreMal ventanaAvisoNombreMal = new AvisoNombreMal();
                ventanaAvisoNombreMal.Show();
                return false;
            }
        }
        private void btnEditarClienteCargado_Click(object sender, EventArgs e)
        {
            // se habilita la bandera del cliente editado
            gestor.banderaClienteEditado = true;

            // Habilita los TextBox
            this.HabilitarCamposPanelCliente();

            // Validacion de teclas
            TBoxNombreApellido.KeyPress += Nombres_KeyPress;
            TBoxDNI.KeyPress += NumerosComa_KeyPress;
            TBoxTelefono.KeyPress += NumeroTelefono_KeyPress;
        }
        #endregion

        // PARTE DETALLE PAGO:
        #region DetallePago

        // Botones generales
        private void btnCancelarFacturacion_Click(object sender, EventArgs e)
        {
            panelDetallePago.Visible = false;
            this.LimpiarDP();
        }
        // Metodo para limpiar el DP
        private void btnLimpiarCamposDP_Click(object sender, EventArgs e)
        {
            this.LimpiarDP();
        }
        private void LimpiarDP()
        {
            // Resetear checks box
            checkBoxEfectivo.Checked = false;
            checkBoxTransferencia.Checked = false;
            checkBoxTarjeta.Checked = false;
            checkBoxTarjeta1.Checked = false;
            checkBoxTarjeta2.Checked = false;
            checkBoxMutual.Checked = false;

            TBoxEfectivo.Text = "0";
            TBoxTarjeta1.Text = "0";
            TBoxTarjeta2.Text = "0";
            TBoxTarjetaTotal.Text = "0";
            TBoxTransferencia.Text = "0";
            TBoxTotalDelPagoAct.Text = "0";
            TBoxMutual.Text = "0";

            cmbBoxTar1CreDeb.SelectedItem = null;
            cmbBoxMarcaTar1.SelectedItem = null;

            cmbBoxTar2CreDeb.SelectedItem = null;
            cmbBoxMarcaTar2.SelectedItem = null;

            TBoxNumeroTar1.Text = "XXXX";
            TBoxNumeroTar2.Text = "XXXX";

            cmbBoxFacturacion.SelectedItem = "NO";

            TBoxObservacionesCobro.Text = "Ninguna";

            gestor.cobroDelPedido = null;
            gestor.facturaDelCobro = null;
        }
        private void btnConfirmarDetallePago_Click(object sender, EventArgs e)
        {
            // Validamos los metodos de pago:

            // Banderas de validaciones:
            bool banderaEfectivo = true;
            bool banderaTarjetas = true;
            bool banderaTransferencia = true;
            bool banderaFacturacion = true;
            bool banderaMutual = true;

            // SI hay pago con efectivo
            if (checkBoxEfectivo.Checked == true)
            {
                banderaEfectivo = this.ValidarEfectivoIngresado();
            }
            else
            {
                gestor.cobroDelPedido.dineroEfectivo = 0;
            }
            // Si hay pago con obra social
            if (checkBoxMutual.Checked == true)
            {
                banderaMutual = this.ValidarMutualIngresado();
            }
            else
            {
                gestor.cobroDelPedido.dineroObraSocial = 0;
                gestor.cobroDelPedido.nombreObraSocial = null;
            }

            // SI hay transferencia
            if (checkBoxTransferencia.Checked == true)
            {
                banderaTransferencia = this.ValidarTransferenciaIngresada();

            }
            else
            {
                gestor.cobroDelPedido.dineroTransferencia = 0;
            }

            // Si hay pago con tarjetas:
            if (checkBoxTarjeta.Checked == true)
            {
                banderaTarjetas = false;
                // tarjeta 1 o 2
                if (checkBoxTarjeta1.Checked == true || checkBoxTarjeta2.Checked == true)
                {
                    banderaTarjetas = this.ValidarTarjetasIngresadas();
                }
                // Ver si aca iria validacion de que se selecciono tarjeta pero no se ingreso ninguna.
            }
            else
            {
                gestor.cobroDelPedido.dineroTarjeta1 = 0;
                gestor.cobroDelPedido.dineroTarjeta2 = 0;
            }

            // Tomamos aclaraciones del pago
            gestor.cobroDelPedido.aclaracionesDeCobro = TBoxObservacionesCobro.Text;

            // Falta lo de la facturacion:
            if (cmbBoxFacturacion.SelectedItem == "NO")
            {
                gestor.cobroDelPedido.factura = gestor.facturaDelCobro;
                banderaFacturacion = true;
            }
            else if (cmbBoxFacturacion.SelectedItem == "SI")
            {
                // Acordate de validar que el total de items facturados no supere a la sumatoria de todo el dinero del cobro!
                banderaFacturacion = false;
                // comienzo de validaciones
                if (gestor.facturaDelCobro.items.Count > 0 && gestor.facturaDelCobro.totalItems.Count > 0
                    && gestor.facturaDelCobro.items.Count == gestor.facturaDelCobro.totalItems.Count &&
                    float.TryParse(TBoxTotalItemsFacturados.Text, out float totalItemsFacturados))
                {
                    gestor.cobroDelPedido.factura = gestor.facturaDelCobro;
                    gestor.totalFacturado = totalItemsFacturados;
                    banderaFacturacion = true;
                }
                else
                {
                    // Mostrar mensaje de error
                    MessageBox.Show("Hay un error en los items de facturacion ingresados. Ingresa al menos un item.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // Validacion final
            if (banderaEfectivo && banderaTransferencia && banderaTarjetas && banderaFacturacion && banderaMutual &&
                float.TryParse(TBoxTotal.Text, out float totalRegistrarPedido) &&
                float.TryParse(TBoxTotalDelPagoAct.Text, out float totalDP)
                && totalDP <= totalRegistrarPedido)
            {
                if (cmbBoxFacturacion.SelectedItem == "SI" &&
                    float.TryParse(TBoxTotalItemsFacturados.Text, out float totalItemsFac) &&
                    totalItemsFac < totalDP)
                {
                    // Se factura y el monto a facturar es menor al total del DP
                    AvisoFacturacion ventanaAvisoFacturacion = new AvisoFacturacion(gestor);
                    ventanaAvisoFacturacion.ShowDialog();

                    if (ventanaAvisoFacturacion.DialogResult == DialogResult.OK)
                    {
                        banderaValoresDinero = true;
                        panelDetallePago.Visible = false;
                        gestor.senaPedido = totalDP;
                        banderaDP = true;
                    }
                }
                else
                {
                    // Se factura y el monto a facturar es igual al total del DP
                    banderaValoresDinero = true;
                    panelDetallePago.Visible = false;
                    gestor.senaPedido = totalDP;
                    banderaDP = true;
                }
            }
            else
            {
                if (banderaEfectivo && banderaTransferencia && banderaTarjetas && banderaFacturacion && banderaMutual)
                {
                    // Estan bien todos los datos ingresados pero el total DP es mayor al total del Registro Pedido
                    AvisoMontoVentaMal ventanaAvisoMontoVentaMal = new AvisoMontoVentaMal();
                    ventanaAvisoMontoVentaMal.Show();
                }
            }
        }

        // Metodos de pagos
        private void checkBoxEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEfectivo.Checked)
            {
                TBoxEfectivo.Enabled = true;
            }
            else
            {
                TBoxEfectivo.Enabled = false;
                TBoxEfectivo.Text = "0";
            }
        }
        private void checkBoxTransferencia_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTransferencia.Checked)
            {
                TBoxTransferencia.Enabled = true;
            }
            else
            {
                TBoxTransferencia.Enabled = false;
                TBoxTransferencia.Text = "0";
            }
        }
        private void checkBoxTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTarjeta.Checked)
            {
                checkBoxTarjeta1.Enabled = true;
                checkBoxTarjeta2.Enabled = true;
            }
            else
            {
                checkBoxTarjeta1.Enabled = false;
                checkBoxTarjeta2.Enabled = false;

                checkBoxTarjeta1.Checked = false;
                checkBoxTarjeta2.Checked = false;

                // Limpiamos el panel
                TBoxTarjeta1.Text = "0";
                cmbBoxMarcaTar1.SelectedItem = null;
                cmbBoxTar1CreDeb.SelectedItem = null;
                TBoxNumeroTar1.Text = "XXXX";

                TBoxTarjeta2.Text = "0";
                cmbBoxMarcaTar2.SelectedItem = null;
                cmbBoxTar2CreDeb.SelectedItem = null;
                TBoxNumeroTar2.Text = "XXXX";
            }
        }
        private void checkBoxMutual_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBoxMutual.Checked)
            {
                TBoxMutual.Enabled = true;
            }
            else
            {
                TBoxMutual.Enabled = false;
                TBoxMutual.Text = "0";
            }
        }

        // Facturacion
        private void cmbBoxFacturacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxFacturacion.SelectedItem == "NO")
            {
                // Limpiamos y deshabilitamos el panel
                panelFactura.Enabled = false;
                dGVItems.Rows.Clear();
                TBoxItemAgg.Clear();
                TBoxTotalItemsFacturados.Text = "0";
                TBoxPrecioItemAgg.Text = "0";

                gestor.facturaDelCobro = new Factura();
                gestor.totalFacturado = 0;
            }
            else if (cmbBoxFacturacion.SelectedItem == "SI")
            {
                // Limpiamos y habilitamos el panel
                panelFactura.Enabled = true;
                dGVItems.Rows.Clear();
                TBoxItemAgg.Clear();
                TBoxTotalItemsFacturados.Text = "0";
                TBoxPrecioItemAgg.Text = "0";

                //creamos la factura
                if (gestor.facturaDelCobro == null)
                {
                    gestor.facturaDelCobro = new Factura();
                    gestor.totalFacturado = 0;
                }
            }
        }
        private void btnAggItem_Click(object sender, EventArgs e)
        {
            // Banderas
            bool banderaItemCorrectoDeAgg = false;

            if (!string.IsNullOrWhiteSpace(TBoxItemAgg.Text)
                && float.TryParse(TBoxPrecioItemAgg.Text, out float totItem)
                && totItem > 0)
            {
                banderaItemCorrectoDeAgg = true;
            }
            else
            {
                // Mostrar mensaje de error
                MessageBox.Show("Hay un error en la descripcion o el total del item que desa agregar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            if (float.TryParse(TBoxPrecioItemAgg.Text, out float totalItem)
                && (gestor.totalFacturado + totalItem) <= gestor.cobroDelPedido.monto
                && banderaItemCorrectoDeAgg)
            {
                // Añade al dgv
                this.AgregarItemDGV(TBoxItemAgg.Text, totalItem);

                // Añade a cada lista
                gestor.facturaDelCobro.items.Add(TBoxItemAgg.Text);
                gestor.facturaDelCobro.totalItems.Add(totalItem);

                // limpio los text box
                TBoxItemAgg.Clear();
                TBoxPrecioItemAgg.Clear();

                // ACtualizo el valor del total facturado
                gestor.totalFacturado += totalItem;
                TBoxTotalItemsFacturados.Text = gestor.totalFacturado.ToString();

            }
            else
            {
                // Mostrar mensaje de error
                MessageBox.Show("Recuerde que la suma de todos los items no puede superar el monto total de cobro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnBorrarItemAgg_Click(object sender, EventArgs e)
        {
            if (dGVItems.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dGVItems.SelectedRows[0];

                int numeroItem = Convert.ToInt32(filaSeleccionada.Cells["NumeroItem"].Value);

                foreach (DataGridViewRow fila in dGVItems.Rows)
                {
                    int numeroItemFila = Convert.ToInt32(fila.Cells["NumeroItem"].Value);
                    if (numeroItemFila == numeroItem)
                    {
                        // Removemos el ítem de la lista
                        gestor.facturaDelCobro.items.Remove(gestor.facturaDelCobro.items[numeroItem - 1]);
                        gestor.facturaDelCobro.totalItems.Remove(gestor.facturaDelCobro.totalItems[numeroItem - 1]);

                        // Removemos la fila del DataGridView
                        dGVItems.Rows.Clear();

                        float totalFacturadoAcumulador = 0;

                        for (int i = 0; i <= gestor.facturaDelCobro.items.Count - 1; i++)
                        {
                            this.AgregarItemDGVCicloFor(gestor.facturaDelCobro.items[i], gestor.facturaDelCobro.totalItems[i], i);

                            totalFacturadoAcumulador += gestor.facturaDelCobro.totalItems[i];
                        }

                        TBoxTotalItemsFacturados.Text = totalFacturadoAcumulador.ToString();
                        gestor.totalFacturado = totalFacturadoAcumulador;

                        // Salimos del bucle ya que hemos encontrado y eliminado la fila deseada
                        break;
                    }
                }
            }
            else
            {
                // Mostrar mensaje de error
                MessageBox.Show("No hay ningun item seleccionado para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // Agg un item al dgv facturas
        public void AgregarItemDGV(string itemDesc, float montoItem)
        {
            DataGridViewRow fila = new DataGridViewRow();

            DataGridViewTextBoxCell NumeroItem = new DataGridViewTextBoxCell();
            NumeroItem.Value = (gestor.facturaDelCobro.items.Count + 1);

            DataGridViewTextBoxCell DescripcionItem = new DataGridViewTextBoxCell();
            DescripcionItem.Value = itemDesc;

            DataGridViewTextBoxCell TotalItem = new DataGridViewTextBoxCell();
            TotalItem.Value = montoItem;

            fila.Cells.Add(NumeroItem);
            fila.Cells.Add(DescripcionItem);
            fila.Cells.Add(TotalItem);

            dGVItems.Rows.Add(fila);
        }
        public void AgregarItemDGVCicloFor(string itemDesc, float montoItem, int pos)
        {
            DataGridViewRow fila = new DataGridViewRow();

            DataGridViewTextBoxCell NumeroItem = new DataGridViewTextBoxCell();
            NumeroItem.Value = (pos + 1);

            DataGridViewTextBoxCell DescripcionItem = new DataGridViewTextBoxCell();
            DescripcionItem.Value = itemDesc;

            DataGridViewTextBoxCell TotalItem = new DataGridViewTextBoxCell();
            TotalItem.Value = montoItem;

            fila.Cells.Add(NumeroItem);
            fila.Cells.Add(DescripcionItem);
            fila.Cells.Add(TotalItem);

            dGVItems.Rows.Add(fila);
        }

        // SUB-REGIONES:

        // PARTE ACTUALIZACION DEL MONTO DEL DP:
        #region ActualizacionTotalDP
        private void TBoxMutual_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(TBoxMutual.Text, out float montoMutual))
            {
                if (this.ActualizarMontoCobro())
                {
                    // Nada todo ok
                }
                else
                {
                    TBoxMutual.Text = "0";
                    checkBoxMutual.Checked = false;
                }
            }
        }
        private void TBoxEfectivo_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(TBoxEfectivo.Text, out float montoEfectivo))
            {
                if (this.ActualizarMontoCobro())
                {
                    // Nada todo ok
                }
                else
                {
                    TBoxEfectivo.Text = "0";
                    checkBoxEfectivo.Checked = false;
                }
            }
        }
        private void TBoxTransferencia_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(TBoxTransferencia.Text, out float montoEfectivo))
            {
                if (this.ActualizarMontoCobro())
                {
                    // Nada todo ok
                }
                else
                {
                    TBoxTransferencia.Text = "0";
                    checkBoxTransferencia.Checked = false;
                }
            }
        }
        private void TBoxTarjeta1_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(TBoxTarjeta1.Text, out float nuevoTar1) && float.TryParse(TBoxTarjeta2.Text, out float nuevoTar2))
            {
                if (this.ActualizarMontoCobro())
                {
                    TBoxTarjetaTotal.Text = (nuevoTar1 + nuevoTar2).ToString();
                }
                else
                {
                    checkBoxTarjeta1.Checked = false;
                    cmbBoxTar1CreDeb.SelectedItem = null;
                    cmbBoxMarcaTar1.SelectedItem = null;
                    TBoxTarjeta1.Text = "0";
                    TBoxNumeroTar1.Text = "XXXX";

                    if (checkBoxTarjeta2.Checked == false)
                    {
                        checkBoxTarjeta.Checked = false;

                        checkBoxTarjeta1.Enabled = false;
                        checkBoxTarjeta2.Enabled = false;
                    }
                }
            }
            else
            {
                TBoxTarjetaTotal.Text = "0";
            }
        }
        private void TBoxTarjeta2_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(TBoxTarjeta1.Text, out float nuevoTar1) && float.TryParse(TBoxTarjeta2.Text, out float nuevoTar2))
            {
                if (this.ActualizarMontoCobro())
                {
                    TBoxTarjetaTotal.Text = (nuevoTar1 + nuevoTar2).ToString();
                }
                else
                {
                    checkBoxTarjeta2.Checked = false;
                    cmbBoxTar2CreDeb.SelectedItem = null;
                    cmbBoxMarcaTar2.SelectedItem = null;
                    TBoxTarjeta2.Text = "0";
                    TBoxNumeroTar2.Text = "XXXX";

                    if (checkBoxTarjeta1.Checked == false)
                    {
                        checkBoxTarjeta.Checked = false;

                        checkBoxTarjeta1.Enabled = false;
                        checkBoxTarjeta2.Enabled = false;
                    }
                }
            }
            else
            {
                TBoxTarjetaTotal.Text = "0";
            }
        }

        // Metodo que se invoca opara actualizar el monto del cobro (DP)
        public bool ActualizarMontoCobro()
        {
            if (float.TryParse(TBoxEfectivo.Text, out float montoEfectivo) &&
            float.TryParse(TBoxTransferencia.Text, out float montoTransf) &&
            float.TryParse(TBoxTarjeta1.Text, out float montoTar1) &&
            float.TryParse(TBoxTarjeta2.Text, out float montoTar2) &&
            float.TryParse(TBoxMutual.Text, out float montoMutual) &&
            float.TryParse(TBoxTotal.Text, out float total))
            {
                if ((montoEfectivo + montoTransf + montoTar1 + montoTar2 + montoMutual) <= total)
                {
                    gestor.cobroDelPedido.monto = montoEfectivo + montoTransf + montoTar1 + montoTar2 + montoMutual;
                    TBoxTotalDelPagoAct.Text = gestor.cobroDelPedido.monto.ToString();
                    lblSaldoRestanteCompletar.Text = (total - (montoEfectivo + montoTransf + montoTar1 + montoTar2 + montoMutual)).ToString();
                    return true;
                }
                else
                {
                    // Mostrar mensaje de error
                    MessageBox.Show("Recuerde que el monto del cobro no puede superar al total.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        #endregion

        // PARTE HABILITAR DESHABILITAR TARJETAS DP:
        #region TarjetasDP
        // CheckBox tarjeta 1
        private void checkBoxTarjeta1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTarjeta1.Checked)
            {
                cmbBoxTar1CreDeb.Enabled = true;
                TBoxTarjeta1.Enabled = true;
                TBoxNumeroTar1.Enabled = true;

                // Cargamos combo Box
                // Llenamos los comboBox
                cmbBoxTar1CreDeb.Items.Clear();
                cmbBoxTar1CreDeb.Items.AddRange(new string[] { "Debito", "Credito" });

            }
            else
            {
                cmbBoxTar1CreDeb.SelectedItem = null;
                cmbBoxMarcaTar1.SelectedItem = null;
                TBoxTarjeta1.Text = "0";
                TBoxNumeroTar1.Text = "XXXX";

                cmbBoxTar1CreDeb.Enabled = false;
                cmbBoxMarcaTar1.Enabled = false;
                TBoxTarjeta1.Enabled = false;
                TBoxNumeroTar1.Enabled = false;
            }
        }

        // cmbBox credito/debito tarjeta 1 (que pasa al cambiar la seleccion)
        private void cmbBoxTar1CreDeb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxTar1CreDeb.SelectedItem == "Credito")
            {
                cmbBoxMarcaTar1.Enabled = true;
                cmbBoxMarcaTar1.Items.Clear();
                cmbBoxMarcaTar1.Items.AddRange(new string[] { "Visa", "Mastercard", "Naranja", "Cabal" });
            }
            else if (cmbBoxTar1CreDeb.SelectedItem == "Debito")
            {
                cmbBoxMarcaTar1.Enabled = true;
                cmbBoxMarcaTar1.Items.Clear();
                cmbBoxMarcaTar1.Items.AddRange(new string[] { "Visa", "Mastercard", "Cabal" });
            }
        }

        // CheckBox tarjeta 2
        private void checkBoxTarjeta2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTarjeta2.Checked)
            {
                cmbBoxTar2CreDeb.Enabled = true;
                TBoxTarjeta2.Enabled = true;
                TBoxNumeroTar2.Enabled = true;

                // Cargamos combo Box
                // Llenamos los comboBox
                cmbBoxTar2CreDeb.Items.Clear();
                cmbBoxTar2CreDeb.Items.AddRange(new string[] { "Debito", "Credito" });

            }
            else
            {
                cmbBoxTar2CreDeb.SelectedItem = null;
                cmbBoxMarcaTar2.SelectedItem = null;
                TBoxTarjeta2.Text = "0";
                TBoxNumeroTar2.Text = "XXXX";

                cmbBoxTar2CreDeb.Enabled = false;
                cmbBoxMarcaTar2.Enabled = false;
                TBoxTarjeta2.Enabled = false;
                TBoxNumeroTar2.Enabled = false;
            }
        }

        // cmbBox credito/debito tarjeta 1 (que pasa al cambiar la seleccion)
        private void cmbBoxTar2CreDeb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxTar2CreDeb.SelectedItem == "Credito")
            {
                cmbBoxMarcaTar2.Enabled = true;
                cmbBoxMarcaTar2.Items.Clear();
                cmbBoxMarcaTar2.Items.AddRange(new string[] { "Visa", "Mastercard", "Naranja", "Cabal" });
            }
            else if (cmbBoxTar2CreDeb.SelectedItem == "Debito")
            {
                cmbBoxMarcaTar2.Enabled = true;
                cmbBoxMarcaTar2.Items.Clear();
                cmbBoxMarcaTar2.Items.AddRange(new string[] { "Visa", "Mastercard", "Cabal" });
            }
        }
        #endregion

        // VALIDACIONES DEL DP
        #region ValidacionesDP
        bool ValidarEfectivoIngresado()
        {
            // Valido que sea mayor a 0
            if (float.TryParse(TBoxEfectivo.Text, out float montoEfectivo) && montoEfectivo > 0)
            {
                gestor.cobroDelPedido.dineroEfectivo = montoEfectivo;
                return true;
            }
            else
            {
                // Mostrar mensaje de error
                MessageBox.Show("Hay un error en el monto de efectivo ingresado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        bool ValidarTransferenciaIngresada()
        {
            // Valido que sea mayor a 0
            if (float.TryParse(TBoxTransferencia.Text, out float montoTransferencia) && montoTransferencia > 0)
            {
                gestor.cobroDelPedido.dineroTransferencia = montoTransferencia;
                return true;
            }
            else
            {
                // Mostrar mensaje de error
                MessageBox.Show("Hay un error en el monto de transferencia ingresado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        bool ValidarTarjetasIngresadas()
        {
            // Banderas
            bool bandera1 = true;
            bool bandera2 = true;

            if (checkBoxTarjeta1.Checked == true)
            {
                bandera1 = false;
                if (float.TryParse(TBoxTarjeta1.Text, out float montoTar1)
                    && montoTar1 > 0
                    && cmbBoxMarcaTar1.SelectedItem != null
                    && cmbBoxTar1CreDeb.SelectedItem != null
                    && TBoxNumeroTar1.Text != "XXXX"
                    && TBoxNumeroTar1.Text.Length == 4)
                {
                    gestor.cobroDelPedido.dineroTarjeta1 = montoTar1;
                    gestor.cobroDelPedido.marcaTarjeta1 = cmbBoxMarcaTar1.SelectedItem.ToString();
                    gestor.cobroDelPedido.tipoTarjeta1 = cmbBoxTar1CreDeb.SelectedItem.ToString();
                    gestor.cobroDelPedido.Ultimos4NumerosTarejta1 = TBoxNumeroTar1.Text;

                    bandera1 = true;
                }
                else
                {
                    // Mostrar mensaje de error
                    MessageBox.Show("Hay un error en los datos ingresados de la tarjeta 1." +
                        "\n Por favor complete todos los campos. " +
                        "\n (num tarjeta tiene que se distinto de XXXX)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

            if (checkBoxTarjeta2.Checked == true)
            {
                bandera2 = false;
                if (float.TryParse(TBoxTarjeta2.Text, out float montoTar2)
                    && montoTar2 > 0
                    && cmbBoxMarcaTar2.SelectedItem != null
                    && cmbBoxTar2CreDeb.SelectedItem != null
                    && TBoxNumeroTar2.Text != "XXXX"
                    && TBoxNumeroTar2.Text.Length == 4)
                {
                    gestor.cobroDelPedido.dineroTarjeta2 = montoTar2;
                    gestor.cobroDelPedido.marcaTarjeta2 = cmbBoxMarcaTar2.SelectedItem.ToString();
                    gestor.cobroDelPedido.tipoTarjeta2 = cmbBoxTar2CreDeb.SelectedItem.ToString();
                    gestor.cobroDelPedido.Ultimos4NumerosTarejta2 = TBoxNumeroTar2.Text;

                    bandera2 = true;
                }
                else
                {
                    // Mostrar mensaje de error
                    MessageBox.Show("Hay un error en los datos ingresados de la tarjeta 2." +
                        "\n Por favor complete todos los campos. " +
                        "\n (num tarjeta tiene que se distinto de XXXX)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

            if (bandera1 && bandera2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool ValidarMutualIngresado()
        {
            // Valido que sea mayor a 0
            if (float.TryParse(TBoxMutual.Text, out float montoMutual) && montoMutual > 0)
            {
                gestor.cobroDelPedido.dineroObraSocial = montoMutual;
                gestor.cobroDelPedido.nombreObraSocial = cmbBoxObraSocial.SelectedItem.ToString();
                return true;
            }
            else
            {
                // Mostrar mensaje de error
                MessageBox.Show("Hay un error en el monto de mutual ingresado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        #endregion

        #endregion

        // PARTE ANTEOJO SOL:
        #region AnteojoSol
        void LimpiarPanelSol()
        {
            checkBoxSol.Checked = false;
            TBoxDetalleSol.Enabled = false;
            TBoxDetalleSol.Text = "Ninguna.";
        }
        private void checkBoxSol_CheckedChanged(object sender, EventArgs e)
        {
            // Check box para no rellenar sol
            if (checkBoxSol.Checked)
            {
                TBoxDetalleSol.Enabled = false;
                TBoxDetalleSol.Text = "Ninguna.";

                checkBoxReparacion.Checked = false;
                TBoxDetalleReparacion.Enabled = true;
                TBoxDetalleReparacion.Text = "";
            }
            else
            {
                TBoxDetalleSol.Enabled = true;
                TBoxDetalleSol.Text = "";
            }
        }
        #endregion

        // PARTE REPARACION:
        #region Reparacion
        void LimpiarPanelReparacion()
        {
            checkBoxReparacion.Checked = false;
            TBoxDetalleReparacion.Enabled = false;
            TBoxDetalleReparacion.Text = "Ninguna.";
        }
        private void checkBoxReparacion_CheckedChanged(object sender, EventArgs e)
        {
            // Check box para no rellenar reparacion
            if (checkBoxReparacion.Checked)
            {
                TBoxDetalleReparacion.Enabled = false;
                TBoxDetalleReparacion.Text = "Ninguna.";

                checkBoxSol.Checked = false;
                TBoxDetalleSol.Enabled = true;
                TBoxDetalleSol.Text = "";
            }
            else
            {
                TBoxDetalleReparacion.Enabled = true;
                TBoxDetalleReparacion.Text = "";
            }
        }
        #endregion

        // PARTE PANEL BUSQUEDA DE CLIENTE:
        #region PanelBusquedaCliente
        public void OcultarPanelBusquedaCliente()
        {
            panelBusquedaCliente.Visible = false;
            panelColorTurBusqueda.Visible = false;
            lblNombreBusqueda.Visible = false;
            TBoxNombreBusqueda.Visible = false;
            dGVBusquedaCliente.Visible = false;
            btnCancelarBusqueda.Visible = false;
            btnSeleccionarClienteBusqueda.Visible = false;
        }
        public void VisibilizarPanelBusquedaCliente()
        {
            panelBusquedaCliente.Visible = true;
            panelColorTurBusqueda.Visible = true;
            lblTituloBusqueda.Visible = true;
            dGVBusquedaCliente.Visible = true;
            btnBuscarCliente.Visible = true;
            btnSeleccionarClienteBusqueda.Visible = true;
            btnCancelarBusqueda.Visible = true;
            lblNombreBusqueda.Visible = true;
            TBoxNombreBusqueda.Visible = true;
        }
        // Agg un item al dgv facturas
        private void btnSeleccionarClienteBusqueda_Click(object sender, EventArgs e)
        {
            if (dGVBusquedaCliente.SelectedRows.Count > 0)
            {
                // Habilitar el boton de editar cliente
                btnEditarClienteCargado.Enabled = true;

                DataGridViewRow filaSeleccionada = dGVBusquedaCliente.SelectedRows[0];

                int IdClienteSelec = Convert.ToInt32(filaSeleccionada.Cells["IdCliente"].Value);

                // Debe indicar cual es el objeto cliente seleccionado
                gestor.SetClienteActualYaRegistrado(IdClienteSelec);

                // Debe completar los text box del registro con los datos del cliente seleccionado
                // Datos cliente
                TBoxNombreApellido.Text = gestor.clienteActual.nombre;
                TBoxTelefono.Text = gestor.clienteActual.telefono;
                TBoxDNI.Text = gestor.clienteActual.dni;
                TBoxDireccion.Text = gestor.clienteActual.direccion;


                for (int i = 0; i < gestor.obraSocialesLista.Count; i++)
                {
                    if (gestor.obraSocialesLista[i] == gestor.clienteActual.obraSocial)
                    {
                        cmbBoxObraSocial.SelectedIndex = i;
                        break;
                    }
                }

                // oculta los objetos de la busqueda:
                panelBusquedaCliente.Visible = false;

                // Limpiar dgv
                TBoxNombreBusqueda.Clear();
                dGVBusquedaCliente.Rows.Clear();
            }
            else
            {
                AvisoNoHayCLienteSeleccionado ventanaAviso = new AvisoNoHayCLienteSeleccionado();
                ventanaAviso.Show();
            }
        }
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
                AvisoNoHayCLientes ventanaAvisoNoHayCLientes = new AvisoNoHayCLientes();
                ventanaAvisoNoHayCLientes.Show();
            }
        }

        // Metodo para agregar los clientes al data grid view
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

        private void btnCancelarBusqueda_Click(object sender, EventArgs e)
        {
            // oculta los objetos de la busqueda:
            panelBusquedaCliente.Visible = false;

            // Limpiar dgv
            TBoxNombreBusqueda.Clear();
            dGVBusquedaCliente.Rows.Clear();
        }
        #endregion

        // KEYPRESS:
        #region KeyPress
        // Para que solo se ingresen numeros
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Expresión regular que solo permite números
            Regex regex = new Regex(@"[^0-9]");

            // Verificar si el carácter ingresado coincide con la expresión regular
            if (regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                // Si no coincide, cancelar la pulsación
                e.Handled = true;
                // Reproducir un sonido de error
                SystemSounds.Beep.Play();
            }
        }
        // Para nombres
        private void Nombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Expresión regular que permite letras, espacios y algunos caracteres especiales comunes en nombres
            Regex regex = new Regex(@"[^a-zA-ZñÑ\s\-\'\,]");

            // Verificar si el carácter ingresado coincide con la expresión regular
            if (regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                // Si no coincide, cancelar la pulsación
                e.Handled = true;
                // Reproducir un sonido de error
                SystemSounds.Beep.Play();
            }
        }

        // Para que solo se ingresen numeros, coma y punto
        private void NumeroTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Expresión regular que solo permite números, paréntesis y guiones
            Regex regex = new Regex(@"[^0-9\(\)\-]");

            // Verificar si el carácter ingresado coincide con la expresión regular
            if (regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                // Si no coincide, cancelar la pulsación
                e.Handled = true;
                // Reproducir un sonido de error
                SystemSounds.Beep.Play();
            }
        }

        // Para que solo se ingresen numeros, coma y punto
        private void NumerosComa_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Expresión regular que solo permite números, puntos y comas
            Regex regex = new Regex(@"[^0-9.,]");

            // Verificar si el carácter ingresado coincide con la expresión regular
            if (regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                // Si no coincide, cancelar la pulsación
                e.Handled = true;
                // Reproducir un sonido de error
                SystemSounds.Beep.Play();
            }
        }

        #endregion

        // ENTERS:
        #region Enters
        private void TBoxDetalleSol_Enter(object sender, EventArgs e)
        {
            TBoxDetalleSol.Text = "";
        }

        private void TBoxDetalleReparacion_Enter(object sender, EventArgs e)
        {
            TBoxDetalleReparacion.Text = "";
        }

        private void TBoxTotal_Enter(object sender, EventArgs e)
        {
            TBoxTotal.Text = "";
        }

        private void TBoxObservacionesPago_Enter(object sender, EventArgs e)
        {
            TBoxObservacionesPago.Text = "";
        }
        private void TBoxTransferencia_Enter(object sender, EventArgs e)
        {
            TBoxTransferencia.Text = "";
        }

        private void TBoxTarjeta1_Enter(object sender, EventArgs e)
        {
            TBoxTarjeta1.Text = "";
        }

        private void TBoxNumeroTar1_Enter(object sender, EventArgs e)
        {
            TBoxNumeroTar1.Text = "";
        }

        private void TBoxNumeroTar2_Enter(object sender, EventArgs e)
        {
            TBoxNumeroTar2.Text = "";
        }

        private void TBoxTarjeta2_Enter(object sender, EventArgs e)
        {
            TBoxTarjeta2.Text = "";
        }

        private void TBoxObservacionesCobro_Enter(object sender, EventArgs e)
        {
            TBoxObservacionesCobro.Text = "";
        }

        private void TBoxPrecioItemAgg_Enter(object sender, EventArgs e)
        {
            TBoxPrecioItemAgg.Text = "";
        }
        private void TBoxEfectivo_Enter(object sender, EventArgs e)
        {
            TBoxEfectivo.Text = "";
        }
        private void TBoxMutual_Enter(object sender, EventArgs e)
        {
            TBoxMutual.Text = "";
        }
        #endregion




    }
}
