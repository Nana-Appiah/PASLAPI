using LivenessAPI.EndPoint;
using LivenessAPI.repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add custom repository to the service collection
builder.Services.AddSingleton<Verification>(new Verification());

//build the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//adding first endpoint
app.MapPost("/api/paslverification/{payLoad}", async (PayLoad payLoad, Verification myRep) => await myRep.LivenessVerificationAsync(payLoad)).WithName("LivenessVerificationAsync");

app.MapPost("/api/GhanaCardVerification/{payLoad}", async (PayLoad payLoad, Verification myRep) => await myRep.LivenessVerificationWithDataAsync(payLoad)).WithName("LivenessVerificationWithDataAsync");

//start the API
app.Run();

