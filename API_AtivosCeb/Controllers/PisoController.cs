using API_AtivosCeb.Models;
using API_AtivosCeb.Models.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_AtivosCeb.Controllers
{
    public class PisoController : ApiController
    {
        static readonly RepositorioPisos repositorio = new RepositorioPisos();

        public IEnumerable<pisos> GetAllPisos()
        {
            return repositorio.GetAll();
        }

        public pisos GetPisos(int id)
        {
            pisos item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public String GetDescricaoPiso(int idPiso)
        {
            return repositorio.GetDescPisoPorId(idPiso);
        }

        [ActionName("Inserir")]
        public HttpResponseMessage PostPisos(pisos item)
        {
            item = repositorio.Add(item);
            var response = Request.CreateResponse<pisos>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.idPiso });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutPisos(int id, pisos pisos)
        {
            pisos.idPiso = id;
            if (!repositorio.Update(pisos))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeletePisos(int id)
        {
            pisos item = repositorio.Get(id);

            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repositorio.Remove(id);
        }
    }
}
