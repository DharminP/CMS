
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.Authority = builder.Configuration["Jwt:Authority"];
                o.Audience = builder.Configuration["Jwt:Audience"];
                o.RequireHttpsMetadata = false;
                o.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = c =>
                    {
                        c.NoResult();

                        c.Response.StatusCode = 500;
                        c.Response.ContentType = "text/plain";
                        // if (app.Environment.IsDevelopment())
                        // {
                        //     return c.Response.WriteAsync(c.Exception.ToString());
                        // }
                        return c.Response.WriteAsync("An error occured processing your authentication.");
                    }
                };
            });
builder.Services.AddAuthorization();
// builder.Services.AddAuthorization(options =>
// {
//     options.AddPolicy("Administrator", policy => policy.RequireClaim("user_roles", "[Administrator]"));
// });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IPolicyRepository, PolicyRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyOrigins",
    builder =>
    {
        builder.WithOrigins("http://localhost:4200");
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();

    }
    );
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyOrigins");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller}/{action}/{id?}");
app.MapControllers();

app.Run();
