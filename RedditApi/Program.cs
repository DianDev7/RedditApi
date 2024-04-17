var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(); 
builder.Services.AddCors(options => // Add CORS services,Cross-Origin Resource Sharing configuration

{
    options.AddPolicy("AllowAll", // Define a CORS policy named "AllowAll"
        builder =>
        {
            builder.AllowAnyOrigin() // Allow requests from any origin
                   .AllowAnyMethod() // Allow any HTTP method
                   .AllowAnyHeader(); // Allow any HTTP header
        });
});

//CORS is used to enable communication between the frontend and backend components
//of the application, allowing them to exchange data securely across different domains or ports.

var app = builder.Build(); 


if (app.Environment.IsDevelopment()) 
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger(); 
    app.UseSwaggerUI(); 
}

app.UseCors("AllowAll"); // Apply CORS policy

app.UseHttpsRedirection(); 
app.UseAuthorization(); 
app.MapControllers(); 

app.Run();
