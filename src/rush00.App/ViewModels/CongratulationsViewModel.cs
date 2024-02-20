using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ReactiveUI;
using rush00.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace rush00.App.ViewModels;

public class CongratulationsViewModel : ViewModelBase
{
    private string? _totalDays;

    public string? TotalDays
    {
        get => _totalDays;
        set => this.RaiseAndSetIfChanged(ref _totalDays, value);
    }

    public CongratulationsViewModel(IEnumerable<HabitCheck> items, string Motivation)
    {
        TotalDays = $"Congratulations!\n{items.Count(x => x.IsChecked == true) + 1}/{items.Count()} days checked.\nFinally: {Motivation}";
    }
}

