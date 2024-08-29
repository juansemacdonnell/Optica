using OpticaSurinV2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpricaSurinV2.Clases
{
    public class Pedido
    {
        // Atributos
        public int IdPedido { get; set; }
        // Resolver lo de numero de pedido (ver como hacerlo q se haga autoincremental)
        public float total { get; set; }
        public float sena { get; set; }

        // Para manejo de datos:
        public float saldo { get; set; }
        public DateTime fechaRecibido { get; set; }
        public DateTime fechaPrometido { get; set; }
        public string observaciones { get; set; }
        public string detallePedido { get; set; }
        public string tipo {  get; set; }


        // Para BD
        public int? IdReceta { get; set; }
        public Receta receta { get; set; }


        // Para BD
        public int IdCliente { get; set; }
        public Cliente cliente { get; set; }

        public List<Cobro> cobros {  get; set; }

        // Constructores
        public Pedido()
        {
        }

        // Constructor pedido receta
        public Pedido(Receta receta, Cliente cliente, float total, 
           float sena, DateTime fechaRecibido, DateTime fechaPrometido, string observacionesPed)
        {
            this.receta = receta;
            this.cliente = cliente;
            this.total = total;
            this.sena = sena;
            this.fechaRecibido = fechaRecibido;
            this.fechaPrometido = fechaPrometido;
            this.observaciones = observacionesPed;
            this.cobros = new List<Cobro>();
            this.detallePedido = "No aplica.";

            this.tipo = "RECETA";

            // Se calcula el saldo restante:
            this.saldo = this.total - this.sena;
        }

        // Constructor pedido arreglo y sol
        public Pedido(Cliente cliente, float total, float sena, DateTime fechaRecibido, DateTime fechaPrometido, string observacionesPed, string tipo, string detalle)
        {
            this.cliente = cliente;
            this.total = total;
            this.sena = sena;
            this.fechaRecibido = fechaRecibido;
            this.fechaPrometido = fechaPrometido;
            this.observaciones = observacionesPed;
            this.cobros = new List<Cobro>();
            this.tipo = tipo;
            this.detallePedido = detalle;

            // Se calcula el saldo restante:
            this.saldo = this.total - this.sena;
        }


        // Metodos:
        public int GetIdPedido()
        { 
            // Método para obtener el número de pedido actual
            return this.IdPedido;
        }
       
        public float ObtenerSaldo()
        {
            return saldo;
        }

        public void AggCobro(Cobro nuevoCobro)
        {
            this.cobros.Add(nuevoCobro);
        }
    }
}
