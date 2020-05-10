using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_AtivosCeb.Models.Repositorios
{
    public class RepositorioReparos : Interfaces.InterfaceReparos
    {
        public reparos Add(reparos item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            Banco.InserirReparo(item);
            return item;
        }

        public reparos Get(int id)
        {
            return Banco.ListarReparos().Find(p => p.idReparo == id);
        }

        public IEnumerable<reparos> GetAll()
        {
            return Banco.ListarReparos();
        }

        public IEnumerable<reparos> GetReparoAtivo(int idAtivo)
        {
            return Banco.ListarReparos().FindAll(p => p.idAtivo == idAtivo);
        }

        public void Remove(int idReparo)
        {
            //
        }

        public bool Update(reparos item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = Banco.ListarReparos().FindIndex(p => p.idReparo == item.idReparo);
            if (index == -1)
            {
                return false;
            }
            Banco.FinalizarReparo(item);
            return true;
        }
    }
}