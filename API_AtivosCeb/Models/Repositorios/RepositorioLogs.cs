using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_AtivosCeb.Models.Repositorios
{
    public class RepositorioLogs : Interfaces.InterfaceLogs
    {
        public logs Add(logs item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            Banco.InserirLog(item);
            return item;
        }

        public logs Get(int id)
        {
            return Banco.ListarLogs().Find(p => p.idLogs == id);
        }

        public IEnumerable<logs> GetAll()
        {
            return Banco.ListarLogs();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(logs item)
        {
            throw new NotImplementedException();
        }
    }
}