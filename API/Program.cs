using API.Middlewares;
using BLL.Abstract;
using BLL.Concrete;
using BLL.Mapper;
using DAL.Abstract;
using DAL.Concrete;
using DAL.Context;
using DTO.UserDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using Validation;

var builder = WebApplication.CreateBuilder(args);

ConfigureLogging(builder);

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

ConfigureMiddleware(app);

app.Run();

void ConfigureLogging(WebApplicationBuilder builder)
{
    IConfigurationRoot configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
    Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

    builder.Host.UseSerilog(Log.Logger);
}

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddDbContext<LibraryContext>(options =>
    {
        options.UseSqlServer(configuration.GetConnectionString("LibraryDb"));
    });

    services.AddScoped(typeof(ValidationFilter<>));
    services.AddScoped(typeof(IValidator<>), typeof(GenericValidator<>));
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(ConfigureSwagger);

    RegisterServices(services);

    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                    .GetBytes(configuration.GetSection("AppSettings:Token").Value)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

    services.AddHttpContextAccessor();
    services.AddAutoMapper(typeof(AutoMapperProfiles));
}

void RegisterServices(IServiceCollection services)
{
    services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

    services.AddScoped<IAuthorBookRepository, AuthorBookRepository>();
    services.AddScoped<IAuthorRepository, AuthorRepository>();
    services.AddScoped<IBookRepository, BookRepository>();
    services.AddScoped<ILoanRepository, LoanRepository>();
    services.AddScoped<IMemberRepository, MemberRepository>();
    services.AddScoped<IRoleRepository, RoleRepository>();
    services.AddScoped<IUserRepository, UserRepository>();

    services.AddScoped<IAuthorBookServices, AuthorBookServices>();
    services.AddScoped<IAuthorServices, AuthorServices>();
    services.AddScoped<IAuthServices, AuthServices>();
    services.AddScoped<IBookServices, BookServices>();
    services.AddScoped<ILoanServices, LoanServices>();
    services.AddScoped<IMemberServices, MemberServices>();
    services.AddScoped<IRoleServices, RoleServices>();
    services.AddScoped<IUserServices, UserServices>();
    services.AddScoped<IGenericAuthorService, GenericAuthorService>();
}

void ConfigureSwagger(SwaggerGenOptions options)
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"Bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
}

// Method to configure middleware
void ConfigureMiddleware(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
}
