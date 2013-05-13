class Move
{
    public Point pos = new Point();
    public int rocks;
    public Move(int row, int col, int rocks)
    {
        this.pos.row = row;
        this.pos.col = col;
        this.rocks = rocks;
    }
}