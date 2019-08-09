using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_AtivosCeb.Models.Repositorios
{
    public class RepositorioCategorias : Interfaces.InterfaceCategorias
    {
        public categorias Add(categorias item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            Banco.InserirCategoria(item);
            return item;
        }

        public categorias Get(int id)
        {
            return Banco.ListarCategorias().Find(p => p.idCategoria == id);
        }

        public IEnumerable<categorias> GetAll()
        {
            return Banco.ListarCategorias();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(categorias item)
        {
            throw new NotImplementedException();
        }
    }
}