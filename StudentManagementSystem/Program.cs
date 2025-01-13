using BLL.Helper;
using BLL.IService;
using BLL.Service;
using DAL.DBContext;
using DAL.Entities;
using DAL.IRepo;
using DAL.Repo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using BLL;
using DAL;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().
    AddEntityFrameworkStores<ApplicationDBContext>();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


//service


//builder.Services.AddScoped<IAuthService, AuthService>();
//builder.Services.AddScoped<IStudentService, StudentService>();
//builder.Services.AddScoped<ISupjectService, SubjectService>();
//builder.Services.AddScoped<IStudentSujectService, StudentSubjectService>();
//builder.Services.AddScoped<IStudentSubjectGradeService, StudentSubjectGradeService>();
builder.Services.service1();



//Repo
//builder.Services.AddScoped<IStudentRepo, StudentRepo>();
//builder.Services.AddScoped<ISubjectRepo, SupjectRepo>();
//builder.Services.AddScoped<IStudentSubjectRepo, StudentSubjectRepo>();
//builder.Services.AddScoped<IStudentSubjectGrades, StudentSubjectGradeRepo>();
builder.Services.service2();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;
        o.SaveToken = false;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["JWT:Issure"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            ClockSkew = TimeSpan.Zero
        };
    });
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "StudentManagementSystem", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseExceptionHandler("/error"); // مسار مخصص للأخطاء
app.UseHsts();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseCors("AllowAll"); 
app.UseAuthorization();
app.MapControllers();

app.Run();