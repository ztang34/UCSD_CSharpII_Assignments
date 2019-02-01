using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Rectangle : Shape
    {
        public override List<Point> Vertices
        {
            get
            {
                return base.Vertices;
            }
            set
            {
                if (value.Count == 2 || value.Count == 4)
                {
                    _Vertices = Normalize(value); //call Normalize method to get vertices of rectangle
                }
                else
                {
                    throw new ArgumentException("Vertices", "Rectangle can only have two or 4 vertices");
                }
            }
        }

        public double Width
        {
            get
            {
                var bounds = Utils.GetBoundingBox(Vertices);
                return (bounds.Item3 - bounds.Item1);
            }

        }

        public double Height
        {
            get
            {
                var bounds = Utils.GetBoundingBox(Vertices);
                return (bounds.Item4 - bounds.Item2);
            }
        }

        public Rectangle(List<Point> vertices)
        {
            Vertices = vertices;
        }

        public Rectangle(Point v1, Point v2) : this(new List<Point>() { v1, v2 })
        {

        }

        public Rectangle(Point v1, Point v2, Point v3, Point v4) : this(new List<Point>() { v1, v2, v3, v4 })
        {

        }

        public override double Area()
        {
            return Width * Height;
        }

        public bool IsSquare()
        {
            return (Height == Width);
        }

        public List<Triangle> ToTriangles()
        {
            List<Triangle> triangles = new List<Triangle>();
            triangles.Add(new Triangle(Vertices[0], Vertices[1], Vertices[2])); //break Rectangle into two triangles
            triangles.Add(new Triangle(Vertices[2], Vertices[3], Vertices[0]));

            return triangles;
        }

        public override string ToString()
        {
            return "Rectangle: "+  base.ToString();
        }

        private List<Point> Normalize (List<Point> input)
        {          
          var bounds = Utils.GetBoundingBox(input); //use GetBoundingBox to normalize input vertices to make a rectangle

          Point pt1 = new Point(bounds.Item1, bounds.Item2);
          Point pt2 = new Point(bounds.Item1, bounds.Item4);
          Point pt3 = new Point(bounds.Item3, bounds.Item4);
          Point pt4 = new Point(bounds.Item3, bounds.Item2);

          return new List<Point>() { pt1, pt2, pt3, pt4 };      
        }


    }
}
