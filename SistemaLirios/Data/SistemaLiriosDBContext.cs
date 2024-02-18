using Microsoft.EntityFrameworkCore;
using SistemaLirios.Data.Map;
using SistemaLirios.Models;

namespace SistemaLirios.Data
{
    public class SistemaLiriosDBContext : DbContext
    {
        public SistemaLiriosDBContext(DbContextOptions<SistemaLiriosDBContext> options) 
            : base(options) 
        { 
        }

        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<GastosModel> Gastos { get; set; }
        public DbSet<OrigemModel> Origem { get; set; }
        public DbSet<PagamentoModel> Pagamento { get; set; }
        public DbSet<PerfilModel> Perfil { get; set; }
        public DbSet<PrestadorModel> Prestador { get; set; }
        public DbSet<ProdutoModel> Produto { get; set; }
        public DbSet<ServicoModel> Servico { get; set; }
        public DbSet<TipoServicoModel> TipoServico { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<VendaModel> Venda { get; set; }
        public DbSet<HistoricoModel> Historico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new VendaMap());
            modelBuilder.ApplyConfiguration(new GastosMap());
            modelBuilder.ApplyConfiguration(new OrigemMap());
            modelBuilder.ApplyConfiguration(new PagamentoMap());
            modelBuilder.ApplyConfiguration(new PrestadorMap());
            modelBuilder.ApplyConfiguration(new ServicoMap());
            modelBuilder.ApplyConfiguration(new TipoServicoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PerfilMap());
            modelBuilder.Entity<HistoricoModel>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
    }
}
