using System.Globalization;

namespace XMatrixAssignment;

class Program
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

        Menu m = new();
        m.Run();
    }
}