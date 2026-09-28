using System.Reflection;
using Xunit;

namespace TextFilterApp.Tests;

public class TextFilterTests
{
    private const string InputText = "This is the input text file for Unit Test of TextFilterApp Application in C#";

    private static readonly string[] InputWords =
    {
        "This", "is", "the", "input", "text", "file", "for", "Unit",
        "Test", "of", "TextFilterApp", "Application", "in", "C#"
    };

    private const string ExpectedResult = "file for";

    [Fact]
    public void CleanUpContent_Should_Split_Text_To_Words()
    {
        var result = TextFilterHelper.CleanUpContent(InputText);
        Assert.Equal(InputWords, result);
    }

    [Fact]
    public void FilterMoreThanThree_Should_Remain_Words()
    {
        var result = TextFilterHelper.FilterMoreThanThree(InputWords);
        Assert.DoesNotContain("is", result);
        Assert.DoesNotContain("of", result);
        Assert.DoesNotContain("in", result);
        Assert.DoesNotContain("C#", result);
        Assert.Contains("the", result);
    }

    [Fact]
    public void FilterVowelInMiddle_Should_Remain_Words()
    {
        var result = TextFilterHelper.FilterVowelInMiddle(InputWords);
        Assert.DoesNotContain("the", result);
        Assert.DoesNotContain("input", result);
        Assert.DoesNotContain("TextFilterApp", result);
        Assert.Contains("file", result);
        Assert.Contains("for", result);
    }

    [Fact]
    public void FilterLetters_Should_Remain_Words()
    {
        var result = TextFilterHelper.FilterLetters(InputWords);
        Assert.DoesNotContain("the", result);
        Assert.DoesNotContain("input", result);
        Assert.DoesNotContain("text", result);
        Assert.Contains("file", result);
        Assert.Contains("for", result);
        Assert.Contains("is", result);
    }

    [Fact]
    public void ApplyFilter_Should_Match_Result()
    {
        var result = TextFilterHelper.ApplyFilters(InputText);
        Assert.Equal(ExpectedResult, result);
    }
}
