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

        public IEnumerable<ativos> GetCondicao(string condicao)
        {
            return Banco.ListarAtivos().FindAll(p => p.condicao == condicao);
        }

        //public IEnumerable<string> GetModelosCategoria(int idCategoria)
        //{
        //    return Banco.ListarModelos().FindAll(p => p.idCategoria == idCategoria);
        //}

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

        public ativos GetNumeroSerie(string numeroSerie)
        {
            return Banco.ListarAtivos().Find(p => p.numeroSerie == numeroSerie);
        }

        public ativos GetServiceTag(string serviceTag)
        {
            return Banco.ListarAtivos().Find(p => p.serviceTag == serviceTag);
        }

        public ativos GetPatrimonio(int patrimonio)
        {
            return Banco.ListarAtivos().Find(p => p.patrimonio == patrimonio);
        }

        public IEnumerable<ativos> GetPisoCategoria(int idPiso, int idCategoria)
        {
            return Banco.ListarAtivos().FindAll(p => p.idPiso == idPiso && p.idCategoria == idCategoria);
        }

        public IEnumerable<ativos> GetCategoriaFabricante(int idCategoria, int idFabricante)
        {
            return Banco.ListarAtivos().FindAll(p => p.idCategoria == idCategoria && p.idFabricante == idFabricante);
        }

        public IEnumerable<ativos> GetCategoriaPisoFabricante(int idCategoria, int idPiso, int idFabricante)
        {
            return Banco.ListarAtivos().FindAll(p => p.idCategoria == idCategoria && p.idPiso == idPiso && p.idFabricante == idFabricante);
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
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = Banco.ListarAtivos().FindIndex(p => p.idAtivo == item.idAtivo);
            if (index == -1)
            {
                return false;
            }
            Banco.AtualizarAtivo(item);
            return true;
        }

        public bool UpdateDescontinuar(ativos item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = Banco.ListarAtivos().FindIndex(p => p.idAtivo == item.idAtivo);
            if (index == -1)
            {
                return false;
            }
            Banco.DescontinuarAtivo(item);
            return true;
        }

        public bool UpdateCondicao(ativos item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = Banco.ListarAtivos().FindIndex(p => p.idAtivo == item.idAtivo);
            if (index == -1)
            {
                return false;
            }
            Banco.AlterarCondicao(item);
            return true;
        }
    }
}