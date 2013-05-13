class Patern
{
    public string[] patern;
    public int height, width, cellsNeeded;
    public int maxHeight, maxWidth;

    public Patern(int height, int width, int cellsNeeded)
    {
        this.height = height;
        this.width = width;
        this.cellsNeeded = cellsNeeded;
        patern = new string[height];
    }
}
