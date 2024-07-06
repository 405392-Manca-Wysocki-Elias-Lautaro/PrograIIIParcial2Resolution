using Microsoft.EntityFrameworkCore;
using Parcial2.Context;
using Parcial2.Repositories;
using Parcial2.Repositories.Impl;
using Parcial2.Services;
using Parcial2.Services.Impl;
using Parcial2.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ContextDb>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConectionDatabase"));

});

// builder.Services.AddScoped<ContextDb>(provider => provider.GetService<ContextDb>());

builder.Services.AddScoped<IObrasRepository, ObrasRepositoryImpl>();
builder.Services.AddScoped<IObrasService, ObrasServiceImpl>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();