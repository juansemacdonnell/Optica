using OpricaSurinV2;
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

namespace OpticaSurinV2.Pantallas
{
    public partial class PantallaInformeFinal : Form
    {
        Gestor gestor;
        public PantallaInformeFinal(Gestor gestor)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            // Obtener el ancho del formulario
            int formAncho = this.ClientSize.Width;

            this.gestor = gestor;
        }


        // Metodo que genera el histograma
        public void GenerarHistograma(int[] ventasPorMes)

        {
            histogramaFrecuencias.Series["Fo"].Points.Clear();

            // Ocultar la grilla del eje X y del eje Y
            histogramaFrecuencias.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            histogramaFrecuencias.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            // Deshabilitar las marcas mayores y menores del eje X
            histogramaFrecuencias.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            histogramaFrecuencias.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;

            // Ajustar el ancho de las barras para que haya espacio entre ellas
            histogramaFrecuencias.Series["Fo"]["PointWidth"] = "0.8"; // Ajusta el ancho según tu preferencia

            // Configurar el color del borde de las barras
            histogramaFrecuencias.Series["Fo"].BorderColor = System.Drawing.Color.Black;

            // Configurar etiquetas del eje X para que se muestren los números de los meses
            histogramaFrecuencias.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
            histogramaFrecuencias.ChartAreas[0].AxisX.Interval = 1;

            // Iterar sobre los datos para agregar puntos al histograma
            for (int i = 0; i < ventasPorMes.Length; i++)
            {
                // Agregar un punto al histograma para cada mes (i + 1 para que los meses empiecen en 1)
                histogramaFrecuencias.Series["Fo"].Points.AddXY(i + 1, ventasPorMes[i]);
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCambiarAnio_Click(object sender, EventArgs e)
        {
            // configurar con ventana
            SelectorAnio ventanaSelector = new SelectorAnio(gestor);
            ventanaSelector.ShowDialog();

            if (ventanaSelector.DialogResult == DialogResult.OK)
            {
                List<Pedido> pedidosDelAnio = gestor.pedidoService.ObtenerPedidosDelAnio(gestor.anioSeleccionado);

                List<System.Object> datos = gestor.CalcularDatosInformeAnual(pedidosDelAnio);

                this.CargarDatos(datos);
            }
        }

        private void PantallaInformeFinal_Load(object sender, EventArgs e)
        {
            int anioSeleccionado = DateTime.Now.Year;

            List<Pedido> pedidosDelAnio = gestor.pedidoService.ObtenerPedidosDelAnio(anioSeleccionado);

            List<System.Object> datos = gestor.CalcularDatosInformeAnual(pedidosDelAnio);

            this.CargarDatos(datos);
        }

        void CargarDatos(List<System.Object> datos)
        {
            /*       0              1              2               3               4               
            * cant pedidos ,  total dinero, efectivo total, tarjeta total, transferencia total,
            *         5             6             7            8                 9                 
               total facturado, total receta, total sol, total arreglo, acumuladores por mes,
                       10
               ingreso promedio    */

            // Generamos histograma
            this.GenerarHistograma((int[])datos[9]);

            // Primer Panel
            #region Primer Panel
            TBoxTotalFacturadoAuto.Text = datos[5].ToString();

            // Buscamos el mes con mas y menos ventas
            // Variables para almacenar el mes con mayor y menor ventas

            int mesMayorVentas = 0;
            int mesMenorVentas = 0;

            // Iterar sobre el array para encontrar el mes con mayor y menor ventas
            int[] ventas = (int[])datos[9];

            for (int i = 1; i <= 12; i++)
            {
                if (i == 1)
                {
                    mesMayorVentas = 1;
                    mesMenorVentas = 1;
                }
                else if (ventas[i - 1] > ventas[mesMayorVentas - 1])
                {
                    mesMayorVentas = i;
                }
                else if (ventas[i - 1] < ventas[mesMenorVentas - 1])
                {
                    mesMenorVentas = i;
                }
            }

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

            lblMesMasVendidoCompletar.Text = meses[mesMayorVentas];
            TBoxMesMasVendidoCompletar.Text = ventas[mesMayorVentas - 1].ToString();

            lblMesMenosVendidoCompletar.Text = meses[mesMenorVentas];
            TBoxMesMenosVendidoCompletar.Text = ventas[mesMenorVentas - 1].ToString();

            TBoxIngresoPromedioMensualCompletar.Text = datos[10].ToString();
            #endregion

            // Segundo Panel
            #region Segundo Panel
            TBoxTotalCompletar.Text = datos[1].ToString();
            TBoxEfectivoCompletar.Text = datos[2].ToString();
            TBoxTarjetaCompletar.Text = datos[3].ToString();
            TBoxTransferenciaCompletar.Text = datos[4].ToString();
            #endregion

            // Tercer Panel
            #region Tercer Panel
            TBoxCantidadTotalPedidos.Text = datos[0].ToString();
            TBoxRecetaTotal.Text = datos[6].ToString();
            TBoxSolTotal.Text = datos[7].ToString();
            TBoxArregloTotal.Text = datos[8].ToString();
            #endregion
        }

    }
}
