namespace AutoCoder_UI
{
    partial class Form3
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
            send = new Button();
            output = new RichTextBox();
            uinput = new TextBox();
            SuspendLayout();
            // 
            // send
            // 
            send.Location = new Point(637, 360);
            send.Name = "send";
            send.Size = new Size(99, 53);
            send.TabIndex = 0;
            send.Text = "Send";
            send.UseVisualStyleBackColor = true;
            send.Click += send_Click;
            // 
            // output
            // 
            output.Location = new Point(25, 22);
            output.Name = "output";
            output.Size = new Size(711, 313);
            output.TabIndex = 1;
            output.Text = "";
            // 
            // uinput
            // 
            uinput.Location = new Point(25, 390);
            uinput.Name = "uinput";
            uinput.Size = new Size(572, 23);
            uinput.TabIndex = 2;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(uinput);
            Controls.Add(output);
            Controls.Add(send);
            Name = "Form3";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button send;
        private RichTextBox output;
        private TextBox uinput;
    }
}