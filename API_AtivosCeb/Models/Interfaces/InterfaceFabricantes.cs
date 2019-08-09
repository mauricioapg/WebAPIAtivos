using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_AtivosCeb.Models.Interfaces
{
    interface InterfaceFabricantes
    {
        IEnumerable<fabricantes> GetAll();
        fabricantes Get(int id);
        fabricantes Add(fabricantes item);
        void Remove(int id);
        bool Update(fabricantes item);
    }
}
