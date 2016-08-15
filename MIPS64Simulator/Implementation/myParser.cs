using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace microMIPS_simulator
{
    public partial class parserForm : Form
    {
        string[] registers = {"R0","R1","R2","R3","R4","R5","R6","R7","R8","R9","R10",
        "R11","R12","R13","R14","R15","R16","R17","R18","R19","R20",
        "R21","R22","R23","R24","R25","R26","R27","R28","R29","R30","R31"};
        string[] commands = { "OR", "DSRLV", "SLT", "NOP", "BNE", "LD", "SD", "DADDIU", "J" };

        bool syntaxErrorFound = false;
        bool semanticErrorFound = false;

        public parserForm()
        {
            InitializeComponent();

            parserBox.Text = "OR R1,R2,R3\r\nL1: DADDIU R1,R2,123\r\nJ L1";

            // 1.R - type instructions: OR, DSRLV, SLT, NOP
            // 2.I - type instructions: BNE, LD, SD, DADDIU
            // 3.J - type instruction: J

            // OR rd,rs,rt
            // DSRLV rd,rt,rs
            // SLT rd,rs,rt

            // BNE rs,rt,offset
            // LD rt,offset(base)
            // SD rt,offset(base)
            // DADDIU rt,rs,immediate

            // J instr_index
        }

        private void parseForm_Click(object sender, EventArgs e)
        {
            resultBox.Clear();

            List<Statement> statementList = new List<Statement>();            

            bool breakLoop = false;

            string sourceCode = parserBox.Text.Replace(" ", string.Empty).ToUpper();

            string[] statements = sourceCode.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            for (int index = 0; index <= statements.Count() - 1; index++) // LEXICAL ANALYSIS
            {
                int lineNumber = index + 1;

                if (statements[index] == "") // if a blank line is found
                {
                    if (index < statements.Count() - 1) // if statement is not the last line
                        index++; // go to next line
                    else if (index == statements.Count() - 1) // if statement is the last line
                        break; // stop the loop
                }
                
                statements[index] += ";";

                char[] characters = statements[index].ToCharArray();
                string[] meaning = new string[characters.Count()];

                bool expectingLabel = false; // checks if there is a label in the statement

                for (int p = 0; p <= characters.Count() - 1; p++)
                {
                    meaning[p] = getCharMeaning(characters[p]); // gets meaning of every character in line
                    if (meaning[p] == "colon")
                    {
                        expectingLabel = true;
                        break;
                    }
                }

                string labelName = "";
                string commandName = "";
                string registerD = "";
                string registerS = "";
                string registerT = "";
                string offset = "";
                string instructionIndex = "";
                string baseContent = "";
                string immediate = "";

                string partialString = "";

                for (int p = 0; p <= characters.Count() - 1 && breakLoop == false; p++)
                {
                    switch (meaning[p])
                    {
                        case "alphabet":
                        case "number":
                            partialString += characters[p];
                            if (expectingLabel == true)
                            {
                                // just let the loop continue
                            }
                            else if (commands.Contains(partialString) == true && commandName == "")
                            {
                                commandName = partialString;
                                partialString = "";
                            }                            
                            break;
                        case "colon":
                            if (labelName == "") // if there is no label yet
                            {
                                labelName = partialString;
                                partialString = "";
                                expectingLabel = false;
                            }
                            else if (labelName != "") // if there is already a label
                            {
                                showSyntaxError(index, "Excess number of colons");
                                breakLoop = true;
                            }
                            break;
                        case "comma":
                            switch (commandName)
                            {
                                case "OR":
                                case "SLT":
                                    if (registerD == "")
                                    {
                                        registerD = partialString;
                                        partialString = "";
                                    }
                                    else if (registerS == "")
                                    {
                                        registerS = partialString;
                                        partialString = "";
                                    }
                                    else
                                    {
                                        showSyntaxError(index, "An extra comma is found");
                                        breakLoop = true;
                                    }
                                    break; // the third register is inserted when newLine is seen
                                case "DSRLV":
                                    if (registerD == "")
                                    {
                                        registerD = partialString;
                                        partialString = "";
                                    }
                                    if (registerT == "")
                                    {
                                        registerT = partialString;
                                        partialString = "";
                                    }
                                    else
                                    {
                                        showSyntaxError(index, "An extra comma is found");
                                        breakLoop = true;
                                    }
                                    break; // the third register is inserted when newLine is seen
                                case "BNE":
                                    if (registerS == "")
                                    {
                                        registerS = partialString;
                                        partialString = "";
                                    }
                                    if (registerT == "")
                                    {
                                        registerT = partialString;
                                        partialString = "";
                                    }
                                    else
                                    {
                                        showSyntaxError(index, "An extra comma is found");
                                        breakLoop = true;
                                    }
                                    break;
                                case "LD":
                                case "SD":
                                    if (registerT == "")
                                    {
                                        registerT = partialString;
                                        partialString = "";
                                    }
                                    else if (registerT != "")
                                    {
                                        showSyntaxError(index, "An extra comma is found");
                                        breakLoop = true;
                                    }
                                    break; // the offset and base is inserted when newLine is seen
                                case "DADDIU":
                                    if (registerT == "")
                                    {
                                        registerT = partialString;
                                        partialString = "";
                                    }
                                    else if (registerS == "")
                                    {
                                        registerS = partialString;
                                        partialString = "";
                                    }
                                    else
                                    {
                                        showSyntaxError(index, "An extra comma is found");
                                        breakLoop = true;
                                    }
                                    break; // the immediate is inserted when newLine is seem
                                case "J":
                                    showSyntaxError(index, "The jump statement must not contain a comma");
                                    breakLoop = true;
                                    break;
                            }
                            break;
                        case "openParenthesis":
                            switch (commandName)
                            {
                                case "LD":
                                case "SD":
                                    if (offset == "")
                                    {
                                        offset = partialString;
                                        partialString = "";
                                    }
                                    else if (offset != "")
                                    {
                                        showSyntaxError(index, "An extra open parenthesis has been found");
                                        breakLoop = true;
                                    }
                                    break;
                                default:
                                    showSyntaxError(index, "An unneeded open parenthesis has been found");
                                    breakLoop = true;
                                    break;
                            }
                            break;
                        case "closeParenthesis":
                            switch (commandName)
                            {
                                case "LD":
                                case "SD":
                                    if (baseContent == "")
                                    {
                                        baseContent = partialString;
                                        partialString = "";
                                    }
                                    else if (baseContent != "")
                                    {
                                        showSyntaxError(index, "An extra close parenthesis has been found");
                                        breakLoop = true;
                                    }
                                    break;
                                default:
                                    showSyntaxError(index, "An unneeded close parenthesis has been found");
                                    breakLoop = true;
                                    break;
                            }
                            break;
                        case "semicolon": // a semicolon is automatically added to the end of the string
                            switch (commandName)
                            {
                                case "OR":
                                case "SLT":
                                    registerT = partialString;
                                    if (registerD == "" || registerS == "" || registerT == "")
                                    {
                                        showSyntaxError(index, "The statement is missing a register");
                                        breakLoop = true;
                                    }
                                    break; // the third register is inserted when newLine is seen
                                case "DSRLV":
                                    registerS = partialString;
                                    if (registerD == "" || registerT == "" || registerS == "")
                                    {
                                        showSyntaxError(index, "The statement is missing a register");
                                        breakLoop = true;
                                    }
                                    break; // the third register is inserted when newLine is seen
                                case "BNE":
                                    if (registerT != "")
                                        offset = partialString;
                                    else if (registerT == "")
                                    {
                                        showSyntaxError(index, "The statement is missing the offset");
                                        breakLoop = true;
                                    }
                                    break;
                                case "DADDIU":
                                    if (registerS != "")
                                        immediate = partialString;
                                    else if (registerS == "")
                                    {
                                        showSyntaxError(index, "The statement is missing the immediate");
                                        breakLoop = true;
                                    }
                                    break; // the immediate is inserted when newLine is seen
                                case "SD":
                                case "LD":
                                    if (registerT == "")
                                    {
                                        showSyntaxError(index, "The statement is missing its register");
                                        breakLoop = true;
                                    }
                                    else if (offset == "")
                                    {
                                        showSyntaxError(index, "The statement is missing its offset");
                                        breakLoop = true;
                                    }
                                    else if (baseContent == "")
                                    {
                                        showSyntaxError(index, "The statement is missing its base");
                                        breakLoop = true;
                                    }
                                    break;
                                case "J":
                                    if (partialString != "")
                                    {
                                        instructionIndex = partialString; // will be reprocessed in pointJump() method
                                    }
                                    else if (partialString == "")
                                    {
                                        showSyntaxError(index, "The statement is missing the target label");
                                        breakLoop = true;
                                    }
                                    break;
                                default:
                                    showSyntaxError(index, "The statement is invalid");
                                    breakLoop = true;
                                    break;
                            }
                            break;
                    }
                }
                
                partialString = "";

                switch (commandName) // SYNTACTICAL ANALYSIS
                {
                    case "OR":
                    case "SLT":
                        if (!registers.Contains(registerT) || !registers.Contains(registerS) || !registers.Contains(registerD))
                            showSyntaxError(index, "The register is not valid");
                        break;
                    case "DSRLV":
                        if (!registers.Contains(registerT) || !registers.Contains(registerS) || !registers.Contains(registerD))
                            showSyntaxError(index, "The register is not valid");
                        break;
                    case "BNE":
                        if (!registers.Contains(registerT) || !registers.Contains(registerS))
                            showSyntaxError(index, "The register is not valid");
                        else if (!isInteger(offset))
                            showSyntaxError(index, "The offset is not integer");
                        break;
                    case "LD":
                    case "SD":
                        if (!registers.Contains(baseContent))
                            showSyntaxError(index, "The base register is invalid");
                        else if (!registers.Contains(registerT))
                            showSyntaxError(index, "The register is invalid");
                        else if (offset == "")
                            showSyntaxError(index, "The offset is missing");
                        break;
                    case "DADDIU":
                        if (!registers.Contains(registerT) || !registers.Contains(registerS))
                            showSyntaxError(index, "The register is invalid");
                        else if (immediate == "")
                            showSyntaxError(index, "The statement is missing an immediate");
                        else if (isInteger(immediate) == false)
                            showSyntaxError(index, "The immediate is not integer");
                        break;
                }

                Statement statement = new Statement(); // every statement will be saved as an object

                statement.lineNumber = index * 4;
                statement.labelName = labelName;
                statement.commandName = commandName;
                statement.registerD = registerD;
                statement.registerS = registerS;
                statement.registerT = registerT;
                statement.offset = offset;
                statement.instructionIndex = instructionIndex;
                statement.baseContent = baseContent;
                statement.immediate = immediate;

                //showObject(statement); // shows this statement's properties

                statementList.Add(statement);   
            }

            pointJumps(statementList);
        }

        private void pointJumps(List<Statement> allStatements)
        {
            bool targetFound = false;
            foreach (Statement fromStatement in allStatements)
            {
                targetFound = false;
                if (fromStatement.commandName == "J")
                {
                    foreach (Statement toStatement in allStatements)
                    {
                        if (fromStatement.instructionIndex == toStatement.labelName)
                        {
                            fromStatement.instructionIndex = toStatement.lineNumber.ToString();
                            targetFound = true;
                            break;
                        }
                    }
                    if (targetFound == false)
                    {
                        showSyntaxError(fromStatement.lineNumber, "The target label is not found");
                        break;
                    }
                }
            }
        }
    }

    public class Statement
    {
        public int lineNumber = 0;
        public string labelName = "";
        public string commandName = "";
        public string registerD = "";
        public string registerS = "";
        public string registerT = "";
        public string offset = "";
        public string instructionIndex = "";
        public string baseContent = "";
        public string immediate = "";
    }

    public partial class parserForm
    {
        private string getCharMeaning(char unknown)
        {
            string meaning = "";

            if (Char.IsLetter(unknown))
                meaning = "alphabet";
            else if (Char.IsDigit(unknown))
                meaning = "number";
            else if (unknown == '(')
                meaning = "openParenthesis";
            else if (unknown == ')')
                meaning = "closeParenthesis";
            else if (unknown == ',')
                meaning = "comma";
            else if (unknown == '#')
                meaning = "sharp";
            else if (unknown == ':')
                meaning = "colon";
            else if (unknown == ';')
                meaning = "semicolon";
            else
                meaning = "unknown";

            return meaning;
        }

        private bool isInt(string maybeHex)
        {
            int justNothing = 0;
            return Int32.TryParse(maybeHex, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.CurrentCulture, out justNothing);
        }

        private void showSyntaxError(int index, string message)
        {
            resultBox.Text += "SYNTAX ERROR IN LINE " + index + ": " + message + Environment.NewLine;
            syntaxErrorFound = true;
        }

        private bool isInteger(string maybeInteger)
        {
            int nothing = 0;
            return int.TryParse(maybeInteger, out nothing);
        }

        private string removeSpaces(string code)
        {
            return string.Join("", code.Split(new char[] { ' ' }));
        }

        private void showObject(Statement statement)
        {
            resultBox.Text += "Line Number: " + statement.lineNumber + Environment.NewLine;
            resultBox.Text += "Label Name: " + statement.labelName + Environment.NewLine;
            resultBox.Text += "Command Name: " + statement.commandName + Environment.NewLine;
            resultBox.Text += "Register D: " + statement.registerD + Environment.NewLine;
            resultBox.Text += "Register S: " + statement.registerS + Environment.NewLine;
            resultBox.Text += "Register T: " + statement.registerT + Environment.NewLine;
            resultBox.Text += "Offset: " + statement.offset + Environment.NewLine;
            resultBox.Text += "Instruction Index: " + statement.instructionIndex + Environment.NewLine;
            resultBox.Text += "Base: " + statement.baseContent + Environment.NewLine;
            resultBox.Text += "Immediate: " + statement.immediate + Environment.NewLine;
            resultBox.Text += Environment.NewLine;
        }
    }
}
