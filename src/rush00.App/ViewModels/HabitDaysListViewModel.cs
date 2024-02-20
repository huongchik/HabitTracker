using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ReactiveUI;
using rush00.Data;

namespace rush00.App.ViewModels;

public class HabitDaysListViewModel : ViewModelBase
{
    public MainWindowViewModel mwvm { get; set; }
    public DateTime EndDate { get; set; }
    public string Motivation { get; set; }
    public HabitDaysListViewModel(IEnumerable<HabitCheck> items, MainWindowViewModel main, string motivation, DateTime end)
    {
        mwvm = main;
        Motivation = motivation;
        EndDate = end;
        Items = new List<HabitCheck>(items);
    }
    public List<HabitCheck> Items { get; }

    
    public void ChangeContent(ViewModelBase vmb)
    {
        mwvm.Content = vmb;
    }
}

