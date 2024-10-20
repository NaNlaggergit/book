using System;
using System.Drawing;

namespace Book // Note: actual namespace depends on the project name.
{
    class Book : IComparable
    {
        public string Title;
        public int Theme;
        public int CompareTo(object obj)
        {
            var book=(Book)obj;
            var compareTitle = this.Title.CompareTo(book.Title);
            var compareTheme = this.Theme.CompareTo(book.Theme);
            int sum=compareTitle+compareTheme;
            if(sum<0)
                return -1;
            if(sum>1)
                return 1;
            return 0;
        }
    }
    public class Point
    {
        public double X;
        public double Y;
    }
    public class ClockwiseComparer : IComparer<Point>
    {
        public int Compare(Point point1,Point point2)
        {
            var angle1=Math.Atan2(point1.Y, point1.X);
            var angle2=Math.Atan2(point2.Y, point2.X);
            if (angle1 < 0)
                angle1 += 2 * Math.PI;
            if (angle2 < 0)
                angle2+=2* Math.PI;
            return angle1.CompareTo(angle2);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = new[]
            {
                new Point { X = 1, Y = 0 },
                new Point { X = -1, Y = 0 },
                new Point { X = 0, Y = 1 },
                new Point { X = 0, Y = -1 },
                new Point { X = 0.01, Y = 1 }
            };
            Array.Sort(array, new ClockwiseComparer());
            foreach (Point e in array)
                Console.WriteLine("{0} {1}", e.X, e.Y);
        }
    }
}