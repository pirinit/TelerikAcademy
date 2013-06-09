public struct Point
{
    public int Row { get; set; }
    public int Col { get; set; }
    public int DistanceFromStart { get; set; }

    public Point(int row, int col, int distance) : this()
    {
        this.Row = row;
        this.Col = col;
        this.DistanceFromStart = distance;
    }
}