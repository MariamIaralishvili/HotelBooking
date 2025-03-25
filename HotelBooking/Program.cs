using System.Text;
using HotelBooking.Core.DBContexti;
using HotelBooking.Core.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Domain.Mapper;
using HotelBooking.Domain.Services;
using HotelBooking.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HotelBookingContext>(
    str => { str.UseSqlServer(builder.Configuration.GetConnectionString("HotelBookingDB")); }
    );

builder.Services.AddControllers();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "Www.BookingHotel.com",
        ValidAudience = "Www.BookingHotel.com",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("kHBajhuwuqdjkdfjdfjdfhjdhdf")),
        ClockSkew = TimeSpan.Zero,
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelBooking", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
         {
     {
         new OpenApiSecurityScheme
         {
             Reference = new OpenApiReference
             {
                 Type = ReferenceType.SecurityScheme,
                 Id = "Bearer"
             }
         },
         new string[] {}
     }
         });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
builder.Services.AddScoped<ICityRepository, CitiesRepository>();
builder.Services.AddScoped<IHotelRepository, HotelsRepository>();
builder.Services.AddScoped<IBookedRoomRepository, BookedRoomsRepository>();
builder.Services.AddScoped<IFavoriteRepository, FavoritesRepository>();
builder.Services.AddScoped<IRoomRepository, RoomsRepository>();
builder.Services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
builder.Services.AddScoped<IUserRepository, UsersRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IBookedRoomService, BookedRoomService>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IRoomTypeService, RoomTypeService>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddAutoMapper(typeof(Mapperi));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
