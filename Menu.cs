namespace XMatrixAssignment;

public class Menu
{
    private List<XMatrix> vec = new List<XMatrix>();

    public Menu() { }

    public void Run()
    {
        int n;
        do
        {
            PrintMenu();
            try
            {
                n = int.Parse(Console.ReadLine()!);
            }
            catch (System.FormatException) { n = -1; }
            switch (n)
            {
                case 1:
                    GetElement();
                    break;
                case 2:
                    PrintMatrix();
                    break;
                case 3:
                    AddMatrix();
                    break;
                case 4:
                    Sum();
                    break;
                case 5:
                    Mul();
                    break;
            }

        } while (n != 0);

    }
    #region Menu operations

    static private void PrintMenu()
    {
        Console.WriteLine("\n\n 0. - Quit");
        Console.WriteLine(" 1. - Get an element");
        Console.WriteLine(" 2. - Print a matrix");
        Console.WriteLine(" 3. - Set a matrix");
        Console.WriteLine(" 4. - Add matrices");
        Console.WriteLine(" 5. - Multiply matrices");
        Console.Write(" Choose: ");
    }

    private int GetIndex()
    {
        if (vec.Count == 0) return -1;
        int n = 0;
        bool ok;
        do
        {
            Console.Write("Give a matrix index: ");
            ok = false;
            try
            {
                n = int.Parse(Console.ReadLine()!);
                ok = true;
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Integer is expected!");
            }
            if (n <= 0 || n > vec.Count)
            {
                ok = false;
                Console.WriteLine("No such matrix!");
            }
        } while (!ok);
        return n - 1;
    }

    private void GetElement()
    {
        if (vec.Count == 0)
        {
            Console.WriteLine("Set a matrix first!");
            return;
        }
        int ind = GetIndex();
        do
        {
            try
            {
                Console.WriteLine("Give the index of the row: ");
                int i = int.Parse(Console.ReadLine()!);
                Console.WriteLine("Give the index of the column: ");
                int j = int.Parse(Console.ReadLine()!);
                Console.WriteLine($"a[{i},{j}]={vec[ind][i - 1, j - 1]}");
                break;
            }
            catch (System.FormatException)
            {
                Console.WriteLine($"Index must be between 1 and {vec[ind].Size}");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"Index must be between 1 and {vec[ind].Size}");
            }
        } while (true);
    }

    private void PrintMatrix()
    {
        if (vec.Count == 0)
        {
            Console.WriteLine("Set a matrix first!");
            return;
        }
        int ind = GetIndex();
        Console.Write(vec[ind].ToString());
    }

    private void AddMatrix()
    {
        int ind = vec.Count;
        bool ok = false;
        int n = -1;

        do
        {
            Console.Write("Size of the matrix: ");
            try
            {
                n = int.Parse(Console.ReadLine()!);
                //if (n % 2 == 0)

                //    Console.WriteLine("Odd integer is expected!");
                //else

                    ok = n > 0;

            }
            catch (System.FormatException)
            {
                Console.WriteLine("Positive integer is expected!");
            }
        } while (!ok);
        XMatrix d = new XMatrix(n);

        ok = true;
        List<double> elements = new List<double>();
        for (int i = 0; i < d.Count; i++)
        {
            Console.Write("Insert an element: ");
            try
            {
                double elem = double.Parse(Console.ReadLine()!);
                elements.Add(elem);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Number is expected!");
                ok = false;
                break;
            }
        }

        if (ok)
        {
            d.Set(elements);
            vec.Add(d);
        }
    }

    private void Sum()
    {
        if (vec.Count == 0)
        {
            Console.WriteLine("Set a matrix first!");
            return;
        }
        Console.Write("1st matrix: ");
        int ind1 = GetIndex();
        Console.Write("2nd matrix: ");
        int ind2 = GetIndex();
        try
        {
            Console.Write((vec[ind1] + vec[ind2]).ToString());
        }
        catch (XMatrix.DifferentSizeException)
        {
            Console.WriteLine("Dimension mismatch!");
        }
    }

    private void Mul()
    {
        if (vec.Count == 0)
        {
            Console.WriteLine("Set a matrix first!");
            return;
        }
        Console.Write("1st matrix: ");
        int ind1 = GetIndex();
        Console.Write("2nd matrix: ");
        int ind2 = GetIndex();
        try
        {
            Console.Write((vec[ind1] * vec[ind2]).ToString());
        }
        catch (XMatrix.DifferentSizeException)
        {
            Console.WriteLine("Dimension mismatch!");
        }
    }

    #endregion
}
