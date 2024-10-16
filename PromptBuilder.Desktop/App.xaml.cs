﻿namespace PromptBuilder.Desktop;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using PromptBuilder.Desktop.Models;
using PromptBuilder.Desktop.ViewModels;
using PromptBuilder.Desktop.Views;
using System.Windows;

/// <summary>
/// Interaction logic for App.xaml.
/// </summary>
public partial class App : Application
{
    public App()
    {
        Ioc.Default.ConfigureServices(new ServiceCollection()
            .AddSingleton<ShellView>(provider => new ShellView
            {
                DataContext = provider.GetService<ShellViewModel>(),
            })
            .AddSingleton<ShellViewModel>()
            .AddSingleton<ListTemplateViewModel>()
            .AddSingleton<ListPromptViewModel>()
            .AddSingleton<SettingsViewModel>()
            .AddTransient<CreateTemplateViewModel>()
            .BuildServiceProvider());
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var shellView = Ioc.Default.GetService<ShellView>();
        shellView?.Show();
        base.OnStartup(e);
    }
}
