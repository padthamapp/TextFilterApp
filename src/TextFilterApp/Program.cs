using TextFilterApp;

var filePath = Path.Combine(AppContext.BaseDirectory, "input.txt");
var validateResult = FileValidator.Validator(filePath);

try
{
    if (!validateResult)
    {
        Console.WriteLine("File Validator fail");
        return;
    }
    var content = File.ReadAllText(filePath);
    Console.Write(TextFilterHelper.ApplyFilters(content));
}
catch (Exception e)
{
    Console.WriteLine($"Error: {e.Message}");
}






