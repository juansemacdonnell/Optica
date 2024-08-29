using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using OpricaSurinV2;
using OpricaSurinV2.Clases;
using OpticaSurinV2.Clases;
using ScottPlot;
using SkiaSharp;


namespace OpticaSurinV2.Pantallas
{
    public partial class Informes : Form
    {
        Gestor gestor;

        // Obras sociales ordenadas:
        string[] obrasSocialesOrdenadas;
        int[] dineroObrasSocialesOrdenadas;

        public Informes(Gestor gestor)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            this.gestor = gestor;

            // Ocultamos los paneles secundarios
            this.OcultarPanelesSecundarios();

        }


        // REGIONES
        // BOTONES GENERALES
        #region BotonesGenerales
        private void btnMensualmente_Click(object sender, EventArgs e)
        {
            // habilitamos btn seleccionar mes:
            btnCambiarMes.Visible = true;
            btnCambiarAño.Visible = false;
            btnCambiarPeriodo.Visible = false;
            btnCambiarMes.Location = new Point(602, 111);

            // Ocultamos los paneles secundarios
            this.OcultarPanelesSecundarios();

            // configurar con ventana
            SelectorFecha ventanaSelector = new SelectorFecha(gestor);
            ventanaSelector.ShowDialog();

            if (ventanaSelector.DialogResult == DialogResult.OK)
            {
                // Comenzamos busqueda de pedidos:
                gestor.pedidosParaInforme = gestor.pedidoService.ObtenerPedidosDelMes(
                    gestor.anioSeleccionado, gestor.mesSeleccionado);

                int[] datos = gestor.GetDatosEstadisticosPanelGeneral(gestor.pedidosParaInforme);

                // Cargamos los datos a la pantalla:
                this.CargarDatosPanelGeneral(datos);

                // Titulo
                var meses = new Dictionary<int, string>
                {
                    { 1, "Enero" },
                    { 2, "Febrero" },
                    { 3, "Marzo" },
                    { 4, "Abril" },
                    { 5, "Mayo" },
                    { 6, "Junio" },
                    { 7, "Julio" },
                    { 8, "Agosto" },
                    { 9, "Septiembre" },
                    { 10, "Octubre" },
                    { 11, "Noviembre" },
                    { 12, "Diciembre" }
                };

                lblTituloMes.Text = meses[gestor.mesSeleccionado] + " del " + gestor.anioSeleccionado.ToString();
            }
        }
        private void btnAnualmente_Click(object sender, EventArgs e)
        {
            // Habilitamos boton para cambiar
            btnCambiarMes.Visible = false;
            btnCambiarPeriodo.Visible = false;
            btnCambiarAño.Visible = true;
            btnCambiarAño.Location = new Point(602, 111);

            // Ocultamos los paneles secundarios
            this.OcultarPanelesSecundarios();

            gestor.anioSeleccionado = DateTime.Now.Year;

            // Comenzamos busqueda de pedidos:
            gestor.pedidosParaInforme = gestor.pedidoService.ObtenerPedidosDelAnio(gestor.anioSeleccionado);

            int[] datos = gestor.GetDatosEstadisticosPanelGeneral(gestor.pedidosParaInforme);

            // Cargamos los datos a la pantalla:
            this.CargarDatosPanelGeneral(datos);

            // Titulo
            lblTituloMes.Text = "Datos del " + gestor.anioSeleccionado.ToString();
        }

        // Boton para buscar datos de la ultima semana
        private void btnSemanalmente_Click(object sender, EventArgs e)
        {
            // deshabilitamos boton para cambiar
            btnCambiarMes.Visible = false;
            btnCambiarAño.Visible = false;
            btnCambiarPeriodo.Visible = false;

            DateTime diaActual = DateTime.Now;
            DateTime primerDiaSemana = diaActual.AddDays(-6);

            // Ocultamos los paneles secundarios
            this.OcultarPanelesSecundarios();

            // Busco los pedidos de la semana:
            gestor.pedidosParaInforme = gestor.pedidoService.ObtenerPedidosDelPeriodo(primerDiaSemana, diaActual);

            int[] datos = gestor.GetDatosEstadisticosPanelGeneral(gestor.pedidosParaInforme);

            // Cargamos los datos a la pantalla:
            this.CargarDatosPanelGeneral(datos);

            // Titulo
            lblTituloMes.Text = "Ultima semana ";
        }

        // Boton para buscar datos del periodo seleccionado
        private void btnPeriodoElegido_Click(object sender, EventArgs e)
        {
            // Habilitamos boton para cambiar
            btnCambiarMes.Visible = false;
            btnCambiarPeriodo.Visible = true;
            btnCambiarAño.Visible = false;
            btnCambiarPeriodo.Location = new Point(602, 111);

            // Ocultamos los paneles secundarios
            this.OcultarPanelesSecundarios();

            // configurar con ventana
            SelectorPeriodo ventanaSelector = new SelectorPeriodo(gestor);
            ventanaSelector.ShowDialog();

            if (ventanaSelector.DialogResult == DialogResult.OK)
            {

                // Comenzamos busqueda de pedidos:
                gestor.pedidosParaInforme = gestor.pedidoService.ObtenerPedidosDelPeriodo(
                    gestor.fechaDesdePeriodo, gestor.fechaHastaPeriodo);

                int[] datos = gestor.GetDatosEstadisticosPanelGeneral(gestor.pedidosParaInforme);

                // Cargamos los datos a la pantalla:
                this.CargarDatosPanelGeneral(datos);

                // Titulo
                lblTituloMes.Location = new Point(190, 3);
                lblTituloMes.Text = "Período: " + gestor.fechaDesdePeriodo.ToString("dd/MM/yy") + " - " + gestor.fechaHastaPeriodo.ToString("dd/MM/yy");
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            gestor.pedidosParaInforme = null;
            this.Close();
        }
        private void btnInformeAnual_Click(object sender, EventArgs e)
        {
            PantallaInformeFinal ventana = new PantallaInformeFinal(gestor);
            ventana.Show();
        }
        #endregion

        // METODOS GENERALES / DE CARGA DE DATOS AL PANEL
        #region Metodos de Cargas de Datos
        private void Informes_Load(object sender, EventArgs e)
        {
            // cuando se cargue la ventana por primera vez se mostraran los datos del mes actual:
            gestor.pedidosParaInforme = gestor.pedidoService.ObtenerPedidosDelMesActual();

            int[] datos = gestor.GetDatosEstadisticosPanelGeneral(gestor.pedidosParaInforme);

            // Cargamos los datos a la pantalla:
            this.CargarDatosPanelGeneral(datos);

            // Obtener el mes en formato textual completo y año
            string mesTexto = DateTime.Now.ToString("MMMM", new CultureInfo("es-ES"));
            string anio = DateTime.Now.ToString("yyyy");

            lblTituloMes.Text = mesTexto + anio;
        }
        void CargarDatosPanelGeneral(int[] datos)
        {
            // Vector de datos  [totalDinero, saldoPendiente, efectivoTotal, tarjetaTotal, transferenciaTotal];

            // Panel verde:
            TBoxTotalCompletar.Text = "$ " + datos[0].ToString();
            TBoxEfectivoCompletar.Text = "$ " + datos[2].ToString();
            TBoxTarjetaCompletar.Text = "$ " + datos[3].ToString();
            TBoxTransferenciaCompletar.Text = "$ " + datos[4].ToString();

            // Panel Amarillo:
            TBoxSaldoPendienteCompletar.Text = "$ " + datos[1].ToString();

            // Grafico

            var x = new List<ISeries>
            {
                new PieSeries<float>
                {
                    Values = new List<float> { datos[2] },
                    Name = "Efectivo",
                    Fill = new SolidColorPaint(new SKColor(0, 191, 255)) // Celeste para efectivo
                },
                new PieSeries<float>
                {
                    Values = new List<float> { datos[3] },
                    Name = "Tarjeta",
                    Fill = new SolidColorPaint(new SKColor(255, 0, 0)) // Rojo para tarjeta
                },
                new PieSeries<float>
                {
                    Values = new List<float> { datos[4] },
                    Name = "Transferencia",
                    Fill = new SolidColorPaint(new SKColor(0, 255, 0)) // Verde para transferencia
                }
            };
            // Utilizar el control
            graficoMediosDePago.Series = x;

        }

        void CargarDatosTarjetas(int[] datos)
        {
            /*          0               1
             * acumuladorCredito, acumuladorDebito,
             *          2                            3                        4                        5
                acumuladorCreditoVisa, acumuladorCreditoMastercard, acumuladorCreditoCabal, acumuladorCreditoNaranja,
                        6                            7                        8 
                acumuladorDebitoVisa, acumuladorDebitoMastercard, acumuladorDebitoCabal */
            // Cargamos totales de debito y credito
            TBoxTotalCredito.Text = datos[0].ToString();
            TBoxTotalDebito.Text = datos[1].ToString();

            // Cargamos marcas de tarjetas de credito
            TBoxVisaCredito.Text = datos[2].ToString();
            TBoxMastercardCredito.Text = datos[3].ToString();
            TBoxCabalCredito.Text = datos[4].ToString();
            TBoxNaranjaCredito.Text = datos[5].ToString();

            // Cargamos marcas de tarjetas de debito
            TBoxVisaDebito.Text = datos[6].ToString();
            TBoxMastercardDebito.Text = datos[7].ToString();
            TBoxCabalDebito.Text = datos[8].ToString();

            // Grafico credito
            var x = new List<ISeries>
            {
                new PieSeries<float>
                {
                    Values = new List<float> { datos[2] },
                    Name = "Visa",
                    Fill = new SolidColorPaint(new SKColor(0, 0, 139)) // Azul para visa
                },
                new PieSeries<float>
                {
                    Values = new List<float> { datos[3] },
                    Name = "Mastercard",
                    Fill = new SolidColorPaint(new SKColor(255, 0, 0)) // Rojo para master
                },
                new PieSeries<float>
                {
                    Values = new List<float> { datos[4] },
                    Name = "Cabal",
                    Fill = new SolidColorPaint(new SKColor(255, 255, 0)) // Amarillo para cabal
                },
                new PieSeries<float>
                {
                    Values = new List<float> { datos[5] },
                    Name = "Naranja",
                    Fill = new SolidColorPaint(new SKColor(255, 165, 0)) // Naranja para naranja
                }
            };
            // Utilizar el control
            graficoCredito.Series = x;

            // Grafico debito
            var y = new List<ISeries>
            {
                new PieSeries<float>
                {
                    Values = new List<float> { datos[6] },
                    Name = "Visa",
                    Fill = new SolidColorPaint(new SKColor(0, 0, 139)) // Azul para visa
                },
                new PieSeries<float>
                {
                    Values = new List<float> { datos[7] },
                    Name = "Mastercard",
                    Fill = new SolidColorPaint(new SKColor(255, 0, 0)) // Rojo para master
                },
                new PieSeries<float>
                {
                    Values = new List<float> { datos[8] },
                    Name = "Cabal",
                    Fill = new SolidColorPaint(new SKColor(255, 255, 0)) // Amarillo para cabal
                }
            };
            // Utilizar el control
            graficoDebito.Series = y;

        }

        void CargarDatosObrasSociales(List<System.Object> datos)
        {
            this.obrasSocialesOrdenadas = (string[])datos[0];
            this.dineroObrasSocialesOrdenadas = (int[])datos[1];

            // Cargamos el total de dinero con obras sociales:
            TBoxTotalObrasSociales.Text = datos[2].ToString();

            // Cargamos las 6 Obras sociales mas usadas:
            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        lblOScompletar1.Text = obrasSocialesOrdenadas[0];
                        TBoxCompletarOS1.Text = dineroObrasSocialesOrdenadas[0].ToString();
                        break;
                    case 1:
                        lblOScompletar2.Text = obrasSocialesOrdenadas[1];
                        TBoxCompletarOS2.Text = dineroObrasSocialesOrdenadas[1].ToString();
                        break;
                    case 2:
                        lblOScompletar3.Text = obrasSocialesOrdenadas[2];
                        TBoxCompletarOS3.Text = dineroObrasSocialesOrdenadas[2].ToString();
                        break;
                    case 3:
                        lblOScompletar4.Text = obrasSocialesOrdenadas[3];
                        TBoxCompletarOS4.Text = dineroObrasSocialesOrdenadas[3].ToString();
                        break;
                    case 4:
                        lblOScompletar5.Text = obrasSocialesOrdenadas[4];
                        TBoxCompletarOS5.Text = dineroObrasSocialesOrdenadas[4].ToString();
                        break;
                    case 5:
                        lblOScompletar6.Text = obrasSocialesOrdenadas[5];
                        TBoxCompletarOS6.Text = dineroObrasSocialesOrdenadas[5].ToString();
                        break;
                    default:
                        break;
                }
            }

            // Cargar cmbBox
            // Agregamos items al cmb box Obra Social
            cmbBoxObraSocial.Items.Clear();
            foreach (string obraSocial in gestor.obraSocialesLista)
            {
                cmbBoxObraSocial.Items.Add(obraSocial);
            }
            cmbBoxObraSocial.SelectedItem = cmbBoxObraSocial.Items[0];

            // Grafico

            var x = new List<ISeries>();

            for (int i = 0; i < obrasSocialesOrdenadas.Length; i++)
            {
                x.Add(new PieSeries<float>
                {
                    Values = new List<float> { dineroObrasSocialesOrdenadas[i] },
                    Name = obrasSocialesOrdenadas[i]
                });
            }
            // Utilizar el control
            graficoObrasSociales.Series = x;
        }

        void CargarDatosInfoGeneral(int[] datos)
        {
            // cargamos datos
            TBoxCantidadTotalPedidos.Text = datos[0].ToString();
            TBoxTotalFacturadoAutomaticamente.Text = datos[1].ToString();
            TBoxRecetaTotal.Text = datos[2].ToString();
            TBoxSolTotal.Text = datos[3].ToString();    
            TBoxArregloTotal.Text = datos[4].ToString();

            // Grafico debito
            var y = new List<ISeries>
            {
                new PieSeries<float>
                {
                    Values = new List<float> { datos[2] },
                    Name = "Receta",
                    Fill = new SolidColorPaint(new SKColor(0, 0, 139)) // Azul para visa
                },
                new PieSeries<float>
                {
                    Values = new List<float> { datos[3] },
                    Name = "Sol",
                    Fill = new SolidColorPaint(new SKColor(255, 0, 0)) // Rojo para master
                },
                new PieSeries<float>
                {
                    Values = new List<float> { datos[4] },
                    Name = "Arreglos",
                    Fill = new SolidColorPaint(new SKColor(255, 255, 0)) // Amarillo para cabal
                }
            };
            // Utilizar el control
            graficoProductos.Series = y;

        }
        void OcultarPanelesSecundarios()
        {
            panelTarjetas.Visible = false;
            panelInfoGeneral.Visible = false;
            panelObrasSociales.Visible = false;
        }
        #endregion

        // BOTONES DENTRO DEL PRIMER PANEL
        #region Botones Panel General
        private void btnCambiarMes_Click(object sender, EventArgs e)
        {
            // configurar con ventana
            SelectorFecha ventanaSelector = new SelectorFecha(gestor);
            ventanaSelector.ShowDialog();

            if (ventanaSelector.DialogResult == DialogResult.OK)
            {
                // Comenzamos busqueda de pedidos:
                gestor.pedidosParaInforme = gestor.pedidoService.ObtenerPedidosDelMes(
                    gestor.anioSeleccionado, gestor.mesSeleccionado);

                // [total, saldo, efect, tarj, trans, cantPed, cantCerca, cantLejos]
                int[] datos = gestor.GetDatosEstadisticosPanelGeneral(gestor.pedidosParaInforme);

                // Cargamos los datos a la pantalla:
                this.CargarDatosPanelGeneral(datos);

                // Titulo
                // Inicializar el diccionario de números y meses
                var meses = new Dictionary<int, string>
                {
                    { 1, "Enero" },
                    { 2, "Febrero" },
                    { 3, "Marzo" },
                    { 4, "Abril" },
                    { 5, "Mayo" },
                    { 6, "Junio" },
                    { 7, "Julio" },
                    { 8, "Agosto" },
                    { 9, "Septiembre" },
                    { 10, "Octubre" },
                    { 11, "Noviembre" },
                    { 12, "Diciembre" }
                };
                lblTituloMes.Text = meses[gestor.mesSeleccionado] + " del " + gestor.anioSeleccionado.ToString();
            }

        }
        private void btnCambiarAño_Click(object sender, EventArgs e)
        {
            // configurar con ventana
            SelectorAnio ventanaSelector = new SelectorAnio(gestor);
            ventanaSelector.ShowDialog();

            if (ventanaSelector.DialogResult == DialogResult.OK)
            {
                // Comenzamos busqueda de pedidos:
                gestor.pedidosParaInforme = gestor.pedidoService.ObtenerPedidosDelAnio(gestor.anioSeleccionado);

                int[] datos = gestor.GetDatosEstadisticosPanelGeneral(gestor.pedidosParaInforme);

                // Cargamos los datos a la pantalla:
                this.CargarDatosPanelGeneral(datos);

                // Titulo
                lblTituloMes.Text = "Datos del " + gestor.anioSeleccionado.ToString();
            }
        }

        // Boton para cambiar el periodo seleccionado
        private void btnSeleccionarPeriodo_Click(object sender, EventArgs e)
        {
            // configurar con ventana
            SelectorPeriodo ventanaSelector = new SelectorPeriodo(gestor);
            ventanaSelector.ShowDialog();

            if (ventanaSelector.DialogResult == DialogResult.OK)
            {

                // Comenzamos busqueda de pedidos:
                gestor.pedidosParaInforme = gestor.pedidoService.ObtenerPedidosDelPeriodo(
                    gestor.fechaDesdePeriodo, gestor.fechaHastaPeriodo);

                // [total, saldo, efect, tarj, trans, cantPed, cantCerca, cantLejos]
                int[] datos = gestor.GetDatosEstadisticosPanelGeneral(gestor.pedidosParaInforme);

                // Cargamos los datos a la pantalla:
                this.CargarDatosPanelGeneral(datos);

                // Titulo
                lblTituloMes.Location = new Point(190, 3);
                lblTituloMes.Text = "Período: " + gestor.fechaDesdePeriodo.ToString("dd/MM/yy") + " - " + gestor.fechaHastaPeriodo.ToString("dd/MM/yy");
            }
        }

        private void btnTarjetas_Click(object sender, EventArgs e)
        {
            // Ocultamos los paneles secundarios y habilitamos el de tarjetas
            panelTarjetas.Visible = true;
            panelInfoGeneral.Visible = false;
            panelObrasSociales.Visible = false;
            panelTarjetas.Location = new Point(640, 63);

            int[] datos = gestor.CalcularDatosTarjetas(gestor.pedidosParaInforme);

            this.CargarDatosTarjetas(datos);
        }

        private void btnObrasSociales_Click(object sender, EventArgs e)
        {
            // Ocultamos los paneles secundarios y habilitamos el de obras sociales
            panelTarjetas.Visible = false;
            panelInfoGeneral.Visible = false;
            panelObrasSociales.Visible = true;
            panelObrasSociales.Location = new Point(640, 63);

            List<System.Object> datos = gestor.CalcularDatosObrasSociales(gestor.pedidosParaInforme);

            this.CargarDatosObrasSociales(datos);
        }

        private void btnInfoGeneral_Click(object sender, EventArgs e)
        {
            // Ocultamos los paneles secundarios y habilitamos el de info general
            panelTarjetas.Visible = false;
            panelInfoGeneral.Visible = true;
            panelObrasSociales.Visible = false;
            panelInfoGeneral.Location = new Point(640, 63);

            int[] datos = gestor.CalcularDatosInfoGeneral(gestor.pedidosParaInforme);

            this.CargarDatosInfoGeneral(datos);
        }
        #endregion


        private void btnBuscarMontoOS_Click(object sender, EventArgs e)
        {
            string obraSocialSeleccionada = cmbBoxObraSocial.SelectedItem.ToString();

            int posicion = Array.IndexOf(obrasSocialesOrdenadas, obraSocialSeleccionada);

            TBoxCompletarObraSocialBuscada.Text = dineroObrasSocialesOrdenadas[posicion].ToString();

        }

        private void cmbBoxObraSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBoxCompletarObraSocialBuscada.Text = "-";
        }
    }
}
