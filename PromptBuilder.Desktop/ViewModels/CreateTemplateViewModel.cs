using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    private string templateBody = "Template body.";

    [ObservableProperty]
    private string newVariableName = string.Empty;

    [ObservableProperty]
    private ObservableCollection<string> templateVariables = new ();

    [RelayCommand]
    private void AddNewVariable()
    {
        if (this.TemplateVariables.Contains(this.NewVariableName))
        {
            return;
        }

        this.TemplateVariables.Add(this.NewVariableName);
        this.NewVariableName = string.Empty;
    }
}
