using PokemonApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<PokemonService>();
builder.Services.AddControllers();

// Configure localization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
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

// Configure request localization
app.UseRequestLocalization(options =>
{
    options.SetDefaultCulture("es-ES");
    options.AddSupportedCultures("es-ES", "en-US");
    options.AddSupportedUICultures("es-ES", "en-US");
});

app.MapControllers();

app.Run();
