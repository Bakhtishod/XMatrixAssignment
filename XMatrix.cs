
namespace XMatrixAssignment
{
    public class XMatrix
    {
        #region Exceptions
        public class NegativeSizeException : Exception { };
        public class ReferenceToNullPartException : Exception { };
        public class DifferentSizeException : Exception { };
        #endregion

        #region Attribute
        private readonly List<double> x = new();
        #endregion

        #region Constructors

        public XMatrix(int k)
        {
            if (k <= 0) throw new NegativeSizeException();

            size = k;

            if (k == 1)
            {
                x.Add(0);
                return;
            }

            int range;
            if (k % 2 == 0)
            {
                range = 2 * k;
            }
            else
            {
                range = 2 * k - 1;
            }

            for (int i = 0; i < range; ++i)
            {
                x.Add(0);
            }
        }
        public XMatrix(XMatrix d)
        {
            size = d.size;
            for (int i = 0; i < d.x.Count; ++i)
            {
                x.Add(d.x[i]);
            }
        }
        #endregion

        #region Properties

        public int Size // Property for getting the size of the matrix
        {
            get { return size; }
        }

        private int size;

        public int Count // Property for getting the count of diagonal elements
        {
            get { return x.Count; }
        }

        public double this[int i, int j] //Property for getting and setting an element with square bracket
        {
            get
            {
                if (i < 0 || i >= Size || j < 0 || j >= Size)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    int mainInd = 0;
                    bool indFound = false;
                    if (i == j || i + j == Size - 1)
                    {
                        for (int indI = 0; indI < Size; ++indI)
                        {
                            for (int indJ = 0; indJ < Size; ++indJ)
                            {
                                if (indI == i && indJ == j)
                                {
                                    indFound = true;
                                    break;
                                }
                                else if (indI == indJ || indI + indJ == Size - 1)
                                {
                                    mainInd++;
                                }
                            }
                            if (indFound) break;
                        }
                        return x[mainInd];
                    }
                    else
                    {
                        return 0;
                    }

                }
            }
            set
            {
                if (i < 0 || i >= Size || j < 0 || j >= Size)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    int mainInd = 0;
                    bool indFound = false;
                    if (i == j || i + j == Size - 1)
                    {
                        for (int indI = 0; indI < Size; ++indI)
                        {
                            for (int indJ = 0; indJ < Size; ++indJ)
                            {
                                if (indI == i && indJ == j)
                                {
                                    indFound = true;
                                    break;
                                }
                                else if (indI == indJ || indI + indJ == Size - 1)
                                {
                                    mainInd++;
                                }
                            }
                            if (indFound) break;
                            }
                        x[mainInd] = value;
                    }

                }
            }
        }

        #endregion

        #region Getters and setters

        public override int GetHashCode()
        {
            return (base.GetHashCode() << 2);
        }

        public override string ToString()
        {
            string str = "";
            int matInd = 0;

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (i == j || i + j == Size - 1)
                    {
                        str += "\t" + x[matInd];
                        matInd++;
                    }
                    else
                    {
                        str += "\t0";
                    }
                }
                str += "\n";
            }
            return str;
        }

        public override bool Equals(Object? obj)
        {
            if (obj == null || !(obj is XMatrix))
                return false;
            else
            {
                XMatrix? diag = obj as XMatrix;
                if (diag!.Count != this.Count) return false;
                for (int i = 0; i < x.Count; i++)
                {
                    if (x[i] != diag.x[i]) return false;
                }
                return true;
            }
        }

        public void Set(in List<double> x)
        {
            if (this.Count != x.Count) throw new DifferentSizeException();
            for (int i = 0; i < Count; i++)
            {
                this.x[i] = x[i];
            }
        }

        #endregion

        #region Operators

        public static XMatrix operator +(XMatrix a, XMatrix b)
        {
            if (a.Size != b.Size) throw new DifferentSizeException();
            XMatrix c = new(a.Size);
            for (int i = 0; i < c.Count; ++i)
            {
                c.x[i] = a.x[i] + b.x[i];
            }
            return c;
        }

        public static XMatrix operator *(XMatrix a, XMatrix b)
        {
            if (a.Size != b.Size) throw new DifferentSizeException();

            List<double> vec = [];
            for (int i = 0; i < a.Size; i++)
            {
                for (int j = 0; j < a.Size; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < a.Size; k++)
                    {
                        if ((i == k || i + k == a.Size - 1) && (k == j || k + j == a.Size - 1))
                        {
                            sum += a[i, k] * b[k, j];
                        }
                    }
                    if (i == j || i + j == a.Size - 1)
                    {
                        vec.Add(sum);
                    }
                }
            }

            XMatrix c = new(a.Size);
            c.Set(vec);
            return c;
        }

        #endregion

    }
}
