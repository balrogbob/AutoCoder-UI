using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenAI.ChatGpt;
using OpenAI.ChatGpt.Models.ChatCompletion.Messaging;

namespace AutoCoder_UI
{
    public partial class Form3 : Form
    {
        private OpenAiClient _client;

        public Form3()
        {
            InitializeComponent();
            _client = new OpenAiClient("{YOUR_OPENAI_API_KEY}", "http://localhost:1234/v1/");
        }

        private async void send_Click(object sender, EventArgs e)
        {
            string text = uinput.Text;
            await foreach (string chunk in _client.StreamChatCompletions(new UserMessage("<|im_start|>user" + Environment.NewLine + text + "<|im_end|><|im_start|>assistant" + Environment.NewLine), maxTokens: 80))
            {
                output.Text += chunk;
            }
        }
    }
}
