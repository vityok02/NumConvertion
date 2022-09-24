using NumConvertion;
using static NumConvertion.ConsoleHelpers;

Console.WriteLine("Welcome to NumConvertion system");
Console.WriteLine();

decimal number;
int firstNumberSystem;
int lastNumberSystem;

while (true)
{
    number = GetDecimalValueFromConsole("Enter number: ");

    ShowMenu();

    Console.WriteLine("Select first number system: ");
    firstNumberSystem = GetSystem();
    Console.WriteLine("Select last number system: ");
    lastNumberSystem = GetSystem();

    Console.WriteLine($"Convert '{number}': {firstNumberSystem} -> {lastNumberSystem} number system");

    ConvertNumber(number, firstNumberSystem, lastNumberSystem);
}

int GetSystem()
{
    while (true)
    {
        var choice = GetOperation();

        if (!choice.HasValue)
        {
            Console.WriteLine("Wrong choice");
            continue;
        }

        int system = 0;
        switch (choice)
        {
            case NumberSystems.Bin:
                system = 2;
                break;
            case NumberSystems.Oct:
                system = 8;
                break;
            case NumberSystems.Dec:
                system = 10;
                break;
            case NumberSystems.Hex:
                system = 16;
                break;
            case NumberSystems.Other:
                system = GetOtherSystem();
                break;
            default:
                Console.WriteLine("Unknown choice");
                break;

        }
        int GetOtherSystem()
        {
            return system = GetIntValueFromConsole("Enter number system");
        }
        return system;
    }
}

void ConvertNumber(decimal number, int firstNumberSystem, int lastNumberSystem)
{
    ConvertFrom10ToQ();

    decimal ConvertTo10()
    {
        decimal fullResult = 0;

        char[] chars = number.ToString().ToCharArray();
        decimal result = 0;
        string[] numToComma = number.ToString().Split(",");
        int j = numToComma[0].Length - 1;
        string strChar;
        int intChar;
        for (int i = 0; i < chars.Length; i++)
        {
            strChar = chars[i].ToString();
            if (chars[i] == ',')
            {
                continue;
            }
            intChar = int.Parse(strChar);
            result = intChar * (decimal)Math.Pow(firstNumberSystem, j);
            fullResult = fullResult + result;
            j--;
        }
        return fullResult;
    }

    void ConvertFrom10ToQ()
    {
        decimal number = ConvertTo10();

        string[] stringNumber = number.ToString().Split(",");

        int remainder;

        string resultToComma = "";

        string resultAfterComma = "";

        int firstPart = int.Parse(stringNumber[0]);

        bool contain = number.ToString().Contains(',');

        string strNum1 = "";

        string strNum2 = "";

        int checkerNum;

        if (contain == true)
        {
            int charsAfterComma = GetIntValueFromConsole("Enter numbers after comma");

            decimal secondPart = decimal.Parse(stringNumber[1]);

            string strSecondPart = secondPart.ToString();

            strSecondPart = 0 + "," + strSecondPart;

            decimal dSecondPart = decimal.Parse(strSecondPart);

            decimal dSecondPart2 = dSecondPart;

            string[] parts;

            string secondPartToString;

            string firstChar;

            for (int i = 0; i < charsAfterComma; i++)
            {
                dSecondPart2 = dSecondPart2 * lastNumberSystem;
                parts = dSecondPart2.ToString().Split(",");
                secondPartToString = 0 + "," + parts[1];
                firstChar = GetFirstChar(dSecondPart2.ToString());
                checkerNum = int.Parse(firstChar);
                strNum2 = CheckHex();
                resultAfterComma = String.Concat(resultAfterComma, Convert.ToString(strNum2));
                dSecondPart2 = decimal.Parse(secondPartToString);
            }
            resultAfterComma = "," + resultAfterComma;
        }

        for (int i = 0; firstPart > 0; i++)
        {
            remainder = firstPart % lastNumberSystem;
            checkerNum = remainder;
            strNum1 = CheckHex();
            firstPart = firstPart / lastNumberSystem;
            resultToComma = String.Concat(resultToComma, strNum1);
        }

        char[] chars = resultToComma.ToCharArray();
        Array.Reverse(chars);
        string result = new string(chars);

        string fullResult = result + resultAfterComma;

        Console.WriteLine("Result: " + fullResult);

        string GetFirstChar(string value)
        {
            string[] chars = value.Split(",");
            string firstChar = chars[0];
            return firstChar;
        }
        string CheckHex()
        {
            switch (checkerNum)
            {
                case 10:
                    strNum1 = "A";
                    break;
                case 11:
                    strNum1 = "B";
                    break;
                case 12:
                    strNum1 = "C";
                    break;
                case 13:
                    strNum1 = "D";
                    break;
                case 14:
                    strNum1 = "E";
                    break;
                case 15:
                    strNum1 = "F";
                    break;
                default:
                    strNum1 = checkerNum.ToString();
                    break;
            }
            return strNum1;
        }
    }
}