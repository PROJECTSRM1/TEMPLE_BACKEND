using TempleAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<WeekEventService>();
builder.Services.AddSingleton<MonthEventService>();
builder.Services.AddSingleton<YearCalendarService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddSingleton<DharshanBookingService>();
builder.Services.AddScoped<IDonationService, DonationService>();
builder.Services.AddSingleton<SpecialDonationService>();
builder.Services.AddSingleton<EventRegistrationService>();
builder.Services.AddSingleton<OfflineDonationService>();
builder.Services.AddSingleton<PoojaBookingService>();
builder.Services.AddSingleton<AnnadanamService>();
builder.Services.AddSingleton<MaalaService>();
builder.Services.AddSingleton<SpecialSevaBookingService>();
builder.Services.AddSingleton<DayEventService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.AllowAnyOrigin()  // you can restrict this later for security
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Enable Swagger only in development
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TempleAPI V1");
        c.RoutePrefix = "swagger";
    });
}
else
{
    // In production, use proper exception handler
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("AllowReactApp");
app.UseAuthorization();
app.MapControllers();

app.Run();
