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
        const int openai_model_max_tokens = 4096;

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
                temperature = 0
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
            
            Remember that you must obey 3 things: 
               - you are generating code for the file {filename}
               - do not stray from the names of the files and the shared dependencies we have decided on
               - MOST IMPORTANT OF ALL - the purpose of our app is {prompt} - every line of code you generate must be valid code. Do not include code fences in your response, for example
            
            Bad response:
            ```javascript 
            console.log(""hello world"")
            ```
            
            Good response:
            console.log(""hello world"")
            
            Begin generating the code now."
            );

            return (filename, filecode);
        }

        private static void ReportTokens(string prompt)
        {
            WriteToTextBox($"\u001b[37m{prompt.Count()} tokens\u001b[0m in prompt: \u001b[92m{prompt.Substring(0, 50)}\u001b[0m", Color.Black, new Font("Times New Roman", 12, FontStyle.Bold), HorizontalAlignment.Center);
        }

        private static void WriteFile(string filename, string filecode, string directory)
        {
            WriteToTextBox("\u001b[94m[" + filename + "]\u001b[0m", Color.Black, new Font("Times New Roman", 12, FontStyle.Bold), HorizontalAlignment.Center);
            WriteToTextBox(filecode, Color.Black, new Font("Times New Roman", 12, FontStyle.Bold), HorizontalAlignment.Center);

            var filePath = Path.Combine(directory, filename);
            var dir = Path.GetDirectoryName(filePath);
            Directory.CreateDirectory(dir);

            File.WriteAllText(filePath, filecode);
        }

        private static void CleanDirectory(string directory)
        {
            var extensionsToSkip = new[] { ".png", ".jpg", ".jpeg", ".gif", ".bmp", ".svg", ".ico", ".tif", ".tiff" };

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

            WriteToTextBox("hi its me, 🐣the smol developer🐣! you said you wanted:", Color.Black, new Font("Times New Roman", 12, FontStyle.Bold), HorizontalAlignment.Center);
            WriteToTextBox("\u001b[92m" + prompt + "\u001b[0m", Color.Black, new Font("Times New Roman", 12, FontStyle.Bold), HorizontalAlignment.Center);

            var filepathsString = await GenerateResponse(
                // Assistant content
                @"You are an AI developer who is trying to write a program that will generate code for the user based on their intent.
            
            When given their intent, create a complete, exhaustive list of filepaths that the user would write code into to make the program. Do not include executable files.
            
            only list the filepaths you would write, and return them without a leading slash as a json list of strings. 

            Only include lines that have files. Directories should begin with generated\\.

            do not add any other explanation, or description, or label, only return a json list of strings ",
                // User Content
                prompt
            );

            var listActual = new List<string>();
            try
            {
                string jsonContent = ExtractJsonContent(filepathsString);
                Console.WriteLine(jsonContent, Color.Black, new Font("Times New Roman", 12, FontStyle.Bold), HorizontalAlignment.Center);

                listActual = JsonSerializer.Deserialize<List<string>>(jsonContent);

                string sharedDependencies = null;
                if (File.Exists("shared_dependencies.md"))
                {
                    sharedDependencies = File.ReadAllText("shared_dependencies.md");
                }

                if (file != null)
                {
                    Console.WriteLine("file" + file, Color.Black, new Font("Times New Roman", 12, FontStyle.Bold), HorizontalAlignment.Center);
                    var (filename, filecode) = await GenerateFile(file, filepathsString, sharedDependencies, prompt);
                    WriteFile(filename, filecode, directory);
                }
                else
                {
                    CleanDirectory(directory);

                    sharedDependencies = await GenerateResponse(
                        // Assistant Content
                        @"You are an AI developer who is trying to write a program that will generate code for the user based on their intent.
                    
                    In response to the user's prompt:
            
                    ---
                    the app is: {prompt}
                    ---
                    
                    the files we have decided to generate are: {filepathsString}

                    Now that we have a list of files, we need to understand what dependencies they share.
                    Please name and briefly describe what is shared between the files we are generating, including _Layouts.cshtml files.
                    Exclusively focus on the names of the shared dependencies, and do not add any other explanation.",
                        // User Content
                        prompt
                    );

                    WriteToTextBox(sharedDependencies, Color.Black, new Font("Times New Roman", 12, FontStyle.Bold), HorizontalAlignment.Center);
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
                WriteToTextBox("Failed to parse result: " + ex.Message, Color.Black, new Font("Times New Roman", 12, FontStyle.Bold), HorizontalAlignment.Center);
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