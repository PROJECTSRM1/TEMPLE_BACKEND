using OfflineDonationsAPI.Services;
using TempleAPI.Services;
using OfflineDonationsAPI.Services;
//using TempleCalendarAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddSingleton<WeekEventService>();
builder.Services.AddSingleton<MonthEventService>();
builder.Services.AddSingleton<YearEventService>();
// Add custom service
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddSingleton<DharshanBookingService>();
builder.Services.AddScoped<IDonationService, DonationService>();
builder.Services.AddSingleton<SpecialDonationService>();
builder.Services.AddSingleton<EventRegistrationService>();
builder.Services.AddSingleton<TempleAPI.Services.SpecialSevaService>();
builder.Services.AddSingleton<IOfflineDonationService, OfflineDonationService>();
builder.Services.AddSingleton<IPoojaBookingService, PoojaBookingService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<DayEventService>();

// Enable Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enable CORS for React frontend
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Middleware
app.UseStaticFiles();
app.UseCors();
app.UseAuthorization();
app.MapControllers();

// Enable Swagger UI in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TempleAPI V1");
        c.RoutePrefix = "swagger";
    });
}

app.Run();
