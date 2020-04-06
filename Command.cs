using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Graphical_PL_Application
{
    /// <summary>
    /// Command class.
    /// </summary>
    /// <seealso cref="GPLApplication" />
    public class Command : GPLApplication
    {
        private int movetoX;
        private int movetoY;
        private int drawtoX;
        private int drawtoY;
        
        String[] maincommand = { "moveto", "drawto", "clear", "reset" };
        String[] shapecommand = { "circle", "rectangle", "triangle" };
        /// <summary>
        /// Main commandline functon.
        /// </summary>
        /// <param name="textcmdline">string.</param>
        /// <param name="graph">Graphics.</param>
        /// <param name="pnl">Panel.</param>
        public void MainCommandline(string textcmdline, Graphics graph, Panel pnl)
        {
            try
            {
                //removing spaces in between commands from a particular command line
                textcmdline = Regex.Replace(textcmdline, @"\s+", " ");
                string[] cmdwords = textcmdline.Split(' ');
                for (int i = 0; i < cmdwords.Length; i++)
                {
                    cmdwords[i] = cmdwords[i].Trim();
                }

                String CommandFirstWord = cmdwords[0].ToLower();
                Boolean firstWordCommand = maincommand.Contains(CommandFirstWord);
                Boolean firstWordShape = shapecommand.Contains(CommandFirstWord);

                ShapeFactory sf = new ShapeFactory();

                if (firstWordCommand)
                {
                    if (CommandFirstWord.ToLower().Equals("moveto"))
                    {
                        String cmdargs = textcmdline.Substring(6, (textcmdline.Length - 6));
                        String[] parameters = cmdargs.Split(',');
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            parameters[i] = parameters[i].Trim();
                        }
                        movetoX = int.Parse(parameters[0]);
                        movetoY = int.Parse(parameters[1]);
                        graph.TranslateTransform(movetoX, movetoY);
                    }

                    else if (CommandFirstWord.ToLower().Equals("drawto"))
                    {
                        String cmdargs = textcmdline.Substring(6, (textcmdline.Length - 6));
                        String[] parameters = cmdargs.Split(',');
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            parameters[i] = parameters[i].Trim();
                        }
                        drawtoX = int.Parse(parameters[0]);
                        drawtoY = int.Parse(parameters[1]);
                        graph.TranslateTransform(drawtoX, drawtoY);
                    }
                    else if (CommandFirstWord.ToLower().Equals("clear"))
                    {
                        pnl.Refresh();
                    }
                    else if (CommandFirstWord.ToLower().Equals("reset"))
                    {
                        graph.ResetTransform();
                    }
                }

                else if (firstWordShape)
                {
                    if (CommandFirstWord.ToLower().Equals("circle"))
                    {
                        String cmdargs = textcmdline.Substring(6, (textcmdline.Length - 6));
                        String[] parameters = cmdargs.Split(',');
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            parameters[i] = parameters[i].Trim();
                        }

                        IShape sh = sf.Getshapes("circle");
                        sh.GetValues(0, 0, 0, float.Parse(cmdwords[1]));
                        sh.Draw(graph, 0, 0);
                    }

                    else if (CommandFirstWord.ToLower().Equals("rectangle"))
                    {
                        String cmdargs = textcmdline.Substring(9, (textcmdline.Length - 9));
                        String[] parameters = cmdargs.Split(',');
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            parameters[i] = parameters[i].Trim();
                        }

                        IShape shc = sf.Getshapes("rectangle");
                        shc.GetValues(float.Parse(parameters[0]), float.Parse(parameters[1]), 0, 0);
                        shc.Draw(graph, 0, 0);
                    }

                    else if (CommandFirstWord.ToLower().Equals("triangle"))
                    {
                        String cmdargs = textcmdline.Substring(8, (textcmdline.Length - 8));
                        String[] parameters = cmdargs.Split(',');
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            parameters[i] = parameters[i].Trim();
                        }

                        IShape shp = sf.Getshapes("triangle");
                        shp.GetValues(float.Parse(parameters[0]), float.Parse(parameters[1]), float.Parse(parameters[2]), 0);
                        shp.Draw(graph, 0, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
