using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_AtivosCeb.Models;
using API_AtivosCeb.Models.Repositorios;

namespace API_AtivosCeb.Controllers
{
    public class AtivoController : ApiController
    {
        static readonly RepositorioAtivos repositorio = new RepositorioAtivos();

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

        public ativos GetAtivosPatrimonio(int patrimonio)
        {
            ativos item = repositorio.GetPatrimonio(patrimonio);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        [ActionName("Inserir")]
        public HttpResponseMessage PostAtivos(ativos item)
        {
            item = repositorio.Add(item);
            var response = Request.CreateResponse<ativos>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.idAtivo });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutAtivos(int id, ativos ativos)
        {
            ativos.idAtivo = id;
            if (!repositorio.Update(ativos))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
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
