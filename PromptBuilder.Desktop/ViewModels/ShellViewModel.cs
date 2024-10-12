using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PromptBuilder.Desktop.Services;

namespace PromptBuilder.Desktop.ViewModels;

internal partial class ShellViewModel : ObservableObject
{
    [ObservableProperty]
    private NavigationService navigationService;

    public ShellViewModel(NavigationService navigationService)
    {
        this.navigationService = navigationService;
    }

    [RelayCommand]
    public void NavigateToTemplates()
    {
        this.NavigationService.NavigateTo<ListTemplateViewModel>();
    }

    [RelayCommand]
    public void NavigateToPrompts()
    {
        this.NavigationService.NavigateTo<ListPromptViewModel>();
    }

    [RelayCommand]
    public void NavigateToSettings()
    {
        this.NavigationService.NavigateTo<SettingsViewModel>();
    }
}
