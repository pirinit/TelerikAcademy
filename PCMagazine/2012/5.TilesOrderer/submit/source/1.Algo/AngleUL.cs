class AngleUL : Tile
{
    public AngleUL(int row, int col, bool[,] gameField)
    {
        this.row = row;
        this.col = col;
        this.gameField = gameField;
    }

    public override bool IsPlacePossible(int row, int col)
    {
        if (gameField[row + 1, col] ||
            gameField[row, col - 1] ||
            gameField[row, col])
        {
            return false;
        }

        return true;
    }

    public override void Place()
    {
        gameField[row + 1, col] = true;
        gameField[row, col - 1] = true;
        gameField[row, col] = true;

        this.isFixed = true;
    }
}