using DNATestingSystem.GrpcService.ThinhLC.Services;
using DNATestingSystem.Services.ThinhLC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddScoped<IServiceProviders, ServiceProviders>();
builder.Services.AddScoped<ISampleThinhLCService, SampleThinhLCService>();
builder.Services.AddScoped<ISampleTypeThinhLCService, SampleTypeThinhLCService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<SampleThinhLCGrpcService>();
app.MapGrpcService<SampleTypeThinhGrpcService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
