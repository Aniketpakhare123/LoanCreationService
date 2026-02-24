using LoanTable.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using LoanTable.Application.Mapping;
using LoanTable.Application.Interfaces;
using LoanTable.Infrastructure.Repository;
using LoanTable.Application.DTO;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddScoped<ILoanRepo, LoanAccountService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
      options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<OriginationClient>(client =>
{
  client.BaseAddress = new Uri(builder.Configuration["OriginationAddress"] ?? "https://loanoriginations-f4bvd8g4h8agadac.canadacentral-01.azurewebsites.net");
});

builder.Services.AddHttpClient<SanctionClient>(client =>
{
  client.BaseAddress = new Uri(builder.Configuration["SanctionAddress"] ?? "https://sanctionanddisbursement-g0b3efeaemhyaygn.canadacentral-01.azurewebsites.net");
});

builder.Services.AddDbContext<ApplicationDbContext>(
    Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn"))
  );

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
