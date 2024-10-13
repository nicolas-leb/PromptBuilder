namespace PromptBuilder.Desktop.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using PromptBuilder.Desktop.Models;
using System.Collections.ObjectModel;

internal partial class ListTemplateViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<TemplateModel> templates;

    public ListTemplateViewModel()
    {
        templates = new ObservableCollection<TemplateModel>()
        {
            new TemplateModel()
            {
                Name = "Business Email",
                Category = "Business",
            },
            new TemplateModel()
            {
                Name = "Validate Requirement",
                Category = "Business",
            },
            new TemplateModel()
            {
                Name = "Email Summary",
                Category = "Personnal",
            },
        };
    }
}
