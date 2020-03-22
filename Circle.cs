using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphical_PL_Application
{
    public class Circle : IShape
    {
        private float wid;
        private float hght;
        private float hypt;
        private float rad;
        public void GetValue(float width, float height, float hypotenus, float radius)
        {
            wid = width;
            hght = height;
            hypt = hypotenus;
            rad = radius;
        }
        public void Draw(Graphics g,int x,int y)
        {
            //SolidBrush sb = new SolidBrush(Color.Black);
            g.DrawEllipse(new Pen(Color.Black,5),x,y,rad,rad);
            //g.FillEllipse(sb, 100, 100, 100, 100);// int.Parse(txtshapesize.Text), int.Parse(txtshapesize.Text));
        }
    }
}
