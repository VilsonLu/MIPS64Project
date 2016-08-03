using MIPS64Simulator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIPS64Simulator.Models;
using MIPS64Simulator.Helper;

namespace MIPS64Simulator.Implementation
{
    public class Parser : IParser
    {
        #region Constants
        private string[] registers = {"R0","R1","R2","R3","R4","R5","R6","R7","R8","R9","R10",
        "R11","R12","R13","R14","R15","R16","R17","R18","R19","R20",
        "R21","R22","R23","R24","R25","R26","R27","R28","R29","R30","R31"};
        private string[] commands = { "OR", "DSRLV", "SLT", "NOP", "BNE", "LD", "SD", "DADDIU", "J" };
        private OpcodeGenerator opcodeGenerator;
        #endregion

        public Parser()
        {
            opcodeGenerator = new OpcodeGenerator();
        }


        public IEnumerable<Statement> Parse(string code)
        {
            List<Statement> statementList = new List<Statement>();
            string[] statements = code.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            #region Syntatic Analysis
            for (int index = 0; index <= statements.Count() - 1; index++) // LEXICAL ANALYSIS
            {
                int lineNumber = index + 1;
                bool expectingLabel = false;
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

                for (int p = 0; p <= characters.Count() - 1; p++)
                {
                    meaning[p] = GetCharMeaning(characters[p]); // gets meaning of every character in line
                    if (meaning[p] == "colon")
                        expectingLabel = true;
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

                for (int p = 0; p <= characters.Count() - 1; p++)
                {
                    switch (meaning[p])
                    {
                        case "alphabet":
                        case "number":
                            partialString += characters[p];
                            if (commands.Contains(partialString) == true && commandName == "")
                            {
                                if (expectingLabel == true)
                                {
                                    // just let the loop continue until a colon is found
                                }
                                else if (commands.Contains(partialString) == true && commandName == "")
                                {
                                    commandName = partialString;
                                    partialString = "";
                                }                            
                                break;
                            }
                            break;
                        case "colon":
                            if (labelName == "") // if there is no label yet
                            {
                                labelName = partialString;
                                partialString = "";
                            }
                            else if (labelName != "") // if there is already a label
                            {
                                throw new Exception(String.Format("Line {0}: Excess number of colons", index));
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
                                        throw new Exception(String.Format("Line {0}: An extra comma is found", index));
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
                                        throw new Exception(String.Format("Line {0}: An extra comma is found", index));
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
                                        throw new Exception(String.Format("Line {0}: An extra comma is found", index));
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
                                        throw new Exception(String.Format("Line {0}: An extra comma is found", index));
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
                                        throw new Exception(String.Format("Line {0}: An extra comma is found", index));
                                    }
                                    break; // the immediate is inserted when newLine is seem
                                case "J":
                                    throw new Exception(String.Format("Line {0}: The jump statement must not contain a comma", index));
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
                                        throw new Exception(String.Format("Line {0}: An extra open parenthesis has been found", index));
                                    }
                                    break;
                                default:
                                    throw new Exception(String.Format("Line {0}: An unneeded open parenthesis has been found", index));
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
                                        throw new Exception(String.Format("Line {0}:An extra close parenthesis has been found", index));
                                    }
                                    break;
                                default:
                                    throw new Exception(String.Format("Line {0}: An unneeded close parenthesis has been found", index));
                                    
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
                                        throw new Exception(String.Format("Line {0}: The statement is missing a register", index));
                                    }
                                    break; // the third register is inserted when newLine is seen
                                case "DSRLV":
                                    registerS = partialString;
                                    if (registerD == "" || registerT == "" || registerS == "")
                                    {
                                        throw new Exception(String.Format("Line {0}: The statement is missing a register", index));
                                    }
                                    break; // the third register is inserted when newLine is seen
                                case "BNE":
                                    if (registerT != "")
                                        offset = partialString;
                                    else if (registerT == "")
                                    {
                                        throw new Exception(String.Format("Line {0}: The statement is missing the offset", index));
                                    }
                                    break;
                                case "DADDIU":
                                    if (registerS != "")
                                        immediate = partialString;
                                    else if (registerS == "")
                                    {
                                        throw new Exception(String.Format("Line {0}: The statement is missing immediate", index));
                                    }
                                    break; // the immediate is inserted when newLine is seen
                                case "SD":
                                case "LD":
                                    if (registerT == "")
                                    {
                                        throw new Exception(String.Format("Line {0}: The statement is missing its register", index));
                                    }
                                    else if (offset == "")
                                    {
                                        throw new Exception(String.Format("Line {0}: The statement is missing its offset", index));
                                    }
                                    else if (baseContent == "")
                                    {
                                        throw new Exception(String.Format("Line {0}: The statement is missing its base", index));
                                    }
                                    break;
                                case "J":
                                    if (partialString != "")
                                    {
                                        instructionIndex = partialString;
                                        bool targetFound = false;
                                        foreach (Statement statementLine in statementList)
                                        {
                                            if (statementLine.Label == instructionIndex)
                                            {
                                                instructionIndex = statementLine.Line.ToString("D" + 4);
                                                targetFound = true;
                                                break;
                                            }
                                        }
                                        if (targetFound == false)
                                        {
                                            throw new Exception(String.Format("Line {0}: The target label is not found", index));
                                        }
                                    }
                                    else if (partialString != "")
                                    {
                                        throw new Exception(String.Format("Line {0}: The target label is not found", index));
                                    }
                                    break;
                                default:
                                    throw new Exception(String.Format("Line {0}: The statement is invalid", index));
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
                            throw new Exception(String.Format("Line {0}: The register is not valid", index));
                        break;
                    case "DSRLV":
                        if (!registers.Contains(registerT) || !registers.Contains(registerS) || !registers.Contains(registerD))
                            throw new Exception(String.Format("Line {0}: The register is not valid", index));
                        break;
                    case "BNE":
                        if (!registers.Contains(registerT) || !registers.Contains(registerS))
                            throw new Exception(String.Format("Line {0}: The register is not valid", index));
                        else if (!IsInteger(offset))
                            throw new Exception(String.Format("Line {0}: The offset is not integer", index));
                        break;
                    case "LD":
                    case "SD":
                        if (!registers.Contains(baseContent))
                            throw new Exception(String.Format("Line {0}: The base register is invalid", index));
                        else if (!registers.Contains(registerT))
                            throw new Exception(String.Format("Line {0}: The register is invalid", index));
                        else if (offset == "")
                            throw new Exception(String.Format("Line {0}: The offset is missing", index));
                        break;
                    case "DADDIU":
                        if (!registers.Contains(registerT) || !registers.Contains(registerS))
                            throw new Exception(String.Format("Line {0}: The register is invalid", index));
                        else if (immediate == "")
                            throw new Exception(String.Format("Line {0}: The statement is missing an immediate", index));
                        else if (!IsInteger(immediate))
                            throw new Exception(String.Format("Line {0}: The immediate is not integer", index));
                        break;
                }


                Statement statement = new Statement();
                statement.Line = index * 4;
                statement.Label = labelName;
                statement.Instruction = commandName;
                statement.RD = registerD;
                statement.RS = registerS;
                statement.RT = registerT;
                statement.Offset = offset;
                statement.Base = baseContent;
                statement.Immediate = immediate;
                statement.InstructionIndex = instructionIndex;
                statement.InstructionType = GetInstructiontType(commandName);
                statement.Code = statements[index];
                statement.Opcode = opcodeGenerator.GetOpcode(statement);
                statementList.Add(statement);
                
                labelName = "";
                commandName = "";
                registerD = "";
                registerS = "";
                registerT = "";
                offset = "";
                instructionIndex = "";
                baseContent = "";
                immediate = "";

                // return statementList; // returns array of objects containing each statement in code
            }


            #endregion

            return statementList;
        }


        #region Helper Methods
        private string GetCharMeaning(char unknown)
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

        private bool IsInteger(string maybeInteger)
        {
            int nothing = 0;
            return int.TryParse(maybeInteger, out nothing);
        }

        private InstructionType GetInstructiontType(string operation)
        {
            switch (operation.ToUpperInvariant())
            {
                case "OR":
                case "DSRLV":
                case "SLT":
                case "NOP": return InstructionType.RType;

                case "DADDIU":
                case "LD":
                case "SD":
                case "BNE": return InstructionType.IType;

                case "J": return InstructionType.JType;

                default: return InstructionType.Unknown;
            }
        }

        #endregion
    }
}
