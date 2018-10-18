namespace NibblerProgrammer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.codeText = new System.Windows.Forms.RichTextBox();
            this.outText = new System.Windows.Forms.RichTextBox();
            this.typingTimer = new System.Windows.Forms.Timer(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // codeText
            // 
            this.codeText.Location = new System.Drawing.Point(9, 10);
            this.codeText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.codeText.Name = "codeText";
            this.codeText.Size = new System.Drawing.Size(442, 421);
            this.codeText.TabIndex = 0;
            this.codeText.Text = "";
            this.codeText.TextChanged += new System.EventHandler(this.Typing);
            // 
            // outText
            // 
            this.outText.Location = new System.Drawing.Point(454, 10);
            this.outText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.outText.Name = "outText";
            this.outText.ReadOnly = true;
            this.outText.Size = new System.Drawing.Size(168, 421);
            this.outText.TabIndex = 1;
            this.outText.Text = "";
            // 
            // typingTimer
            // 
            this.typingTimer.Interval = 1000;
            this.typingTimer.Tick += new System.EventHandler(this.typingTimer_Tick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(626, 10);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(131, 421);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 440);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.outText);
            this.Controls.Add(this.codeText);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "PP";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox codeText;
        private System.Windows.Forms.RichTextBox outText;
        private System.Windows.Forms.Timer typingTimer;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

