using System.Drawing;

namespace Graphical_PL_Application
{
    /// <summary>
    /// Rectangle class.
    /// </summary>
    /// <inheritdoc cref="IShape"/>
    public class Rectangle : IShape
    {
        private float widths;
        private float heights;
        /// <summary>
        /// Get parameters for rectangle.
        /// </summary>
        /// <param name="width">Float precesion number.</param>
        /// <param name="height">Float precesion number.</param>
        /// <param name="hypotenus">Float precesion number.</param>
        /// <param name="radius">Float precesion number.</param>
        public void GetValues(float width, float height, float hypotenus, float radius)
        {
            widths = width;
            heights = height;
        }
        /// <summary>
        /// Draw the rectangle.
        /// </summary>
        /// <param name="g">Graphics.</param>
        /// <param name="x">An integer.</param>
        /// <param name="y">An integer.</param>
        public void Draw(Graphics g, int x, int y)
        {
            //SolidBrush sb = new SolidBrush(Color.Red);
            //g.FillRectangle(sb, x, y, 2 *fl,fl);
            g.DrawRectangle(new Pen(Color.Black, 5), x, y, widths, heights);
        }
    }
}
