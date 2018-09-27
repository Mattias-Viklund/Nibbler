using NibblerProgrammer.Compilation.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibblerProgrammer.Compilation
{
    class Parser
    {
        public Parser()
        {
            InstructionBase.InitializeList();

        }

        public string[] Parse(string[] lines)
        {
            if (lines.Length == 0)
                return null;

            string[] nibblerLines = new string[lines.Length];

            int currentLine = 0;
            foreach (string s in lines)
            {
                string line = s.Trim().ToUpper();
                string[] words = line.Split(' ');

                // DEFAULT INSTRUCTION NOP
                nibblerLines[currentLine] = InstructionBase.instructions[0].Parse(words);

                foreach (InstructionBase instruction in InstructionBase.instructions)
                {
                    if (instruction.GetKey() == words[0])
                        nibblerLines[currentLine] = instruction.Parse(words);

                }
                currentLine++;

            }
            return nibblerLines;

        }
    }
}
