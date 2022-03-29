var calc = new ExpressionCalculatror.Classes.Calculator();

Console.Write("Введите выражение: ");
string expression = Console.ReadLine();
ExpressionCalculatror.Classes.Display.Test2(expression, calc.MakeData(expression));

