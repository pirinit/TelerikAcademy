using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PotentialPatern : IComparable<PotentialPatern>
{
    public Patern patern;
    public int upperRow;
    public int upperCol;
    public int lowerRow;
    public int lowerCol;
    public int foodInRange;

    public PotentialPatern(Patern patern, int upperRow, int upperCol, int lowerRow, int lowerCol)
    {
        this.patern = patern;
        this.upperRow = upperRow;
        this.upperCol = upperCol;
        this.lowerRow = lowerRow; 
        this.lowerCol = lowerCol;
        this.foodInRange = VodoNedorasliAlgo.CalcFoodQuantity(upperRow, upperCol, lowerRow, lowerCol);
    }

    public int CompareTo(PotentialPatern other)
    {
        return other.foodInRange.CompareTo(this.foodInRange);
    }
}