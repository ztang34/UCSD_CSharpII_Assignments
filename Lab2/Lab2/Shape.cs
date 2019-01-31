using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public abstract class Shape
    {
        protected List<Point> _Vertices = new List<Point>();

        public virtual List<Point> Vertices
        {
            get
            {
                List<Point> copiedVertices = new List<Point>(_Vertices.Count);
                foreach (Point vertice in _Vertices)
                {
                    copiedVertices.Add(vertice);
                }

                return copiedVertices; //return a copied List
            }
            set
            {
                _Vertices = value;
            }
        }

        public Shape()
        {

        }

        public Shape (List<Point> vertices)
        {
            Vertices = vertices;
        }

        public abstract double Area();

        public virtual double Perimeter ()
        {
            double perimeter = 0;

            for (int i = 0; i< Vertices.Count - 1; ++i)
            {
                perimeter += Vertices[i].Distance(Vertices[i + 1]);
            }

            perimeter += Vertices[Vertices.Count - 1].Distance(Vertices[0]);

            return perimeter;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Point pt in Vertices)
            {
                sb.Append($", {pt}");
            }

            sb.Remove(0, 1); //remove first comma

            return sb.ToString();

        }

    }
}
