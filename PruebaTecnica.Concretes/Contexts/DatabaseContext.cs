using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using PruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnica.Concretes.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<EmpresaModel> Empresas { get; set; }

    }
}
