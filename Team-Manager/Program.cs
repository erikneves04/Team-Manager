using Microsoft.EntityFrameworkCore;
using Team_Manager.Data;
using Team_Manager.Domain.Interfaces.Services;
using Team_Manager.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TeamManagerContext>(options =>
                options.UseSqlServer(ConnectionString));

builder.Services.AddScoped<ITeamServices, TeamServices>();
builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
