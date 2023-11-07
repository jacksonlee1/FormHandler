using FileService;
using Microsoft.AspNetCore.Http.Features;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var emailConfig = builder.Configuration
        .GetSection("EmailConfiguration")
        .Get<EmailConfiguration>();
// var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddSingleton(emailConfig ?? new EmailConfiguration());

  builder.Services.AddScoped<IEmailSender, EmailSender>();

  builder.Services.AddScoped<IFileUploader,FileUploader>();

            builder.Services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

//             builder.Services.AddCors(options =>
// {
//     options.AddDefaultPolicy(
//                       policy  =>
//                       {
//                           policy.WithOrigins("http://192.168.1.67",
//                                               "http://netbuildit.xyz")
//                                               .AllowAnyHeader()
//                                               .AllowAnyMethod();
//                       });
// });

    
builder.Services.AddControllers();
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

app.MapControllers();

app.Run();
