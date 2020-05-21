using System.Drawing;

namespace Graphical_PL_Application
{
    /// <summary>
    /// This is the IShape Interface.
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Main methods for drawing shapes. 
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <param name="x">An integer</param>
        /// <param name="y">An integer</param>
        void Draw(Graphics g, int x, int y);
        /// <summary>
        /// Method for getting parameters to draw shapes.
        /// </summary>
        /// <param name="width">Float precision number.</param>
        /// <param name="height">Float precision number.</param>
        /// <param name="hypotenus">Float precision number.</param>
        /// <param name="radius">Float precision number.</param>
        void GetValues(float width, float height, float hypotenus, float radius);
    }
}
