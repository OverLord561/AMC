using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        #region Task
        //Suppose a point and a triangle in 2D space are given.Check whether the point belongs to the triangle.
        //The triangle is given by its vertices.The input data are 8 double numbers. 
        //The first two numbers are coordinates of the point.The second two numbers are coordinates of the first vertex of the triangle.
        //The third two numbers are coordinates of the second vertex of the triangle.The fourth two numbers are coordinates of the third vertex of the triangle.
        //Input data guarantee that length of the edges are greater than 1e-8.All input numbers are separated by spaces.
        //Input data guarantee that inputs and the results will be less than 9 223 372 036 854 775 807.0.
        //Output data must be one integer number 1 if point belongs to the triangle; 0 - if not.
        //We consider that the point belongs to the triangle, if it is incide triangle, or lies on the edges of the triangle.
        #endregion
        double ab, bc, ac, at, bt, ct, s, s1, s2, s3 = 0.0;
        string sourceSequence = "1.0 1.0 0.0 0.0 0.0 3.0 4.0 0.0";

        double[] separatedSequence = GetDoubleArrayFromString(sourceSequence);


        Point test = new Point(separatedSequence[0], separatedSequence[1]);
        Point A = new Point(separatedSequence[2], separatedSequence[3]);
        Point B = new Point(separatedSequence[4], separatedSequence[5]);
        Point C = new Point(separatedSequence[6], separatedSequence[7]);

        ab = GetLength(A, B);
        bc = GetLength(B, C);
        ac = GetLength(C, A);

        at = GetLength(A, test);
        bt = GetLength(B, test);
        ct = GetLength(C, test);

        s = GetSquare(ab, bc, ac);
        s1 = GetSquare(ab, at, bt);
        s2 = GetSquare(ac, ct, at);
        s3 = GetSquare(bc, bt, ct);

        if (Math.Abs(s - (s1 + s2 + s3)) <= 0.1)
        {
            Console.WriteLine("1");
        }
        else
        {
            Console.WriteLine("0");
        }

        Console.ReadLine();

    }

    //Get square via three sides of triangle
    static double GetSquare(double len1, double len2, double len3)
    {
        double halfPerimeter = 0.0;
        double square = 0.0;
        halfPerimeter = (len1 + len2 + len3) / 2;
        square = Math.Sqrt(halfPerimeter * (halfPerimeter - len1) * (halfPerimeter - len2) * (halfPerimeter - len3));
        return Math.Round(square, 5);
    }

    //Get length between two points
    static double GetLength(Point p1, Point p2)
    {
        double len = 0.0;
        len = Math.Sqrt(Math.Pow(p1.x - p2.x, 2) + Math.Pow(p1.y - p2.y, 2));
        return Math.Round(len, 5);
    }

    // Convert string sequence of numbers into double array 
    public static double[] GetDoubleArrayFromString(string sourceString)
    {
        sourceString = sourceString.Replace('.', ',');       
       
        string[] separatedNumbers = sourceString.Split(' ');
        double[] separatedSequence = Array.ConvertAll<string, double>(separatedNumbers, double.Parse); //Convert string array into double array
        return separatedSequence;
    }


    struct Point
    {
        public double x;
        public double y;
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}