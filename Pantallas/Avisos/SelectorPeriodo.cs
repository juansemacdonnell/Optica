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
    public partial class SelectorPeriodo : Form
    {
        Gestor gestor;
        public SelectorPeriodo(Gestor gestor)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.gestor = gestor;

            dTPFechaHasta.Value = DateTime.Now.AddHours(+1);

            // Reproducir un sonido de error al abrir la ventana
            SystemSounds.Beep.Play();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            // Tomamos las selecciones:
            if (dTPFechaDesde.Value <= dTPFechaHasta.Value)
            {
                gestor.fechaDesdePeriodo = dTPFechaDesde.Value.Date;
                gestor.fechaHastaPeriodo = dTPFechaHasta.Value.Date.AddDays(1).AddTicks(-1); 

                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            else
            {
                // Mostrar mensaje de confirmación
                MessageBox.Show("La fecha Hasta debe ser mayor o igual a la fecha desde.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
