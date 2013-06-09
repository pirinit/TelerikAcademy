public class ScoreEntry
{
    private string name;
    private int points;

    public ScoreEntry(string име, int то4ки)
    {
        this.name = име;
        this.points = то4ки;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Points
    {
        get { return this.points; }
        set { this.points = value; }
    }
}