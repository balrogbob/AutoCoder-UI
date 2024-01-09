namespace AutoCoder_UI.lib
{
    public class ChatCompletionParams
    {
        public string model { get; set; }
        public List<Message> messages { get; set; }
        public int max_tokens { get; set; }

        public Double temperature { get; set; }
        public int mirostat { get; set; }
        public Double repeat_penalty { get; set; }
        public Double min_p { get; set; }
        public Double top_p { get; set; }
        public Double top_k { get; set; }
    }
}