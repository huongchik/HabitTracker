using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Avalonia.Markup.Xaml;
using rush00.App.ViewModels;
using rush00.App.Views;

namespace rush00.App
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
            }
            using (var context = new HabitDbContext())
            {
                context.Database.EnsureCreated();
            }
            // using (var context = new HabitDbContext())
            // {
            //     var habit = context.Habits
            //         .Include(x => x.IsFinished)
            //         .FirstOrDefault(x => !x.IsFinished);
            //     // Concole.WriteLine(habit);
            // }

            base.OnFrameworkInitializationCompleted();
        }
        // private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        // {
        //     if (e == Exit)
        //     using (var db = new MyDbContext())
        //     {
        //         db.SaveChanges();
        //     }
        // }

    }
}
