using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace PromptBuilder.Desktop.ViewModels;

internal partial class ShellViewModel : ObservableObject
{

    [ObservableProperty]
    private ObservableObject currentView;

    [RelayCommand]
    public void NavigateToTemplates()
    {
        var vm = Ioc.Default.GetService<ListTemplateViewModel>();
        if (vm is not null)
        {
            this.CurrentView = vm;
        }
    }

    [RelayCommand]
    public void NavigateToPrompts()
    {
        var vm = Ioc.Default.GetService<ListPromptViewModel>();
        if (vm is not null)
        {
            this.CurrentView = vm;
        }
    }

    [RelayCommand]
    public void NavigateToSettings()
    {
        var vm = Ioc.Default.GetService<SettingsViewModel>();
        if (vm is not null)
        {
            this.CurrentView = vm;
        }
    }
}
