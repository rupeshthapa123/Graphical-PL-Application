using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Graphical_PL_Application
{
    public class CommandValidations
    {
        private Boolean Validcmd = true;
        public bool IsCmdValid 
        { 
            get => Validcmd; 
            set => Validcmd = value;
        }

        private Boolean ValidSyntax = true;
        public bool IsSyntaxValid 
        {
            get => ValidSyntax;
            set => ValidSyntax = value; 
        }
        
        private Boolean ValidParameter = true;
        public bool IsParameterValid 
        {
            get => ValidParameter; 
            set => ValidParameter = value;
        }

        private Boolean iscommandinvalid = false;
        public bool IsCommandInvalid 
        { 
            get => iscommandinvalid;
            set => iscommandinvalid = value; 
        }

        private int LineNumber = 0;

        public CommandValidations(TextBox textBoxCmd)
        {
            int numberOfCmdLines = textBoxCmd.Lines.Length;     
            if (numberOfCmdLines == 0) 
            {
                IsCmdValid = false;
            }
            else
            {
                for (int i = 0; i < numberOfCmdLines; i++)
                {
                    String SingleCmdLine = textBoxCmd.Lines[i];
                    SingleCmdLine = SingleCmdLine.Trim();
                    if (!SingleCmdLine.Equals(""))
                    {
                        CheckCmdLineValidation(SingleCmdLine);
                        LineNumber = (i + 1);
                        if (!IsCmdValid)
                        {
                            if (!IsParameterValid) 
                            {
                                MessageBox.Show("Paramter error at : " + LineNumber); 
                            }
                            else if (!IsSyntaxValid) 
                            {
                                MessageBox.Show("Syntax error at : " + LineNumber);
                            }
                            else 
                            { 
                                MessageBox.Show(" Command error at : " + LineNumber); 
                            }
                            
                            IsCommandInvalid = true;
                        }
                    }
                }
            }
        }
        public void CheckCmdLineValidation(string command)
        {
            String[] Syntax = { "drawto", "moveto"};
            String[] Shapes = { "circle", "rectangle", "triangle" };
            String[] Variables = { "radius", "width", "height", "hypotenuse" };
           
            command = Regex.Replace(command, @"\s+", " ");
            string[] commandsAfterSpliting = command.Split(' ');
            for (int i = 0; i < commandsAfterSpliting.Length; i++)
            {
                commandsAfterSpliting[i] = commandsAfterSpliting[i].Trim();
            }
           
            String CommandlineWord = commandsAfterSpliting[0].ToLower();
            Boolean CmdisSyntax = Syntax.Contains(CommandlineWord);
            Boolean CmdisShape = Shapes.Contains(CommandlineWord);
            Boolean CmdisVariable = Variables.Contains(CommandlineWord);

            if (CmdisSyntax)
            {
                if (CommandlineWord.Equals("drawto") || CommandlineWord.Equals("moveto"))
                {
                    String args = command.Substring(6, (command.Length - 6));
                    String[] parameters = args.Split(',');

                    if (parameters.Length == 2)
                    {
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            if (!parameters[i].Trim().All(char.IsDigit))
                            {
                                IsCmdValid = false;
                            }
                        }
                    }
                    else
                    {
                        IsCmdValid = false;
                    }
                }
            }
           
            else if (CmdisShape)
            {
                if (CommandlineWord.ToLower().Equals("circle"))
                {
                    if (commandsAfterSpliting.Length == 2)
                    {
                        if (commandsAfterSpliting[1].Trim().All(char.IsDigit))
                        {
                        }
                        else if (commandsAfterSpliting[1].Trim().All(char.IsLetter))
                        {
                            if (Variables.Contains(commandsAfterSpliting[1].ToLower()))
                            {
                            }
                            else 
                            {
                                IsCmdValid = false;
                                IsParameterValid = false;
                            }
                        }
                        else
                        {
                            IsCmdValid = false; 
                            IsParameterValid = false;
                        }
                    }
                    else
                    { 
                        IsCmdValid = false;
                        IsParameterValid = false;
                    }
                }
                else if (CommandlineWord.ToLower().Equals("rectangle"))
                {
                    String args = command.Substring(9, (command.Length - 9));
                    String[] parameter = args.Split(',');

                    if (parameter.Length == 2)
                    {
                        for (int i = 0; i < parameter.Length; i++)
                        {
                            parameter[i] = parameter[i].Trim();
                            if (parameter[i].All(char.IsDigit))
                            {
                            }
                            else if (parameter[i].All(char.IsLetter))
                            {
                                if (Variables.Contains(parameter[i].ToLower()))
                                {
                                }
                                else 
                                {
                                    IsCmdValid = false;
                                    IsParameterValid = false;
                                }
                            }
                            else 
                            {
                                IsCmdValid = false;
                                IsParameterValid = false;
                            }
                        }
                    }
                    else
                    {
                        IsCmdValid = false;
                        IsParameterValid = false;
                    }
                }
                else if (CommandlineWord.ToLower().Equals("triangle"))
                {
                    String args = command.Substring(8, (command.Length - 8));
                    String[] parameter = args.Split(',');

                    if (parameter.Length == 3)
                    {
                        for (int i = 0; i < parameter.Length; i++)
                        {
                            parameter[i] = parameter[i].Trim();
                            if (parameter[i].All(char.IsDigit))
                            {
                            }
                            else if (parameter[i].All(char.IsLetter))
                            {
                                if (Variables.Contains(parameter[i].ToLower()))
                                {
                                }
                                else
                                {
                                    IsCmdValid = false;
                                    IsParameterValid = false; 
                                }
                            }
                            else 
                            {
                                IsCmdValid = false;
                                IsParameterValid = false; 
                            }
                        }
                    }
                    else 
                    {
                        IsCmdValid = false;
                        IsParameterValid = false;
                    }
                }
            }
            else if (CmdisVariable)
            {
                if (commandsAfterSpliting.Length == 3)
                {
                    if (commandsAfterSpliting[1].Equals("="))
                    {
                        if (!commandsAfterSpliting[2].Trim().All(char.IsDigit)) 
                        {
                            IsCmdValid = false;
                            IsParameterValid = false;
                        }
                    }
                    else
                    {
                        IsCmdValid = false;
                    }
                }
                else
                {
                    IsCmdValid = false; 
                }
            }
            else
            {
                IsCmdValid = false; 
                IsSyntaxValid = false; 
            }
            if (!IsCmdValid)
            {
                IsCommandInvalid = true;
            }
        }
    }
}