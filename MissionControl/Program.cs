using ApplicationLayer;
using DomainLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions
.PropertyNamingPolicy = null;
});
builder.Services.AddApplication();
builder.Services.AddScoped<OrderModel>();
builder.Services.AddScoped<OrderRemap>();
builder.Services.AddScoped<MethodModel>();
builder.Services.AddScoped<StandardMethodModel>();
builder.Services.AddScoped<DataModel>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(x => x
         .AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
