using System.Security.Cryptography.X509Certificates;
using Day003.Tools;

namespace Day004;

public class PeselToolTest
{
    [Theory]
    [InlineData("", false)]
    [InlineData("1234567890", false)]
    [InlineData("123456789012", false)]
    [InlineData("123456789O1", false)]
    [InlineData("73050531615", true)]
    [InlineData("03240168899", true)]
    [InlineData("00010114616", true)]
    public void Test_Pesel_Is_Valid(string number, bool expected)
    {
        Assert.Equal(expected, PeselTool.IsValid(number));
    }
}