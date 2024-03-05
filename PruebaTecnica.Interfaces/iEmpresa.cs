using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Interfaces
{
    public interface iEmpresa
    {
        Task<List<EmpresaModel>> GeteEmpresasAsync();

        Object NewEmpresa(EmpresaModel empresa);
        Object DeleteEmpresa(int empresaId);
        
    }
}
