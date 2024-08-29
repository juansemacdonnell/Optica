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
    public partial class AvisoNoHayPedidoSeleccionado : Form
    {
        public AvisoNoHayPedidoSeleccionado()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // Reproducir un sonido de error al abrir la ventana
            SystemSounds.Beep.Play();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
