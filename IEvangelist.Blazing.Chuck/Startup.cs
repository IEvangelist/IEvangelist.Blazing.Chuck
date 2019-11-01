using IEvangelist.Blazing.Chuck.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IEvangelist.Blazing.Chuck
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddTransient<IJokeService, ChuckNorrisJokeService>();
            services.AddHttpClient(nameof(ChuckNorrisJokeService),
                client => client.DefaultRequestHeaders.Add("Accept", "application/json"));
            services.AddCors(
                options =>
                    options.AddDefaultPolicy(
                        builder =>
                            builder.AllowAnyOrigin()
                                   .AllowAnyMethod()
                                   .AllowAnyHeader()
                                   .AllowCredentials()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection()
               .UseStaticFiles()
               .UseRouting()
               .UseEndpoints(endpoints =>
               {
                   endpoints.MapBlazorHub();
                   endpoints.MapFallbackToPage("/_Host");
               });
        }
    }
}