
using Microsoft.EntityFrameworkCore;
using Restful_MagicVillaAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDBContext>(option=> {
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
    });
//Adding Content Negotiation for acccepting/denying the xml input and outputv
builder.Services.AddControllers(option=>
                { /*option.ReturnHttpNotAcceptable = true;*/ })
                .AddNewtonsoftJson().AddXmlDataContractSerializerFormatters(); //accepting output xml built in support
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
