using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_PL_Application
{
    public class ShapeFactory
    {
        public IShape Getshapes(string ShapeType)
        {
            if (ShapeType == null)
            {
                return null;
            }
            if (ShapeType == ("Circle").ToLower())
            {
                return new Circle();
            }
            if (ShapeType == ("Rectangle").ToLower())
            {
                return new Rectangle();
            }
            if (ShapeType == ("Triangle").ToLower())
            {
                return new Triangle();
            }
            return null;
        }
    }
}
