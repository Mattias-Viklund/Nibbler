using NibblerProgrammer.Compilation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NibblerProgrammer
{
    public partial class Form1 : Form
    {
        private bool typing = false;
        private bool timerRunning = false;

        private Parser parser = new Parser();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void typingTimer_Tick(object sender, EventArgs e)
        {
            if (!typing)
            {
                timerRunning = false;
                typingTimer.Stop();
                outText.Lines = parser.Parse(codeText.Lines);

            }

            typing = false;

        }

        private void Typing(object sender, EventArgs e)
        {
            if (!timerRunning)
            {
                typingTimer.Start();
                timerRunning = true;

            }

            if (typing != true)
                typing = true;

        }
    }
}
