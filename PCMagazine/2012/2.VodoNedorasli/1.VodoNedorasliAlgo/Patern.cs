class Patern
{
    public string[] patern;
    public int height, width, cellsNeeded;
    public int maxHeight, maxWidth;
    public int rowOffset, colOffset;

    public Patern(int height, int width, int cellsNeeded, int maxWidth, int maxHeight, int rowOffset, int colOffset)
    {
        this.height = height;
        this.width = width;
        this.cellsNeeded = cellsNeeded;
        this.maxHeight = maxHeight;
        this.maxWidth = maxWidth;
        this.rowOffset = rowOffset;
        this.colOffset = colOffset;

        patern = new string[height];
    }

    public Patern(int height, int width, int cellsNeeded)
    {
        this.height = height;
        this.width = width;
        this.cellsNeeded = cellsNeeded;
        patern = new string[height];
    }
}
