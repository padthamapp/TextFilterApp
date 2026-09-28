using System.Linq;

namespace TextFilterApp;
public static class FileValidator
{
    private static readonly string[] allowExtensions = {".txt"};
    public static bool Validator(string? filePath)
    {
        if (String.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentNullException("File path is null or empty", filePath);
        }

        var file = new FileInfo(filePath);

        if (!file.Exists)
        {
            throw new FileNotFoundException("File not found", filePath);
        }

        if (!allowExtensions.Contains(file.Extension, StringComparer.OrdinalIgnoreCase))
        {
            throw new InvalidDataException($"Unsupport file type: {file.Extension}");
        }

        if (file.Length == 0)
        {
            throw new InvalidDataException("File is empty");
        }

        return true;
    }
}