using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Repositories.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<AccountRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<TabunganRepository>();
builder.Services.AddScoped<PengajuanRepository>();
builder.Services.AddScoped<SimpananRepository>();
builder.Services.AddScoped<PinjamanRepository>();
builder.Services.AddScoped<AngsuranRepository>();
builder.Services.AddScoped<JenisPinjamanRepository>();
builder.Services.AddScoped<JenisSimpananRepository>();
builder.Services.AddDbContext<MyContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"));

});

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});


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
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
