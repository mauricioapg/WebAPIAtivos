using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_AtivosCeb.Models.Repositorios
{
    public class RepositorioLocais : Interfaces.InterfaceLocais
    {
        public locais Add(locais item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            Banco.InserirLocal(item);
            return item;
        }

        public locais Get(int id)
        {
            return Banco.ListarLocais().Find(p => p.idLocal == id);
        }

        public IEnumerable<locais> GetAll()
        {
            return Banco.ListarLocais();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(locais item)
        {
            throw new NotImplementedException();
        }
    }
}