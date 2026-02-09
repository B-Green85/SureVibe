using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SureVibe.App.Services;

namespace SureVibe.App.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private string _goal = string.Empty;
    [ObservableProperty] private string _scope = string.Empty;
    [ObservableProperty] private string _repoLayout = string.Empty;
    [ObservableProperty] private string _constraints = string.Empty;
    [ObservableProperty] private string _tasksText = string.Empty;
    [ObservableProperty] private string _acceptanceTestsText = string.Empty;
    [ObservableProperty] private string _evidenceRequiredText = string.Empty;
    [ObservableProperty] private string _forbiddenText = string.Empty;

    [ObservableProperty] private string _output = string.Empty;

    // Backing field for YAML/JSON toggle.
    // Bind YAML RadioButton to UseYaml and JSON RadioButton to UseJson (computed).
    [ObservableProperty] private bool _useYaml = true;

    // Computed mirror property for JSON selection (Avalonia XAML can't bind to "!UseYaml").
    public bool UseJson
    {
        get => !UseYaml;
        set => UseYaml = !value;
    }

    // Keep UseJson in sync in the UI when UseYaml changes.
    partial void OnUseYamlChanged(bool value)
    {
        OnPropertyChanged(nameof(UseJson));
    }

    [RelayCommand]
    private void Compile()
    {
        var format = UseYaml ? OutputFormat.Yaml : OutputFormat.Json;

        var instruction = InstructionCompiler.Parse(
            Goal, Scope, RepoLayout, Constraints,
            TasksText, AcceptanceTestsText, EvidenceRequiredText, ForbiddenText);

        Output = InstructionCompiler.Compile(instruction, format);
    }

    [RelayCommand]
    private async Task CopyOutput()
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            IClipboard? clipboard = desktop.MainWindow?.Clipboard;
            if (clipboard is not null && !string.IsNullOrEmpty(Output))
                await clipboard.SetTextAsync(Output);
        }
    }
}