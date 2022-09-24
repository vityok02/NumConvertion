namespace NumConvertion;

public static class ConsoleHelpers
{
    public static void ShowMenu()
    {
        Dictionary<NumberSystems, string> operations = new()
        {
            {NumberSystems.Bin, "Binary" },
            {NumberSystems.Oct, "Octal" },
            {NumberSystems.Dec, "Decimal" },
            {NumberSystems.Hex, "Hexadecimal" },
            {NumberSystems.Other, "Other" }
        };
        Console.WriteLine("--------------------");
        foreach (var operation in operations)
        {
            Console.WriteLine($"{(int)operation.Key}. {operation.Value}");
        }
        Console.WriteLine("--------------------");
    }

    public static NumberSystems? GetOperation()
    {
        return Enum.TryParse<NumberSystems>(Console.ReadLine(), out var choice)
            ? choice
            : (NumberSystems?)null;
    }

    public static string GetValueFromConsole(string message)
    {
        Console.Write(message);
        string? value;
        while (true)
        {
            value = Console.ReadLine();

            if (!string.IsNullOrEmpty(value))
            {
                break;
            }
        }
        return value;
    }

    public static int GetIntValueFromConsole(string message)
    {
        int intValue;
        while (true)
        {
            var value = GetValueFromConsole(message);
            if (int.TryParse(value, out intValue))
            {
                break;
            }
            Console.WriteLine("This not number");
        }
        return intValue;
    }

    public static decimal GetDecimalValueFromConsole(string message)
    {
        string value;
        decimal LastValue;
        string strOutValue = "";
        decimal outValue;
        string thisNum;
        while (true)
        {
            value = GetValueFromConsole(message);
            char[] chars = value.ToCharArray();
            for(int i = 0; i < chars.Length; i++)
            {
                thisNum = chars[i].ToString();
                switch (thisNum)
                {
                    case "A":
                        thisNum = 10.ToString();
                        break;
                    case "B":
                        thisNum = 11.ToString(); ;
                        break;
                    case "C":
                        thisNum = 12.ToString(); ;
                        break;
                    case "D":
                        thisNum = 13.ToString(); ;
                        break;
                    case "E":
                        thisNum = 14.ToString(); ;
                        break;
                    case "F":
                        thisNum = 15.ToString(); ;
                        break;
                    default:
                        break;
                }
                strOutValue = String.Concat(strOutValue, thisNum);
            }

            if (decimal.TryParse(strOutValue, out LastValue))
            {
                char[] charArray = strOutValue.ToCharArray();
                break;
            }
            Console.WriteLine("This not number");
        }
        return LastValue;
    }
}