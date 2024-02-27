using Answer_6;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter three numbers:");

        Console.Write("Number 1: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Number 2: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Number 3: ");
        int num3 = Convert.ToInt32(Console.ReadLine());

        Flowchart flowchart = new Flowchart();

        flowchart.PrintMinNum(num1, num2, num3);

        Console.ReadLine();
    }
}