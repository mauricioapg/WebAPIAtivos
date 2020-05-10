using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_AtivosCeb.Models.Interfaces
{
    interface InterfaceReparos
    {
        IEnumerable<reparos> GetAll();
        reparos Get(int id);
        reparos Add(reparos item);
        void Remove(int id);
        bool Update(reparos item);
    }
}
