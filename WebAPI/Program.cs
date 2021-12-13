using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Data;
using Data.Repositories;
using Data.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using WebAPI.Extensions;
using WebAPI.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<NotFoundFilter>();

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers(options => { options.Filters.Add(new ValidationFilter()); });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionHandlerExtension();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
