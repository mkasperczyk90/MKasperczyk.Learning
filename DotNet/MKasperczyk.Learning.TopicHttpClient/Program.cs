using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MKasperczyk.Learning.TopicHttpClient;
using MKasperczyk.Learning.TopicHttpClient.Constants;
using MKasperczyk.Learning.TopicHttpClient.Extensions;
using Polly;

var builder = WebApplication.CreateBuilder(args);
// To understand what's the best solution go to README.md

// first
builder.Services.AddScoped<IGitFirstClient, GitFirstClient>();

// secound
builder.Services.AddScoped<IGitSecondClient, GitSecondClient>();

// third
builder.Services.AddScoped<IGitThirdClient, GitThirdClient>();
builder.Services.AddHttpClient<IGitThirdClient, GitThirdClient>(client => client.SetUpClient());

// fourth
builder.Services.AddScoped<IGitFourthClient, GitFourthClient>();
builder.Services.AddHttpClient("githubapi", client => client.SetUpClient());

// fifth
builder.Services.AddScoped<IGitFifthClient, GitFifthClient>();
builder.Services.AddHttpClient("githubapiwithPolly", client => client.SetUpClient())
    .AddPolicyHandler(Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode).RetryAsync(3));




var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/firstVersion", async ([FromServices] IGitFirstClient client) => await client.GetAsync());
app.MapGet("/secoundVersion", async ([FromServices] IGitSecondClient client) => await client.GetAsync());
app.MapGet("/thirdVersion", async ([FromServices] IGitThirdClient client) => await client.GetAsync());
app.MapGet("/fourthVersion", async ([FromServices] IGitFourthClient client) => await client.GetAsync());
app.MapGet("/fifthVersion", async ([FromServices] IGitFifthClient client) => await client.GetAsync());


app.Run();
