namespace Graphical_PL_Application
{
    /// <summary>
    /// ShapeFactory class. 
    /// </summary>
    public class ShapeFactory
    {
        /// <summary>
        /// Get the shape implementing interface.
        /// </summary>
        /// <param name="ShapeType">String</param>
        /// <returns>Shape</returns>
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
