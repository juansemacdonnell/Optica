using Microsoft.EntityFrameworkCore;
using OpricaSurinV2.Clases;
using OpricaSurinV2.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpricaSurinV2.Servicios
{
    public class PedidoService 
    {
        private readonly ContextDB _contextoDB;

        public PedidoService(ContextDB contextoDB)
        {
            _contextoDB = contextoDB;
        }

        // Agrega un Pedido nuevo a la BD 
        public void AddPedido(Pedido pedido)
        {
            _contextoDB.Pedidos.Add(pedido);

            _contextoDB.SaveChanges();
        }

        // Actualiza un pedido ya cargado en la BD
        public void ActualizarPedido(Pedido pedido)
        {
            _contextoDB.Pedidos.Update(pedido);

            _contextoDB.SaveChanges();
        }

        // Elimina un pedido 
        public void BorrarPedido(Pedido pedido)
        {
            _contextoDB.Pedidos.Remove(pedido);

            _contextoDB.SaveChanges();
        }

        // Trae un Listado de Pedido
        public List<Pedido> GetPedidosXCliente(Cliente cliente)
        {
            int idClienteAEncontrar = cliente.GetIdCliente();
            return _contextoDB.Pedidos
                .Include(pedido => pedido.cliente)
                .Include(pedido => pedido.receta)
                .Include(pedido => pedido.cobros)
                .ThenInclude(cobro => cobro.factura)
                .Where(x => x.IdCliente == idClienteAEncontrar).ToList();
        }

        // Listado de todos los pedidos:
        public List<Pedido> ObtenerPedidosConClienteYReceta()
        {
            return _contextoDB.Pedidos
                .Include(pedido => pedido.cliente)
                .Include(pedido => pedido.receta)
                .Include(pedido => pedido.cobros)
                 .ThenInclude(cobro => cobro.factura)
                .ToList();
        }

        // Listado de los últimos 10 pedidos:
        public List<Pedido> ObtenerUltimos10PedidosConClienteYReceta()
        {
            return _contextoDB.Pedidos
                .Include(pedido => pedido.cliente)
                .Include(pedido => pedido.receta)
                .Include(pedido => pedido.cobros)
                 .ThenInclude(cobro => cobro.factura)
                .OrderByDescending(pedido => pedido.IdPedido)
                .Take(10)
                .ToList();
        }

        // Listado de pedidos con saldo distinto de 0:
        public List<Pedido> ObtenerPedidosConSaldoDistintoDeCero()
        {
            return _contextoDB.Pedidos
                .Include(pedido => pedido.cliente)
                .Include(pedido => pedido.receta)
                .Include(pedido => pedido.cobros)
                 .ThenInclude(cobro => cobro.factura)
                .Where(pedido => pedido.saldo != 0)
                .ToList();
        }

        // Listado de pedidos del mes actual:
        public List<Pedido> ObtenerPedidosDelMesActual()
        {
            // Obtener el primer día del mes actual
            DateTime primerDiaDelMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            // Obtener el primer día del siguiente mes
            DateTime primerDiaDelSiguienteMes = primerDiaDelMes.AddMonths(1);

            return _contextoDB.Pedidos
                .Include(pedido => pedido.cliente)
                .Include(pedido => pedido.receta)
                .Include(pedido => pedido.cobros)
                 .ThenInclude(cobro => cobro.factura)
                .Where(pedido => pedido.fechaRecibido >= primerDiaDelMes && pedido.fechaRecibido < primerDiaDelSiguienteMes)
                .ToList();
        }

        // Listado de pedidos de un determinado mes:
        public List<Pedido> ObtenerPedidosDelMes(int year, int month)
        {
            // Obtener el primer día del mes especificado
            DateTime primerDiaDelMes = new DateTime(year, month, 1);

            // Obtener el primer día del siguiente mes
            DateTime primerDiaDelSiguienteMes = primerDiaDelMes.AddMonths(1);

            return _contextoDB.Pedidos
                .Include(pedido => pedido.cliente)
                .Include(pedido => pedido.receta)
                .Include(pedido => pedido.cobros)
                 .ThenInclude(cobro => cobro.factura)
                .Where(pedido => pedido.fechaRecibido >= primerDiaDelMes && pedido.fechaRecibido < primerDiaDelSiguienteMes)
                .ToList();
        }

        // Listado de pedidos de un año :
        public List<Pedido> ObtenerPedidosDelAnio(int year)
        {
            // Obtener el primer día del mes especificado
            DateTime primerDiaDelAnio = new DateTime(year, 1, 1);

            // Obtener el primer día del siguiente mes
            DateTime primerDiaDelSiguienteAnio = primerDiaDelAnio.AddYears(1);

            return _contextoDB.Pedidos
                .Include(pedido => pedido.cliente)
                .Include(pedido => pedido.receta)
                .Include(pedido => pedido.cobros)
                 .ThenInclude(cobro => cobro.factura)
                .Where(pedido => pedido.fechaRecibido >= primerDiaDelAnio && pedido.fechaRecibido < primerDiaDelSiguienteAnio)
                .ToList();
        }

        // Listado de pedidos de un periodo seleccionado :
        public List<Pedido> ObtenerPedidosDelPeriodo(DateTime fechaDesde, DateTime fechaHasta)
        {
            
            return _contextoDB.Pedidos
                .Include(pedido => pedido.cliente)
                .Include(pedido => pedido.receta)
                .Include(pedido => pedido.cobros)
                 .ThenInclude(cobro => cobro.factura)
                .Where(pedido => pedido.fechaRecibido >= fechaDesde && pedido.fechaRecibido <= fechaHasta)
                .ToList();
        }

        // Trae un pedido particular
        public Pedido GetPedido(int IdPedidoABuscar)
        {
            
            return _contextoDB.Pedidos
                      .Include(pedido => pedido.cliente)
                      .Include(pedido => pedido.receta)
                      .Include(pedido => pedido.cobros)
                       .ThenInclude(cobro => cobro.factura)
                      .FirstOrDefault(pedido => pedido.IdPedido == IdPedidoABuscar);

        }
    }
}
