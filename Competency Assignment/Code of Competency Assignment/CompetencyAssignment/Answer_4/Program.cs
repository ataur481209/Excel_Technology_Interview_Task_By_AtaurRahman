using Answer_4;

class Program
{
    static void Main()
    {
        MethodOverloading calculator = new MethodOverloading();

        int result1 = calculator.Add(2, 3);
        Console.WriteLine("Result of Add(int, int): " + result1);

        int result2 = calculator.Add(2, 3, 4);
        Console.WriteLine("Result of Add(int, int, int): " + result2);

        double result3 = calculator.Add(2.5, 3.5, 4);
        Console.WriteLine("Result of Add(double, double, int): " + result3);

        double result4 = calculator.Add(2.5, 4, 1.5);
        Console.WriteLine("Result of Add(double, int, double): " + result4);

        //Overriding
        BaseClass baseObj = new BaseClass();
        SubClass subObj = new SubClass();

        baseObj.Greetings();
        subObj.Greetings();
    }

}
