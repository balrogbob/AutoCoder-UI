using System;
using System.Collections.Generic;
using AutoCoder_UI.lib;
using System.Text.Json;
using System.Drawing;
namespace AutoCoder_UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        static string APIKEY = "sk-nokey";
        const string generatedDir = "generated"; // generators folder of files, for me it's smol-ai-dotnet\bin\Debug\net7.0\generated
        const string openai_model = "gpt-4-1106-preview"; // or 'gpt-4'
        const int openai_model_max_tokens = 32384;

        public static async Task<string> GenerateResponse(string systemPrompt, string userPrompt, params string[] args)
        {
            // TODO: Fix encoding. Not important to get this working
            //var encoding = TikToken.EncodingForModel(openai_model);
            ReportTokens(systemPrompt);
            ReportTokens(userPrompt);

            var messages = new List<lib.Message>();

            messages.Add(new lib.Message { role = "system", content = systemPrompt });
            messages.Add(new lib.Message { role = "user", content = userPrompt });

            // alternative between assistant and user for each arg
            var role = "assistant";
            foreach (var value in args)
            {
                messages.Add(new lib.Message { role = role, content = value });
                ReportTokens(value);
                role = role == "assistant" ? "user" : "assistant";
            }

            var parameters = new ChatCompletionParams
            {
                model = openai_model,
                messages = messages,
                max_tokens = openai_model_max_tokens,
                temperature = 1,
                repeat_penalty = 1.1,
                mirostat = 0,
                min_p = 0.02,
                top_p = 0,
                top_k = 0
            };

            var client = new OpenAiClient(APIKEY);
            Response response = await client.CallChatCompletionAsync(parameters);

            if (response.error is Error error)
            {
                // response.Error "That model is currently overloaded with other requests. You can retry your request, or contact us through our help center at help.openai.com if the error persists. (Please include the request ID b24afc2c91294744679576584d2954b2 in your message.)"
                return error.message;
            }

            var reply = response.choices[0].message.content;
            return reply;
        }

        public static async Task<(string, string)> GenerateFile(string filename, string filepathsString = null, string sharedDependencies = null, string prompt = null)
        {
            var filecode = await GenerateResponse(
                // Assistant
                $@"You are an AI developer who is trying to write a program that will generate code for the user based on their intent.
            
            the app is: {prompt}

            the files we have decided to generate are: {filepathsString}

            the shared dependencies (like filenames and variable names) we have decided on are: {sharedDependencies}
            
            only write valid code for the given filepath and file type, and return only the code.
            do not add any other explanation, only return valid code for that file type.",

                // User
                $@"We have broken up the program into per-file generation. 
            Now your job is to generate only the code for the file {filename}. 
            Make sure to have consistent filenames if you reference other files we are also generating.
            
            Remember that you must obey 4 things: 
               - you are generating code for the file {filename}
               - do not stray from the names of the files and the shared dependencies we have decided on
               - do not repeat code or variable names
               - MOST IMPORTANT OF ALL - the purpose of our app is {prompt} - every line of code you generate must be valid code. Do not include code fences in your response
            
           
            Begin generating the code now."
            );

            return (filename, filecode);
        }

        private static void ReportTokens(string prompt)
        {
            WriteToTextBox($"{prompt.Count()} ", Color.DarkRed, new Font("Arial", 12, FontStyle.Bold), HorizontalAlignment.Left);
            WriteToTextBox("tokens in prompt: ", Color.ForestGreen, new Font("Arial", 12, FontStyle.Regular), HorizontalAlignment.Left);
            WriteToTextBox($"{prompt.Substring(0, 100)}..." + Environment.NewLine, Color.ForestGreen, new Font("Arial", 10, FontStyle.Regular), HorizontalAlignment.Left);
        }

        private static void WriteFile(string filename, string filecode, string directory)
        {
            WriteToTextBox("[" + filename + "]" + Environment.NewLine, Color.Black, new Font("Times New Roman", 12, FontStyle.Bold), HorizontalAlignment.Left);
            WriteToTextBox(filecode + Environment.NewLine, Color.Black, new Font("Times New Roman", 12, FontStyle.Bold), HorizontalAlignment.Left);

            var filePath = Path.Combine(directory, filename);
            var dir = Path.GetDirectoryName(filePath);
            Directory.CreateDirectory(dir);

            File.WriteAllText(filePath, filecode);
        }

        private static void CleanDirectory(string directory)
        {
            var extensionsToSkip = new[] { ".ass" };

            if (Directory.Exists(directory))
            {
                foreach (var file in Directory.EnumerateFiles(directory))
                {
                    var extension = Path.GetExtension(file);
                    if (!extensionsToSkip.Contains(extension))
                    {
                        File.Delete(file);
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(directory);
            }
        }

        public static void WriteToTextBox(string value, Color color, Font font, HorizontalAlignment alignment)
        {
            // Get the currently active form
            Form activeForm = Application.OpenForms["Form1"];

            if (activeForm != null && activeForm is Form1)
            {
                // Cast the active form to a Form1 instance
                Form1 form = (Form1)activeForm;

                // Call the SetTextBoxValue() method on the form to set the TextBox value
                form.SetTextBoxValue(value, color, font, alignment);
            }
        }
        
        public static async Task MainAsync(string prompt, string directory, string? file = null)
        {

            if (prompt.EndsWith(".md"))
            {
                prompt = File.ReadAllText(prompt);
            }

            WriteToTextBox("hi its me, ", Color.Black, new Font("Arial", 12, FontStyle.Regular), HorizontalAlignment.Center);
            WriteToTextBox("🐣", Color.Red, new Font("Arial", 12, FontStyle.Bold), HorizontalAlignment.Center);
            WriteToTextBox("the smol developer", Color.Black, new Font("Times New Roman", 12, FontStyle.Bold), HorizontalAlignment.Center);
            WriteToTextBox("🐣" + Environment.NewLine, Color.Red, new Font("Arial", 12, FontStyle.Bold), HorizontalAlignment.Center);
            WriteToTextBox("! you said you wanted: ", Color.Black, new Font("Arial", 12, FontStyle.Regular), HorizontalAlignment.Center);
            WriteToTextBox(prompt + Environment.NewLine, Color.Green, new Font("Arial", 12, FontStyle.Regular), HorizontalAlignment.Left);

            var filepathsString = await GenerateResponse(
                // Assistant content
                @"You are an AI developer who is trying to write a program that will generate code for the user based on their intent.
            
            When given their intent, create a complete, exhaustive list of filepaths that the user would write code into to make the program. Do not include executable files.
            
            only list the filepaths you would write, and return them without a leading slash as a json list of strings. 

            Only include lines that have files. Directories should begin with AutoCoder\.

            do not add any other explanation, or description, or label, only return a json list of strings",
                // User Content
                prompt
            );

            var listActual = new List<string>();
            try
            {
                WriteToTextBox("Raw Reply: ", Color.Purple, new Font("Arial", 12, FontStyle.Bold), HorizontalAlignment.Left);
                WriteToTextBox(filepathsString + Environment.NewLine, Color.Red, new Font("Arial", 12, FontStyle.Regular), HorizontalAlignment.Left);
                string jsonContent = ExtractJsonContent(filepathsString);
                WriteToTextBox("Json extracted Reply: ", Color.Purple, new Font("Arial", 12, FontStyle.Bold), HorizontalAlignment.Left);
                WriteToTextBox(jsonContent + Environment.NewLine, Color.Black, new Font("Arial", 12, FontStyle.Regular), HorizontalAlignment.Left);

                listActual = JsonSerializer.Deserialize<List<string>>(jsonContent);

                string sharedDependencies = null;
                if (File.Exists("shared_dependencies.md"))
                {
                    sharedDependencies = File.ReadAllText("shared_dependencies.md");
                }

                if (file != null)
                {
                    WriteToTextBox("file " + file + Environment.NewLine, Color.Yellow, new Font("Arial", 12, FontStyle.Bold), HorizontalAlignment.Left);
                    var (filename, filecode) = await GenerateFile(file, filepathsString, sharedDependencies, prompt);
                    WriteFile(filename, filecode, directory);
                }
                else
                {
                    CleanDirectory(directory);

                    sharedDependencies = await GenerateResponse(
                        // Assistant Content
                        $@"You are an AI developer who is trying to write a program that will generate code for the user based on their intent.
                    
                    In response to the user's prompt:
            
                    ---
                    the app is: {prompt}
                    ---
                    
                    the files we have decided to generate are: {filepathsString}

                    Now that we have a list of files, we need to understand what dependencies they share.
                    Please name and briefly describe what is shared between the files we are generating, including _Layouts.cshtml files
                    Make sure to list any needed or suggested libraries.
                    Exclusively focus on the names of the shared dependencies, and do not add any other explanation.",
                        // User Content
                        prompt
                    );

                    WriteToTextBox(sharedDependencies + Environment.NewLine, Color.Black, new Font("Times New Roman", 12, FontStyle.Regular), HorizontalAlignment.Center);
                    WriteFile("shared_dependencies.md", sharedDependencies, directory);

                    foreach (var f in listActual)
                    {
                        var (filename, filecode) = await GenerateFile(f, filepathsString, sharedDependencies, prompt);
                        WriteFile(filename, filecode, directory);
                    }
                }
            }
            catch (Exception ex)
            {
                WriteToTextBox("Failed to parse result: " + ex.Message + Environment.NewLine, Color.Red, new Font("Times New Roman", 12, FontStyle.Bold), HorizontalAlignment.Center);
            }
        }

        static string ExtractJsonContent(string input)
        {
            // Find the start and end indexes of the JSON content
            int startIndex = input.IndexOf("[");
            int endIndex = input.LastIndexOf("]");

            // Extract the JSON content
            string jsonContent = input.Substring(startIndex, endIndex - startIndex + 1);

            return jsonContent;
        }

        public static async Task Generate(string[] args)
        {
            if (args.Length == 0)
            {
                WriteToTextBox("Please provide the initial prompt as the first argument.", Color.Black, new Font("Times New Roman", 12, FontStyle.Bold), HorizontalAlignment.Center);
                return;
            }

            string prompt = args[0];
            string directory = ""; // Set the directory path here

            await MainAsync(prompt, directory);
        }

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}