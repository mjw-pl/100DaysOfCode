namespace Day003.Tools;

public static class PeselTool
{
    private static readonly int[] Weights = {1, 3, 7, 9, 1, 3, 7, 9, 1, 3};

    public static bool IsValid(string pesel)
    {
        if (string.IsNullOrEmpty(pesel)) return false;
        if (pesel.Length != 11) return false;
        if (pesel.All(char.IsDigit) == false) return false;
        
        return CountSum(pesel).Equals(pesel[10].ToString());
    }
    
    private static string CountSum(string pesel)
    {
        var sum = Weights.Select((t, i) => t * int.Parse(pesel[i].ToString())).Sum();
        var rod = sum % 10;
        
        return rod == 0 ? rod.ToString() : (10-rod).ToString();
    }
}