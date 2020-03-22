using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphical_PL_Application
{
    public class Rectangle : IShape
    {
        private float wid;
        private float hght;
        public void GetValue(float width, float height, float hypotenus, float radius)
        {
            wid = width;
            hght = height;
        }
        public void Draw(Graphics g,int x,int y)
        {
            //SolidBrush sb = new SolidBrush(Color.Red);
            //g.FillRectangle(sb, x, y, 2 *fl,fl);
            g.DrawRectangle(new Pen(Color.Black,5), x, y, wid, hght);
        }
    }
}
