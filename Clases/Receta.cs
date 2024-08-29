using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpricaSurinV2.Clases
{
    public class Receta
    {
        // Atributos
        public int IdReceta { get; set; }

        public string tipo { get; set; }

        // Graduacion Lejos:
        // Ojo Derecho
        public string ojoDerechoEsfericoLejos { get; set; }
        public string cilindroDerechoLejos { get; set; }
        public string gradosDerechoLejos { get; set; }
        public string dNPDLejos { get; set; }

        // Ojo Izquierdo
        public string ojoIzquierdoEsfericoLejos { get; set; }
        public string cilindroIzquierdoLejos { get; set; }
        public string gradosIzquierdoLejos { get; set; }
        public string dNPILejos { get; set; }

        // Graduacion Cerca:
        // Ojo Derecho
        public string ojoDerechoEsfericoCerca { get; set; }
        public string cilindroDerechoCerca { get; set; }
        public string gradosDerechoCerca { get; set; }
        public string dNPDCerca { get; set; }

        // Ojo Izquierdo
        public string ojoIzquierdoEsfericoCerca { get; set; }
        public string cilindroIzquierdoCerca { get; set; }
        public string gradosIzquierdoCerca { get; set; }
        public string dNPICerca { get; set; }

        public string observaciones { get; set; }
        public string doctor { get; set; }
        public DateTime fechaReceta { get; set; }

        // Para BD
        public int IdCliente { get; set; }
        public Cliente cliente { get; set; }

        public List<Pedido> pedidos { get; set; }

        // Constructores
        public Receta()
        {
        }

        public Receta(string ojoDerechoEsfericoLejos, string cilindroDerechoLejos,
            string gradosDerechoLejos, string dNPDLejos, string ojoIzquierdoEsfericoLejos,
            string cilindroIzquierdoLejos, string gradosIzquierdoLejos, string dNPILejos,
            string ojoDerechoEsfericoCerca, string cilindroDerechoCerca, string gradosDerechoCerca,
            string dNPDCerca, string ojoIzquierdoEsfericoCerca, string cilindroIzquierdoCerca,
            string gradosIzquierdoCerca, string dNPICerca, string doctor, DateTime fechaReceta,
            string observaciones, string tipo)
        {
            this.ojoDerechoEsfericoLejos = ojoDerechoEsfericoLejos;
            this.cilindroDerechoLejos = cilindroDerechoLejos;
            this.gradosDerechoLejos = gradosDerechoLejos;
            this.dNPDLejos = dNPDLejos;
            this.ojoIzquierdoEsfericoLejos = ojoIzquierdoEsfericoLejos;
            this.cilindroIzquierdoLejos = cilindroIzquierdoLejos;
            this.gradosIzquierdoLejos = gradosIzquierdoLejos;
            this.dNPILejos = dNPILejos;
            this.ojoDerechoEsfericoCerca = ojoDerechoEsfericoCerca;
            this.cilindroDerechoCerca = cilindroDerechoCerca;
            this.gradosDerechoCerca = gradosDerechoCerca;
            this.dNPDCerca = dNPDCerca;
            this.ojoIzquierdoEsfericoCerca = ojoIzquierdoEsfericoCerca;
            this.cilindroIzquierdoCerca = cilindroIzquierdoCerca;
            this.gradosIzquierdoCerca = gradosIzquierdoCerca;
            this.dNPICerca = dNPICerca;
            this.doctor = doctor;
            this.fechaReceta = fechaReceta;
            this.observaciones = observaciones;
            this.tipo = tipo;
        }
    }
}
