using System;

namespace Recrusive_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Recusive Patterns

            var shape = new Triangle {
                A = 10, B = 20, C = 30
                , Point = new Point() 
            };
            
            var result = Compute(shape);

            Console.WriteLine(result);

            #endregion

            #region Recusive Patterns continued

            var person = new Student { Graduated = false, Name = "Filip Ekberg" };

            if(person is Student { Graduated : false, Name : string name })
            {
                Console.WriteLine($"Looks like {name} didn't graduate..");
            }
            else if(person is Student s)
            {
                Console.WriteLine($"Great! {s.Name} graduated!");
            }

            #endregion
        }

        static string Compute(Shape shape)
        {
            return shape switch
            {
                Triangle t when t.A != t.B => "A != B",
                Triangle { C : 30 } t => $"Found a match! C: {t.C}",
                Triangle (var a, var b, var c, (_, var y)) => $"A: {a}, B: {b}, C: {c}, Y: {y}",

                Rectangle r => $"X: {r.Point.X}, Y: {r.Point.Y}",
                
                _ => "Not sure.."
            };
        }
    }

    abstract class Shape
    {
        public Point Point { get; set; }
    }

    class Triangle : Shape
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public void Deconstruct(out int a, out int b, out int c, out Point point)
        {
            a = A;
            b = B;
            c = C;
            point = Point;
        }
    }

    class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public void Deconstruct(out int width, out int height, out Point point)
        {
            width = Width;
            height = Height;
            point = Point;
        }

    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }
    }

    public abstract class Person
    {
        public string Name { get; set; }
    }

    public class Employee : Person
    {
        public DateTime EmployedAt { get; set; }
    }

    public class Student : Person
    {
        public bool Graduated { get; set; }
    }
}
