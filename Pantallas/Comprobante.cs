using OpricaSurinV2.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpricaSurinV2;
using System.Drawing.Imaging;
using System.Reflection.Metadata;
using iTextSharp.text;
using iTextSharp.text.pdf;
using static System.Runtime.InteropServices.JavaScript.JSType;
using OpticaSurinV2.Clases;
using System.Text.RegularExpressions;


namespace OpricaSurinV2.Pantallas
{
    public partial class Comprobante : Form
    {
        // Variables
        private Gestor gestor;

        // Constructor Comprobante Registrar Pedido
        public Comprobante(Gestor gestor)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            panelRegistroPago.Visible = false;
            // Creamos el gestor
            this.gestor = gestor;

            // Llenamos los campos del comprobante
            this.LlenarCamposComprobante();
        }

        // Constructor  Comprobante Consultar Cliente Receta
        public Comprobante(Gestor gestor, int numero)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Creamos el gestor
            this.gestor = gestor;

            // Llenamos los campos del comprobante
            this.LlenarCamposComprobanteConsultar();

            // Botones
            btnConfirmar.Visible = false;
            btnAtrasEditarDatos.Text = "Volver atras";
            btnReimprimir.Visible = true;
            btnReimprimir.Location = new Point(281, 667);

            // Cargamos info de cobros
            this.CompletarInfoDeCobros();
        }

        // Constructor  Comprobante Sol y Reparacion
        public Comprobante(Gestor gestor, string tipo)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Creamos el gestor
            this.gestor = gestor;

            // Ocultamos campos de receta:
            this.OcultarCamposReceta();
            // ocultamos panel de info
            panelInfoCobros.Visible = false;
            panelRegistroPago.Visible = false;

            // Llenamos los campos del comprobante anteojo sol / receta
            this.LlenarCamposComprobante(tipo);

            // Botones
            btnConfirmar.Visible = true;
            btnReimprimir.Visible = false;
            btnConfirmar.Location = new Point(281, 667);

        }

        // Constructor  Comprobante Consultar Cliente Sol y Reparacion
        public Comprobante(Gestor gestor, string tipo, int numero)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Creamos el gestor
            this.gestor = gestor;

            // Ocultamos campos de receta:
            this.OcultarCamposReceta();
            // ocultamos panel de info
            panelInfoCobros.Visible = false;
            panelRegistroPago.Visible = true;

            // Llenamos los campos del comprobante anteojo sol / receta
            this.LlenarCamposComprobanteConsultar(tipo);

            // Botones
            btnConfirmar.Visible = false;
            btnAtrasEditarDatos.Text = "Volver atras";
            btnReimprimir.Visible = true;
            btnReimprimir.Location = new Point(281, 667);

            // Cargamos info de cobros
            this.CompletarInfoDeCobros();
        }

        // REGIONES
        // COMPROBANTE GENERAL:
        #region ComprobanteGeneral
        // Boton atras
        private void btnAtrasEditarDatos_Click(object sender, EventArgs e)
        {
            // Caso para muestra pedido
            gestor.pedidoSeleccionado = null;

            // Actualizamos el dialog result
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Boton confirmar
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Actualizamos el dialog result
            this.DialogResult = DialogResult.OK;

            // Definimos el tipo de pedido
            string tipoPedido;
            Pedido nuevoPedido = new Pedido();
            if (gestor.recetaDelPedido != null & gestor.detalleReparacion == null && gestor.detalleSol == null)
            {
                tipoPedido = "RECETA";
                // Creamos el pedido:
                nuevoPedido = new Pedido(gestor.GetReceta(), gestor.GetCliente(), gestor.GetTotal(),
                    gestor.GetSena(), gestor.GetFechaRecibido(), gestor.GetFechaPrometido(), gestor.GetObservacionesPago());

                nuevoPedido.AggCobro(gestor.GetCobro());
            }
            else if (gestor.recetaDelPedido == null & gestor.detalleReparacion != null && gestor.detalleSol == null)
            {
                tipoPedido = "REPARACION";
                nuevoPedido = new Pedido(gestor.GetCliente(), gestor.GetTotal(), gestor.GetSena(), gestor.GetFechaRecibido(),
                    gestor.GetFechaPrometido(), gestor.GetObservacionesPago(), tipoPedido, gestor.detalleReparacion);
                nuevoPedido.AggCobro(gestor.GetCobro());
            }
            else if (gestor.recetaDelPedido == null & gestor.detalleReparacion == null && gestor.detalleSol != null)
            {
                tipoPedido = "SOL";
                nuevoPedido = new Pedido(gestor.GetCliente(), gestor.GetTotal(), gestor.GetSena(), gestor.GetFechaRecibido(),
                    gestor.GetFechaPrometido(), gestor.GetObservacionesPago(), tipoPedido, gestor.detalleSol);
                nuevoPedido.AggCobro(gestor.GetCobro());
            }

            // Completamos datos del comprobante
            TBoxSaldoCliente.Text = nuevoPedido.ObtenerSaldo().ToString();
            TBoxSaldo.Text = nuevoPedido.ObtenerSaldo().ToString();

            // Vemos que hacemos segun el caso (guardo o actualizo o nada)
            if (nuevoPedido.tipo == "RECETA")
            {
                if (gestor.banderanuevaReceta && gestor.banderaNuevoCliente)
                {

                    gestor.pedidoService.AddPedido(nuevoPedido);

                }
                if (gestor.banderanuevaReceta && gestor.banderaNuevoCliente == false && gestor.banderaClienteEditado == false)
                {
                    // Se hace un update al cliente viejo se agg la receta
                    gestor.clienteService.ActualizarCliente(gestor.clienteActual);

                    // Se busca el cliente en la BD y se lo agg al pedido para que no se registre nuevamente
                    nuevoPedido.cliente = gestor.clienteActual;

                    nuevoPedido.receta = gestor.recetaDelPedido;

                    // Se hace un update agg nueva receta al cliente viejo
                    gestor.pedidoService.AddPedido(nuevoPedido);
                }
                if (gestor.banderanuevaReceta && gestor.banderaNuevoCliente == false && gestor.banderaClienteEditado)
                {
                    // Se hace un update al cliente viejo se agg la receta y se actualiza la edicion
                    gestor.clienteService.ActualizarCliente(gestor.clienteActual);

                    // Se busca el cliente en la BD y se lo agg al pedido para que no se registre nuevamente
                    nuevoPedido.cliente = gestor.clienteActual;

                    nuevoPedido.receta = gestor.recetaDelPedido;

                    gestor.pedidoService.AddPedido(nuevoPedido);
                }
                if (gestor.banderanuevaReceta == false && gestor.banderaNuevoCliente == false && gestor.banderaClienteEditado == false)
                {
                    // Se busca el cliente en la BD y se lo agg al pedido para que no se registre nuevamente
                    nuevoPedido.cliente = gestor.clienteActual;

                    // Se busca la receta en la BD y se la agg al pedido para que no se registre nuevamente
                    nuevoPedido.receta = gestor.recetaDelPedido;

                    // Se almacena el nuevo Pedido
                    gestor.pedidoService.AddPedido(nuevoPedido);
                }
                if (gestor.banderanuevaReceta == false && gestor.banderaNuevoCliente == false && gestor.banderaClienteEditado)
                {
                    // Se hace un update al cliente viejo por la edicion 

                    gestor.clienteService.ActualizarCliente(gestor.clienteActual);

                    nuevoPedido.cliente = gestor.clienteActual;

                    gestor.pedidoService.AddPedido(nuevoPedido);

                }
            }
            else
            {
                if (gestor.banderaNuevoCliente)
                {
                    // Nuevo cliente sea reparacion o sol
                    gestor.pedidoService.AddPedido(nuevoPedido);
                }
                else if (gestor.banderaNuevoCliente == false && gestor.banderaClienteEditado == false)
                {
                    // Cliente ya cargado sin editar sea reparacion o sol
                    gestor.pedidoService.AddPedido(nuevoPedido);
                }
                else if (gestor.banderaNuevoCliente == false && gestor.banderaClienteEditado != false)
                {
                    // Cliente ya cargado y editado sea reparacion o sol
                    gestor.clienteService.ActualizarCliente(gestor.clienteActual);

                    // Se busca el cliente en la BD y se lo agg al pedido para que no se registre nuevamente
                    nuevoPedido.cliente = gestor.clienteActual;

                    // Se hace un update agg nueva receta al cliente viejo
                    gestor.pedidoService.AddPedido(nuevoPedido);
                }
            }

            // Completamos datos del comprobante
            lblNumeroPedidoCompletarCliente.Text = nuevoPedido.GetIdPedido().ToString();
            lblNumeroPedidoCompletarOptica.Text = nuevoPedido.GetIdPedido().ToString();

            // Quito espacios en el nombre para NombrePDF:
            string nombreSinEspacios = QuitarEspacios(gestor.clienteActual.nombre);

            // Eliminamos botones que no queremos:
            btnAtrasEditarDatos.Visible = false;
            btnConfirmar.Visible = false;

            // CReamos el pdf con la imagen del formulario

            // Definir las coordenadas del área que deseas capturar
            int x = 0; // coordenada x del punto de inicio de la captura
            int y = 0; // coordenada y del punto de inicio de la captura
            int ancho = 550; // ancho del área que deseas capturar
            int alto = 700; // alto del área que deseas capturar

            // Crear un Bitmap del tamaño del área que deseas capturar
            Bitmap bmp = new Bitmap(ancho, alto);

            // Capturar el contenido del formulario en el área especificada
            System.Drawing.Rectangle areaCaptura = new System.Drawing.Rectangle(x, y, ancho, alto);
            this.DrawToBitmap(bmp, areaCaptura);

            // Recortar la parte superior no deseada de la imagen
            Bitmap imagenRecortada = bmp.Clone(new System.Drawing.Rectangle(10, 35, bmp.Width - 10, bmp.Height - 35), bmp.PixelFormat);

            // Generar un nombre de archivo temporal único
            string nombreArchivoTemporal = "tempfile_" + DateTime.Now.Ticks + ".png";
            // Guardar la imagen recortada en un archivo temporal
            string archivoTemporal = Path.Combine(Path.GetTempPath(), nombreArchivoTemporal);
            imagenRecortada.Save(archivoTemporal, ImageFormat.Png);

            // Especificar la ruta de destino para el archivo PDF
            // C:\Users\martin\Desktop\OpticaPDF  --  C:\OpticaPDF
            string directorioDestino = @"C:\OpticaPDF"; // Reemplaza con tu ruta de destino deseada

            // Crear un nuevo documento PDF
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            string archivoPDF = Path.Combine(directorioDestino, "Pedido" + nombreSinEspacios + "_NUM-PEDIDO_" + nuevoPedido.GetIdPedido().ToString() + ".pdf");
            PdfWriter.GetInstance(doc, new FileStream(archivoPDF, FileMode.Create));
            doc.Open();

            // Agregar la imagen recortada al documento PDF
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(archivoTemporal);
            doc.Add(imagen);

            doc.Close();

            // Mostrar mensaje de confirmación
            MessageBox.Show("Archivo PDF generado exitosamente.", "PDF Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        // Función para quitar espacios de una cadena
        static string QuitarEspacios(string cadena)
        {
            return cadena.Replace(" ", "");
        }

        // Metodo que llena los campos del comprobante
        private void LlenarCamposComprobante()
        {
            // Lado cliente:
            TBoxNombreApellidoCliente.Text = gestor.clienteActual.nombre;
            TBoxTotalCliente.Text = gestor.totalPedido.ToString();
            TBoxSenaCliente.Text = gestor.senaPedido.ToString();
            TBoxSaldoCliente.Text = (gestor.totalPedido - gestor.senaPedido).ToString();
            lblFechaRecibidoClienteCompletar.Text = gestor.fechaRecibido.ToString("dd/MM/yy");
            lblFechaPrometidoCompletarCliente.Text = gestor.fechaPrometido.ToString("dd/MM/yy");

            // Lado Optica:
            lblFechaPrometidoCompletarOptica.Text = gestor.fechaPrometido.ToString("dd/MM/yy");
            lblFechaRecibidoCompletarOptica.Text = gestor.fechaRecibido.ToString("dd/MM/yy");

            // Datos cliente
            TBoxNombreApellidoCopiaOP.Text = gestor.clienteActual.nombre;
            TBoxTelefonoCopiaOP.Text = gestor.clienteActual.telefono;
            TBoxDNICopiaOP.Text = gestor.clienteActual.dni;
            TBoxDireccionCopiaOP.Text = gestor.clienteActual.direccion;
            TBoxObraSocialCopiaOPCopiaOP.Text = gestor.clienteActual.obraSocial;

            // Datos receta
            // Lejos
            // Derecho
            TBoxODerEsfericoLejos.Text = gestor.recetaDelPedido.ojoDerechoEsfericoLejos;
            TBoxCilDerLejos.Text = gestor.recetaDelPedido.cilindroDerechoLejos;
            TBoxGradosDerLejos.Text = gestor.recetaDelPedido.gradosDerechoLejos;
            TBoxDNPDLejos.Text = gestor.recetaDelPedido.dNPDLejos;

            //Izquierdo

            TBoxOIzqEsfericoLejos.Text = gestor.recetaDelPedido.ojoIzquierdoEsfericoLejos;
            TBoxCilIzqLejos.Text = gestor.recetaDelPedido.cilindroIzquierdoLejos;
            TBoxGradosIzqLejos.Text = gestor.recetaDelPedido.gradosIzquierdoLejos;
            TBoxDNPILejos.Text = gestor.recetaDelPedido.dNPILejos;

            // Cerca
            // Derecho
            TBoxODerEsfericoCerca.Text = gestor.recetaDelPedido.ojoDerechoEsfericoCerca;
            TBoxCilDerCerca.Text = gestor.recetaDelPedido.cilindroDerechoCerca;
            TBoxGradosDerCerca.Text = gestor.recetaDelPedido.gradosDerechoCerca;
            TBoxDNPDCerca.Text = gestor.recetaDelPedido.dNPDCerca;


            // Izquierdo
            TBoxOIzqEsfericoCerca.Text = gestor.recetaDelPedido.ojoIzquierdoEsfericoCerca;
            TBoxCilIzqCerca.Text = gestor.recetaDelPedido.cilindroIzquierdoCerca;
            TBoxGradosIzqCerca.Text = gestor.recetaDelPedido.gradosIzquierdoCerca;
            TBoxDNPICerca.Text = gestor.recetaDelPedido.dNPICerca;

            // Otros
            TBoxObservaciones.Text = gestor.recetaDelPedido.observaciones;
            TBoxDoctorReceta.Text = gestor.recetaDelPedido.doctor;
            lblFechaRecetaCompletarOptica.Text = gestor.recetaDelPedido.fechaReceta.ToString("dd/MM/yy");

            // Monto
            TBoxTotal.Text = gestor.totalPedido.ToString();
            TBoxSena.Text = gestor.senaPedido.ToString();
            TBoxSaldo.Text = (gestor.totalPedido - gestor.senaPedido).ToString();

            // InHabilitamos campos:
            TBoxSaldoCliente.Enabled = false;
            TBoxTotalCliente.Enabled = false;
            TBoxSenaCliente.Enabled = false;
            TBoxTotal.Enabled = false;
            TBoxSena.Enabled = false;
            TBoxSaldo.Enabled = false;
        }
        private void cmbBoxSeleccionCobro_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelInfoCobros.Visible = false;
        }
        void CompletarInfoDeCobros()
        {
            // Llenamos campos de informacion:
            richTextBoxObservacionPagoCompletar.Text = string.Format(gestor.pedidoSeleccionado.observaciones);
            lblTotalCompletarMI.Text = gestor.pedidoSeleccionado.total.ToString();
            lblSaldoRestanteCompletarMI.Text = gestor.pedidoSeleccionado.saldo.ToString();

            // variables:
            float acumuladorEfectivo = 0;
            float acumuladorTransferencia = 0;
            float acumuladorTarjeta = 0;
            float acumuladorObraSocial = 0;

            // Recorrecmos los cobros del pedido
            int cantidadCobros = 0;
            if (gestor.pedidoSeleccionado.cobros.Count > 0)
            {
                cmbBoxSeleccionCobro.Items.Clear();
                int vuelta = 1;
                foreach (Cobro cobro in gestor.pedidoSeleccionado.cobros)
                {
                    if ((cobro.dineroEfectivo + cobro.dineroTransferencia + cobro.dineroTarjeta1 + cobro.dineroTarjeta2 + cobro.dineroObraSocial ) > 0)
                    {
                        acumuladorEfectivo += cobro.dineroEfectivo;
                        acumuladorTransferencia += cobro.dineroTransferencia;
                        acumuladorTarjeta += cobro.dineroTarjeta1;
                        acumuladorTarjeta += cobro.dineroTarjeta2;
                        acumuladorObraSocial += cobro.dineroObraSocial;

                        string texto = "ID:" + cobro.GetIdCobro().ToString() + "- Cobro " + cobro.fechaCobro.ToString("dd/MM/yy");

                        cmbBoxSeleccionCobro.Items.Add(texto);
                        cantidadCobros += 1;
                    }
                    vuelta++;
                }
            }

            lblEfectivoCompletarMI.Text = acumuladorEfectivo.ToString();
            lblTarjetaCompletarMI.Text = acumuladorTarjeta.ToString();
            lblTransferenciaCompletarMI.Text = acumuladorTransferencia.ToString();
            lblObraSocialCompletarMI.Text = acumuladorObraSocial.ToString();

            lblCantidadCobrosCompletar.Text = cantidadCobros.ToString();
        }
        #endregion

        // COMPROBANTE DE CONSULTAR CLIENTE (reimprime y ve info cobros)
        #region ReimprimirEInfoCobros
        // Metodo que llena los campos del comprobante
        private void LlenarCamposComprobanteConsultar()
        {
            // Llenar id:
            lblNumeroPedidoCompletarCliente.Text = gestor.pedidoSeleccionado.GetIdPedido().ToString();
            lblNumeroPedidoCompletarOptica.Text = gestor.pedidoSeleccionado.GetIdPedido().ToString();


            // Lado cliente:
            TBoxNombreApellidoCliente.Text = gestor.pedidoSeleccionado.cliente.nombre;
            TBoxTotalCliente.Text = gestor.pedidoSeleccionado.total.ToString();
            TBoxSenaCliente.Text = gestor.pedidoSeleccionado.sena.ToString();
            TBoxSaldoCliente.Text = (gestor.pedidoSeleccionado.total - gestor.pedidoSeleccionado.sena).ToString();
            lblFechaRecibidoClienteCompletar.Text = gestor.pedidoSeleccionado.fechaRecibido.ToString("dd/MM/yy");
            lblFechaPrometidoCompletarCliente.Text = gestor.pedidoSeleccionado.fechaPrometido.ToString("dd/MM/yy");

            // Lado Optica:
            lblFechaPrometidoCompletarOptica.Text = gestor.pedidoSeleccionado.fechaPrometido.ToString("dd/MM/yy");
            lblFechaRecibidoCompletarOptica.Text = gestor.pedidoSeleccionado.fechaRecibido.ToString("dd/MM/yy");

            // Datos cliente
            TBoxNombreApellidoCopiaOP.Text = gestor.pedidoSeleccionado.cliente.nombre;
            TBoxTelefonoCopiaOP.Text = gestor.pedidoSeleccionado.cliente.telefono;
            TBoxDNICopiaOP.Text = gestor.pedidoSeleccionado.cliente.dni;
            TBoxDireccionCopiaOP.Text = gestor.pedidoSeleccionado.cliente.direccion;
            TBoxObraSocialCopiaOPCopiaOP.Text = gestor.pedidoSeleccionado.cliente.obraSocial;

            // Datos receta
            // Lejos
            // Derecho
            TBoxODerEsfericoLejos.Text = gestor.pedidoSeleccionado.receta.ojoDerechoEsfericoLejos;
            TBoxCilDerLejos.Text = gestor.pedidoSeleccionado.receta.cilindroDerechoLejos;
            TBoxGradosDerLejos.Text = gestor.pedidoSeleccionado.receta.gradosDerechoLejos;
            TBoxDNPDLejos.Text = gestor.pedidoSeleccionado.receta.dNPDLejos;

            //Izquierdo

            TBoxOIzqEsfericoLejos.Text = gestor.pedidoSeleccionado.receta.ojoIzquierdoEsfericoLejos;
            TBoxCilIzqLejos.Text = gestor.pedidoSeleccionado.receta.cilindroIzquierdoLejos;
            TBoxGradosIzqLejos.Text = gestor.pedidoSeleccionado.receta.gradosIzquierdoLejos;
            TBoxDNPILejos.Text = gestor.pedidoSeleccionado.receta.dNPILejos;

            // Cerca
            // Derecho
            TBoxODerEsfericoCerca.Text = gestor.pedidoSeleccionado.receta.ojoDerechoEsfericoCerca;
            TBoxCilDerCerca.Text = gestor.pedidoSeleccionado.receta.cilindroDerechoCerca;
            TBoxGradosDerCerca.Text = gestor.pedidoSeleccionado.receta.gradosDerechoCerca;
            TBoxDNPDCerca.Text = gestor.pedidoSeleccionado.receta.dNPDCerca;


            // Izquierdo
            TBoxOIzqEsfericoCerca.Text = gestor.pedidoSeleccionado.receta.ojoIzquierdoEsfericoCerca;
            TBoxCilIzqCerca.Text = gestor.pedidoSeleccionado.receta.cilindroIzquierdoCerca;
            TBoxGradosIzqCerca.Text = gestor.pedidoSeleccionado.receta.gradosIzquierdoCerca;
            TBoxDNPICerca.Text = gestor.pedidoSeleccionado.receta.dNPICerca;

            // Otros
            TBoxObservaciones.Text = gestor.pedidoSeleccionado.receta.observaciones;
            TBoxDoctorReceta.Text = gestor.pedidoSeleccionado.receta.doctor;
            lblFechaRecetaCompletarOptica.Text = gestor.pedidoSeleccionado.receta.fechaReceta.ToString("dd/MM/yy");

            // Monto
            TBoxTotal.Text = gestor.pedidoSeleccionado.total.ToString();
            TBoxSena.Text = gestor.pedidoSeleccionado.sena.ToString();
            TBoxSaldo.Text = (gestor.pedidoSeleccionado.total - gestor.pedidoSeleccionado.sena).ToString();

            // InHabilitamos campos:
            TBoxSaldoCliente.Enabled = false;
            TBoxTotalCliente.Enabled = false;
            TBoxSenaCliente.Enabled = false;
            TBoxTotal.Enabled = false;
            TBoxSena.Enabled = false;
            TBoxSaldo.Enabled = false;
        }
        private void VerMasCobros_Click(object sender, EventArgs e)
        {
            if (cmbBoxSeleccionCobro.SelectedItem != null)
            {
                panelInfoCobros.Visible = true;
                // Que cobro es? (pensado hasta maximo 5 cobros por pedido)
                // Obtener el índice seleccionado y restar 1 para obtener el número de cobro
                string cadenaCobroSeleccionado = cmbBoxSeleccionCobro.SelectedItem.ToString();
                string pattern = @"ID:(\d+)-";
                Match match = Regex.Match(cadenaCobroSeleccionado, pattern);

                Cobro cobroSeleccionado = new Cobro();
                if (match.Success)
                {
                    int idDelCobroSeleccionado = int.Parse(match.Groups[1].Value);  
                    cobroSeleccionado = gestor.cobroService.GetCobro(idDelCobroSeleccionado);
                }

                // Completamos info
                lblCobroCompletar.Text = "Cobro " + cobroSeleccionado.fechaCobro.ToString("dd/MM/yy");

                // Panel Facturacion
                float totalFact = 0;
                if (cobroSeleccionado.factura.items.Count > 0)
                {
                    foreach (float monto in cobroSeleccionado.factura.totalItems)
                    {
                        totalFact += monto;
                    }

                    lblFacCompletarCobro.Text = "SI";
                    lblCompletarMontoCobro.Text = totalFact.ToString();
                }
                else
                {
                    lblFacCompletarCobro.Text = "NO";
                    lblCompletarMontoCobro.Text = "0";
                }

                // Panel metodos de pago
                // Tarjeta 1
                if (cobroSeleccionado.tipoTarjeta1 == null)
                {
                    lblTar1CreditoDebitoCompletar.Text = "ninguna";
                    lblMarcaTar1.Text = "ninguna";
                    lblCompletarTarjeta1.Text = "0";
                }
                else
                {
                    lblTar1CreditoDebitoCompletar.Text = cobroSeleccionado.tipoTarjeta1;
                    lblMarcaTar1.Text = cobroSeleccionado.marcaTarjeta1;
                    lblCompletarTarjeta1.Text = cobroSeleccionado.dineroTarjeta1.ToString();
                }
                // Tarjeta 2
                if (cobroSeleccionado.tipoTarjeta2 == null)
                {
                    lblTar2CreditoDebitoCompletar.Text = "ninguna";
                    lblMarcaTar2.Text = "ninguna";
                    lblCompletarTarjeta2.Text = "0";
                }
                else
                {
                    lblTar2CreditoDebitoCompletar.Text = cobroSeleccionado.tipoTarjeta2;
                    lblMarcaTar2.Text = cobroSeleccionado.marcaTarjeta2;
                    lblCompletarTarjeta2.Text = cobroSeleccionado.dineroTarjeta2.ToString();
                }
                // Efectivo
                lblEfectivoCobroCompletar.Text = cobroSeleccionado.dineroEfectivo.ToString();
                // Transferencia
                lblTransferenciaCobroCompletar.Text = cobroSeleccionado.dineroTransferencia.ToString();
                // Obra social
                lblObraSocialCobroCompletar.Text = cobroSeleccionado.dineroObraSocial.ToString();

                // Observaciones
                richTBoxObservacionesCobro.Text = cobroSeleccionado.aclaracionesDeCobro.ToString();
            }
            else
            {
                // Mensaje de error.
                // Mostrar mensaje de confirmación
                MessageBox.Show("No hay ningun cobro seleccionado. Por favor seleccione uno.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            // Completamos datos del comprobante
            TBoxSaldoCliente.Text = gestor.pedidoSeleccionado.ObtenerSaldo().ToString();
            TBoxSaldo.Text = gestor.pedidoSeleccionado.ObtenerSaldo().ToString();

            // Completamos datos del comprobante
            lblNumeroPedidoCompletarCliente.Text = gestor.pedidoSeleccionado.GetIdPedido().ToString();
            lblNumeroPedidoCompletarOptica.Text = gestor.pedidoSeleccionado.GetIdPedido().ToString();

            // Quito espacios en el nombre para NombrePDF:
            string nombreSinEspacios = QuitarEspacios(gestor.clienteActual.nombre);

            // Eliminamos botones que no queremos:
            btnAtrasEditarDatos.Visible = false;
            btnReimprimir.Visible = false;

            panelInfoCobros.Visible = false;
            panelRegistroPago.Visible = false;

            // CReamos el pdf con la imagen del formulario

            // Definir las coordenadas del área que deseas capturar
            int x = 0; // coordenada x del punto de inicio de la captura
            int y = 0; // coordenada y del punto de inicio de la captura
            int ancho = 550; // ancho del área que deseas capturar
            int alto = 700; // alto del área que deseas capturar

            // Crear un Bitmap del tamaño del área que deseas capturar
            Bitmap bmp = new Bitmap(ancho, alto);

            // Capturar el contenido del formulario en el área especificada
            System.Drawing.Rectangle areaCaptura = new System.Drawing.Rectangle(x, y, ancho, alto);
            this.DrawToBitmap(bmp, areaCaptura);

            // Recortar la parte superior no deseada de la imagen
            Bitmap imagenRecortada = bmp.Clone(new System.Drawing.Rectangle(10, 35, bmp.Width - 10, bmp.Height - 35), bmp.PixelFormat);

            // Generar un nombre de archivo temporal único
            string nombreArchivoTemporal = "tempfile_" + DateTime.Now.Ticks + ".png";
            // Guardar la imagen recortada en un archivo temporal
            string archivoTemporal = Path.Combine(Path.GetTempPath(), nombreArchivoTemporal);
            imagenRecortada.Save(archivoTemporal, ImageFormat.Png);

            // Especificar la ruta de destino para el archivo PDF
            // C:\Users\martin\Desktop\OpticaPDF  --  C:\OpticaPDF
            string directorioDestino = @"C:\OpticaPDF"; // Reemplaza con tu ruta de destino deseada

            // Crear un nuevo documento PDF
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            string archivoPDF = Path.Combine(directorioDestino, "Pedido" + nombreSinEspacios + "_NUM-PEDIDO_" + gestor.pedidoSeleccionado.GetIdPedido().ToString() + "_REIMPRESION.pdf");
            PdfWriter.GetInstance(doc, new FileStream(archivoPDF, FileMode.Create));
            doc.Open();

            // Agregar la imagen recortada al documento PDF
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(archivoTemporal);
            doc.Add(imagen);

            doc.Close();

            // Mostrar mensaje de confirmación
            MessageBox.Show("Archivo PDF generado exitosamente.", "PDF Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Eliminamos botones que no queremos:
            btnAtrasEditarDatos.Visible = true;
            btnReimprimir.Visible = true;

            panelInfoCobros.Visible = false;
            panelRegistroPago.Visible = true;
        }
        #endregion

        // COMPROBANTE SOL Y REPARACION
        #region SolYReparacion
        void LlenarCamposComprobante(string tipo)
        {
            // Lado cliente:
            TBoxNombreApellidoCliente.Text = gestor.clienteActual.nombre;
            TBoxTotalCliente.Text = gestor.totalPedido.ToString();
            TBoxSenaCliente.Text = gestor.senaPedido.ToString();
            TBoxSaldoCliente.Text = (gestor.totalPedido - gestor.senaPedido).ToString();
            lblFechaRecibidoClienteCompletar.Text = gestor.fechaRecibido.ToString("dd/MM/yy");
            lblFechaPrometidoCompletarCliente.Text = gestor.fechaPrometido.ToString("dd/MM/yy");

            // Lado Optica:
            lblFechaPrometidoCompletarOptica.Text = gestor.fechaPrometido.ToString("dd/MM/yy");
            lblFechaRecibidoCompletarOptica.Text = gestor.fechaRecibido.ToString("dd/MM/yy");

            // Datos cliente
            TBoxNombreApellidoCopiaOP.Text = gestor.clienteActual.nombre;
            TBoxTelefonoCopiaOP.Text = gestor.clienteActual.telefono;
            TBoxDNICopiaOP.Text = gestor.clienteActual.dni;
            TBoxDireccionCopiaOP.Text = gestor.clienteActual.direccion;
            TBoxObraSocialCopiaOPCopiaOP.Text = gestor.clienteActual.obraSocial;

            // Segun tipo
            if (gestor.detalleSol != null && gestor.detalleReparacion == null)
            {
                // Renombramos campos de observacion (opcion  SOL)
                lblObservaciones.Text = "Detalle de venta: ";
                TBoxObservaciones.Text = gestor.detalleSol.ToString();
            }
            else if (gestor.detalleSol == null && gestor.detalleReparacion != null)
            {
                // Renombramos campos de observacion
                lblObservaciones.Text = "Detalle de reparación: ";
                TBoxObservaciones.Text = gestor.detalleReparacion.ToString();
            }

            // Reubicamos los textos
            lblObservaciones.Location = new Point(5, 20);
            TBoxObservaciones.Location = new Point(125, 18);
            TBoxObservaciones.Size = new Size(300, 23);

            // Monto
            TBoxTotal.Text = gestor.totalPedido.ToString();
            TBoxSena.Text = gestor.senaPedido.ToString();
            TBoxSaldo.Text = (gestor.totalPedido - gestor.senaPedido).ToString();

            // InHabilitamos campos:
            TBoxSaldoCliente.Enabled = false;
            TBoxTotalCliente.Enabled = false;
            TBoxSenaCliente.Enabled = false;
            TBoxTotal.Enabled = false;
            TBoxSena.Enabled = false;
            TBoxSaldo.Enabled = false;
        }
        void LlenarCamposComprobanteConsultar(string tipos)
        {
            // Llenar id:
            lblNumeroPedidoCompletarCliente.Text = gestor.pedidoSeleccionado.GetIdPedido().ToString();
            lblNumeroPedidoCompletarOptica.Text = gestor.pedidoSeleccionado.GetIdPedido().ToString();

            // Lado cliente:
            TBoxNombreApellidoCliente.Text = gestor.pedidoSeleccionado.cliente.nombre;
            TBoxTotalCliente.Text = gestor.pedidoSeleccionado.total.ToString();
            TBoxSenaCliente.Text = gestor.pedidoSeleccionado.sena.ToString();
            TBoxSaldoCliente.Text = (gestor.pedidoSeleccionado.total - gestor.pedidoSeleccionado.sena).ToString();
            lblFechaRecibidoClienteCompletar.Text = gestor.pedidoSeleccionado.fechaRecibido.ToString("dd/MM/yy");
            lblFechaPrometidoCompletarCliente.Text = gestor.pedidoSeleccionado.fechaPrometido.ToString("dd/MM/yy");

            // Lado Optica:
            lblFechaPrometidoCompletarOptica.Text = gestor.pedidoSeleccionado.fechaPrometido.ToString("dd/MM/yy");
            lblFechaRecibidoCompletarOptica.Text = gestor.pedidoSeleccionado.fechaRecibido.ToString("dd/MM/yy");

            // Datos cliente
            TBoxNombreApellidoCopiaOP.Text = gestor.pedidoSeleccionado.cliente.nombre;
            TBoxTelefonoCopiaOP.Text = gestor.pedidoSeleccionado.cliente.telefono;
            TBoxDNICopiaOP.Text = gestor.pedidoSeleccionado.cliente.dni;
            TBoxDireccionCopiaOP.Text = gestor.pedidoSeleccionado.cliente.direccion;
            TBoxObraSocialCopiaOPCopiaOP.Text = gestor.pedidoSeleccionado.cliente.obraSocial;

            // Segun tipo
            if ((gestor.detalleSol != null && gestor.detalleReparacion == null) || gestor.pedidoSeleccionado.tipo == "SOL")
            {
                // Renombramos campos de observacion (opcion  SOL)
                lblObservaciones.Text = "Detalle de venta: ";
                TBoxObservaciones.Text = gestor.pedidoSeleccionado.detallePedido.ToString();
            }
            else if ((gestor.detalleSol == null && gestor.detalleReparacion != null) || gestor.pedidoSeleccionado.tipo == "REPARACION")
            {
                // Renombramos campos de observacion
                lblObservaciones.Text = "Detalle de reparación: ";
                TBoxObservaciones.Text = gestor.pedidoSeleccionado.detallePedido.ToString();
            }

            // Reubicamos los textos
            lblObservaciones.Location = new Point(5, 20);
            TBoxObservaciones.Location = new Point(125, 18);
            TBoxObservaciones.Size = new Size(300, 23);

            // Monto
            TBoxTotal.Text = gestor.pedidoSeleccionado.total.ToString();
            TBoxSena.Text = gestor.pedidoSeleccionado.sena.ToString();
            TBoxSaldo.Text = (gestor.pedidoSeleccionado.total - gestor.pedidoSeleccionado.sena).ToString();

            // InHabilitamos campos:
            TBoxSaldoCliente.Enabled = false;
            TBoxTotalCliente.Enabled = false;
            TBoxSenaCliente.Enabled = false;
            TBoxTotal.Enabled = false;
            TBoxSena.Enabled = false;
            TBoxSaldo.Enabled = false;
        }

        void OcultarCamposReceta()
        {
            panelLejos.Visible = false;
            panelCerca.Visible = false;
            lblDoctor.Visible = false;
            lblFechaReceta.Visible = false;
            lblFechaRecetaCompletarOptica.Visible = false;
            TBoxDoctorReceta.Visible = false;
        }
        #endregion

    
     
    }
}
