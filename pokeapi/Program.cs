using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using pokeapi.authentication;
using pokeapi.models;
using pokeapi.resposatory;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;

namespace pokeapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configration = builder.Configuration;
            

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option => {
                option.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme,
                securityScheme: new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "JWT Authorization header using the Bearer scheme."

                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                      new OpenApiSecurityScheme { Reference = new OpenApiReference
                    { Id = "Bearer", Type = ReferenceType.SecurityScheme } }, new List<string>()
                    }
                });
            }
            );
            builder.Services.AddScoped<Iauthservies, Authservies>();
            builder.Services.AddScoped<IOwnerresposator, Ownerresposatory>();
            builder.Services.AddScoped<ICountryresposator, Countryrespository>();
            builder.Services.AddScoped<ICategoryRepository, Categoryresposatory>();
            builder.Services.AddScoped<IPokemonresposator, Pokemonresposatory>();

            builder.Services.AddDbContext<context>(Option =>
           Option.UseSqlServer("Data Source=.;Initial Catalog=poke;Integrated Security=True")
           );


            builder.Services.AddIdentity<Applicationuser,IdentityRole>().
                AddEntityFrameworkStores<context>();



            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true ,
                    ValidateAudience = true ,
                    ValidateLifetime = true ,
                    ValidIssuer = configration["JWT:Issuer"],
                    ValidAudience = configration["JWT:Audince"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configration["JWT:Key"]))
                };
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();   

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}