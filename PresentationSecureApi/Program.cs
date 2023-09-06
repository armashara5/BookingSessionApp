using InfrastructureLayer;
using ApplicationLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(builder =>
//    {
//        builder.AllowAnyOrigin()
//               .AllowAnyHeader()
//               .AllowAnyMethod();
//    });
//});

// Add services to the container.
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificOrigin",
//        //builder => builder.WithOrigins("https://localhost:7121")
//        builder => builder.WithOrigins("http://localhost:5173")
//            .AllowAnyHeader()
//            .AllowAnyMethod()
//            .AllowCredentials());
//});
builder.Services.AddCors();
var configuration = builder.Configuration;
builder.Services.AddSingleton(configuration);
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<InfrastructureDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("PresentationSecureApi")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<InfrastructureDbContext>();


// Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.IncludeErrorDetails = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
            ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value))
        };
    });

// Authorization
builder.Services.AddAuthorization();


builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
//});
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseCors(options =>
options.WithOrigins("http://localhost:5173")
.AllowAnyHeader()
.AllowAnyMethod()
        .WithHeaders("Authorization", "Content-Type", "access-control-allow-origin")
        .AllowCredentials()
        .WithExposedHeaders("Authorization"));

//app.UseCors("AllowSpecificOrigin");

//app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
