class SpiralFill
{
    int n;
    int cells;
    int layerNumber = 0;
    byte[,] matrix;
    byte row = 1;
    byte col = 0;

    public SpiralFill(int cells, byte[,] targetMatrix)
    {
        this.n = targetMatrix.GetLength(0)-2;
        this.cells = cells;
        this.matrix = targetMatrix;
    }

    void FillOneLine(byte direction, byte lenght)
    {
        for (int i = 0; i < lenght; i++)
        {
            switch (direction)
            {
                case 1:
                    col++;
                    break;
                case 2:
                    row++;
                    break;
                case 3:
                    col--;
                    break;
                case 4:
                    row--;
                    break;
            }
            if (cells > 0)
            {
                matrix[row, col] = 1;
                cells--;
            }
            else
            {
                return;
            }
        }
    }

    void FillOneLayer()
    {
        FillOneLine(1, (byte)(n - layerNumber * 2));
        FillOneLine(2, (byte)(n - layerNumber * 2 - 1));
        FillOneLine(3, (byte)(n - layerNumber * 2 - 1));
        FillOneLine(4, (byte)(n - layerNumber * 2 - 2));
    }


    public void Go()
    {
        int i = 0;
        while (i < cells)
        {
            FillOneLayer();
            layerNumber++;
        }
    }
}