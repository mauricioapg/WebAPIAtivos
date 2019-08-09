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
    public class LocalController : ApiController
    {
        static readonly RepositorioLocais repositorio = new RepositorioLocais();

        public IEnumerable<locais> GetAllLocais()
        {
            return repositorio.GetAll();
        }

        public locais GetLocais(int id)
        {
            locais item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        [ActionName("Inserir")]
        public HttpResponseMessage PostLocais(locais item)
        {
            item = repositorio.Add(item);
            var response = Request.CreateResponse<locais>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.idLocal });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutLocais(int id, locais locais)
        {
            locais.idLocal = id;
            if (!repositorio.Update(locais))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteLocais(int id)
        {
            locais item = repositorio.Get(id);

            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repositorio.Remove(id);
        }
    }
}
