using Point_of_Sale_Lab3.DB;
using Microsoft.EntityFrameworkCore;
using Point_of_Sale_Lab3.ModelData.PaymentData;
using Point_of_Sale_Lab3.ModelData.BusinessData;
using Point_of_Sale_Lab3.ModelData.CustomerData;
using Point_of_Sale_Lab3.ModelData.DiscountData;
using Point_of_Sale_Lab3.ModelData.EmployeeData;
using Point_of_Sale_Lab3.ModelData.ItemData;
using Point_of_Sale_Lab3.ModelData.OrderData;
using Point_of_Sale_Lab3.ModelData.PermissionData;
using Point_of_Sale_Lab3.ModelData.ShiftData;
using Point_of_Sale_Lab3.ModelData.SupportRequestData;
using Microsoft.AspNetCore.Mvc;

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
builder.Services.AddScoped<IEmployeeData, SqlEmployeeData>();
builder.Services.AddScoped<IItemData, SqlItemData>();
builder.Services.AddScoped<IOrderData, SqlOrderData>();
builder.Services.AddScoped<IPaymentData, SqlPaymentData>();
builder.Services.AddScoped<IPermissionData, SqlPermissionData>();
builder.Services.AddScoped<IShiftData, SqlShiftData>();
builder.Services.AddScoped<ISupportRequestData, SqlSupportRequestData>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


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
