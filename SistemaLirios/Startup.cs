﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SistemaLirios.Data;
using SistemaLirios.Repository;
using SistemaLirios.Repository.Interfaces;
using System.Text;

namespace SistemaLirios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<SistemaLiriosDBContext>(
                options => options.UseNpgsql(Configuration.GetConnectionString("DataBase")),
                ServiceLifetime.Scoped
            );

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IGastosRepository, GastosRepository>();
            services.AddScoped<IOrigemRepository, OrigemRepository>();
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IPrestadorRepository, PrestadorRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IServicoRepository, ServicoRepository>();
            services.AddScoped<ITipoServicoRepository, TipoServicoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped<IRelatorioRepository, RelatorioRepository>();
            services.AddScoped<IInventarioRepository, InventarioRepository>();
            services.AddScoped<IInventarioDetallhesRepository, InventarioDetallhesRepository>();

            services.AddSwaggerGen();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("Chave_JWT")["CHAVE_SECRETA_JWT"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
