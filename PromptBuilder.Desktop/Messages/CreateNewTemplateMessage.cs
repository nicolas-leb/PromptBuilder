using PromptBuilder.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptBuilder.Desktop.Messages
{
    internal class CreateNewTemplateMessage
    {
        public TemplateModel Template { get; set; } = new ();
    }
}
