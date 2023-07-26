using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Data;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;
using Sistema_Marcacao_Clinica_Veterinaria.Services;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sistema_Marcacao_Clinica_Veterinaria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var AllowAllOrigins = "_AllowAllOrigins";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            //builder.Services.AddControllers()
            //    .AddJsonOptions(options => {
            //        options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.Strict;
            //        options.JsonSerializerOptions.UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement;
            //        });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkNpgsql()
                .AddDbContext<MarcacaoClinicaVeterinariaDBContext>(
                    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase"))
                    //,ServiceLifetime.Transient
                );

            builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
            builder.Services.AddScoped<ICirurgiaRepository, CirurgiaRepository>();
            builder.Services.AddScoped<IConsultaRepository, ConsultaRepository>();
            builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            builder.Services.AddScoped<IEspecieRepository, EspecieRepository>();
            builder.Services.AddScoped<IExameRepository, ExameRepository>();
            builder.Services.AddScoped<IMarcacaoRepository, MarcacaoRepository>();
            builder.Services.AddScoped<IMarcacaoServicoRepository, MarcacaoServicoRepository>();
            builder.Services.AddScoped<IProprietarioRepository, ProprietarioRepository>();
            builder.Services.AddScoped<IServicoRepository, ServicoRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IVacinaRepository, VacinaRepository>();
            builder.Services.AddScoped<IVeterinarioRepository, VeterinarioRepository>();

            builder.Services.AddScoped<IAnimalService, AnimalService>();
            builder.Services.AddScoped<ICirurgiaService, CirurgiaService>();
            builder.Services.AddScoped<IConsultaService, ConsultaService>();
            builder.Services.AddScoped<IEnderecoService, EnderecoService>();
            builder.Services.AddScoped<IEspecieService, EspecieService>();
            builder.Services.AddScoped<IExameService, ExameService>();
            builder.Services.AddScoped<IMarcacaoService, MarcacaoService>();
            builder.Services.AddScoped<IMarcacaoServicoService, MarcacaoServicoService>();
            builder.Services.AddScoped<IProprietarioService, ProprietarioService>();
            builder.Services.AddScoped<IServicoService, ServicoService>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<IVacinaService, VacinaService>();
            builder.Services.AddScoped<IVeterinarioService, VeterinarioService>();


            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: AllowAllOrigins,
                                  policy =>
                                  {
                                      policy
                                      .WithOrigins("http://localhost:4200")
                                      .AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader();
                                  });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(AllowAllOrigins);

            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();


            app.Run();
        }
    }
}