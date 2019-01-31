using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Triangle : Shape
    {
        public override List<Point> Vertices
        {
            get
            {
                return base.Vertices;
            }
            set
            {
                if (value.Count != 3)
                {
                    throw new ArgumentException("Vertices", "Triangle can only have 3 vertices!");
                }
                else
                {
                    _Vertices = value;
                }

            }
        }

        private double[] SideLength //returns array with triangle side lengths
        {
            get
            {
                double[] sideLength = new double[3];
                sideLength[0] = Vertices[0].Distance(Vertices[1]);
                sideLength[1] = Vertices[1].Distance(Vertices[2]);
                sideLength[2] = Vertices[2].Distance(Vertices[0]);
                Array.Sort(sideLength);

                return sideLength;

            }
        }

        public Triangle(List<Point> vertices) : base (vertices)
        {

        }

        public Triangle(Point v1, Point v2, Point v3) : base (new List<Point>() { v1, v2,v3})
        {

        }

        public override double Area()
        {
            double s = Perimeter() / 2;
            double area = Math.Sqrt(s * (s - SideLength[0]) * (s - SideLength[1]) * (s - SideLength[2]));

            return area;
        }

        public virtual bool IsEquilateral()
        {
            return (Utils.IsRelativelyEqual(SideLength[0], SideLength[2]));
        }

        public virtual bool IsIsosceles()
        {
            return (Utils.IsRelativelyEqual(SideLength[0], SideLength[1]) || Utils.IsRelativelyEqual(SideLength[1], SideLength[2]));
        }

        public virtual bool IsScalene()
        {
            return !IsIsosceles();
        }

        public override string ToString()
        {
            return ("Triangle: " + base.ToString());
        }



    }
}
