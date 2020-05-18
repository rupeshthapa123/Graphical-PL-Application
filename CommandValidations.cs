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

        /// <summary>
        /// lineNumber: indicates line number of the command in the multi-textline control.
        /// </summary>
        private int lineNumber = 0;

        /// <summary>
        /// doesCmdHasLoop: indicates whether command has "LOOP" keyword in the multi-textline control.
        /// </summary>
        private Boolean doesCmdHasLoop = false;

        /// <summary>
        /// doesCmdHasEndLoop: indicates whether command has "ENDLOOP" keyword in the multi-textline control.
        /// </summary>
        private Boolean doesCmdHasEndLoop = false;

        /// <summary>
        /// doesCmdHasIf: indicates whether command has "IF" keyword in the multi-textline control.
        /// </summary>
        private Boolean doesCmdHasIf = false;

        /// <summary>
        /// doesCmdHasEndif: indicates whether command has "ENDIF" keyword in the multi-textline control.
        /// </summary>
        private Boolean doesCmdHasEndif = false;

        /// <summary>
        /// doesCmdHasEndif: indicates whether command has "ENDIF" keyword in the multi-textline control.
        /// </summary>
        private int endIfLineNo = 0;
        private int loopLineNo;
        private int endLoopLineNo;
        private int ifLineNo;

        /// <summary>Gets or sets the line number.</summary>
        /// <value>The line number.</value>
        public int LineNumber { get => lineNumber; set => lineNumber = value; }
        /// <summary>Gets or sets a value indicating whether [does command has loop].</summary>
        /// <value>
        ///   <c>true</c> if [does command has loop]; otherwise, <c>false</c>.</value>
        public bool DoesCmdHasLoop { get => doesCmdHasLoop; set => doesCmdHasLoop = value; }
        /// <summary>Gets or sets a value indicating whether [does command has end loop].</summary>
        /// <value>
        ///   <c>true</c> if [does command has end loop]; otherwise, <c>false</c>.</value>
        public bool DoesCmdHasEndLoop { get => doesCmdHasEndLoop; set => doesCmdHasEndLoop = value; }
        /// <summary>Gets or sets a value indicating whether [does command has if].</summary>
        /// <value>
        ///   <c>true</c> if [does command has if]; otherwise, <c>false</c>.</value>
        public bool DoesCmdHasIf { get => doesCmdHasIf; set => doesCmdHasIf = value; }
        /// <summary>Gets or sets a value indicating whether [does command has endif].</summary>
        /// <value>
        ///   <c>true</c> if [does command has endif]; otherwise, <c>false</c>.</value>
        public bool DoesCmdHasEndif { get => doesCmdHasEndif; set => doesCmdHasEndif = value; }
        /// <summary>Gets or sets the loop line no.</summary>
        /// <value>The loop line no.</value>
        public int LoopLineNo { get => loopLineNo; set => loopLineNo = value; }
        /// <summary>Gets or sets the end loop line no.</summary>
        /// <value>The end loop line no.</value>
        public int EndLoopLineNo { get => endLoopLineNo; set => endLoopLineNo = value; }
        /// <summary>Gets or sets if line no.</summary>
        /// <value>If line no.</value>
        public int IfLineNo { get => ifLineNo; set => ifLineNo = value; }
        /// <summary>Gets or sets the end if line no.</summary>
        /// <value>The end if line no.</value>
        public int EndIfLineNo { get => endIfLineNo; set => endIfLineNo = value; }

        TextBox textBoxCmd;
        /// <summary>
        /// Check the command validations.
        /// </summary>
        /// <param name="textBoxCmd">Textbox</param>
        public CommandValidations(TextBox textBoxCmd)
        {
            this.textBoxCmd = textBoxCmd;
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
                                MessageBox.Show("Command Not Found Error at : " + LineNumber);
                            }
                            else
                            {
                                MessageBox.Show("Syntax error at : " + LineNumber);
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
            String[] Syntax = { "drawto", "moveto", "clear", "reset", "loop", "endloop", "if", "endif" };
            String[] Shapes = { "circle", "rectangle", "triangle" };
            String[] Variables = { "radius", "width", "height", "counter", "hypotenuse" };

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
                else if (CommandlineWord.Equals("loop"))
                {
                    if (commandsAfterSpliting.Length == 2)
                    {
                        if (!commandsAfterSpliting[1].Trim().All(char.IsDigit))
                        {
                            IsCmdValid = false;
                        }
                    }
                    else
                    {
                        IsCmdValid = false;
                    }
                }
                else if (CommandlineWord.Equals("endloop"))
                {
                    if (commandsAfterSpliting.Length == 1)
                    {
                        if (!commandsAfterSpliting[0].Equals("endloop"))
                        {
                            IsCmdValid = false;
                        }
                    }
                    else
                    {
                        IsCmdValid = false;
                    }
                }//endif
                else if (CommandlineWord.Equals("if"))//if radius = x then
                {
                    if (commandsAfterSpliting.Length == 5)
                    {
                        if (Variables.Contains(commandsAfterSpliting[1].ToLower()))
                        {
                            if (commandsAfterSpliting[2].Equals("="))
                            {
                                if (commandsAfterSpliting[3].Trim().All(char.IsDigit))
                                {
                                    if (!commandsAfterSpliting[4].ToLower().Equals("then"))
                                    {
                                        IsCmdValid = false;
                                    }
                                }
                                else { IsCmdValid = false; }

                            }
                            else { IsCmdValid = false; }
                        }
                        else { IsCmdValid = false; }

                    }
                    else { IsCmdValid = false; }

                }
                else if (CommandlineWord.Equals("endif"))
                {
                    if (commandsAfterSpliting.Length != 1)
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
        public void CheckCmdLoopAndIfValidation()
        {
            int numberOfLines = textBoxCmd.Lines.Length;
            for (int i = 0; i < numberOfLines; i++)
            {
                String singleLineCmd = textBoxCmd.Lines[i];
                singleLineCmd = singleLineCmd.Trim();
                if (!singleLineCmd.Equals(""))
                {
                    DoesCmdHasLoop = Regex.IsMatch(singleLineCmd.ToLower(), "loop");
                    if (DoesCmdHasLoop)
                    {
                        LoopLineNo = (i + 1);
                    }
                    DoesCmdHasEndLoop = singleLineCmd.ToLower().Contains("endloop");
                    if (DoesCmdHasEndLoop)
                    {
                        EndLoopLineNo = (i + 1);
                    }
                    DoesCmdHasIf = Regex.IsMatch(singleLineCmd.ToLower(), "if");
                    if (DoesCmdHasIf)
                    {
                        IfLineNo = (i + 1);
                    }
                    DoesCmdHasEndif = singleLineCmd.ToLower().Contains("endif");
                    if (DoesCmdHasEndif)
                    {
                        EndIfLineNo = (i + 1);
                    }
                }
            }
            if (DoesCmdHasLoop)
            {
                if (DoesCmdHasEndLoop)
                {
                    if (LoopLineNo > EndLoopLineNo)
                    {
                        IsCmdValid = false;
                        MessageBox.Show("'ENDLOOP' must be after loop start: Loop starts at" + LoopLineNo + " Loop ends at: " + EndLoopLineNo);
                    }
                }
                else
                {
                    IsCmdValid = false;
                    MessageBox.Show("Loop Not Ended with 'ENDLOOP'");
                }
            }
            if (DoesCmdHasIf)
            {
                if (DoesCmdHasEndif)
                {
                    if (EndIfLineNo < IfLineNo)
                    {
                        IsCmdValid = false;
                        MessageBox.Show("'ENDIF' must be after IF: If starts at" + IfLineNo + " and ends at: " + EndIfLineNo);
                    }
                }
                else
                {
                    IsCmdValid = false;
                    MessageBox.Show("IF Not Ended with 'ENDIF'");
                }
            }
        }
    }
}