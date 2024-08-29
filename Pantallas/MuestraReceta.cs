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

namespace OpricaSurinV2.Pantallas
{
    public partial class MuestraReceta : Form
    {
        Gestor gestor;

        // Bandera edicion receta
        bool banderaEditaronOk = false;

        // Constructor sin boton seleccionar
        public MuestraReceta(Gestor gestorok)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            gestor = gestorok;

            // Completamos casilleros de la receta
            TBoxNombre.Text = gestor.clienteActual.nombre;
            lblFechaRecetaCompletar.Text = gestor.recetaDelPedido.fechaReceta.ToString("dd/MM/yy");

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

            // Quitamos el boton seleccionar
            btnSeleccionarReceta.Visible = false;
            checkBoxCerca.Enabled = false;  
            checkBoxLejos.Enabled = false;
            checkBoxLejos.Visible = false;
            checkBoxCerca.Visible = false;

            // Reubicamos lo botones:
            Point nuevaUbicacion1 = new Point(190, 321);
            Point nuevaUbicacion2 = new Point(315, 321);
            btnCancelar.Location = nuevaUbicacion1;
            btnEditarReceta.Location = nuevaUbicacion2;

            // Deshabilitamos confirmar edicion
            btnConfirmarEdicion.Enabled = false;

        }

        // Constructor con boton seleccionar y sin editar receta
        public MuestraReceta(Gestor gestor ,string nombre)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            gestor = gestor;

            // Completamos casilleros de la receta
            TBoxNombre.Text = nombre;
            lblFechaRecetaCompletar.Text = gestor.recetaDelPedido.fechaReceta.ToString("dd/MM/yy");

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

            // Quitamos el boton editar receta
            btnEditarReceta.Visible = false;
            btnConfirmarEdicion.Visible = false;
            checkBoxCerca.Enabled = false;
            checkBoxLejos.Enabled = false;
            checkBoxLejos.Visible = false;
            checkBoxCerca.Visible = false;

            // Reubicamos lo botones:
            Point nuevaUbicacion1 = new Point(190, 321);
            Point nuevaUbicacion2 = new Point(315, 321);
            btnCancelar.Location = nuevaUbicacion1;
            btnSeleccionarReceta.Location = nuevaUbicacion2;
        }

        // Boton cancelar show dialog = false
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Boton seleccionar shor dialog = true
        private void btnSeleccionarReceta_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnEditarReceta_Click(object sender, EventArgs e)
        {
            // habilita boton confirmar edicion
            btnConfirmarEdicion.Enabled = true;

            checkBoxCerca.Enabled = true;
            checkBoxLejos.Enabled = true;
            checkBoxLejos.Visible = true;
            checkBoxCerca.Visible = true;

            // Datos receta
            // Lejos
            TBoxODerEsfericoLejos.Enabled = true;
            TBoxOIzqEsfericoLejos.Enabled = true;
            TBoxCilDerLejos.Enabled = true;
            TBoxCilIzqLejos.Enabled = true;
            TBoxGradosDerLejos.Enabled = true;
            TBoxGradosIzqLejos.Enabled = true; ;
            TBoxDNPDLejos.Enabled = true;
            TBoxDNPILejos.Enabled = true;
            // Cerca
            TBoxODerEsfericoCerca.Enabled = true;
            TBoxOIzqEsfericoCerca.Enabled = true;
            TBoxCilIzqCerca.Enabled = true;
            TBoxCilDerCerca.Enabled = true;
            TBoxGradosDerCerca.Enabled = true;
            TBoxGradosIzqCerca.Enabled = true;
            TBoxDNPDCerca.Enabled = true;
            TBoxDNPICerca.Enabled = true;
            // Otros
            TBoxObservaciones.Enabled = true;
            TBoxDoctorReceta.Enabled = true;

        }

        // Valoidacion de campos de receta, valida q esten completos los datos de la receta seleccionada
        bool ValidarGraduacionCerca()
        {
            if (string.IsNullOrWhiteSpace(TBoxCilIzqCerca.Text) ||
                string.IsNullOrWhiteSpace(TBoxCilDerCerca.Text) ||
                string.IsNullOrWhiteSpace(TBoxDNPDCerca.Text) ||
                string.IsNullOrWhiteSpace(TBoxDNPICerca.Text) ||
                string.IsNullOrWhiteSpace(TBoxGradosDerCerca.Text) ||
                string.IsNullOrWhiteSpace(TBoxGradosIzqCerca.Text) ||
                string.IsNullOrWhiteSpace(TBoxODerEsfericoCerca.Text) ||
                string.IsNullOrWhiteSpace(TBoxOIzqEsfericoCerca.Text))
            {
                AvisoGraduacionCerca ventanaGraduacionCerca = new AvisoGraduacionCerca();
                ventanaGraduacionCerca.Show();
                return false;
            }
            else
            {
                return true;
            }
        }
        bool ValidarGraduacionLejos()
        {
            if (string.IsNullOrWhiteSpace(TBoxCilDerLejos.Text) ||
    string.IsNullOrWhiteSpace(TBoxCilIzqLejos.Text) ||
    string.IsNullOrWhiteSpace(TBoxDNPDLejos.Text) ||
    string.IsNullOrWhiteSpace(TBoxDNPILejos.Text) ||
    string.IsNullOrWhiteSpace(TBoxGradosDerLejos.Text) ||
    string.IsNullOrWhiteSpace(TBoxGradosIzqLejos.Text) ||
    string.IsNullOrWhiteSpace(TBoxODerEsfericoLejos.Text) ||
    string.IsNullOrWhiteSpace(TBoxOIzqEsfericoLejos.Text))
            {
                AvisoGraduacionLejos ventanaGraduacionLejos = new AvisoGraduacionLejos();
                ventanaGraduacionLejos.Show();
                return false;
            }
            else
            {
                return true;
            }
        }

        // Boton confirmar edicion
        private void btnConfirmarEdicion_Click(object sender, EventArgs e)
        {
            // Datos receta
            // Lejos
            // Derecho
            gestor.recetaDelPedido.ojoDerechoEsfericoLejos = TBoxODerEsfericoLejos.Text;
            gestor.recetaDelPedido.cilindroDerechoLejos = TBoxCilDerLejos.Text;
            gestor.recetaDelPedido.gradosDerechoLejos = TBoxGradosDerLejos.Text;
            gestor.recetaDelPedido.dNPDLejos = TBoxDNPDLejos.Text;

            // Izquierdo
            gestor.recetaDelPedido.ojoIzquierdoEsfericoLejos = TBoxOIzqEsfericoLejos.Text;
            gestor.recetaDelPedido.cilindroIzquierdoLejos = TBoxCilIzqLejos.Text;
            gestor.recetaDelPedido.gradosIzquierdoLejos = TBoxGradosIzqLejos.Text;
            gestor.recetaDelPedido.dNPILejos = TBoxDNPILejos.Text;

            // Cerca
            // Derecho
            gestor.recetaDelPedido.ojoDerechoEsfericoCerca = TBoxODerEsfericoCerca.Text;
            gestor.recetaDelPedido.cilindroDerechoCerca = TBoxCilDerCerca.Text;
            gestor.recetaDelPedido.gradosDerechoCerca = TBoxGradosDerCerca.Text;
            gestor.recetaDelPedido.dNPDCerca = TBoxDNPDCerca.Text;

            // Izquierdo
            gestor.recetaDelPedido.ojoIzquierdoEsfericoCerca = TBoxOIzqEsfericoCerca.Text;
            gestor.recetaDelPedido.cilindroIzquierdoCerca = TBoxCilIzqCerca.Text;
            gestor.recetaDelPedido.gradosIzquierdoCerca = TBoxGradosIzqCerca.Text;
            gestor.recetaDelPedido.dNPICerca = TBoxDNPICerca.Text;
            // Otros
            gestor.recetaDelPedido.observaciones = TBoxObservaciones.Text;
            gestor.recetaDelPedido.doctor = TBoxDoctorReceta.Text;

            // Validacion Receta:
            string nuevoTipo;

            if (checkBoxCerca.Checked == false && checkBoxLejos.Checked == false)
            // Necesito todos los datos:
            {
                if (ValidarGraduacionCerca() && ValidarGraduacionLejos())
                {
                    gestor.recetaDelPedido.tipo = "Ambos";
                    banderaEditaronOk = true;
                }

            }
            if (checkBoxCerca.Checked == true && checkBoxLejos.Checked == false)
            // Necesito solo datos de Lejos
            {
                if (ValidarGraduacionLejos())
                {
                    gestor.recetaDelPedido.tipo = "Lejos";
                    banderaEditaronOk = true;
                }
            }
            if (checkBoxLejos.Checked == true && checkBoxCerca.Checked == false)
            // Necesito solo datos de cerca
            {
                if (ValidarGraduacionCerca())
                {
                    gestor.recetaDelPedido.tipo = "Cerca";
                    banderaEditaronOk = true;
                }
            }
            if (checkBoxLejos.Checked == true && checkBoxCerca.Checked == true)
            {
                AvisoElijaUnaGraduacion ventanaElijaUnaGraduacion = new AvisoElijaUnaGraduacion();
                ventanaElijaUnaGraduacion.Show();
            }

            if (banderaEditaronOk)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }
    }
}
