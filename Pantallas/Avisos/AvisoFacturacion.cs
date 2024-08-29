using OpricaSurinV2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpticaSurinV2.Pantallas
{
    public partial class AvisoFacturacion : Form
    {
        Gestor gestor;
        public AvisoFacturacion(Gestor gestor)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.gestor = gestor;

            // Reproducir un sonido de error al abrir la ventana
            SystemSounds.Beep.Play();

            // Completamos los saldos:
            lblTotalDPCompletar.Text = gestor.cobroDelPedido.monto.ToString();
            lblTotalFacturadoCompletar.Text = gestor.totalFacturado.ToString();

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
