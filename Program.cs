using Point_of_Sale_Lab3.DB;
using Point_of_Sale_Lab3.ModelData.CheckoutData;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddSingleton<ICheckoutData, MockCheckoutData>();
builder.Services.AddDbContextPool<PointOfSaleContext>(options => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=PointOfSaleSystem;Trusted_Connection=True"));
builder.Services.AddScoped<ICheckoutData, SqlCheckoutData>();

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
