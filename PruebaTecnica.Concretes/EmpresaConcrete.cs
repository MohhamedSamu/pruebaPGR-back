using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaTecnica.Concretes.Contexts;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace PruebaTecnica.Concretes
{
    public class EmpresaConcrete : iEmpresa
    {
        private readonly DatabaseContext _dbContext;

        public EmpresaConcrete(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<EmpresaModel>> GeteEmpresasAsync()
        {
            return await _dbContext.Empresas.ToListAsync();
        }

        public Object NewEmpresa(EmpresaModel empresa)
        {
            return _dbContext.Empresas.AddAsync(empresa); 
        }

        public Object DeleteEmpresa(int empresaId)
        {
            EmpresaModel empresa = new EmpresaModel() { Id = empresaId };
            try
            {
                _dbContext.Empresas.Attach(empresa);
                _dbContext.Empresas.Remove(empresa);
                return _dbContext.SaveChanges();
            }catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                return ex;
            }

        }
    }
}
