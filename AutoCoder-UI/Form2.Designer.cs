namespace AutoCoder_UI
{
    partial class Form2
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
            filename = new TextBox();
            OK = new Button();
            Cancel = new Button();
            button3 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // filename
            // 
            filename.Location = new Point(12, 47);
            filename.Name = "filename";
            filename.Size = new Size(390, 23);
            filename.TabIndex = 0;
            // 
            // OK
            // 
            OK.Location = new Point(47, 88);
            OK.Name = "OK";
            OK.Size = new Size(75, 23);
            OK.TabIndex = 1;
            OK.Text = "OK";
            OK.UseVisualStyleBackColor = true;
            OK.Click += OK_Click;
            // 
            // Cancel
            // 
            Cancel.Location = new Point(327, 88);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(75, 23);
            Cancel.TabIndex = 2;
            Cancel.Text = "Cancel";
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += Cancel_Click;
            // 
            // button3
            // 
            button3.Location = new Point(408, 46);
            button3.Name = "button3";
            button3.Size = new Size(61, 24);
            button3.TabIndex = 3;
            button3.Text = "Browse";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 29);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 4;
            label1.Text = "File:";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 123);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(Cancel);
            Controls.Add(OK);
            Controls.Add(filename);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal TextBox filename;
        private Button OK;
        private Button Cancel;
        private Button button3;
        private Label label1;
    }
}