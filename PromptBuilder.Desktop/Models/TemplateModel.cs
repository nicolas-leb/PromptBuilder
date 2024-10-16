using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptBuilder.Desktop.Models
{
    internal class TemplateModel
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public string Body { get; set; }

        public List<string> Variables { get; set; } = new ();
    }
}
