using System;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using rush00.App.Views;
using rush00.Data;

namespace rush00.App.ViewModels;

public class HabitCreateViewModel : ViewModelBase
{
    private string? habit_title;
    public string? HabitTitle
    {
        get => habit_title;
        set => this.RaiseAndSetIfChanged(ref habit_title, value);
    }

    private string? habit_motivation;
    public string? HabitMotivation
    {
        get => habit_motivation;
        set => this.RaiseAndSetIfChanged(ref habit_motivation, value);
    }

    private string? start_date;
    public string? StartDate
    {
        get => start_date;
        set => this.RaiseAndSetIfChanged(ref start_date, value);
    }

    private string? days_count;
    public string? DaysCount
    {
        get => days_count;
        set => this.RaiseAndSetIfChanged(ref days_count, value);
    }
    public ReactiveCommand<Unit, Unit> SubmitCommand { get; }

    public HabitCreateViewModel(MainWindowViewModel mwvm)
    {
        StartDate = new DateTimeOffset(DateTime.Today).ToString();
        SubmitCommand = ReactiveCommand.Create(() =>
        {
            if (HabitTitle == null)
                return;
            if (HabitMotivation == null)
                return;
            
            if (!DateTime.TryParse(StartDate, out DateTime date))
                date = DateTime.Now;

            mwvm.Habit = new Habit(HabitTitle, HabitMotivation, date, int.Parse(DaysCount!));
            using (var db = new HabitDbContext())
            {
                db.Add(mwvm.Habit);
                db.SaveChanges();
            }

            var habitDaysListViewModel = new HabitDaysListViewModel(mwvm.Habit.Days,  mwvm, mwvm.Habit.Motivation, mwvm.Habit.StartDate.AddDays(mwvm.Habit.Days.Count - 1));
            var habitDaysListView = new HabitDaysListView();
            habitDaysListView.DataContext = habitDaysListViewModel;

            mwvm.Content = habitDaysListViewModel;
        });
    }
}