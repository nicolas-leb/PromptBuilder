using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PromptBuilder.Desktop.Models;
using PromptBuilder.Library.Models;
using PromptBuilder.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptBuilder.Desktop.ViewModels;

internal partial class CreateTemplateViewModel : ObservableObject
{
    [ObservableProperty]
    private string templateBody = string.Empty;

    [ObservableProperty]
    private string newVariableName = string.Empty;

    [ObservableProperty]
    private ObservableCollection<string> templateVariables = new ();

    [ObservableProperty]
    private string selectedVariable = string.Empty;

    [ObservableProperty]
    private string category = string.Empty;

    [ObservableProperty]
    private string name = string.Empty;

    public void SetTemplateModel(TemplateModel template)
    {
        this.TemplateBody = template.Body;
        this.TemplateVariables = new ObservableCollection<string>(template.Variables);
        this.Category = template.Category;
        this.Name = template.Name;
        if (this.TemplateVariables.Any())
        {
            this.SelectedVariable = this.TemplateVariables.First();
        }
    }

    [RelayCommand]
    private void AddNewVariable()
    {
        if (string.IsNullOrWhiteSpace(this.NewVariableName))
        {
            return;
        }

        if (this.TemplateVariables.Contains(this.NewVariableName))
        {
            return;
        }

        this.TemplateVariables.Add(this.NewVariableName);

        if (string.IsNullOrEmpty(this.SelectedVariable))
        {
            this.SelectedVariable = this.NewVariableName;
        }

        this.NewVariableName = string.Empty;
    }

    [RelayCommand]
    private void DeleteVariable()
    {
        if (string.IsNullOrWhiteSpace(this.SelectedVariable))
        {
            return;
        }

        this.TemplateVariables.Remove(this.SelectedVariable);
    }

    [RelayCommand]
    private void InsertVariable()
    {
        if (string.IsNullOrWhiteSpace(this.SelectedVariable))
        {
            return;
        }

        this.TemplateBody += "{" + this.SelectedVariable + "}";
    }

    [RelayCommand]
    private async void SaveTemplate()
    {
        var template = new Template
        {
            Name = this.Name,
            Category = this.Category,
            Variables = this.TemplateVariables.ToList(),
            Body = this.TemplateBody,
        };
        CancellationTokenSource cts = new CancellationTokenSource();
        await TemplateService.Save(template, cts.Token);
    }
}
