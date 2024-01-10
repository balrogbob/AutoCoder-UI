namespace AutoCoder_UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            splitContainer3 = new SplitContainer();
            button2 = new Button();
            Console = new RichTextBox();
            splitContainer4 = new SplitContainer();
            Debug = new RichTextBox();
            OptionsTab = new TabControl();
            tabPage1 = new TabPage();
            Chat = new Button();
            label1 = new Label();
            Api_Key = new TextBox();
            buttonSaveSettings = new Button();
            buttonLoadSettings = new Button();
            FilesDir = new TextBox();
            label3 = new Label();
            label2 = new Label();
            ProjectName = new TextBox();
            tabPage2 = new TabPage();
            label6 = new Label();
            textBox1 = new TextBox();
            label7 = new Label();
            textBox2 = new TextBox();
            label5 = new Label();
            Connect_Timeout = new TextBox();
            label4 = new Label();
            API_Url = new TextBox();
            button1 = new Button();
            UserInput = new RichTextBox();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            OptionsTab.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(988, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(93, 22);
            toolStripMenuItem1.Text = "Exit";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2 });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(107, 22);
            toolStripMenuItem2.Text = "About";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 563);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(988, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1 });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(988, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 22);
            toolStripButton1.Text = "toolStripButton1";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 49);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(button1);
            splitContainer1.Panel2.Controls.Add(UserInput);
            splitContainer1.Size = new Size(988, 514);
            splitContainer1.SplitterDistance = 421;
            splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(splitContainer4);
            splitContainer2.Size = new Size(988, 421);
            splitContainer2.SplitterDistance = 338;
            splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(button2);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(Console);
            splitContainer3.Panel2.Paint += splitContainer3_Panel2_Paint;
            splitContainer3.Size = new Size(338, 421);
            splitContainer3.SplitterDistance = 126;
            splitContainer3.TabIndex = 0;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Fill;
            button2.Location = new Point(0, 0);
            button2.Name = "button2";
            button2.Size = new Size(338, 126);
            button2.TabIndex = 0;
            button2.Text = "Press for AutoGen. Type your prompt into the input box below, or edit the prompt.md file. Leave the input box empty to use prompt.md";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Console
            // 
            Console.Dock = DockStyle.Fill;
            Console.Location = new Point(0, 0);
            Console.Name = "Console";
            Console.Size = new Size(338, 291);
            Console.TabIndex = 0;
            Console.Text = "";
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.Location = new Point(0, 0);
            splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(Debug);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(OptionsTab);
            splitContainer4.Size = new Size(646, 421);
            splitContainer4.SplitterDistance = 309;
            splitContainer4.TabIndex = 0;
            // 
            // Debug
            // 
            Debug.Dock = DockStyle.Fill;
            Debug.Location = new Point(0, 0);
            Debug.Name = "Debug";
            Debug.Size = new Size(309, 421);
            Debug.TabIndex = 1;
            Debug.Text = "";
            // 
            // OptionsTab
            // 
            OptionsTab.Controls.Add(tabPage1);
            OptionsTab.Controls.Add(tabPage2);
            OptionsTab.Dock = DockStyle.Fill;
            OptionsTab.Location = new Point(0, 0);
            OptionsTab.Name = "OptionsTab";
            OptionsTab.SelectedIndex = 0;
            OptionsTab.ShowToolTips = true;
            OptionsTab.Size = new Size(333, 421);
            OptionsTab.SizeMode = TabSizeMode.FillToRight;
            OptionsTab.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(Chat);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(Api_Key);
            tabPage1.Controls.Add(buttonSaveSettings);
            tabPage1.Controls.Add(buttonLoadSettings);
            tabPage1.Controls.Add(FilesDir);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(ProjectName);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(325, 393);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Options";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // Chat
            // 
            Chat.Location = new Point(141, 335);
            Chat.Name = "Chat";
            Chat.Size = new Size(75, 23);
            Chat.TabIndex = 13;
            Chat.Text = "Chat";
            Chat.UseVisualStyleBackColor = true;
            Chat.Click += Chat_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 100);
            label1.MinimumSize = new Size(47, 15);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 8;
            label1.Text = "API Key";
            // 
            // Api_Key
            // 
            Api_Key.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Api_Key.Location = new Point(18, 118);
            Api_Key.MinimumSize = new Size(285, 23);
            Api_Key.Name = "Api_Key";
            Api_Key.Size = new Size(285, 23);
            Api_Key.TabIndex = 7;
            // 
            // buttonSaveSettings
            // 
            buttonSaveSettings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonSaveSettings.Location = new Point(222, 336);
            buttonSaveSettings.MaximumSize = new Size(81, 38);
            buttonSaveSettings.MinimumSize = new Size(81, 38);
            buttonSaveSettings.Name = "buttonSaveSettings";
            buttonSaveSettings.Size = new Size(81, 38);
            buttonSaveSettings.TabIndex = 6;
            buttonSaveSettings.Text = "Save Settings";
            buttonSaveSettings.UseVisualStyleBackColor = true;
            buttonSaveSettings.Click += buttonSaveSettings_Click;
            // 
            // buttonLoadSettings
            // 
            buttonLoadSettings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonLoadSettings.Location = new Point(18, 336);
            buttonLoadSettings.MaximumSize = new Size(81, 38);
            buttonLoadSettings.MinimumSize = new Size(81, 38);
            buttonLoadSettings.Name = "buttonLoadSettings";
            buttonLoadSettings.Size = new Size(81, 38);
            buttonLoadSettings.TabIndex = 5;
            buttonLoadSettings.Text = "Load Settings";
            buttonLoadSettings.UseVisualStyleBackColor = true;
            buttonLoadSettings.Click += buttonLoadSettings_Click;
            // 
            // FilesDir
            // 
            FilesDir.Location = new Point(18, 29);
            FilesDir.MinimumSize = new Size(285, 23);
            FilesDir.Name = "FilesDir";
            FilesDir.Size = new Size(285, 23);
            FilesDir.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 8);
            label3.MinimumSize = new Size(229, 15);
            label3.Name = "label3";
            label3.Size = new Size(229, 15);
            label3.TabIndex = 4;
            label3.Text = "Files Directory. Can be full path or relative.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 55);
            label2.MinimumSize = new Size(79, 15);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 3;
            label2.Text = "Project Name";
            label2.Click += label2_Click;
            // 
            // ProjectName
            // 
            ProjectName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ProjectName.Location = new Point(18, 73);
            ProjectName.MinimumSize = new Size(285, 23);
            ProjectName.Name = "ProjectName";
            ProjectName.Size = new Size(285, 23);
            ProjectName.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(textBox1);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(Connect_Timeout);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(API_Url);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(325, 393);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Advanced Options";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label6.Location = new Point(20, 79);
            label6.MaximumSize = new Size(244, 15);
            label6.MinimumSize = new Size(244, 15);
            label6.Name = "label6";
            label6.Size = new Size(244, 15);
            label6.TabIndex = 20;
            label6.Text = "End Tag";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(20, 97);
            textBox1.MinimumSize = new Size(285, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(285, 23);
            textBox1.TabIndex = 19;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(20, 33);
            label7.MinimumSize = new Size(232, 15);
            label7.Name = "label7";
            label7.Size = new Size(232, 15);
            label7.TabIndex = 18;
            label7.Text = "Start Tag";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Location = new Point(20, 51);
            textBox2.MinimumSize = new Size(285, 23);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(285, 23);
            textBox2.TabIndex = 17;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.Location = new Point(20, 168);
            label5.MaximumSize = new Size(244, 33);
            label5.MinimumSize = new Size(244, 33);
            label5.Name = "label5";
            label5.Size = new Size(244, 33);
            label5.TabIndex = 16;
            label5.Text = "Connection Timeout in seconds. Defaults to 60. set to 60000 (An Hour) for local models to be safe.  ";
            // 
            // Connect_Timeout
            // 
            Connect_Timeout.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Connect_Timeout.Location = new Point(20, 204);
            Connect_Timeout.MinimumSize = new Size(285, 23);
            Connect_Timeout.Name = "Connect_Timeout";
            Connect_Timeout.Size = new Size(285, 23);
            Connect_Timeout.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 124);
            label4.MinimumSize = new Size(232, 15);
            label4.Name = "label4";
            label4.Size = new Size(232, 15);
            label4.TabIndex = 14;
            label4.Text = "API URL";
            // 
            // API_Url
            // 
            API_Url.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            API_Url.Location = new Point(20, 142);
            API_Url.MinimumSize = new Size(285, 23);
            API_Url.Name = "API_Url";
            API_Url.Size = new Size(285, 23);
            API_Url.TabIndex = 13;
            // 
            // button1
            // 
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.Dock = DockStyle.Right;
            button1.Location = new Point(888, 0);
            button1.Name = "button1";
            button1.Size = new Size(100, 89);
            button1.TabIndex = 1;
            button1.Text = "Send";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // UserInput
            // 
            UserInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            UserInput.Location = new Point(3, 3);
            UserInput.Name = "UserInput";
            UserInput.Size = new Size(886, 91);
            UserInput.TabIndex = 0;
            UserInput.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(988, 585);
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            OptionsTab.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private StatusStrip statusStrip1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStrip toolStrip1;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private SplitContainer splitContainer4;
        private TabControl OptionsTab;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button button1;
        private Button button2;
        public RichTextBox Console;
        private TextBox FilesDir;
        public RichTextBox UserInput;
        private Label label3;
        private Label label2;
        private TextBox ProjectName;
        private Button buttonSaveSettings;
        private Button buttonLoadSettings;
        private Label label1;
        private TextBox Api_Key;
        private Button Chat;
        public RichTextBox Debug;
        private Label label6;
        private TextBox textBox1;
        private Label label7;
        private TextBox textBox2;
        private Label label5;
        private TextBox Connect_Timeout;
        private Label label4;
        private TextBox API_Url;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripButton toolStripButton1;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
    }
}
