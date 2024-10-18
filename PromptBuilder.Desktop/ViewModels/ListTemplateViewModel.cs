namespace PromptBuilder.Desktop.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using PromptBuilder.Desktop.Messages;
using PromptBuilder.Desktop.Models;
using PromptBuilder.Library.Services;
using System.Collections.ObjectModel;

internal partial class ListTemplateViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<TemplateModel> templates;

    public ListTemplateViewModel()
    {
        this.Templates = new ObservableCollection<TemplateModel>()
        {
            new TemplateModel()
            {
                Name = "Business Email",
                Category = "Business",
                Variables = new List<string> { "var1", "var2"},
                Body = "Body1",
            },
            new TemplateModel()
            {
                Name = "Validate Requirement",
                Category = "Business",
                Variables = new List<string> { "var1", "var2"},
                Body = "Body2",
            },
            new TemplateModel()
            {
                Name = "Email Summary",
                Category = "Personnal",
                Variables = new List<string> { "var1", "var2"},
                Body = "Body3",
            },
        };
    }

    [RelayCommand]
    private void CreateNewTemplate()
    {
        WeakReferenceMessenger.Default.Send(new CreateNewTemplateMessage());
    }

    [RelayCommand]
    private void EditTemplate(TemplateModel template)
    {
        WeakReferenceMessenger.Default.Send(new CreateNewTemplateMessage() { Template = template });
    }

    [RelayCommand]
    private void DeleteTemplate(TemplateModel template)
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        TemplateService.Delete(template.Name, cts.Token);
    }
}
