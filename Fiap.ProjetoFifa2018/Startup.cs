using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.ProjetoFifa2018.Aplicacao.Grupos;
using Fiap.ProjetoFifa2018.Dominio.Repositorios;
using Fiap.ProjetoFifa2018.Persistencia.Contexto;
using Fiap.ProjetoFifa2018.Persistencia.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace Fiap.ProjetoFifa2018
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.Configure<GzipCompressionProviderOptions>(
              o => o.Level = System.IO.Compression.CompressionLevel.Fastest);

            services.AddTransient<ITorneioRepositorio, TorneioRepositorio>();
            services.AddTransient<ITimeRepositorio, TimeRepositorio>();
            services.AddTransient<IJogadorRepositorio, JogadorRepositorio>();

            services.AddScoped<IServicoGrupo, ServicoGrupo>();

            services.AddResponseCompression(o =>
            {
                o.Providers.Add<GzipCompressionProvider>();
            });

            var connection = @"Server=(localdb)\mssqllocaldb;Database=ProjetoFifa2018;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<CopaContexto>
                (options => options.UseSqlServer(connection));

            services.AddAuthentication("app")
                .AddCookie("app",
                o =>
                {
                    o.LoginPath = "/account/index";
                    o.AccessDeniedPath = "/account/denied";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseAuthentication();

            app.UseResponseCompression();

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    const int durationInSeconds = 60 * 60 * 24;
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] =
                        "public,max-age=" + durationInSeconds;
                }
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
