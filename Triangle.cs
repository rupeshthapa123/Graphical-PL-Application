using System;
using System.Drawing;
using System.Windows.Forms;

namespace Graphical_PL_Application
{
    /// <summary>
    /// Triangle class.
    /// </summary>
    /// <inheritdoc cref="IShape"/>
    public class Triangle : IShape
    {
        private float widths;
        private float heights;
        private float hypotnus;
        /// <summary>
        /// Get parameter for triangle.
        /// </summary>
        /// <param name="width">Float precesion number.</param>
        /// <param name="height">Float precesion number.</param>
        /// <param name="hypotenus">Float precesion number.</param>
        /// <param name="radius">Float precesion number.</param>
        public void GetValues(float width, float height, float hypotenus, float radius)
        {
            widths = width;
            heights = height;
            hypotnus = hypotenus;
        }
        /// <summary>
        /// Check triangle exist or not.
        /// </summary>
        /// <returns>true or false.</returns>
        public Boolean checkTriangleValidity()
        {
            // check condition for triangle
            if (widths + heights <= hypotnus || widths + hypotnus <= heights || heights + hypotnus <= widths)
                return false;
            else
                return true;
        }
        /// <summary>
        /// Draw the triangle.
        /// </summary>
        /// <param name="g">Graphics.</param>
        /// <param name="x">An integer.</param>
        /// <param name="y">An integer.</param>
        public void Draw(Graphics g, int x, int y)
        {
            if (checkTriangleValidity())
            {
                Pen mypn = new Pen(Color.Black, 5);
                
                Point[] points = new Point[3];
                points[0].X = 10;
                points[0].Y = 10;

                points[1].X = Convert.ToInt32(50 - widths);
                points[1].Y = 10;

                points[2].X = 10;
                points[2].Y = Convert.ToInt32(50 - heights);

                g.DrawPolygon(mypn, points);
            }
            else
            {
                MessageBox.Show("Value not provided properly");
            }
        }
    }
}
