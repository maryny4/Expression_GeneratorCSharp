using System.Data;

public class ExpressionGenerator
{
    private static Random random = new Random();

    private static char GetRandomOperation(char[] operations)
    {
        int index = random.Next(operations.Length);
        return operations[index];
    }

    private static string GenerateExpression(int minValue, int maxValue, char[] operations)
    {
        int number1 = random.Next(minValue, maxValue);
        int number2 = random.Next(minValue, maxValue);
        char operation = GetRandomOperation(operations);

        return $"{number1} {operation} {number2}";
    }

    public static double CalculateExpression(string expression)
    {
        DataTable dt = new DataTable();
        var result = dt.Compute(expression, "");
        return Convert.ToDouble(result);
    }

    public static string GenerateAdditionSubtractionExpression(int minValue, int maxValue)
    {
        char[] operations = { '+', '-' };
        return GenerateExpression(minValue, maxValue, operations);
    }

    public static string GenerateMultiplicationDivisionExpression(int minValue, int maxValue)
    {
        char[] operations = { '*', '/' };
        return GenerateExpression(minValue, maxValue, operations);
    }

    public static string GenerateExpressionWithoutBrackets(int minNum, int maxNum, int minRange, int maxRange)
    {
        List<char> operators = new List<char> { '+', '-', '*', '/' };
        char operator1 = operators[random.Next(operators.Count)];
        char operator2 = operators[random.Next(operators.Count)];

        int num1, num2, num3;
        string expression;

        do
        {
            num1 = random.Next(minNum, maxNum + 1);
            num2 = random.Next(minNum, maxNum + 1);
            num3 = random.Next(minNum, maxNum + 1);

            expression = $"{num1} {operator1} {num2} {operator2} {num3}";
        } while (!IsIntegerResult(expression, minRange, maxRange));

        return expression;
    }

    public static string GenerateExpressionWithBrackets(int minNum, int maxNum, int minRange, int maxRange)
    {
        List<char> operators = new List<char> { '+', '-', '*', '/' };
        char operator1 = operators[random.Next(operators.Count)];
        char operator2 = operators[random.Next(operators.Count)];

        int num1, num2, num3;
        string expression;

        do
        {
            num1 = random.Next(minNum, maxNum + 1);
            num2 = random.Next(minNum, maxNum + 1);
            num3 = random.Next(minNum, maxNum + 1);

            if (random.Next(2) == 0)
            {
                expression = $"({num1} {operator1} {num2}) {operator2} {num3}";
            }
            else
            {
                expression = $"{num1} {operator1} ({num2} {operator2} {num3})";
            }
        } while (!IsIntegerResult(expression, minRange, maxRange));

        return expression;
    }

    private static bool IsIntegerResult(string expression, int minRange, int maxRange)
    {
        double result = CalculateExpression(expression);
        return Math.Floor(result) == result && result >= minRange && result <= maxRange;
    }

    private static char GetRandomOperatorForFloatingPoint()
    {
        char[] operators = { '+', '-', '*', '/' };
        int index = random.Next(operators.Length);
        return operators[index];
    }

    private static decimal CalculateExpressionForFloatingPoint(int number1, int number2, char selectedOperator)
    {
        switch (selectedOperator)
        {
            case '+':
                return (decimal)(number1 + number2);
            case '-':
                return (decimal)(number1 - number2);
            case '*':
                return (decimal)(number1 * number2);
            case '/':
                if (number2 != 0)
                {
                    return (decimal)(number1) / number2;
                }

                return 0;
            default:
                return 0;
        }
    }

    public static Tuple<int, char, int, decimal> GenerateRandomExampleForFloatingPoint(decimal targetResult,
        int minNumber, int maxNumber)
    {
        while (true)
        {
            int number1 = random.Next(minNumber, maxNumber + 1);
            int number2 = random.Next(minNumber, maxNumber + 1);
            char selectedOperator = GetRandomOperatorForFloatingPoint();

            decimal result = CalculateExpressionForFloatingPoint(number1, number2, selectedOperator);

            if (Math.Abs(result - targetResult) < 0.0001M)
            {
                return Tuple.Create(number1, selectedOperator, number2, result);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        string additionSubtractionExpression = ExpressionGenerator.GenerateAdditionSubtractionExpression(-15, 15);
        double additionSubtractionResult = ExpressionGenerator.CalculateExpression(additionSubtractionExpression);
        Console.WriteLine($"{additionSubtractionExpression} = {additionSubtractionResult}");

        string multiplicationDivisionExpression = ExpressionGenerator.GenerateMultiplicationDivisionExpression(1, 15);
        double multiplicationDivisionResult = ExpressionGenerator.CalculateExpression(multiplicationDivisionExpression);
        Console.WriteLine($"{multiplicationDivisionExpression} = {multiplicationDivisionResult}");

        string expressionWithoutBrackets = ExpressionGenerator.GenerateExpressionWithoutBrackets(-15, 15, 1, 100);
        double resultWithoutBrackets = ExpressionGenerator.CalculateExpression(expressionWithoutBrackets);
        Console.WriteLine($"{expressionWithoutBrackets} = {resultWithoutBrackets}");

        string expressionWithBrackets = ExpressionGenerator.GenerateExpressionWithBrackets(-15, 15, 1, 100);
        double resultWithBrackets = ExpressionGenerator.CalculateExpression(expressionWithBrackets);
        Console.WriteLine($"{expressionWithBrackets} = {resultWithBrackets}");
        var example1 = ExpressionGenerator.GenerateRandomExampleForFloatingPoint(0.25M, 1, 100);
        var example2 = ExpressionGenerator.GenerateRandomExampleForFloatingPoint(0.1M, 1, 100);
        var example3 = ExpressionGenerator.GenerateRandomExampleForFloatingPoint(0.5M, 1, 100);
        var example4 = ExpressionGenerator.GenerateRandomExampleForFloatingPoint(-3M, 1, 100);

        if (example1 != null)
        {
            Console.WriteLine($"{example1.Item1} {example1.Item2} {example1.Item3} = {example1.Item4}");
        }

        if (example2 != null)
        {
            Console.WriteLine($"{example2.Item1} {example2.Item2} {example2.Item3} = {example2.Item4}");
        }

        if (example3 != null)
        {
            Console.WriteLine($"{example3.Item1} {example3.Item2} {example3.Item3} = {example3.Item4}");
        }

        if (example4 != null)
        {
            Console.WriteLine($"{example4.Item1} {example4.Item2} {example4.Item3} = {example4.Item4}");
        }
    }
}