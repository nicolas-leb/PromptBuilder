namespace PromptBuilder.Desktop.Services;

using CommunityToolkit.Mvvm.ComponentModel;

internal partial class NavigationService : ObservableObject
{
    private readonly Func<Type, ObservableObject> _viewModelFactory;

    [ObservableProperty]
    private ObservableObject currentView;

    public NavigationService(Func<Type, ObservableObject> viewModelFactory)
    {
        this._viewModelFactory = viewModelFactory;
    }

    public void NavigateTo<TViewModel>()
        where TViewModel : ObservableObject
    {
        var viewModel = this._viewModelFactory.Invoke(typeof(TViewModel));
        CurrentView = viewModel;
    }
}
