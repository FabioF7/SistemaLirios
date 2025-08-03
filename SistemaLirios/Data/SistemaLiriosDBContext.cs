using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaLirios.Data.Map;
using SistemaLirios.Models;
using System;

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
        public DbSet<InventarioDetalhesModel> InventarioDetalhes { get; set; }
        public DbSet<InventarioModel> Inventario { get; set; }

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
            modelBuilder.ApplyConfiguration(new InventarioMap());
            modelBuilder.ApplyConfiguration(new InventarioDetalhesMap());
            modelBuilder.Entity<HistoricoModel>().HasNoKey();

            // Converter datas para UTC ao salvar
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                    {
                        property.SetValueConverter(new DateTimeConverter());
                    }
                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }

    // Classe auxiliar para converter datas para UTC
    internal class DateTimeConverter : ValueConverter<DateTime, DateTime>
    {
        public DateTimeConverter() : base(
            v => v.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(v, DateTimeKind.Utc) : v.ToUniversalTime(),
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
        {
        }
    }
}