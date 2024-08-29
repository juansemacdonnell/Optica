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
    public partial class SelectorAnio : Form
    {
        Gestor gestor;
        public SelectorAnio(Gestor gestor)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.gestor = gestor;

            // Reproducir un sonido de error al abrir la ventana
            SystemSounds.Beep.Play();

            // Llenar ComboBox de Años (desde 2020 hasta 2030)
            for (int i = 2020; i <= 2030; i++)
            {
                comboBoxAnio.Items.Add(i);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Tomamos las selecciones:
            if (comboBoxAnio.SelectedItem != null)
            {
                gestor.anioSeleccionado = (int)comboBoxAnio.SelectedItem;

                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            else
            {
                // Mostrar mensaje de confirmación
                MessageBox.Show("Por favor seleccione un mes y un año. Si quiere cancelar la busqueda cierre la ventana.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
