using Microsoft.EntityFrameworkCore;
using odbYP3_2024.Data;
using System;

namespace odbYP3_2024
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Добавляем файл конфигурации OdbConnection.json
            builder.Configuration.AddJsonFile("Data/config/OdbConnection.json", optional: false, reloadOnChange: true);

            // Добавляем DbContext с использованием строки подключения из OdbConnection.json
            builder.Services.AddDbContext<OdbYp32024Context>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Добавляем контроллеры
            builder.Services.AddControllers();

            // Настройка OpenAPI
            builder.Services.AddOpenApi();

            // Регистрация Swagger
            builder.Services.AddSwaggerGen();

            // Регистрация CORS для скачивание с помощью Swagger
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()   // Разрешить запросы с любых источников
                          .AllowAnyHeader()   // Разрешить любые заголовки
                          .AllowAnyMethod();  // Разрешить любые методы (GET, POST и т.д.)
                });
            });

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Конфигурация HTTP-конвейера | Включение Swagger
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
                    c.RoutePrefix = string.Empty; // Делает Swagger корневой страницей
                });

                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
