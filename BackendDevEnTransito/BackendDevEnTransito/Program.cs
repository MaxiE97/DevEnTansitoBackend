using BackendDevEnTansito.DevEnTransito.Application.Mappings;
using BackendDevEnTansito.DevEnTransito.Application.Services.Candidate;
using BackendDevEnTansito.DevEnTransito.Application.Services.Company;
using BackendDevEnTansito.DevEnTransito.Application.Services.JobIt;
using BackendDevEnTansito.DevEnTransito.Infrastucture.Data.Context;
using BackendDevEnTansito.DevEnTransito.Infrastucture.Repositories.Candidate;
using BackendDevEnTansito.DevEnTransito.Infrastucture.Repositories.Company;
using BackendDevEnTansito.DevEnTransito.Infrastucture.Repositories.JobIt;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// DB Configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


//AutoMapper Configuration 
builder.Services.AddAutoMapper(typeof(AutoMapperConfigProfile));

// Depencies injections 
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IJobItRepository, JobItRepository>();
builder.Services.AddScoped<IJobItService, JobItService>();
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<ICandidateService, CandidateService>();


//Controllers Configuration
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
