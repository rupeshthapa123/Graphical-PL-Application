using System.Drawing;

namespace Graphical_PL_Application
{
    /// <summary>
    /// Circle Class.
    /// </summary>
    /// <inheritdoc cref="IShape"/>
    public class Circle : IShape
    {
        private float rad;
        /// <summary>
        /// Get parameter for drawing circle.
        /// </summary>
        /// <param name="width">float precision number.</param>
        /// <param name="height">float precision number.</param>
        /// <param name="hypotenus">float precision number.</param>
        /// <param name="radius">float precision number.</param>
        public void GetValues(float width, float height, float hypotenus, float radius)
        {
            rad = radius;
        }
        /// <summary>
        /// Draw the circle.
        /// </summary>
        /// <param name="g">Graphics.</param>
        /// <param name="x">An integer.</param>
        /// <param name="y">An integer.</param>
        public void Draw(Graphics g, int x, int y)
        {
            //SolidBrush sb = new SolidBrush(Color.Black);
            g.DrawEllipse(new Pen(Color.Black, 5), x, y, rad, rad);
            //g.FillEllipse(sb, 100, 100, 100, 100);
            // int.Parse(txtshapesize.Text), int.Parse(txtshapesize.Text));
        }
    }
}
