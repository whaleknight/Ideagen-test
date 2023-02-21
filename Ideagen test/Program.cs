// See https://aka.ms/new-console-template for more information
Console.WriteLine("Ideagen test");
Console.WriteLine("=========================");
Console.WriteLine("( 11.5 + 15.4 ) + 10.1 = ");
Console.WriteLine(Calculate("( 11.5 + 15.4 ) + 10.1 "));
Console.WriteLine("10 - (2 + 3 * (7 - 5)) = ");
Console.WriteLine(Calculate("10 - ( 2 + 3 * ( 7 - 5 ) )"));
Console.WriteLine("23 - ( 29.3 - 12.5 ) = ");
Console.WriteLine(Calculate("23 - ( 29.3 - 12.5 )"));
Console.WriteLine("( 1 / 2 ) - 1 + 1 = ");
Console.WriteLine(Calculate("( 1 / 2 ) - 1 + 1"));
Console.WriteLine("1 + 1  = ");
Console.WriteLine(Calculate("1 + 1 "));
Console.WriteLine("2 * 2  = ");
Console.WriteLine(Calculate("2 * 2"));
Console.WriteLine("1 + 2 + 3  = ");
Console.WriteLine(Calculate("1 + 2 + 3 "));
Console.WriteLine("6 / 2   = ");
Console.WriteLine(Calculate("6 / 2"));
Console.WriteLine("11 + 23  = ");
Console.WriteLine(Calculate("11 + 23"));
Console.WriteLine("11.1 + 23  = ");
Console.WriteLine(Calculate("11.1 + 23"));
Console.WriteLine("1 + 1 * 3  = ");
Console.WriteLine(Calculate("1 + 1 * 3"));
Console.WriteLine("=========================");
Console.WriteLine("Please input a string to calculate");
string variableName = Console.ReadLine();
Console.WriteLine(Calculate(variableName));

double Calculate(string sum)
{
    var tokens = sum.Split(' ');
    var stack = new Stack<double>();
    var operatorStack = new Stack<char>();

    for (int i = 0; i < tokens.Length; i++)
    {
        var token = tokens[i];
        if (double.TryParse(token, out double number))
        {
            stack.Push(number);
        }
        else if (token == "+" || token == "-" || token == "*" || token == "/")
        {
            while (operatorStack.Count > 0 && GetPrecedence(token[0]) <= GetPrecedence(operatorStack.Peek()))
            {
                EvaluateTop(stack, operatorStack);
            }
            operatorStack.Push(token[0]);
        }
        else if (token == "(")
        {
            operatorStack.Push(token[0]);
        }
        else if (token == ")")
        {
            while (operatorStack.Peek() != '(')
            {
                EvaluateTop(stack, operatorStack);
            }
            operatorStack.Pop(); // Pop '('
        }
    }

    while (operatorStack.Count > 0)
    {
        EvaluateTop(stack, operatorStack);
    }

    return stack.Peek();
}

static int GetPrecedence(char op)
{
    switch (op)
    {
        case '+':
        case '-':
            return 1;
        case '*':
        case '/':
            return 2;
        default:
            return 0;
    }
}

static void EvaluateTop(Stack<double> stack, Stack<char> operatorStack)
{
    char op = operatorStack.Pop();
    double b = stack.Pop();
    double a = stack.Pop();
    double result;
    switch (op)
    {
        case '+':
            result = a + b;
            break;
        case '-':
            result = a - b;
            break;
        case '*':
            result = a * b;
            break;
        case '/':
            result = a / b;
            break;
        default:
            throw new ArgumentException("Invalid operator: " + op);
    }
    stack.Push(result);
}
