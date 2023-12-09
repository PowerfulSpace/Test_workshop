

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

DefaultFilesOptions options = new DefaultFilesOptions();
options.DefaultFileNames.Clear(); // удаляем имена файлов по умолчанию
options.DefaultFileNames.Add("index.html"); // добавляем новое имя файла
app.UseDefaultFiles(options); // установка параметров


app.UseStaticFiles();

app.Run(async (context) => await context.Response.WriteAsync("Hello World"));

app.Run();
