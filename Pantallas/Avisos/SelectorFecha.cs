using OpricaSurinV2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpticaSurinV2.Pantallas
{
    public partial class SelectorFecha : Form
    {
        Gestor gestor;

        public SelectorFecha(Gestor gestor)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.gestor = gestor;

            // Reproducir un sonido de error al abrir la ventana
            SystemSounds.Beep.Play();

            // Llenar ComboBox de Meses
            comboBoxMes.Items.AddRange(new string[] { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" });

            // Llenar ComboBox de Años (desde 2020 hasta 2030)
            for (int i = 2020; i <= 2030; i++)
            {
                comboBoxAnio.Items.Add(i);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Inicializar el diccionario de meses y números
            var meses = new Dictionary<string, int>
            {
                { "Enero", 1 },
                { "Febrero", 2 },
                { "Marzo", 3 },
                { "Abril", 4 },
                { "Mayo", 5 },
                { "Junio", 6 },
                { "Julio", 7 },
                { "Agosto", 8 },
                { "Septiembre", 9 },
                { "Octubre", 10 },
                { "Noviembre", 11 },
                { "Diciembre", 12 }
            };

            // Tomamos las selecciones:
            if (comboBoxAnio.SelectedItem != null && comboBoxMes.SelectedItem != null)
            {
                gestor.anioSeleccionado = (int)comboBoxAnio.SelectedItem;
                string mesSeleccionadoString = comboBoxMes.SelectedItem.ToString();
                gestor.mesSeleccionado = meses[mesSeleccionadoString];

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
