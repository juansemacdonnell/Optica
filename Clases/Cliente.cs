using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpricaSurinV2.Clases
{
    public class Cliente
    {
        // Atributos
        public int IdCliente { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string dni { get; set; }
        public string obraSocial { get; set; }
        public string direccion { get; set; }

        // Para BD
        public List<Pedido> pedidos { get; set; }
        public List<Receta> recetas { get; set; }


        // Constructores
        public Cliente()
        {
            recetas = new List<Receta>();
            pedidos = new List<Pedido>();
        }

        public Cliente(string nombre, string telefono, string dni, string obraSocial,
            string direccion)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            this.dni = dni;
            this.obraSocial = obraSocial;
            this.direccion = direccion;
            this.recetas = new List<Receta>();
            this.pedidos = new List<Pedido>();
        }

        // Metodo
        public void AggRecetaCliente(Receta nuevaReceta)
        {
            this.recetas.Add(nuevaReceta);
        }

        // Setters y getters
        public int GetIdCliente()
        {
            return this.IdCliente;
        }

        public void AggPedido(Pedido nuevoPedido)
        {
            this.pedidos.Add(nuevoPedido);
        }
    }
}
