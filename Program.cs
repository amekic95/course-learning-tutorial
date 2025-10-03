using course_learning_tutorial.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using course_learning_tutorial.Repositories;
using course_learning_tutorial.Services;
using Microsoft.EntityFrameworkCore;
using course_learning_tutorial.MinimalApis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddValidatorsFromAssemblyContaining<course_learning_tutorial.Data.Validators.CreateCourseRequestValidator>();

//Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Logging.SetMinimumLevel(LogLevel.Information);

var app = builder.Build();

app.MapCourseEndpoints();
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
