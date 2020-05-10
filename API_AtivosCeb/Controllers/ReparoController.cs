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
using JsonPatch;

namespace API_AtivosCeb.Controllers
{
    public class ReparoController : ApiController
    {
        static readonly RepositorioReparos repositorio = new RepositorioReparos();

        public IEnumerable<reparos> GetAllReparos()
        {
            return repositorio.GetAll();
        }

        public reparos GetReparos(int id)
        {
            reparos item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<reparos> GetReparosAtivo(int idAtivo)
        {
            return repositorio.GetReparoAtivo(idAtivo);
        }

        [System.Web.Http.ActionName("Inserir")]
        public HttpResponseMessage PostReparos(reparos item)
        {
            item = repositorio.Add(item);
            var response = Request.CreateResponse<reparos>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.idReparo });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutReparos(int id, reparos reparos)
        {
            reparos.idReparo = id;
            if (!repositorio.Update(reparos))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public String PatchFinalizaReparo(int id, reparos item)
        {
            item.idReparo = id;
            if (!repositorio.Update(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return "Atualizado";
        }

        public void DeleteReparos(int id)
        {
            reparos item = repositorio.Get(id);

            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repositorio.Remove(id);
        }
    }
}
