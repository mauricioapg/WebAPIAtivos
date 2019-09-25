using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_AtivosCeb.Models.Repositorios
{
    public class RepositorioPisos: Interfaces.InterfacePisos
    {
        public pisos Add(pisos item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            Banco.InserirPiso(item);
            return item;
        }

        public pisos Get(int id)
        {
            return Banco.ListarPisos().Find(p => p.idPiso == id);
        }

        public IEnumerable<pisos> GetAll()
        {
            return Banco.ListarPisos();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(pisos item)
        {
            throw new NotImplementedException();
        }
    }
}