using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_AtivosCeb.Models.Interfaces
{
    interface InterfaceLogs
    {
        IEnumerable<logs> GetAll();
        logs Get(int id);
        logs Add(logs item);
        void Remove(int id);
        bool Update(logs item);
    }
}
