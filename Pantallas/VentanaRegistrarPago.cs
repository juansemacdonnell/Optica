using OpricaSurinV2;
using OpricaSurinV2.Pantallas;
using OpticaSurinV2.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpticaSurinV2.Pantallas
{
    public partial class VentanaRegistrarPago : Form
    {
        Gestor gestor;
        public VentanaRegistrarPago(Gestor gestor)
        {
            InitializeComponent();

            // Establecer la posición de inicio de la ventana
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 10);


            this.gestor = gestor;

            gestor.cobroDelPedido = new Cobro();
            gestor.facturaDelCobro = new Factura();

            // Cargamos cmb facturacion:
            cmbBoxFacturacion.Items.Clear();
            cmbBoxFacturacion.Items.AddRange(new string[] { "NO", "SI" });
            cmbBoxFacturacion.SelectedItem = cmbBoxFacturacion.Items[0];

            // Habilitamos la otra ventana, cargamos datos del pedido
            richTextBoxObservacionPagoCompletar.Text = string.Format(gestor.pedidoSeleccionado.observaciones);
            lblSaldoRestanteCompletar.Text = gestor.pedidoSeleccionado.saldo.ToString();

            // Cargamos validaciones de keypress
            // Habilitamos las validaciones:
            TBoxTransferencia.KeyPress += NumerosComa_KeyPress;
            TBoxEfectivo.KeyPress += NumerosComa_KeyPress;
            TBoxMutual.KeyPress += NumerosComa_KeyPress;

            TBoxNumeroTar1.KeyPress += SoloNumeros_KeyPress;
            TBoxNumeroTar2.KeyPress += SoloNumeros_KeyPress;

            TBoxTarjeta1.KeyPress += NumerosComa_KeyPress;
            TBoxTarjeta2.KeyPress += NumerosComa_KeyPress;

            TBoxPrecioItemAgg.KeyPress += NumerosComa_KeyPress;

        }

        // Constructor ventana lado derecho:
        public VentanaRegistrarPago(Gestor gestor, int numero)
        {
            InitializeComponent();

            // Obtener el ancho de la pantalla
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;

            // Obtener el ancho de la ventana
            int formWidth = this.Width;

            // Calcular la posición de inicio de la ventana
            int xPosition = screenWidth - formWidth;

            // Establecer la posición de inicio de la ventana
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(xPosition, 10);

            this.gestor = gestor;

            gestor.cobroDelPedido = new Cobro();
            gestor.facturaDelCobro = new Factura();

            // Cargamos cmb facturacion:
            cmbBoxFacturacion.Items.Clear();
            cmbBoxFacturacion.Items.AddRange(new string[] { "NO", "SI" });
            cmbBoxFacturacion.SelectedItem = cmbBoxFacturacion.Items[0];

            // Habilitamos la otra ventana, cargamos datos del pedido
            richTextBoxObservacionPagoCompletar.Text = string.Format(gestor.pedidoSeleccionado.observaciones);
            lblSaldoRestanteCompletar.Text = gestor.pedidoSeleccionado.saldo.ToString();
        }

        // REGIONES
        // BOTONES GENERALES
        #region BotnesGenerales
        // Boton cancelar
        private void btnCancelarFacturacion_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.LimpiarDP();
            this.Close();
        }

        // Boton para limpiar
        private void btnLimpiarCamposDP_Click(object sender, EventArgs e)
        {
            this.LimpiarDP();
        }
        // Metodo para limpiar el DP
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

            TBoxObservacionesCobro.Text = "Ninguna.";

            gestor.cobroDelPedido = null;
            gestor.facturaDelCobro = null;
        }

        // Boton para confirmar el Detalle de pago
        private void btnConfirmarDP_Click(object sender, EventArgs e)
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
                float.TryParse(lblSaldoRestanteCompletar.Text, out float saldoRestante) &&
                float.TryParse(TBoxTotalDelPagoAct.Text, out float totalDP)
                && totalDP <= saldoRestante)
            {
                if (cmbBoxFacturacion.SelectedItem == "SI" &&
                    float.TryParse(TBoxTotalItemsFacturados.Text, out float totalItemsFac) &&
                    totalItemsFac < totalDP)
                {
                    AvisoFacturacion ventanaAvisoFacturacion = new AvisoFacturacion(gestor);
                    ventanaAvisoFacturacion.ShowDialog();

                    if (ventanaAvisoFacturacion.DialogResult == DialogResult.OK)
                    {
                        gestor.pedidoSeleccionado.saldo = saldoRestante - totalDP;
                        gestor.pedidoSeleccionado.AggCobro(gestor.cobroDelPedido);

                        gestor.pedidoService.ActualizarPedido(gestor.pedidoSeleccionado);

                        this.DialogResult = DialogResult.OK;

                        gestor.cobroDelPedido = null;
                        gestor.facturaDelCobro = null;

                        this.Close();
                    }
                }
                else
                {
                    gestor.pedidoSeleccionado.saldo = saldoRestante - totalDP;
                    gestor.pedidoSeleccionado.AggCobro(gestor.cobroDelPedido);

                    gestor.pedidoService.ActualizarPedido(gestor.pedidoSeleccionado);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                if (banderaEfectivo && banderaTransferencia && banderaTarjetas && banderaFacturacion && banderaMutual)
                {
                    AvisoMontoVentaMal ventanaAvisoMontoVentaMal = new AvisoMontoVentaMal();
                    ventanaAvisoMontoVentaMal.Show();
                }
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
                gestor.cobroDelPedido.nombreObraSocial = gestor.clienteActual.obraSocial;
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

        // CHECKS DE MP
        #region ChecksBox MP
        private void checkBoxTarjeta_CheckedChanged_1(object sender, EventArgs e)
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

        private void checkBoxEfectivo_CheckedChanged_1(object sender, EventArgs e)
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

        private void checkBoxTransferencia_CheckedChanged_1(object sender, EventArgs e)
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
        private void checkBoxMutual_CheckedChanged(object sender, EventArgs e)
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
        #endregion

        // PARTE ACTUALIZACION MONTOS
        #region ActualizacionMonto
        // Metodos si cambia el contenido de los TBox de DP
        private void TBoxEfectivo_TextChanged_1(object sender, EventArgs e)
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
        private void TBoxTransferencia_TextChanged_1(object sender, EventArgs e)
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
        // Metodos que al captar una modificacion en un TBox modifican el saldo de seña
        private void TBoxTarjeta1_TextChanged_1(object sender, EventArgs e)
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
        private void TBoxTarjeta2_TextChanged_1(object sender, EventArgs e)
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

        // Metodo que se invoca opara actualizar el monto del cobro (DP)
        public bool ActualizarMontoCobro()
        {
            if (float.TryParse(TBoxEfectivo.Text, out float montoEfectivo) &&
            float.TryParse(TBoxTransferencia.Text, out float montoTransf) &&
            float.TryParse(TBoxTarjeta1.Text, out float montoTar1) &&
            float.TryParse(TBoxTarjeta2.Text, out float montoTar2) &&
            float.TryParse(TBoxMutual.Text, out float montoMutual) &&
            float.TryParse(lblSaldoRestanteCompletar.Text, out float saldoRestante))
            {
                if ((montoEfectivo + montoTransf + montoTar1 + montoTar2+ montoMutual) <= saldoRestante)
                {
                    gestor.cobroDelPedido.monto = montoEfectivo + montoTransf + montoTar1 + montoTar2 + montoMutual;
                    TBoxTotalDelPagoAct.Text = gestor.cobroDelPedido.monto.ToString();
                    return true;
                }
                else
                {
                    // Mostrar mensaje de error
                    MessageBox.Show("Recuerde que el monto del cobro no puede superar al saldo restante.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        #endregion

        // FACTURACION
        #region Facturacion
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

        // Boton para agg un item al DGV facturas
        private void btnAggItem_Click_1(object sender, EventArgs e)
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

        // Boton para borrar un item del DGV Facturas
        private void btnBorrarItemAgg_Click_1(object sender, EventArgs e)
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
        // Agg un item al dgv facturas
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
        #endregion

        // PARTE HABILITAR DESHABILITAR TARJETAS DP:
        #region Tarjetas
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

        // cmbBox credito/debito tarjeta 2 (que pasa al cambiar la seleccion)
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

        // ENTERS
        #region Enters (limpian TBox)
        private void TBoxEfectivo_Enter(object sender, EventArgs e)
        {
            TBoxEfectivo.Text = "";
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
        private void TBoxPrecioItemAgg_Enter(object sender, EventArgs e)
        {
            TBoxPrecioItemAgg.Text = "";
        }
        private void TBoxObservacionesCobro_Enter(object sender, EventArgs e)
        {
            TBoxObservacionesCobro.Text = "";
        }
        private void TBoxTarjeta2_Enter(object sender, EventArgs e)
        {
            TBoxTarjeta2.Text = "";
        }
        private void TBoxMutual_Enter(object sender, EventArgs e)
        {
            TBoxMutual.Text = "";
        }
        #endregion

        // KEYPRESS:
        #region KeyPress
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
        #endregion






    
    }
}
