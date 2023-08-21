using System.Text;
using Hotel.DatabaseContext;
using Hotel.Services;
using Hotel.Services.EmailService;
using Hotel.Services.PasswordService;
using Hotel.Services.RoomService;
using HotelApp.Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .AddJsonFile("appsetting.Enviroment.json",
        optional: true,
        reloadOnChange: true);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        
    }).AddCookie(x=>
    {
        x.Cookie.Name = "token";
    }).AddJwtBearer(x=>
    {
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
    x.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            context.Token = context.Request.Cookies["token"];
            return Task.CompletedTask;
        }
    };

});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableSensitiveDataLogging();
});
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
// builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();



builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    
    options.IdleTimeout = TimeSpan.FromMinutes(3);
}
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(cors =>
{
    cors.
        AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSession();

app.UseAuthentication();

app.MapControllers();

app.Run();