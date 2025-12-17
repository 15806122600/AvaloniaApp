using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using AvaloniaApp.Services;

namespace AvaloniaApp.ViewModels;

public partial class KeypadViewModel : ViewModelBase
{
    private readonly Action<decimal> _onConfirmed;
    private readonly Action _onCancel;

    [ObservableProperty]
    private string _inputValue = "0";

    public KeypadViewModel(Action<decimal> onConfirmed, Action onCancel)
    {
        _onConfirmed = onConfirmed;
        _onCancel = onCancel;
    }

    [RelayCommand]
    private void AddDigit(string digit)
    {
        if (InputValue == "0" && digit != ".")
        {
            InputValue = digit;
        }
        else
        {
            InputValue += digit;
        }
    }

    [RelayCommand]
    private void Backspace()
    {
        if (InputValue.Length > 1)
        {
            InputValue = InputValue.Substring(0, InputValue.Length - 1);
        }
        else
        {
            InputValue = "0";
        }
    }

    [RelayCommand]
    private void Clear()
    {
        InputValue = "0";
    }

    [RelayCommand]
    private void Confirm()
    {
        if (decimal.TryParse(InputValue, out var result))
        {
            _onConfirmed?.Invoke(result);
            // Cleanup or reset if needed
            InputValue = "0";
        }
    }

    [RelayCommand]
    private void Cancel()
    {
        _onCancel?.Invoke();
        InputValue = "0";
    }
}
