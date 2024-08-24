using FluentValidation;
using MediatR;
using SkateShop.Api.Extensions;
using SkateShop.Api.Filters;
using SkateShop.Application.Commands.Users.Login;
using SkateShop.Application.Queries.TopBarMessages.All;
using SkateShop.Domain.Authentication;
using SkateShop.Domain.Notifications;
using SkateShop.Domain.Repositories;
using SkateShop.Infrastructure;
using SkateShop.Infrastructure.Authentication;
using SkateShop.Infrastructure.Notifications;
using SkateShop.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers(options => options.Filters.Add<NotificationFilter>())
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblies(new[] {
    typeof(GetAllTopBarMessagesQueryHandler).Assembly
}));

builder.Services.AddDbContext<DataContext>();
builder.Services.AddCorsExtension();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<INotificationContext, NotificationContext>();

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PipelineValidationBehavior<,>));
builder.Services.AddTransient<ITopBarMessageRepository, TopBarMessageRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddValidatorsFromAssemblyContaining<LoginUserCommandValidator>();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));

builder.Services.AddAuthenticationExtension(builder.Configuration);
builder.Services.AddSwaggerAuthentication();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("top-bar:getById", policy => policy.RequireClaim("permissions", "top-bar:getById"));
    options.AddPolicy("top-bar:create", policy => policy.RequireClaim("permissions", "top-bar:create"));
    options.AddPolicy("top-bar:update", policy => policy.RequireClaim("permissions", "top-bar:update"));
    options.AddPolicy("top-bar:delete", policy => policy.RequireClaim("permissions", "top-bar:delete"));
});

// Add services to the container.

builder.Services.AddControllers();
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

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
