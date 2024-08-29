using Microsoft.EntityFrameworkCore;
using OpricaSurinV2;
using OpricaSurinV2.Clases;
using OpricaSurinV2.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpricaSurinV2.Servicios
{
    public class ClienteService 
    {
        private readonly ContextDB _contextoDB;

        public ClienteService(ContextDB contextoDB)
        {
            _contextoDB = contextoDB;
        }

        // Agrega un cliente nuevo a la BD 
        public void AddCliente(Cliente cliente)
        {
            _contextoDB.Clientes.Add(cliente);

            _contextoDB.SaveChanges();
        }

        // Actualiza un cliente ya cargado en la BD
        public void ActualizarCliente(Cliente clienteActualizado)
        {
            _contextoDB.Clientes.Update(clienteActualizado);

            _contextoDB.SaveChanges();
        }

        // Elimina un cliente 
        public void BorrarCliente(Cliente clientaABorrar)
        {
            _contextoDB.Clientes.Remove(clientaABorrar);

            _contextoDB.SaveChanges();
        }

        // Trae un cliente particular de la BD
        public Cliente GetCliente(int IdClienteABuscar) 
        {
            //return _contextoDB.Clientes.Where(x => x.IdCliente == IdClienteABuscar).FirstOrDefault();
            return _contextoDB.Clientes
                      .Include(c => c.recetas) // Carga ansiosa de las recetas
                      .FirstOrDefault(x => x.IdCliente == IdClienteABuscar);

        }

        // Trae un Listado de clientes que contienen el nombre pasado por cadena
        public List<Cliente> GetClientesXNombre(String nombreClienteABuscar) 
        {
            
            return _contextoDB.Clientes.Where(x => x.nombre.ToUpper().Contains(nombreClienteABuscar.ToUpper())).ToList(); 

        }

    }
}
