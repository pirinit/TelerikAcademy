public class GameFieldItem
{
    public bool isOccupied;
    public bool[] canNotHoldTile;

    public GameFieldItem()
    {
        this.canNotHoldTile = new bool[8];
    }
}