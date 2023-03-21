using GraphQLExample.Infra;
using GraphQLExampleAPI;
using GraphQLExampleAPI.Mutations;
using GraphQLExampleAPI.Queries;
using GraphQLExampleAPI.Types;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Web.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//builder.Services.AddMvc(option => option.EnableEndpointRouting = false)
//               .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
//               .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
builder.Services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
builder.Services.AddTransient<UserRepository, UserRepository>();
builder.Services.AddScoped<BlogSchema>();
builder.Services.AddScoped<BlogQuery>();
builder.Services.AddScoped<BlogMutation>();
builder.Services.AddScoped<UserType>();
builder.Services.AddScoped<UserInputType>();
//builder.Services.AddDbContext<GraphQLContext>(opcoes => opcoes.UseInMemoryDatabase(databaseName: "Blog"));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
            {
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<GraphQLContext>();

    DbGenerator.Iniciar(services);
}


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
