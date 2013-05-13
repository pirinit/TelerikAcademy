class AngleDR : Tile
{
    public AngleDR(int row, int col, bool[,] gameField)
    {
        this.row = row;
        this.col = col;
        this.gameField = gameField;
    }

    public override bool IsPlacePossible(int row, int col)
    {
        if (gameField[row, col] ||
            gameField[row, col + 1] ||
            gameField[row - 1, col])
        {
            return false;
        }

        return true;
    }

    public override void Place()
    {
        gameField[row, col] = true;
        gameField[row, col - 1] = true;
        gameField[row + 1, col] = true;

        this.isFixed = true;
    }
}