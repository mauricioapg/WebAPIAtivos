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
    public class CategoriaController : ApiController
    {
        static readonly RepositorioCategorias repositorio = new RepositorioCategorias();

        public IEnumerable<categorias> GetAllCategorias()
        {
            return repositorio.GetAll();
        }

        public categorias GetCategorias(int id)
        {
            categorias item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public String GetDescricao (int idCategoria)
        {
            return Banco.ObterDescricaoCategorias(idCategoria);
        }

        [ActionName("Inserir")]
        public HttpResponseMessage PostCategorias(categorias item)
        {
            item = repositorio.Add(item);
            var response = Request.CreateResponse<categorias>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.idCategoria });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutCategorias(int id, categorias categorias)
        {
            categorias.idCategoria = id;
            if (!repositorio.Update(categorias))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteCategorias(int idCategoria)
        {
            categorias item = repositorio.Get(idCategoria);

            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repositorio.Remove(idCategoria);
        }
    }
}
