using backend.src.Modules.SolveReview;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Configuration.AddUserSecrets<Program>();
var connectionString = builder.Configuration.GetConnectionString("CodeRevDB") 
                       ?? throw new InvalidOperationException("Connection string 'CodeRevDB' not found.");

builder.Services.AddSolveReviewModule(connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
    app.UseSwagger();
    // app.MapOpenApi();
}

app.MapControllers();

app.Run();
