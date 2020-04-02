using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace Graphical_PL_Application
{
    public partial class GPLApplication : Form
    {
        Graphics g;
        public GPLApplication()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();       
        }
        private void btnexecute_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && !textBox1.Text.Equals(""))
            {
                CommandValidations cmdval = new CommandValidations(textBox1);
                if(!cmdval.IsCommandInvalid)
                {
                    try
                    {                        
                        string comm = textBox1.Text;
                        Command c = new Command();
                        c.MainCommandline(comm, g);
                    }
                    catch (Exception exc)
                    {
                        txtErrorOutput.Text += "\r\n" + exc.ToString();
                    }
                }
                else if (!cmdval.IsSyntaxValid)
                {
                    txtErrorOutput.Text += "\r\n Command Syntax Error.";
                }
                else if (!cmdval.IsParameterValid)
                {
                    txtErrorOutput.Text += "\r\n Paramter Error.";
                }
                else
                {
                    txtErrorOutput.Text += "\r\n Command Errors. Click Help for checking commands and syntax.";
                }
            }
            else
            {
                txtErrorOutput.Text += (" Command Field Is Empty !!!!!");
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void GPLApplication_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            txtErrorOutput.Text = "";
            panel1.Refresh();
        }
        private void btnreset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            txtErrorOutput.Text = "";
            panel1.Refresh();
            g.ResetTransform();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "TXT files(*.txt)|*.txt|All files(*.*)|*.*";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter write = new StreamWriter(File.Create(save.FileName));
                    write.WriteLine(textBox1.Text);
                    write.Close();
                    MessageBox.Show("File Saved Successfully");
                }
            }
            catch(IOException)
            {
                MessageBox.Show("Error","IO Exception");
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Stream stream = null;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Browse File from Specific Folder";
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "TXT files(*.txt)|*.txt|All files(*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if ((stream = openFileDialog.OpenFile()) != null)
                    {
                        using (stream)
                        {
                            textBox1.Text = File.ReadAllText(openFileDialog.FileName);
                        }
                    }
                }
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("Error", "File not Found");
            }
            catch (IOException)
            {
                MessageBox.Show("Error", "IO exception");
            }        
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtErrorOutput.Text = "";
            string help = "Commands :\r\n moveto X,Y  =>(Move Pen Postion) \r\n drawto X,Y =>(Move Position)" +
                "\r\n \r\nDraw Commands :\r\n( Circle radius )\r\n( Rectangle Width,height )" +
                "\r\n(Triangle width,height,hypotenus)";

            txtErrorOutput.Text = help;
        }
    }
}
