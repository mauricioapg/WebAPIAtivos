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
    public class FabricanteController : ApiController
    {
        static readonly RepositorioFabricantes repositorio = new RepositorioFabricantes();

        public IEnumerable<fabricantes> GetAllFabricantes()
        {
            return repositorio.GetAll();
        }

        public fabricantes GetFabricantes(int id)
        {
            fabricantes item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public String GetDescricaoFabricante(int idFabricante)
        {
            return repositorio.GetDescFabricantePorId(idFabricante);
        }

        [ActionName("Inserir")]
        public IHttpActionResult PostFabricantes([FromBody]fabricantes item)
        {
            //item = repositorio.Add(item);
            //var response = Request.CreateResponse<fabricantes>(HttpStatusCode.Created, item);

            //string uri = Url.Link("DefaultApi", new { id = item.idFabricante });
            //response.Headers.Location = new Uri(uri);
            //return response;

            fabricantes fabricante = repositorio.GetAll().FirstOrDefault(l => l.idFabricante == item.idFabricante);

            if (fabricante != null)
                return ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.Conflict, "Já existe um fabricante cadastrado com esse ID."));
            else
            {
                repositorio.Add(item);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
            }
        }

        public void PutFabricantes(int id, fabricantes fabricantes)
        {
            fabricantes.idFabricante = id;
            if (!repositorio.Update(fabricantes))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteFabricantes(int id)
        {
            fabricantes item = repositorio.Get(id);

            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repositorio.Remove(id);
        }
    }
}
