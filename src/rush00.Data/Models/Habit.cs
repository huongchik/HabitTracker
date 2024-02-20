namespace rush00.Data;

public class Habit
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Motivation { get; set; }
    public DateTime StartDate { get; set; }
    public bool IsFinished { get; set; }
    public List<HabitCheck> Days { get; }

    public Habit()
    { }
    public Habit(string title, string motivation, DateTime start_date, int days_count)
    {
        Title = title;
        Motivation = motivation;
        StartDate = start_date;
        IsFinished = false;

        Days = new List<HabitCheck>();
        for (var i = 0; i < days_count; i++)
        {
            Days.Add(new HabitCheck(start_date.AddDays(i)));
        }
    }
}
