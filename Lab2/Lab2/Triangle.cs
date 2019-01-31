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
                if (Vertices.Count != 3)
                {
                    throw new ArgumentException("Vertices", "Triangle can only have 3 vertices!");
                }
                else
                {
                    Vertices = value;
                }

            }
        }



    }
}
