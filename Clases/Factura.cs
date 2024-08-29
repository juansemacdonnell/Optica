using OpricaSurinV2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticaSurinV2.Clases
{
    public class Factura
    {
        // Atributos
        public int IdFactura {  get; set; }
        public List<String> items {  get; set; }
        public List<float> totalItems { get; set; }

        public Cobro cobro { get; set; }

        // Constructores
        public Factura()
        {
            this.items = new List<String>();
            this.totalItems = new List<float>(); 
        }
        public Factura(List<string> items, List<float> totalItems)
        {
            this.items = items;
            this.totalItems = totalItems;
        }
    }
}
