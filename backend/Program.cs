using System;
using System.IO;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();



app.MapGet("/", () => "Hello World!");

app.MapPost("/upload", async (HttpRequest request) => {
    var file = request.Form.Files["file"];
    var path = Path.GetTempFileName();
    await using FileStream fs = new(path, FileMode.Create);
    if (file is null) {
        return false;
    }
    await file.OpenReadStream().CopyToAsync(fs);
    return true;
});

app.Run("http://localhost:5294");