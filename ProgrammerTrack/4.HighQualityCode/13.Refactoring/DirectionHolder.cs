public class DirectionHolder
{
    private int[] deltaCol;
    private int[] deltaRow;
    private int currentDirection = 0;

    public void Next()
    {
        this.currentDirection++;
        if (this.currentDirection > 7)
        {
            this.currentDirection = 0;
        }
    }

    public int DeltaCol
    {
        get
        {
            return this.deltaCol[currentDirection];
        }
    }

    public int DeltaRow
    {
        get
        {
            return this.deltaRow[currentDirection];
        }
    }

    public DirectionHolder()
    {
        this.currentDirection = 0;
        this.deltaCol = new int[] { 1, 0, -1, -1, -1, 0, 1, 1 };
        this.deltaRow = new int[] { 1, 1, 1, 0, -1, -1, -1, 0 };
    }
}
