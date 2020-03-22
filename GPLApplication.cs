using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_PL_Application
{
    public partial class GPLApplication : Form
    {
       
        Graphics g;
        public GPLApplication()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
           
        }
        private void btnexecute_Click(object sender, EventArgs e)
        {
            string comm = textBox1.Text;
            Command c = new Command();
            c.Commandline(comm,g);
            c.Movecoordinates(comm, g);
            int ax = c.mouseX;
            int ay = c.mouseY;
            g.TranslateTransform(ax, ay);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
           
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void GPLApplication_Load(object sender, EventArgs e)
        {

        }
    }
}
