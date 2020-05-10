using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using API_AtivosCeb.Models;
using API_AtivosCeb.Models.Repositorios;
using AutoMapper;
using JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API_AtivosCeb.Controllers
{
    public class AtivoController : ApiController
    {
        static readonly RepositorioAtivos repositorio = new RepositorioAtivos();
        IMapper mapper;

        public IEnumerable<ativos> GetAllAtivos()
        {
            return repositorio.GetAll();
        }

        public ativos GetAtivos(int id)
        {
            ativos item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<ativos> GetAtivosCondicao(string condicao)
        {
            return repositorio.GetCondicao(condicao);
        }

        public IEnumerable<ativos> GetAtivosLocal(int idLocal)
        {
            return repositorio.GetLocal(idLocal);
        }

        public IEnumerable<ativos> GetAtivosPiso(int idPiso)
        {
            return repositorio.GetPiso(idPiso);
        }

        public IEnumerable<ativos> GetAtivosFabricante(int idFabricante)
        {
            return repositorio.GetFabricante(idFabricante);
        }

        public IEnumerable<ativos> GetAtivosCategoria(int idCategoria)
        {
            return repositorio.GetCategoria(idCategoria);
        }

        public IEnumerable<ativos> GetAtivosPisoCategoria(int idPiso, int idCategoria)
        {
            return repositorio.GetPisoCategoria(idPiso, idCategoria);
        }

        public IEnumerable<ativos> GetAtivosCategoriaFabricante(int idCategoria, int idFabricante)
        {
            return repositorio.GetCategoriaFabricante(idCategoria, idFabricante);
        }

        public IEnumerable<ativos> GetAtivosCategoriaPisoFabricante(int idCategoria, int idPiso, int idFabricante)
        {
            return repositorio.GetCategoriaPisoFabricante(idCategoria, idPiso, idFabricante);
        }

        public ativos GetAtivosPatrimonio(int patrimonio)
        {
            ativos item = repositorio.GetPatrimonio(patrimonio);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public ativos GetAtivosNumeroSerie(string numeroSerie)
        {
            ativos item = repositorio.GetNumeroSerie(numeroSerie);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public ativos GetAtivosServiceTag(string serviceTag)
        {
            ativos item = repositorio.GetServiceTag(serviceTag);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        [System.Web.Http.ActionName("Inserir")]
        public HttpResponseMessage PostAtivos(ativos item)
        {
            item = repositorio.Add(item);
            var response = Request.CreateResponse<ativos>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.idAtivo });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        //[System.Web.Http.Route("api/ativo/PutAtivos")]
        [System.Web.Http.ActionName("PutAtivos")]
        [System.Web.Http.HttpPut]
        public String PutAtivos(int id, ativos item)
        {
            item.idAtivo = id;
            if (!repositorio.Update(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return "Atualizado";
        }

        //[System.Web.Http.Route("api/ativo/PutDescontinuarAtivos")]
        [System.Web.Http.ActionName("PutDescontinuarAtivos")]
        [System.Web.Http.HttpPut]
        public String PutDescontinuarAtivos(int id, ativos item)
        {
            item.idAtivo = id;
            if (!repositorio.UpdateDescontinuar(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return "Atualizado";
        }

        public String PatchCondicaoAtivos(int id, ativos item)
        {
            item.idAtivo = id;
            if (!repositorio.UpdateCondicao(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return "Atualizado";
        }

        public void DeleteAtivos(int id)
        {
            ativos item = repositorio.Get(id);

            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repositorio.Remove(id);
        }
    }
}
