using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphical_PL_Application
{
    public class Triangle : IShape
    {
        private float widths;
        private float heights;
        private float hypotnus;
        public void GetValues(float width, float height, float hypotenus, float radius)
        {
            widths = width;
            heights = height;
            hypotnus = hypotenus;
        }
        public Boolean checkTriangleValidity()
        {
            // check condition for triangle
            if (widths + heights <= hypotnus || widths + hypotnus <= heights || heights + hypotnus <= widths)
                return false;
            else
                return true;
        }
        public void Draw(Graphics g,int x,int y)
        {
            if (checkTriangleValidity())
            {
                Pen mypn = new Pen(Color.Black,5);
                Point[] points= new Point[3];

                points[0].X = x;
                points[0].Y = y;

                points[1].X = Convert.ToInt32(x - widths);
                points[1].Y = y;

                points[2].X = x;
                points[2].Y = Convert.ToInt32(y - heights);

                g.DrawPolygon(mypn, points);
            }
        }   
    }
}
