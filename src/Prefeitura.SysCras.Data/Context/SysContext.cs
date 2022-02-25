using Microsoft.EntityFrameworkCore;
using Prefeitura.SysCras.Business.Entities;

namespace Prefeitura.SysCras.Data.Context
{
    public class SysContext : DbContext
    {
        public SysContext(DbContextOptions<SysContext> options) : base(options) 
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<AssuntoAtendimento> AssuntoAtendimentos { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<TipoAtendimento> TiposAtendimentos { get; set; }
        public DbSet<Cidadao> Cidadaos { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Resolve o mapeametno no DbContext
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SysContext).Assembly);

            

            base.OnModelCreating(modelBuilder);
        }
    }
 
}
