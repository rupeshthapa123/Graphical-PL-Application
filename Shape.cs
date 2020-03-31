using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphical_PL_Application
{
    public interface IShape
    {
       void Draw(Graphics g,int x,int y);
       void GetValues(float width, float height, float hypotenus, float radius);
    }
}
