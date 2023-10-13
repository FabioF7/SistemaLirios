using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaLirios.Data.Map;
using SistemaLirios.Models;

namespace SistemaLirios.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class SistemaLiriosDBContext : DbContext
    {
        public SistemaLiriosDBContext(DbContextOptions<SistemaLiriosDBContext> options) 
            : base(options) 
        { 
        }

        public DbSet<ProdutoModel> Produto { get; set; }
        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<VendaModel> Venda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new VendaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
