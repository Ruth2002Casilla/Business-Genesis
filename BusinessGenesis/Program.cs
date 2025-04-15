using BusinessGenesis.Components;
using BusinessGenesis.DAL;
using BusinessGenesis.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddDbContext<GenesisContex>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ConStr")));

builder.Services.AddScoped<ActividadesClavesServices>();
builder.Services.AddScoped<AliadosClaveService>();
builder.Services.AddScoped<CanalServices>();
builder.Services.AddScoped<EmpresaServices>();
builder.Services.AddScoped<EstructuraDeCostoServices>();
builder.Services.AddScoped<FuenteDeIngresoServices>();
builder.Services.AddScoped<NegocioServices>();
builder.Services.AddScoped<PropuestaValorServices>();
builder.Services.AddScoped<RecursosClaveServices>();
builder.Services.AddScoped<RelacionConClienteServices>();
builder.Services.AddScoped<SegmentoClienteServices>();
builder.Services.AddScoped<TipoProductoServices>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
