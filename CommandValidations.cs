using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Graphical_PL_Application
{
    /// <summary>
    /// CommandValidation class.
    /// </summary>
    public class CommandValidations
    {
        private Boolean Validcmd = true;
        /// <summary>Gets or sets a value indicating whether this instance is command valid.</summary>
        /// <value>
        /// <c>true</c> if this instance is command valid; otherwise, <c>false</c>.</value>
        public bool IsCmdValid
        {
            get => Validcmd;
            set => Validcmd = value;
        }

        private Boolean ValidSyntax = true;
        /// <summary>Gets or sets a value indicating whether this instance is Syntax valid.</summary>
        /// <value>
        /// <c>true</c> if this instance is syntax valid; otherwise, <c>false</c>.</value>
        public bool IsSyntaxValid
        {
            get => ValidSyntax;
            set => ValidSyntax = value;
        }

        private Boolean ValidParameter = true;
        /// <summary>Gets or sets a value indicating whether this instance is parameter valid.</summary>
        /// <value>
        /// <c>true</c> if this instance is parameter valid; otherwise, <c>false</c>.</value>
        public bool IsParameterValid
        {
            get => ValidParameter;
            set => ValidParameter = value;
        }

        private Boolean iscommandinvalid = false;
        /// <summary>Gets or sets a value indicating whether this instance is command invalid.</summary>
        /// <value>
        /// <c>true</c> if this instance is command invalid; otherwise, <c>false</c>.</value>
        public bool IsCommandInvalid
        {
            get => iscommandinvalid;
            set => iscommandinvalid = value;
        }

        private int LineNumber = 0;
        /// <summary>
        /// Check the command validations.
        /// </summary>
        /// <param name="textBoxCmd">Textbox</param>
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
        /// <summary>
        /// Check commands for any error such as syntax, parameter or validity.
        /// </summary>
        /// <param name="command">string</param>
        public void CheckCmdLineValidation(string command)
        {
            String[] Syntax = { "drawto", "moveto", "clear", "reset" };
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
                else if (CommandlineWord.Equals("clear") || CommandlineWord.Equals("reset"))
                {
                    IsCmdValid = true;
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