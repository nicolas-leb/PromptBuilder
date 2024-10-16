namespace PromptBuilder.Library.Models
{
    public class Template
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public string Body { get; set; }

        public List<string> Variables { get; set; } = new();
    }
}
