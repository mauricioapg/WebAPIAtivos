using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_AtivosCeb.Models.Interfaces
{
    interface InterfaceAtivos
    {
        IEnumerable<ativos> GetAll();
        ativos Get(int id);
        ativos Add(ativos item);
        void Remove(int id);
        bool Update(ativos item);
    }
}
