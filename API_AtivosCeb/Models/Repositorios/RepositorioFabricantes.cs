using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_AtivosCeb.Models.Repositorios
{
    public class RepositorioFabricantes : Interfaces.InterfaceFabricantes
    {
        public fabricantes Add(fabricantes item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            Banco.InserirFabricante(item);
            return item;
        }

        public fabricantes Get(int id)
        {
            return Banco.ListarFabricantes().Find(p => p.idFabricante == id);
        }

        public String GetDescFabricantePorId(int id)
        {
            return Banco.ObterDescFabricantePorId(id);
        }

        public IEnumerable<fabricantes> GetAll()
        {
            return Banco.ListarFabricantes();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(fabricantes item)
        {
            throw new NotImplementedException();
        }
    }
}