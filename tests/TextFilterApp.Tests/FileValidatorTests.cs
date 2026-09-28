using System.Reflection;
using Xunit;

namespace TextFilterApp.Tests;

public class FileValidatorTests
{
    [Fact]
    public void Validator_Should_Return_Content_When_File_Is_Valid()
    {
        var path = Path.Combine(Path.GetTempPath(), "test.txt");
        File.WriteAllText(path, "hello world");

        var result = FileValidator.Validator(path);

        Assert.True(result);
        File.Delete(path);
    }

    [Theory]
    [InlineData(" ")]
    [InlineData("")]
    [InlineData(null)]
    public void Validator_Should_Throw_When_FilePath_Is_Null(string? path)
    {
        Assert.Throws<ArgumentNullException>(() => FileValidator.Validator(path));
    }

    [Fact]
    public void Validator_Should_Throw_When_File_Not_Found()
    {
        var path = Path.Combine(Path.GetTempPath(), "test.txt");
        File.WriteAllText(path, "hello world");

        Assert.Throws<FileNotFoundException>(() => FileValidator.Validator("test.txt"));
        File.Delete(path);
    }

    [Theory]
    [InlineData(".log")]
    [InlineData(".jpg")]
    [InlineData(".text")]
    public void Validator_Should_Throw_When_Invalid_FileExtentions(string? extension)
    {
        var path = Path.Combine(Path.GetTempPath(), $"test.{extension}");
        File.WriteAllText(path, "hello world");

        Assert.Throws<InvalidDataException>(() => FileValidator.Validator(path));
        File.Delete(path);
    }

    [Fact]
    public void Validator_Should_Throw_Empty_Content()
    {
        var path = Path.Combine(Path.GetTempPath(), "test.txt");
        File.WriteAllText(path, "");

        Assert.Throws<InvalidDataException>(() => FileValidator.Validator(path));
        File.Delete(path);
    }
}
