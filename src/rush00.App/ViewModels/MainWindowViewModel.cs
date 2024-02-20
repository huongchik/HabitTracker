using System;
using System.Windows.Input;
using System.Reactive.Linq;
using ReactiveUI;
using rush00.Data;
using System.IO;
using System.Linq;

namespace rush00.App.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase? _content;
    public ViewModelBase? Content
    {
        get => _content;
        set => this.RaiseAndSetIfChanged(ref _content, value);
    }

    private Habit? _habit;
    public Habit? Habit
    {
        get => _habit;
        set => this.RaiseAndSetIfChanged(ref _habit, value);
    }

    public MainWindowViewModel()
    {
        if (File.Exists("../rush00.Data/habits.db"))
        {
            using (var context = new HabitDbContext())
            {
                var d = context.Habits.SingleOrDefault(b => b.Id == 1);
                if (d is not null)
                {
                    Habit = new Habit(d.Title, d.Motivation, d.StartDate, context.Habits.Count());
                }
            }
        }
        if (Habit == null)
        {
            Content = new HabitCreateViewModel(this);
        }
        else
        {
            using (var context = new HabitDbContext())
            {
                Content = new HabitDaysListViewModel(context.HabitChecks, this, Habit.Motivation, Habit.StartDate.AddDays(context.HabitChecks.Count()-1));
            }
        }
    }
}
