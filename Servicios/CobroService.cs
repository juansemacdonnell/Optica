using Microsoft.EntityFrameworkCore;
using OpricaSurinV2.Clases;
using OpricaSurinV2.Contexto;
using OpticaSurinV2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticaSurinV2.Servicios
{
    public class CobroService
    {
        private readonly ContextDB _contextoDB;

        public CobroService(ContextDB contextoDB)
        {
            _contextoDB = contextoDB;
        }

        // Agrega un cobro nuevo a la BD 
        public void AddCobro(Cobro cobro)
        {
            _contextoDB.Cobros.Add(cobro);

            _contextoDB.SaveChanges();
        }

        // Actualiza un cobro ya cargado en la BD
        public void ActualizarCobro(Cobro cobroAct)
        {
            _contextoDB.Cobros.Update(cobroAct);

            _contextoDB.SaveChanges();
        }

        // Elimina un cobro 
        public void BorrarCliente(Cobro cobro)
        {
            _contextoDB.Cobros.Remove(cobro);

            _contextoDB.SaveChanges();
        }

        // Trae un cobro particular de la BD
        public Cobro GetCobro(int IdCobroABuscar)
        {
            return _contextoDB.Cobros.Include(cobro => cobro.factura)
                .FirstOrDefault(x => x.IdCobro == IdCobroABuscar);

        }

        // Trae un Listado de cobros de un pedido
        public List<Cobro> GetCobrosXPedido(int IdPedidoABuscar)
        {

            return _contextoDB.Cobros.Where(x => x.IdPedido == IdPedidoABuscar)
                .Include(cobro => cobro.factura).ToList();

        }

    }
}
