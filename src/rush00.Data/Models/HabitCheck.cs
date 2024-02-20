namespace rush00.Data;

public class HabitCheck
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string DateString { get; set; }
    public bool IsChecked { get; set; }


    public HabitCheck(DateTime date)
    {
        Date = date;
        DateString = Date.Date.ToString("d");
        IsChecked = false;
    }
}
