using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Serialization;
using AutoCoder_UI.lib;

namespace AutoCoder_UI
{
    public partial class Form1 : Form
    {
        public static Form? Instance;
        public void SetTextBoxValue(string value, Color color, Font font, HorizontalAlignment alignment)
        {
            RichTextBox richTextBox = (RichTextBox)Console;

            if (richTextBox != null)
            {
                // Calculate the selection length based on the existing text in the TextBox control
                int selectionLength = richTextBox.Text.Length - richTextBox.SelectionLength;

                // Set the selection properties to the given values
                richTextBox.SelectionColor = color;
                richTextBox.SelectionFont = new Font(
                    font.FontFamily,
                    font.Size,
                    font.Style
                    );
                richTextBox.SelectionAlignment = alignment;

                // Append the new value to the existing value in the TextBox control with the updated selection properties, and then clear the selection
                richTextBox.SelectedText += Environment.NewLine + value;
                // Auto scroll to the new text
                richTextBox.ScrollToCaret();

            }
        }
        public Form1()
        {
            InitializeComponent();
            Instance = this;
            LoadFormSettings();
        }

        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void AppendMessage(string message)
        {
            SetTextBoxValue(message, Color.Black, new Font("Times New Roman", 12, FontStyle.Regular), HorizontalAlignment.Left);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string prompt = "prompt.md";
            string newFilePath;

            try
            {
                prompt = File.ReadAllText(prompt);
            }
            catch (FileNotFoundException ex)
            {

                
                    prompt = UserInput.Text;
                    SetTextBoxValue($"The file '{ex.FileName}' does not exist. Please create the file and try again.", Color.Red, new Font("Times New Roman", 12, FontStyle.Bold), HorizontalAlignment.Left);

                    DialogResult result = MessageBox.Show("The file does not exist.\n\nPlease choose a file to read from.", "Error", MessageBoxButtons.AbortRetryIgnore);

                    switch (result)
                    {
                        case DialogResult.Abort:
                            Environment.Exit(0);
                            break;
                        case DialogResult.Retry:
                            newFilePath = GetFileName();

                            if (!string.IsNullOrEmpty(newFilePath))
                            {
                                prompt = File.ReadAllText(newFilePath);
                            }
                            else
                            {
                                SetTextBoxValue("No file was selected.", Color.Black, new Font("Times New Roman", 12, FontStyle.Regular), HorizontalAlignment.Left);
                            }
                            return;
                        case DialogResult.Ignore:

                            SetTextBoxValue("Please provide the initial prompt as the first argument into the text box below, or create a prompt.md file in the same directory as the executable.", Color.Black, new Font("Times New Roman", 12, FontStyle.Regular), HorizontalAlignment.Left);
                            return;
                    }
                
            }
            if (UserInput.Text.Length != 0)
            {
                prompt = UserInput.Text;
            }
            if (prompt.Length != 0)
            {
                if (FilesDir.Text.Length == 0)
                {
                    string directory = "generated"; // Set the directory path here
                    Program.MainAsync(prompt, directory);
                }
                else
                {
                    Program.MainAsync(prompt, FilesDir.Text);
                }
            }




        }
        private static string GetFileName()
        {
            // Create a new instance of the custom dialog box
            Form2 form = new Form2();
            DialogResult result = form.ShowDialog();

            // If the OK button was pressed, return the file path from the text box
            if (result == DialogResult.OK && !string.IsNullOrEmpty(form.filename.Text))
            {
                string newFilePath = form.filename.Text;
                form.Close();
                return newFilePath;
            }
            // If the Browse button was pressed or no file path was entered, open a file dialog and return the selected file path
            else if (result == DialogResult.OK && string.IsNullOrEmpty(form.filename.Text))
            {
                OpenFileDialog ofd = new OpenFileDialog();
                result = ofd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    form.filename.Text = ofd.FileName;
                    string newFilePath = ofd.FileName;
                    form.Close();
                    return newFilePath;
                }
            }
            // If the Cancel button was pressed, do not show any file dialog and return null
            else if (result == DialogResult.Cancel)
            {
                form.Close();
                return null;
            }

            // If no valid result was obtained, return null
            form.Close();
            return null;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void SaveFormSettingsToXMLFile(FormSettings settings)
        {
            // Create a new instance of the XmlSerializer class with the type of the custom class
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(FormSettings));

            try
            {
                // Open a new FileStream object for writing to an XML file
                using (FileStream fileStream = new FileStream("formsettings.xml", FileMode.Create))
                {
                    // Serialize the custom class instance to the XML file
                    xmlSerializer.Serialize(fileStream, settings);
                }
            }
            catch (IOException ex)
            {
                SetTextBoxValue($"An error occurred while trying to save the form settings to an XML file: {ex.Message}", Color.Black, new Font("Times New Roman", 12, FontStyle.Regular), HorizontalAlignment.Left);
            }
        }
        private void SaveFormSettings()
        {
            // Create a new instance of the custom class and populate its properties with the contents of the TextBox controls on your form
            FormSettings settings = new FormSettings
            {
                FilesDir = FilesDir.Text,
                ProjectName = ProjectName.Text,
                Api_Key = Api_Key.Text,
                API_Url = API_Url.Text,
                Connect_Timeout = Connect_Timeout.Text
                // Populate more properties as needed
            };

            // Save the custom class instance to an XML file
            SaveFormSettingsToXMLFile(settings);
        }

        private void LoadFormSettings()
        {
            // Create a new instance of the custom class and load its properties from an XML file
            FormSettings settings = new FormSettings();

            LoadFormSettingsFromXMLFile(settings);
        }
        private void LoadFormSettingsFromXMLFile(FormSettings settings)
        {
            try
            {
                // Open a new FileStream object for reading from an XML file
                using (FileStream fileStream = new FileStream("formsettings.xml", FileMode.Open))
                {
                    // Create a new instance of the XmlSerializer class with the type of the custom class
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(FormSettings));

                    // Deserialize the XML file to the custom class instance
                    FormSettings loadedSettings = (FormSettings)xmlSerializer.Deserialize(fileStream);

                    if (loadedSettings != null)
                    {
                        // Assign the deserialized properties to the TextBox controls on your form
                        FilesDir.Text = loadedSettings.FilesDir;
                        ProjectName.Text = loadedSettings.ProjectName;
                        Api_Key.Text = loadedSettings.Api_Key;
                        API_Url.Text = loadedSettings.API_Url;
                        Connect_Timeout.Text = loadedSettings.Connect_Timeout;
                        // Assign more properties as needed
                    }
                }
            }

            catch (IOException ex)
            {
                SetTextBoxValue($"An error occurred while trying to load the form settings from an XML file: {ex.Message}", Color.Black, new Font("Times New Roman", 12, FontStyle.Regular), HorizontalAlignment.Left);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonLoadSettings_Click(object sender, EventArgs e)
        {
            LoadFormSettings();
        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            SaveFormSettings();
        }
    }
}
