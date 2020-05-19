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
        /// <summary>
        /// Global variable. 
        /// </summary>
        public int radius = 0;
        public int width = 0;
        public int height = 0;
        public int hypotenus = 0;
        public int counter = 0;
        public int loopnumber = 0;

        TextBox textBox;
        Panel pnldraw;
        Graphics graph;

        String[] maincommand = { "moveto", "drawto", "clear", "reset", "loop", "endloop", "if", "endif" };
        String[] shapecommand = { "circle", "rectangle", "triangle" };
        String[] variable = { "radius", "width", "height", "counter", "hypotenus" };

        public void loadCommand(TextBox textBoxCmd, Graphics graph, Panel panelDraw)
        {
            this.textBox = textBoxCmd;
            this.pnldraw = panelDraw;
            this.graph = graph;

            int numberOfLines = textBoxCmd.Lines.Length;
      
            for (loopnumber = 0; loopnumber < numberOfLines; loopnumber++)
            {
                String oneLineCommand = textBoxCmd.Lines[loopnumber];
                oneLineCommand = oneLineCommand.Trim();
                if (!oneLineCommand.Equals(""))
                {
                    RunCommand(oneLineCommand);
                }
            }
        }
        private void RunCommand(String singleLineCommand)
        {
            ShapeFactory sf = new ShapeFactory();
            Boolean hasEquals = singleLineCommand.Contains("=");
            Boolean hasplus = singleLineCommand.Contains("+");
            singleLineCommand = Regex.Replace(singleLineCommand, @"\s+", " ");
            if (hasEquals)
            {
                string[] words = singleLineCommand.Split(' ');
                for (int i = 0; i < words.Length; i++)
                {
                    words[i] = words[i].Trim();
                }
                String firstWord = words[0].ToLower();
                if (firstWord.Equals("if"))
                {
                    Boolean loop = false;
                    if (words[1].ToLower().Equals("radius"))
                    {
                        if (radius == int.Parse(words[3]))
                        {
                            loop = true;
                        }
                    }
                    else if (words[1].ToLower().Equals("width"))
                    {
                        if (width == int.Parse(words[3]))
                        {
                            loop = true;
                        }
                    }
                    else if (words[1].ToLower().Equals("height"))
                    {
                        if (height == int.Parse(words[3]))
                        {
                            loop = true;
                        }

                    }
                    else if (words[1].ToLower().Equals("counter"))
                    {
                        if (counter == int.Parse(words[3]))
                        {
                            loop = true;
                        }
                    }
                    int ifStartLine = (GetStartLineNumber("if"));
                    int ifEndLine = (GetEndLineNumber("endif") - 1);
                    loopnumber = ifEndLine;
                    if (loop)
                    {
                        for (int j = ifStartLine; j <= ifEndLine; j++)
                        {
                            string oneLineCommand1 = textBox.Lines[j];
                            oneLineCommand1 = oneLineCommand1.Trim();
                            if (!oneLineCommand1.Equals(""))
                            {
                                RunCommand(oneLineCommand1);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("If Statement is false");
                    }
                }
                else
                {
                    string[] words2 = singleLineCommand.Split('=');
                    for (int j = 0; j < words2.Length; j++)
                    {
                        words2[j] = words2[j].Trim();
                    }
                    if (words2[0].ToLower().Equals("radius"))
                    {
                        radius = int.Parse(words2[1]);
                    }
                    else if (words2[0].ToLower().Equals("width"))
                    {
                        width = int.Parse(words2[1]);
                    }
                    else if (words2[0].ToLower().Equals("height"))
                    {
                        height = int.Parse(words2[1]);
                    }
                    else if (words2[0].ToLower().Equals("counter"))
                    {
                        counter = int.Parse(words2[1]);
                    }
                }
            }
          
            else
            {
                MainCommandline(singleLineCommand);
            }
        }
        /// <summary>
        /// Main commandline functon.
        /// </summary>
        /// <param name="textcmdline">string.</param>
        public void MainCommandline(string textcmdline)
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
                        pnldraw.Refresh();
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
                        shp.Draw(graph,0,0);
                    }
                }
                else
                {
                    if (CommandFirstWord.Equals("loop"))
                    {
                        counter = int.Parse(cmdwords[1]);
                        int loopStartLine = (GetStartLineNumber("loop"));
                        int loopEndLine = (GetEndLineNumber("endloop") - 1);
                        loopnumber = loopEndLine;
                        for (int i = 0; i < counter; i++)
                        {
                            for (int j = loopStartLine; j <= loopEndLine; j++)
                            {
                                String oneLineCommand = textBox.Lines[j];
                                oneLineCommand = oneLineCommand.Trim();
                                if (!oneLineCommand.Equals(""))
                                {
                                    RunCommand(oneLineCommand);
                                }
                            }
                        }
                    }
                    else if (CommandFirstWord.Equals("if"))
                    {
                        Boolean loop = false;
                        if (cmdwords[1].ToLower().Equals("radius"))
                        {
                            if (radius == int.Parse(cmdwords[1]))
                            {
                                loop = true;
                            }
                        }
                        else if (cmdwords[1].ToLower().Equals("width"))
                        {
                            if (width == int.Parse(cmdwords[1]))
                            {
                                loop = true;
                            }
                        }
                        else if (cmdwords[1].ToLower().Equals("height"))
                        {
                            if (height == int.Parse(cmdwords[1]))
                            {
                                loop = true;
                            }

                        }
                        else if (cmdwords[1].ToLower().Equals("counter"))
                        {
                            if (counter == int.Parse(cmdwords[1]))
                            {
                                loop = true;
                            }
                        }
                        int ifStartLine = (GetStartLineNumber("if"));
                        int ifEndLine = (GetEndLineNumber("endif") - 1);
                        loopnumber = ifEndLine;
                        if (loop)
                        {
                            for (int j = ifStartLine; j <= ifEndLine; j++)
                            {
                                String oneLineCommand = textBox.Lines[j];
                                oneLineCommand = oneLineCommand.Trim();
                                if (!oneLineCommand.Equals(""))
                                {
                                    RunCommand(oneLineCommand);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public int GetStartLineNumber(string syntax)
        {
            int numberOfCmdLines = textBox.Lines.Length;
            int lineNum = 0;
            for (int i = 0; i < numberOfCmdLines; i++)
            {
                String oneLineCommand = textBox.Lines[i];
                oneLineCommand = Regex.Replace(oneLineCommand, @"\s+", " ");
                string[] words = oneLineCommand.Split(' ');
                //removing white spaces in between words
                for (int j = 0; j < words.Length; j++)
                {
                    words[j] = words[j].Trim();
                }
                String firstWord = words[0].ToLower();
                if (firstWord.Equals(syntax))
                {
                    lineNum = i + 1;
                }
            }
            return lineNum;
        }
        public int GetEndLineNumber(string syntax)
        {
            int numberOfCmdLines = textBox.Lines.Length;
            int lineNum = 0;
            for (int i = 0; i < numberOfCmdLines; i++)
            {
                String oneLineCommand = textBox.Lines[i];
                oneLineCommand = oneLineCommand.Trim();
                if (oneLineCommand.ToLower().Equals(syntax))
                {
                    lineNum = i + 1;
                }
            }
            return lineNum;
        }
    }
}
