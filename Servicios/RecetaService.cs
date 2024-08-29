using OpricaSurinV2.Clases;
using OpricaSurinV2.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpricaSurinV2.Servicios
{
    public class RecetaService 
    {
        private readonly ContextDB _contextoDB;

        public RecetaService(ContextDB contextoDB)
        {
            _contextoDB = contextoDB;
        }

        // Agrega una Receta nueva a la BD 
        public void AddReceta(Receta receta)
        {
            _contextoDB.Recetas.Add(receta);

            _contextoDB.SaveChanges();
        }


        // Actualiza una receta ya cargada en la BD
        public void ActualizarReceta(Receta recetaActualizada)
        {
            _contextoDB.Recetas.Update(recetaActualizada);

            _contextoDB.SaveChanges();
        }

        // Elimina una receta 
        public void BorrarReceta(Receta receta)
        {
            _contextoDB.Recetas.Remove(receta);

            _contextoDB.SaveChanges();
        }

        // Trae una receta particular de la BD
        public Receta GetReceta(int IdRecetaAEncontrar)
        {
            return _contextoDB.Recetas.Where(x => x.IdReceta == IdRecetaAEncontrar).FirstOrDefault();
        }

        // Trae un Listado de recetas que tienen el mismo Cliente
        public List<Receta> GetRecetasXCliente(int IdClienteRectas)
        {
            return _contextoDB.Recetas.Where(x => x.IdCliente == IdClienteRectas).ToList();
        }
    }
}
