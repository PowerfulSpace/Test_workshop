

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

DefaultFilesOptions options = new DefaultFilesOptions();
options.DefaultFileNames.Clear(); // ������� ����� ������ �� ���������
options.DefaultFileNames.Add("index.html"); // ��������� ����� ��� �����
app.UseDefaultFiles(options); // ��������� ����������


app.UseStaticFiles();

app.Run(async (context) => await context.Response.WriteAsync("Hello World"));

app.Run();
