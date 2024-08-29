using OpricaSurinV2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticaSurinV2.Clases
{
    public class Cobro
    {
        // Atributos
        public int IdCobro { get; set; }
        // monto = sumatoria de dinero en tarjeta + efec + trans
        public float monto {  get; set; }

        // metodos de pago
        // tarjeta 1
        public float dineroTarjeta1 { get; set; }
        public string tipoTarjeta1 { get; set; }
        public string marcaTarjeta1 { get; set; }
        public string Ultimos4NumerosTarejta1 { get; set; }

        // tarjeta 2
        public float dineroTarjeta2 { get; set; }
        public string tipoTarjeta2 { get; set; }
        public string marcaTarjeta2 { get; set; }
        public string Ultimos4NumerosTarejta2 { get; set; }

        // transferencia
        public float dineroTransferencia { get; set; }

        // obra social
        public float dineroObraSocial {  get; set; }
        public string nombreObraSocial { get; set; }

        // efectivo
        public float dineroEfectivo { get; set; }

        // siempre la fecha actual
        public DateTime fechaCobro { get; set; }
        public string aclaracionesDeCobro;

        // Para BD
        public int IdFactura { get; set; }
        public Factura factura { get; set; }

        public int IdPedido { get; set; }
        public Pedido pedido { get; set;}

        // COnstructor
        public Cobro()
        {
            this.fechaCobro = DateTime.Now;
        }

        public int GetIdCobro()
        {
            return IdCobro;
        }
    }
}
