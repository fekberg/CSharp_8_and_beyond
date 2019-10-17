using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Recrusive_Patterns
{
    class Program
    {
        static async Task Main(string[] args)
        {
            #region ExplainShape

            var shape = new Rectangle { Width = 100, Height = 0 };
            // new Triangle { A = 10, B = 10, C = 30 };
            
            var result = ExplainShape(shape);

            Console.WriteLine(result);

            #endregion

            #region GetShapeFrom HttpResponseMessage

            var shape2 = await GetShapeFrom(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
                // StatusCode = HttpStatusCode.Forbidden
                // StatusCode = HttpStatusCode.NotModified
                // StatusCode = HttpStatusCode.BadRequest
                // StatusCode = HttpStatusCode.SeeOther
            });

            Console.WriteLine(ExplainShape(shape2));

            #endregion
        }

        #region Example 1
        public string Example1()
        {
            object shape = new Triangle { A = 100, B = 100, C = 400 };

            var result = shape switch {
                Triangle t => $"A: {t.A} B: {t.B} C: {t.C}",
                Rectangle r => $"X: {r.Point.X}  Y: {r.Point.Y}  Height: {r.Height} Width: {r.Width}",
                _ => throw new Exception("Unknown shape")
            };

            return result;
        }
        #endregion

        #region Example 2
        static string ExplainShape(object shape)
        {
            return shape switch
            {
                Triangle t when t.A != t.B => $"A != B, ({t.A} != {t.B})",

                #region Tuple Pattern

                Triangle (var a, var b, var c, _) => $"A: {a}, B: {b}, C: {c}",

                #endregion

                #region Positional Pattern

                Rectangle (0, 0, _) r => "0, 0",

                #endregion

                #region Property Pattern

                Rectangle { Width: 100 } r => $"Width: {r.Width}",

                #endregion

                #region Any rectangle

                Rectangle r => $"Point X: {r.Point.X}, Y: {r.Point.Y}",

                #endregion

                #region Default Pattern

                _ => "Other shapes"

                #endregion
            };
        }
        #endregion

        #region Example 3
        static string VisibilityFrom(bool? state)
        {
            return state switch
            {
                true => "Visible",
                false => "Hidden",
                _ => "Blink"
            };
        }
        #endregion

        #region Example 4
        static async Task<object> GetShapeFrom(HttpResponseMessage message)
        {
            var shape = (message.StatusCode, message.IsSuccessStatusCode) switch
            {
                (HttpStatusCode.NotModified, true) => await FromCache(),
                (HttpStatusCode.OK, _) => await ExtractShape(message),
                (_, true) => await ExtractShape(message),
                (HttpStatusCode.RequestTimeout, _) => await GetShapeFrom(message),
                (_, false) => throw new Exception("Network error"),
                _ => throw new Exception()
            };

            return shape;
        }
        #endregion

        #region Data

        private static Task<object> FromCache()
            => Task.FromResult((object)new Rectangle { Height = 200, Width = 400 });

        public static Task<object> ExtractShape(HttpResponseMessage message) 
            => Task.FromResult((object)new Triangle { A = 100, B = 100, C = 300, Point = new Point { X = 0, Y = 100} });

        #endregion
    }
   
    /*
    abstract class Shape
    { }
    */

    class Triangle // : Shape
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public Point Point { get; set; }

        public void Deconstruct(out int a, out int b, out int c, out Point point)
        {
            a = A;
            b = B;
            c = C;

            point = Point;
        }
    }

    class Rectangle // : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Point Point { get; set; }

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
}
