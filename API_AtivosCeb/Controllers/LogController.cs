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
    public class LogController : ApiController
    {
        static readonly RepositorioLogs repositorio = new RepositorioLogs();

        public IEnumerable<logs> GetAllReparos()
        {
            return repositorio.GetAll();
        }

        public logs GetLogs(int id)
        {
            logs item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        [ActionName("Inserir")]
        public HttpResponseMessage PostLogs(logs item)
        {
            item = repositorio.Add(item);
            var response = Request.CreateResponse<logs>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.idLogs });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutLogs()
        {
            
        }

        public void DeleteLogs(int id)
        {
            
        }
    }
}
