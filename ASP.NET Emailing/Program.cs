using EmailService;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// we add our services
var emailConfig = builder.Configuration
        .GetSection("EmailConfiguration")
        .Get<EmailConfiguration>();

builder.Services.AddSingleton(emailConfig);

builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//disable limits for file upload
builder.Services.Configure<FormOptions>(o => {
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapGet("/sendEmail", ([FromServices] IEmailSender emailSender, string email) =>
{
    var message = new Message(new string[] { email }, "Test email", "This is the content from our email.");
    emailSender.SendEmail(message);

    return Results.Ok();
})
.WithName("SendEmail");

app.MapGet("/sendEmailAsync", ([FromServices] IEmailSender emailSender, string email) =>
{
    var message = new Message(new string[] { email }, "Test email", "This is the content from our async email.");
    emailSender.SendEmailAsync(message);

    return Results.Ok();
})
.WithName("SendEmailAsync");

app.MapPost("/sendEmailWithFile", async ([FromServices] IEmailSender emailSender, [FromServices] IHttpContextAccessor httpContext, string email) =>
{
    var files = httpContext.HttpContext.Request.Form.Files.Any() ? httpContext.HttpContext.Request.Form.Files : new FormFileCollection();

    var message = new Message(new string[] { email }, "Test email", "This is the content from our async email.", files);
    await emailSender.SendEmailAsync(message);

    return Results.Ok();
})
.WithName("SendEmailWithFile");

app.Run();
