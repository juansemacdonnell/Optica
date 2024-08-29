using OpricaSurinV2.Contexto;
using OpricaSurinV2.Pantallas;
using OpricaSurinV2.Servicios;
using OpticaSurinV2.Pantallas;
using OpticaSurinV2.Servicios;

namespace OpricaSurinV2
{
    public partial class Inicio : Form
    {
        // Inicializamos el context DB
        private static ContextDB _contextoDB = new ContextDB();

        // Inicializamos los servicios opara pasarle al gestor
        private static ClienteService _clienteService = new ClienteService(_contextoDB);
        private static RecetaService _recetaService = new RecetaService(_contextoDB);
        private static PedidoService _pedidoService = new PedidoService(_contextoDB);
        private static CobroService _cobroService = new CobroService(_contextoDB);

        // Inicializamos el gestor del programa con todos los servicios para acceder a la BD
        Gestor gestor = new Gestor(_clienteService, _recetaService, _pedidoService, _cobroService);

        public Inicio()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            int ancho = (Screen.PrimaryScreen.Bounds.Width / 2) - (860 / 2);
            int alto = (Screen.PrimaryScreen.Bounds.Height / 2) - (500 / 2);

            Point localizacion = new Point(ancho, alto);
            panelInicio.Location = localizacion;

        }
        private void btnRegistrarPedido_Click(object sender, EventArgs e)
        {
            Form ventana = new RegistrarPedido(gestor);
            ventana.Show();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            Form ventanaBusquedaCliente = new BuscarCliente(gestor);
            ventanaBusquedaCliente.Show();
        }

        private void btnListadoPedidos_Click(object sender, EventArgs e)
        {
            ListadosDePedidos ventanaUltimosPedidos = new ListadosDePedidos(gestor);
            ventanaUltimosPedidos.Show();
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            Informes ventanaInformes = new Informes(gestor);
            ventanaInformes.Show();
        }

        private void btnRegistrarAnteojoSolAr_Click(object sender, EventArgs e)
        {
            ArreglosYSol ventanaArreglosYSol = new ArreglosYSol(gestor);
            ventanaArreglosYSol.Show();
        }
    }
}
