using EstoreAdminModel.Services;
using EStoreAdminRepository;
using EstoreAdminService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//it will try to collect all controller in a Project and Create an Instance
//holded in Builder.Sevice Collection Class.
builder.Services.AddControllersWithViews();


///IOC (Inversion of Control) is a concept will try to create an Object and
///holded in the ServiceCollection Object
builder.Services.Add(new ServiceDescriptor(
    typeof(IBrandService),
    typeof(BrandService),
    ServiceLifetime.Transient));

builder.Services.Add(new ServiceDescriptor(
    typeof(ITypeService),
    typeof(TypeService),
    ServiceLifetime.Transient));

string? _connectionString = 
    builder.Configuration.GetConnectionString("EstoreConnection");

builder.Services.AddDbContext<BrandRepository>(options =>
{
    options.UseSqlServer(_connectionString);
});

builder.Services.AddDbContext<TypeRepository>(options =>
{
    options.UseSqlServer(_connectionString);
});


var app = builder.Build();

app.UseStaticFiles();

///Pre Defined Middlewares
app.UseRouting();
app.MapControllers();

app.Run();
