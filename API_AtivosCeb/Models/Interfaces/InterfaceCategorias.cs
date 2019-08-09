using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_AtivosCeb.Models.Interfaces
{
    interface InterfaceCategorias
    {
        IEnumerable<categorias> GetAll();
        categorias Get(int id);
        categorias Add(categorias item);
        void Remove(int id);
        bool Update(categorias item);
    }
}
