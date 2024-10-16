﻿using PromptBuilder.Library.Models;
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
    public const string Extension = ".json";
    public static Task Save(Template template, CancellationToken cancellationToken)
    {
        string templateAsJson = JsonSerializer.Serialize(template);
        string path = Path.Combine(FolderName, $"{template.Name}{Extension}");

        if (Directory.Exists(FolderName) == false)
        {
            Directory.CreateDirectory(FolderName);
        }

        return File.WriteAllTextAsync(path, templateAsJson, cancellationToken);
    }

    public static void Delete(string templateName, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(templateName))
        {
            throw new ArgumentException($"'{nameof(templateName)}' cannot be null or whitespace.", nameof(templateName));
        }

        string path = Path.Combine(FolderName, $"{templateName}{Extension}");

        if (File.Exists(path) == false)
        {
            return;
        }

        File.Delete(path);
    }
}
