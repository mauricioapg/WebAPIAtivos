using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_AtivosCeb.Models.Interfaces
{
    interface InterfaceLocais
    {
        IEnumerable<locais> GetAll();
        locais Get(int id);
        locais Add(locais item);
        void Remove(int id);
        bool Update(locais item);
    }
}
