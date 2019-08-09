using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_AtivosCeb.Models.Repositorios
{
    public class RepositorioAtivos : Interfaces.InterfaceAtivos
    {
        public ativos Add(ativos item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            Banco.InserirAtivo(item);
            return item;
        }

        public ativos Get(int id)
        {
            return Banco.ListarAtivos().Find(p => p.idAtivo == id);
        }

        public IEnumerable<ativos> GetLocal(int idLocal)
        {
            return Banco.ListarAtivos().FindAll(p => p.idLocal == idLocal);
        }

        public IEnumerable<ativos> GetPiso(int idPiso)
        {
            return Banco.ListarAtivos().FindAll(p => p.idPiso == idPiso);
        }

        public IEnumerable<ativos> GetFabricante(int idFabricante)
        {
            return Banco.ListarAtivos().FindAll(p => p.idFabricante == idFabricante);
        }

        public IEnumerable<ativos> GetCategoria(int idCategoria)
        {
            return Banco.ListarAtivos().FindAll(p => p.idCategoria == idCategoria);
        }

        public ativos GetPatrimonio(int patrimonio)
        {
            return Banco.ListarAtivos().Find(p => p.patrimonio == patrimonio);
        }

        public IEnumerable<ativos> GetAll()
        {
            return Banco.ListarAtivos();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ativos item)
        {
            throw new NotImplementedException();
        }
    }
}