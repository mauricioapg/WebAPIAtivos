using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_AtivosCeb.Models.Interfaces
{
    interface InterfacePisos
    {
        IEnumerable<pisos> GetAll();
        pisos Get(int id);
        pisos Add(pisos item);
        void Remove(int id);
        bool Update(pisos item);
    }
}
