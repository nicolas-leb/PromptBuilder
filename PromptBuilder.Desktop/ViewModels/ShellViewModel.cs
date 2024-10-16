using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using PromptBuilder.Desktop.Messages;

namespace PromptBuilder.Desktop.ViewModels;

internal partial class ShellViewModel : ObservableObject, IRecipient<CreateNewTemplateMessage>
{

    [ObservableProperty]
    private ObservableObject currentView;

    public ShellViewModel()
    {
        WeakReferenceMessenger.Default.Register<CreateNewTemplateMessage>(this, (r, m) =>
        {
            this.Receive(m);
        });
    }

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

    public void Receive(CreateNewTemplateMessage message)
    {
        var vm = Ioc.Default.GetService<CreateTemplateViewModel>();
        vm.SetTemplateModel(message.Template);
        if (vm is not null)
        {
            this.CurrentView = vm;
        }
    }
}
