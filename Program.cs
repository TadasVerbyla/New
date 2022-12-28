using Point_of_Sale_Lab3.DB;
using Point_of_Sale_Lab3.ModelData.PaymentData;
using Microsoft.EntityFrameworkCore;
using Point_of_Sale_Lab3.ModelData.BusinessData;
using Point_of_Sale_Lab3.ModelData.CustomerData;
using Point_of_Sale_Lab3.ModelData.DiscountData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddSingleton<ICheckoutData, MockCheckoutData>();
builder.Services.AddDbContextPool<PointOfSaleContext>
    (options => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=PointOfSaleSystem;Trusted_Connection=True"));

//Services to add
builder.Services.AddScoped<IBusinessData, SqlBusinessData>();
builder.Services.AddScoped<ICustomerData, SqlCustomerData>();
builder.Services.AddScoped<IDiscountData, SqlDiscountData>();
builder.Services.AddScoped<IPaymentData, SqlPaymentData>();


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
