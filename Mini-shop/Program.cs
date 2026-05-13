using Microsoft.EntityFrameworkCore;
using Mini_shop.DataAccessLayer;

var builder = WebApplication.CreateBuilder(args);

// 1. CORS Siyas?tini T?nziml?
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.WithOrigins("http://localhost:5174", "https://mini-shop.azurewebsites.net") // H?r iki ehtimal? ?lav? etdik
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 2. MÜHÜM: UseCors mütl?q UseAuthorization-dan ?VV?L v? MapControllers-d?n ?VV?L g?lm?lidir
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

// 3. MÜHÜM: app.Run() h?r zaman ?n sonda olmal?d?r!
app.Run();