using PromptBuilder.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PromptBuilder.Library.Services;

public class TemplateService
{
    public const string FolderName = "Templates";
    public static Task Save(Template template, CancellationToken cancellationToken)
    {
        string templateAsJson = JsonSerializer.Serialize(template);
        string path = Path.Combine(FolderName, $"{template.Name}.template");

        if (Directory.Exists(FolderName) == false)
        {
            Directory.CreateDirectory(FolderName);
        }

        return File.WriteAllTextAsync(path, templateAsJson, cancellationToken);
    }
}
