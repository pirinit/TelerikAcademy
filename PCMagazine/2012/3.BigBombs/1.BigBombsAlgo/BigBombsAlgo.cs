using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

class BigBombsAlgo
{
    const int Timer = 10000;
    const int ChickenPrice = 1;
    const int MinePrice = 6;
    const int PigPrice = 7;
    const int BombPrice = 10;
    const int Offset = 45;
    const int MaxBombRange = 19;
    const int GameFieldSize = 100;
    const int AvailableMoney = 200;
    const int GameFieldLeft = Offset;
    const int GameFieldRight = Offset + GameFieldSize;
    const int GameFieldTop = Offset;
    const int GameFieldBottom = Offset + GameFieldSize;

    public class DeffenseUnit
    {
        public int x;
        public int y;
        public int value;
        public int strength;
        public bool isAlive;
        public int number;

        public DeffenseUnit(int value, int strength, int x, int y, int number)
        {
            this.value = value;
            this.strength = strength;
            this.x = x;
            this.y = y;
            this.number = number;
            this.isAlive = true;
        }

        public override string ToString()
        {
            return String.Format("strength {0}, [{1},{2}]", this.strength, this.x, this.y);
        }
    }

    public class AttackUnit : IComparable<AttackUnit>
    {
        public int x;
        public int y;
        public int value;
        private int strength;
        public int damage;
        public double efficiency;
        public List<int> destroyedMines;
        public List<int> destryedChickens;

        public int Strength
        {
            get
            {
                return this.strength;
            }
            set
            {
                this.strength = value;
                this.value = value * PigPrice;
            }
        }

        public AttackUnit(int strength, int x, int y)
        {
            this.Strength = strength;
            this.x = x;
            this.y = y;
            this.value = strength * PigPrice;
            this.destroyedMines = new List<int>(201);
            this.destryedChickens = new List<int>(201);
        }

        public int CompareTo(AttackUnit other)
        {
            return this.efficiency.CompareTo(other.efficiency);
        }

        public override string ToString()
        {
            return String.Format("strength {0}, [{1},{2}]", this.Strength, this.x, this.y);
        }
    }

    public class Bomb
    {
        public int x;
        public int y;
        private int value;
        private int range;
        public int damage;
        public double efficiency;
        public List<int> destroyedMines;
        public List<int> destroyedChickens;

        public int Range
        {
            get
            {
                return this.range;
            }
            set
            {
                this.range = value;
                this.value = value * BombPrice + BombPrice;
            }
        }

        public int Value
        {
            get
            {
                return this.value;
            }
        }

        public Bomb(int range, int x, int y)
        {
            this.Range = range;
            this.x = x;
            this.y = y;
            this.destroyedMines = new List<int>();
            this.destroyedChickens = new List<int>();
        }

        public Bomb Clone()
        {
            Bomb cloned = new Bomb(this.range, this.x, this.y);
            cloned.damage = this.damage;
            cloned.efficiency = this.efficiency;
            for (int i = 0; i < this.destroyedChickens.Count; i++)
            {
                cloned.destroyedChickens.Add(this.destroyedChickens[i]);
            }

            for (int i = 0; i < this.destroyedMines.Count; i++)
            {
                cloned.destroyedMines.Add(this.destroyedMines[i]);
            }
            return cloned;
        }
        //void CalcBomb()
        //{
        //    DeffenseUnit currentDeffense;
        //    for (int deltaY = 0; deltaY <= Range; deltaY++)
        //    {
        //        for (int deltaX = -bombBorders[Range][deltaY]; deltaX <= bombBorders[Range][deltaY]; deltaX++)
        //        {
        //            currentDeffense = gameField[this.x + deltaX, this.y + deltaY];
        //            if (currentDeffense != null)
        //            {
        //                this.damage += currentDeffense.value;
        //                if (currentDeffense.strength == 0)
        //                {
        //                    //mine
        //                    this.destroyedMines.Add(currentDeffense.number);
        //                }
        //                else
        //                {
        //                    //chickens
        //                    this.destroyedChickens.Add(currentDeffense.number);
        //                }
        //            }
        //        }
        //    }
        //    for (int deltaY = -1; deltaY >= -Range; deltaY--)
        //    {
        //        for (int deltaX = -bombBorders[Range][-deltaY]; deltaX <= bombBorders[Range][-deltaY]; deltaX++)
        //        {
        //            currentDeffense = gameField[this.x + deltaX, this.y + deltaY];
        //            if (currentDeffense != null)
        //            {
        //                this.damage += currentDeffense.value;
        //                if (currentDeffense.strength == 0)
        //                {
        //                    //mine
        //                    this.destroyedMines.Add(currentDeffense.number);
        //                }
        //                else
        //                {
        //                    //chickens
        //                    this.destroyedChickens.Add(currentDeffense.number);
        //                }
        //            }
        //        }
        //    }
        //    this.efficiency = (double)this.damage / this.Range;
        //}
    }

    public class GameSolution
    {
        public int damage;
        public int value;
        public StringBuilder output = new StringBuilder();
    }

    public static DeffenseUnit[,] gameField;
    public static List<DeffenseUnit> mines;
    public static List<DeffenseUnit> chickens;
    public static List<AttackUnit> possibleAttacks;
    public static int deffenseValue;
    public static int money;
    public static int[] deltaXDeffence;
    public static int[] deltaYDeffence;
    public static List<List<int>> nextLayerElementsDeltaX;
    public static List<List<int>> nextLayerElementsDeltaY;
    public static List<Bomb> bestBombsMine;
    public static List<Bomb> bestBombsDamage;
    public static List<Bomb> bestBombsMineAndDamage;

    static void Init()
    {
        deltaXDeffence = new int[] { 0, 2, 0, -2 };
        deltaYDeffence = new int[] { 2, 0, -2, 0 };
        //bombBorders = new List<List<int>>();
        //bombBorders.Add(new List<int> { 0, });
        //bombBorders.Add(new List<int> { 1, 0, });
        //bombBorders.Add(new List<int> { 2, 1, 0, });
        //bombBorders.Add(new List<int> { 3, 2, 2, 0, });
        //bombBorders.Add(new List<int> { 4, 3, 3, 2, 0, });
        //bombBorders.Add(new List<int> { 5, 4, 4, 4, 3, 0, });
        //bombBorders.Add(new List<int> { 6, 5, 5, 5, 4, 3, 0, });
        //bombBorders.Add(new List<int> { 7, 6, 6, 6, 5, 4, 3, 0, });
        //bombBorders.Add(new List<int> { 8, 7, 7, 7, 6, 6, 5, 3, 0, });
        //bombBorders.Add(new List<int> { 9, 8, 8, 8, 8, 7, 6, 5, 4, 0, });
        //bombBorders.Add(new List<int> { 10, 9, 9, 9, 9, 8, 8, 7, 6, 4, 0, });
        //bombBorders.Add(new List<int> { 11, 10, 10, 10, 10, 9, 9, 8, 7, 6, 4, 0, });
        //bombBorders.Add(new List<int> { 12, 11, 11, 11, 11, 10, 10, 9, 8, 7, 6, 4, 0, });
        //bombBorders.Add(new List<int> { 13, 12, 12, 12, 12, 12, 11, 10, 10, 9, 8, 6, 5, 0, });
        //bombBorders.Add(new List<int> { 14, 13, 13, 13, 13, 13, 12, 12, 11, 10, 9, 8, 7, 5, 0, });
        //bombBorders.Add(new List<int> { 15, 14, 14, 14, 14, 14, 13, 13, 12, 12, 11, 10, 9, 7, 5, 0, });
        //bombBorders.Add(new List<int> { 16, 15, 15, 15, 15, 15, 14, 14, 13, 13, 12, 11, 10, 9, 7, 5, 0, });
        //bombBorders.Add(new List<int> { 17, 16, 16, 16, 16, 16, 15, 15, 15, 14, 13, 12, 12, 10, 9, 8, 5, 0, });
        //bombBorders.Add(new List<int> { 18, 17, 17, 17, 17, 17, 16, 16, 16, 15, 14, 14, 13, 12, 11, 9, 8, 5, 0, });
        //bombBorders.Add(new List<int> { 19, 18, 18, 18, 18, 18, 18, 17, 17, 16, 16, 15, 14, 13, 12, 11, 10, 8, 6, 0, });

        bestBombsMine = new List<Bomb>(21);
        bestBombsDamage = new List<Bomb>(21);
        bestBombsMineAndDamage = new List<Bomb>(21);
        nextLayerElementsDeltaX = new List<List<int>>();
        nextLayerElementsDeltaY = new List<List<int>>();
        nextLayerElementsDeltaX.Add(new List<int> { 0, });
        nextLayerElementsDeltaX.Add(new List<int> { -1, 0, 0, 1, });
        nextLayerElementsDeltaX.Add(new List<int> { -2, -1, -1, 0, 0, 1, 1, 2, });
        nextLayerElementsDeltaX.Add(new List<int> { -3, -2, -2, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 2, 2, 3, });
        nextLayerElementsDeltaX.Add(new List<int> { -4, -3, -3, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 3, 3, 4, });
        nextLayerElementsDeltaX.Add(new List<int> { -5, -4, -4, -4, -4, -4, -4, -3, -3, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 5, });
        nextLayerElementsDeltaX.Add(new List<int> { -6, -5, -5, -5, -5, -5, -5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 5, 5, 5, 5, 6, });
        nextLayerElementsDeltaX.Add(new List<int> { -7, -6, -6, -6, -6, -6, -6, -5, -5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 6, 6, 6, 6, 7, });
        nextLayerElementsDeltaX.Add(new List<int>
        {
            -8, -7, -7, -7, -7, -7, -7, -6, -6, -6, -6, -5, -5, -5, -5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 8,
        });
        nextLayerElementsDeltaX.Add(new List<int>
        {
            -9, -8, -8, -8, -8, -8, -8, -8, -8, -7, -7, -7, -7, -6, -6, -5, -5, -4, -4, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 4, 4, 5, 5, 6, 6, 7, 7, 7, 7,
            8, 8, 8, 8, 8, 8, 8, 8, 9,
        });
        nextLayerElementsDeltaX.Add(new List<int>
        {
            -10, -9, -9, -9, -9, -9, -9, -9, -9, -8, -8, -8, -8, -7, -7, -7, -7, -6, -6, -6, -6, -5, -5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6,
            6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 9, 9, 9, 9, 9, 9, 9, 9, 10,
        });
        nextLayerElementsDeltaX.Add(new List<int>
        {
            -11, -10, -10, -10, -10, -10, -10, -10, -10, -9, -9, -9, -9, -8, -8, -7, -7, -6, -6, -5, -5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6,
            7, 7, 8, 8, 9, 9, 9, 9, 10, 10, 10, 10, 10, 10, 10, 10, 11,
        });
        nextLayerElementsDeltaX.Add(new List<int>
        {
            -12, -11, -11, -11, -11, -11, -11, -11, -11, -10, -10, -10, -10, -9, -9, -8, -8, -7, -7, -6, -6, -5, -5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4,
            5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 10, 10, 11, 11, 11, 11, 11, 11, 11, 11, 12,
        });
        nextLayerElementsDeltaX.Add(new List<int>
        {
            -13, -12, -12, -12, -12, -12, -12, -12, -12, -12, -12, -11, -11, -11, -11, -10, -10, -10, -10, -9, -9, -9, -9, -8, -8, -8, -8, -7, -7, -6, -6, -5, -5, -5, -5, -4, -4,
            -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 5, 5, 6, 6, 7, 7, 8, 8, 8, 8, 9, 9, 9, 9, 10, 10, 10, 10, 11, 11, 11, 11, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 13,
        });
        nextLayerElementsDeltaX.Add(new List<int>
        {
            -14, -13, -13, -13, -13, -13, -13, -13, -13, -13, -13, -12, -12, -12, -12, -11, -11, -11, -11, -10, -10, -9, -9, -8, -8, -7, -7, -7, -7, -6, -6, -5, -5, -4, -4, -3, - 3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 11, 11, 12, 12, 12, 12, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 14,
        });
        nextLayerElementsDeltaX.Add(new List<int>
        {
            -15, -14, -14, -14, -14, -14, -14, -14, -14, -14, -14, -13, -13, -13, -13, -12, -12, -12, -12, -11, -11, -11, -11, -10, -10, -10, -10, -9, -9, -9, -9, -8, -8, -7, -7,
            -6, -6, -5, -5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 9, 9, 10, 10, 10, 10, 11, 11, 11, 11, 12, 12, 12, 12, 13, 13, 13, 13, 14, 14, 14, 14, 14, 14, 14,
            14, 14, 14, 15,
        });
        nextLayerElementsDeltaX.Add(new List<int>
        {
            -16, -15, -15, -15, -15, -15, -15, -15, -15, -15, -15, -14, -14, -14, -14, -13, -13, -13, -13, -12, -12, -11, -11, -10, -10, -9, -9, -8, -8, -7, -7, -6, -6, -5, -5, - 4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13, 13, 13, 14, 14, 14, 14, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 16,
        });
        nextLayerElementsDeltaX.Add(new List<int>
        {
            -17, -16, -16, -16, -16, -16, -16, -16, -16, -16, -16, -15, -15, -15, -15, -15, -15, -14, -14, -14, -14, -13, -13, -12, -12, -12, -12, -11, -11, -10, -10, -9, -9, -8,
            -8, -8, -8, -7, -7, -6, -6, -5, -5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 12, 12, 13, 13, 14, 14, 14, 14, 15, 15, 15, 15,
            15, 15, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 17,
        });
        nextLayerElementsDeltaX.Add(new List<int>
        {
            -18, -17, -17, -17, -17, -17, -17, -17, -17, -17, -17, -16, -16, -16, -16, -16, -16, -15, -15, -14, -14, -14, -14, -13, -13, -13, -13, -12, -12, -11, -11, -11, -11, - 10, -10, -9, -9, -8, -8, -7, -7, -6, -6, -5, -5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 11, 11, 12, 12, 13, 13, 13, 13, 14, 14, 14, 14,
            15, 15, 16, 16, 16, 16, 16, 16, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 18,
        });
        nextLayerElementsDeltaX.Add(new List<int>
        {
            -19, -18, -18, -18, -18, -18, -18, -18, -18, -18, -18, -18, -18, -17, -17, -17, -17, -17, -17, -16, -16, -16, -16, -15, -15, -15, -15, -14, -14, -13, -13, -12, -12, - 11, -11, -10, -10, -10, -10, -9, -9, -8, -8, -7, -7, -6, -6, -6, -6, -5, -5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 10, 10, 11, 11, 12, 12,
            13, 13, 14, 14, 15, 15, 15, 15, 16, 16, 16, 16, 17, 17, 17, 17, 17, 17, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 19,
        });
        nextLayerElementsDeltaY.Add(new List<int> { 0, });
        nextLayerElementsDeltaY.Add(new List<int> { 0, -1, 1, 0, });
        nextLayerElementsDeltaY.Add(new List<int> { 0, -1, 1, -2, 2, -1, 1, 0, });
        nextLayerElementsDeltaY.Add(new List<int> { 0, -2, -1, 1, 2, -2, 2, -3, 3, -2, 2, -2, -1, 1, 2, 0, });
        nextLayerElementsDeltaY.Add(new List<int> { 0, -2, -1, 1, 2, -3, 3, -3, 3, -4, 4, -3, 3, -3, 3, -2, -1, 1, 2, 0, });
        nextLayerElementsDeltaY.Add(new List<int> { 0, -3, -2, -1, 1, 2, 3, -4, -3, 3, 4, -4, 4, -4, 4, -5, 5, -4, 4, -4, 4, -4, -3, 3, 4, -3, -2, -1, 1, 2, 3, 0, });
        nextLayerElementsDeltaY.Add(new List<int> { 0, -3, -2, -1, 1, 2, 3, -4, 4, -5, 5, -5, 5, -5, 5, -6, 6, -5, 5, -5, 5, -5, 5, -4, 4, -3, -2, -1, 1, 2, 3, 0, });
        nextLayerElementsDeltaY.Add(new List<int> { 0, -3, -2, -1, 1, 2, 3, -4, 4, -5, 5, -6, 6, -6, 6, -6, 6, -7, 7, -6, 6, -6, 6, -6, 6, -5, 5, -4, 4, -3, -2, -1, 1, 2, 3, 0, });
        nextLayerElementsDeltaY.Add(new List<int>
        {
            0, -3, -2, -1, 1, 2, 3, -5, -4, 4, 5, -6, -5, 5, 6, -6, 6, -7, 7, -7, 7, -7, 7, -8, 8, -7, 7, -7, 7, -7, 7, -6, 6, -6, -5, 5, 6, -5, -4, 4, 5, -3, -2, -1, 1, 2, 3, 0,
        });
        nextLayerElementsDeltaY.Add(new List<int>
        {
            0, -4, -3, -2, -1, 1, 2, 3, 4, -5, -4, 4, 5, -6, 6, -7, 7, -8, -7, 7, 8, -8, 8, -8, 8, -8, 8, -9, 9, -8, 8, -8, 8, -8, 8, -8, -7, 7, 8, -7, 7, -6, 6, -5, -4, 4, 5, -4,
            -3, -2, -1, 1, 2, 3, 4, 0,
        });
        nextLayerElementsDeltaY.Add(new List<int>
        {
            0, -4, -3, -2, -1, 1, 2, 3, 4, -6, -5, 5, 6, -7, -6, 6, 7, -8, -7, 7, 8, -8, 8, -9, 9, -9, 9, -9, 9, -9, 9, -10, 10, -9, 9, -9, 9, -9, 9, -9, 9, -8, 8, -8, -7, 7, 8,
            -7, -6, 6, 7, -6, -5, 5, 6, -4, -3, -2, -1, 1, 2, 3, 4, 0,
        });
        nextLayerElementsDeltaY.Add(new List<int>
        {
            0, -4, -3, -2, -1, 1, 2, 3, 4, -6, -5, 5, 6, -7, 7, -8, 8, -9, 9, -9, 9, -10, 10, -10, 10, -10, 10, -10, 10, -11, 11, -10, 10, -10, 10, -10, 10, -10, 10, -9, 9, -9, 9,
            -8, 8, -7, 7, -6, -5, 5, 6, -4, -3, -2, -1, 1, 2, 3, 4, 0,
        });
        nextLayerElementsDeltaY.Add(new List<int>
        {
            0, -4, -3, -2, -1, 1, 2, 3, 4, -6, -5, 5, 6, -7, 7, -8, 8, -9, 9, -10, 10, -10, 10, -11, 11, -11, 11, -11, 11, -11, 11, -12, 12, -11, 11, -11, 11, -11, 11, -11, 11, - 10, 10, -10, 10, -9, 9, -8, 8, -7, 7, -6, -5, 5, 6, -4, -3, -2, -1, 1, 2, 3, 4, 0,
        });
        nextLayerElementsDeltaY.Add(new List<int>
        {
            0, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, -6, -5, 5, 6, -8, -7, 7, 8, -9, -8, 8, 9, -10, -9, 9, 10, -10, 10, -11, 11, -12, -11, 11, 12, -12, 12, -12, 12, -12, 12, -12, 12,
            -13, 13, -12, 12, -12, 12, -12, 12, -12, 12, -12, -11, 11, 12, -11, 11, -10, 10, -10, -9, 9, 10, -9, -8, 8, 9, -8, -7, 7, 8, -6, -5, 5, 6, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, 0,
        });
        nextLayerElementsDeltaY.Add(new List<int>
        {
            0, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, -7, -6, 6, 7, -8, -7, 7, 8, -9, 9, -10, 10, -11, 11, -12, -11, 11, 12, -12, 12, -13, 13, -13, 13, -13, 13, -13, 13, -13, 13, -14,
            14, -13, 13, -13, 13, -13, 13, -13, 13, -13, 13, -12, 12, -12, -11, 11, 12, -11, 11, -10, 10, -9, 9, -8, -7, 7, 8, -7, -6, 6, 7, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, 0,
        });
        nextLayerElementsDeltaY.Add(new List<int>
        {
            0, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, -7, -6, 6, 7, -9, -8, 8, 9, -10, -9, 9, 10, -11, -10, 10, 11, -12, -11, 11, 12, -12, 12, -13, 13, -13, 13, -14, 14, -14, 14, -14,
            14, -14, 14, -14, 14, -15, 15, -14, 14, -14, 14, -14, 14, -14, 14, -14, 14, -13, 13, -13, 13, -12, 12, -12, -11, 11, 12, -11, -10, 10, 11, -10, -9, 9, 10, -9, -8, 8, 9, -7, -6, 6, 7, -5, -4, -3, -2, -1,
            1, 2, 3, 4, 5, 0,
        });
        nextLayerElementsDeltaY.Add(new List<int>
        {
            0, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, -7, -6, 6, 7, -9, -8, 8, 9, -10, 10, -11, 11, -12, 12, -13, 13, -13, 13, -14, 14, -14, 14, -15, 15, -15, 15, -15, 15, -15, 15, - 15, 15, -16, 16, -15, 15, -15, 15, -15, 15, -15, 15, -15, 15, -14, 14, -14, 14, -13, 13, -13, 13, -12, 12, -11, 11, -10, 10, -9, -8, 8, 9, -7, -6, 6, 7, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, 0,
        });
        nextLayerElementsDeltaY.Add(new List<int>
        {
            0, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, -8, -7, -6, 6, 7, 8, -9, -8, 8, 9, -10, 10, -12, -11, 11, 12, -12, 12, -13, 13, -14, 14, -15, -14, 14, 15, -15, 15, -15, 15, -16,
            16, -16, 16, -16, 16, -16, 16, -16, 16, -17, 17, -16, 16, -16, 16, -16, 16, -16, 16, -16, 16, -15, 15, -15, 15, -15, -14, 14, 15, -14, 14, -13, 13, -12, 12, -12, -11, 11, 12, -10, 10, -9, -8, 8, 9, -8, - 7, -6, 6, 7, 8, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, 0,
        });
        nextLayerElementsDeltaY.Add(new List<int>
        {
            0, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, -8, -7, -6, 6, 7, 8, -9, 9, -11, -10, 10, 11, -12, -11, 11, 12, -13, 13, -14, -13, 13, 14, -14, 14, -15, 15, -16, 16, -16, 16, - 16, 16, -17, 17, -17, 17, -17, 17, -17, 17, -17, 17, -18, 18, -17, 17, -17, 17, -17, 17, -17, 17, -17, 17, -16, 16, -16, 16, -16, 16, -15, 15, -14, 14, -14, -13, 13, 14, -13, 13, -12, -11, 11, 12, -11, -10,
            10, 11, -9, 9, -8, -7, -6, 6, 7, 8, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, 0,
        });
        nextLayerElementsDeltaY.Add(new List<int>
        {
            0, -6, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, 6, -8, -7, -6, 6, 7, 8, -10, -9, 9, 10, -11, -10, 10, 11, -12, 12, -13, 13, -14, 14, -15, 15, -16, -15, 15, 16, -16, 16, -17,
            17, -17, 17, -18, -17, 17, 18, -18, 18, -18, 18, -18, 18, -18, 18, -18, 18, -19, 19, -18, 18, -18, 18, -18, 18, -18, 18, -18, 18, -18, -17, 17, 18, -17, 17, -17, 17, -16, 16, -16, -15, 15, 16, -15, 15, - 14, 14, -13, 13, -12, 12, -11, -10, 10, 11, -10, -9, 9, 10, -8, -7, -6, 6, 7, 8, -6, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, 6, 0,
        });
    }

    static void Main()
    {
        //ReadInput();
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        ReadInput();
        Init();
        CalcAllBombs();

        GameSolution bestSolution = new GameSolution();

        foreach (var bomb in bestBombsMine)
        {
            bestBombsDamage.Add(bomb);
        }
        foreach (var bomb in bestBombsMineAndDamage)
        {
            bestBombsDamage.Add(bomb);
        }

        // SendPigsMaxEfficiency
        bool firstRun = true;
        for (int i = -1; i < bestBombsDamage.Count; i++)
        {
            if (stopWatch.ElapsedMilliseconds > Timer)
            {
                break;
            }

            money = AvailableMoney;
            GameSolution solution = new GameSolution();

            //play game
            if (!firstRun)
            {
                DetonateBomb(solution, bestBombsDamage[i]);
            }
            firstRun = false;
            SendPigsMaxEfficiency(solution);
            //SendPigsMaxDamage(solution);
            //SendPigsMaxMinesDestroyed(solution);

            bool areAllMinesDestroyed = true;
            for (int j = 0; j < mines.Count; j++)
            {
                if (mines[j].isAlive)
                {
                    areAllMinesDestroyed = false;
                    break;
                }
            }
            if (areAllMinesDestroyed)
            {
                solution.damage *= 2;
            }
            if (bestSolution.damage < solution.damage)
            {
                bestSolution = solution;
            }

            //Console.WriteLine(solution.output);
            //Console.WriteLine("attackDamage: {0}, attackValue: {1}, deffenseValue: {2}", solution.damage, solution.value, deffenseValue);
            //Console.WriteLine("---------------------------------------");
            //Console.ReadLine();

            //resurect all deffense units

            
            for (int j = 0; j < mines.Count; j++)
            {
                mines[j].isAlive = true;
            }
            for (int j = 0; j < chickens.Count; j++)
            {
                chickens[j].isAlive = true;
            }
        }

        // SendPigsMaxDamage
        firstRun = true;
        for (int i = -1; i < bestBombsDamage.Count; i++)
        {
            if (stopWatch.ElapsedMilliseconds > Timer)
            {
                break;
            }

            money = AvailableMoney;
            GameSolution solution = new GameSolution();

            //play game
            if (!firstRun)
            {
                DetonateBomb(solution, bestBombsDamage[i]);
            }
            firstRun = false;
            //SendPigsMaxEfficiency(solution);
            SendPigsMaxDamage(solution);
            //SendPigsMaxMinesDestroyed(solution);

            bool areAllMinesDestroyed = true;
            for (int j = 0; j < mines.Count; j++)
            {
                if (mines[j].isAlive)
                {
                    areAllMinesDestroyed = false;
                    break;
                }
            }
            if (areAllMinesDestroyed)
            {
                solution.damage *= 2;
            }
            if (bestSolution.damage < solution.damage)
            {
                bestSolution = solution;
            }

            //Console.WriteLine(solution.output);
            //Console.WriteLine("attackDamage: {0}, attackValue: {1}, deffenseValue: {2}", solution.damage, solution.value, deffenseValue);
            //Console.WriteLine("---------------------------------------");
            //Console.ReadLine();

            //resurect all deffense units


            for (int j = 0; j < mines.Count; j++)
            {
                mines[j].isAlive = true;
            }
            for (int j = 0; j < chickens.Count; j++)
            {
                chickens[j].isAlive = true;
            }
        }

        // SendPigsMaxMinesDestroyed
        firstRun = true;
        for (int i = -1; i < bestBombsDamage.Count; i++)
        {
            if (stopWatch.ElapsedMilliseconds > Timer)
            {
                break;
            }

            money = AvailableMoney;
            GameSolution solution = new GameSolution();

            //play game
            if (!firstRun)
            {
                DetonateBomb(solution, bestBombsDamage[i]);
            }
            firstRun = false;
            //SendPigsMaxEfficiency(solution);
            //SendPigsMaxDamage(solution);
            SendPigsMaxMinesDestroyed(solution);

            bool areAllMinesDestroyed = true;
            for (int j = 0; j < mines.Count; j++)
            {
                if (mines[j].isAlive)
                {
                    areAllMinesDestroyed = false;
                    break;
                }
            }
            if (areAllMinesDestroyed)
            {
                solution.damage *= 2;
            }
            if (bestSolution.damage < solution.damage)
            {
                bestSolution = solution;
            }

            //Console.WriteLine(solution.output);
            //Console.WriteLine("attackDamage: {0}, attackValue: {1}, deffenseValue: {2}", solution.damage, solution.value, deffenseValue);
            //Console.WriteLine("---------------------------------------");
            //Console.ReadLine();

            //resurect all deffense units


            for (int j = 0; j < mines.Count; j++)
            {
                mines[j].isAlive = true;
            }
            for (int j = 0; j < chickens.Count; j++)
            {
                chickens[j].isAlive = true;
            }
        }

        Console.Write(bestSolution.output);
        Console.WriteLine("attackDamage: {0}, attackValue: {1}, deffenseValue: {2}", bestSolution.damage, bestSolution.value, deffenseValue);

        stopWatch.Stop();
        TimeSpan ts = stopWatch.Elapsed;

        // Format and display the TimeSpan value. 
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine("RunTime " + elapsedTime);
    }

    public static void ReadInput()
    {
        string input = Console.ReadLine();
        int commands = int.Parse(input);

        gameField = new DeffenseUnit[200, 200];
        mines = new List<DeffenseUnit>(commands);
        chickens = new List<DeffenseUnit>(commands);
        
        for (int i = 0; i < commands; i++)
        {
            input = Console.ReadLine();
            string[] inputs = input.Split();
            if (inputs[0][0] == 'c')
            {
                int count = int.Parse(inputs[1]);
                int x = int.Parse(inputs[2]) + Offset;
                int y = int.Parse(inputs[3]) + Offset;
                DeffenseUnit currentChickenGroup = new DeffenseUnit(count * ChickenPrice, count, x, y, chickens.Count);
                chickens.Add(currentChickenGroup);
                gameField[x, y] = currentChickenGroup;
                deffenseValue += currentChickenGroup.value;
            }
            else
            {
                int x = int.Parse(inputs[1]) + Offset;
                int y = int.Parse(inputs[2]) + Offset;
                DeffenseUnit currentMine = new DeffenseUnit(MinePrice, 0, x, y, mines.Count);
                mines.Add(currentMine);
                gameField[x, y] = currentMine;
                deffenseValue += currentMine.value;
            }
        }
    }

    public static void CalcAllPigs(List<DeffenseUnit> targets)
    {
        possibleAttacks = new List<AttackUnit>(targets.Count);

        foreach (var target in targets)
        {
            if (target.isAlive)
            {
                CheapestMineDestroy(target);
            }
        }
    }

    public static void CheapestMineDestroy(DeffenseUnit mine)
    {
        AttackUnit bestAttack = new AttackUnit(10000000,mine.x,mine.y);
        bestAttack.efficiency = 0;

        for (int row = mine.y - 1; row <= mine.y + 1; row++)
        {
            for (int col = mine.x - 1; col <= mine.x + 1; col++)
            {
                if (GameFieldTop > row || row > GameFieldBottom || GameFieldRight < col || col < GameFieldLeft)
                {
                    continue;
                }
                possibleAttacks.Add(AttackInPoint(col, row));
            }
        }
    }

    public static AttackUnit AttackInPoint(int x, int y)
    {
        int deffense = 0;
        AttackUnit currentAttack = new AttackUnit(0, x, y);

        DeffenseUnit currentDeffense;

        for (int row = y - 1; row <= y + 1; row++)
        {
            for (int col = x - 1; col <= x + 1; col++)
            {
                currentDeffense = gameField[col, row];
                if (currentDeffense != null && currentDeffense.isAlive)
                {
                    if (currentDeffense.strength == 0)
                    {
                        //mine
                        currentAttack.damage += currentDeffense.value;
                        currentAttack.destroyedMines.Add(currentDeffense.number);
                    }
                    else
                    {
                        //chickens
                        deffense += currentDeffense.strength;
                        currentAttack.destryedChickens.Add(currentDeffense.number);
                        currentAttack.damage += currentDeffense.value;
                    }
                }
            }
        }

        for (int i = 0; i < deltaXDeffence.Length; i++)
        {
            deffense += GetDeffenseInPoint(x + deltaXDeffence[i], y + deltaYDeffence[i]);
        }

        if (deffense == 0)
        {
            currentAttack.Strength = 1;
        }
        else
        {
            currentAttack.Strength = deffense / 2;
            if (deffense % 2 == 1)
            {
                currentAttack.Strength++;
            }
        }

        currentAttack.efficiency = (double)currentAttack.damage / currentAttack.Strength;
        return currentAttack;
    }

    public static int GetDeffenseInPoint(int x, int y)
    {
        if (gameField[x, y] != null)
        {
            if (gameField[x, y].isAlive)
            {
                return gameField[x, y].strength;
            }
        }
        return 0;
    }

    public static int PerformAttack(AttackUnit attack, GameSolution solution)
    {
        int destroyed = 0;

        for (int row = attack.y - 1; row <= attack.y + 1; row++)
        {
            for (int col = attack.x - 1; col <= attack.x + 1; col++)
            {
                if (gameField[col, row] != null && gameField[col,row].isAlive)
                {
                    gameField[col, row].isAlive = false;
                    destroyed += gameField[col, row].value;
                }
            }
        }
        solution.output.AppendFormat("pigs {0} {1} {2}", attack.Strength, attack.x - Offset, attack.y - Offset);
        solution.output.AppendLine();
        return destroyed;
    }

    public static void CalcAllBombs()
    {
        if (mines.Count != 0)
        {
            CalcAllBombsInPointInit(mines[0].x, mines[0].y);
        }
        else
        {
            CalcAllBombsInPointInit(chickens[0].x, chickens[0].y);
        }
        int lastElementIndex = GameFieldSize + Offset;
        for (int row = Offset; row < lastElementIndex; row++)
        {
            for (int col = Offset; col < lastElementIndex; col++)
            {
                CalcAllBombsInPoint(col, row);
            }
        }
    }

    public static void CalcAllBombsInPointInit(int x, int y)
    {
        Bomb currentBomb = new Bomb(0, x, y);
        for (int range = 0; range <= MaxBombRange; range++)
        {
            AddNextLayerElements(currentBomb, range, x, y);
            bestBombsDamage.Add(currentBomb.Clone());
            bestBombsMine.Add(currentBomb.Clone());
            bestBombsMineAndDamage.Add(currentBomb.Clone());
        }
    }

    public static void CalcAllBombsInPoint(int x, int y)
    {
        Bomb currentBomb = new Bomb(0, x, y);
        for (int range = 0; range <= MaxBombRange; range++)
        {
            AddNextLayerElements(currentBomb, range, x, y);
            if (bestBombsDamage[range].damage < currentBomb.damage)
            {
                bestBombsDamage[range] = currentBomb.Clone();
            }
            if (bestBombsMine[range].destroyedMines.Count < currentBomb.destroyedMines.Count)
            {
                bestBombsMine[range] = currentBomb.Clone();
            }
            if (bestBombsMineAndDamage[range].destroyedMines.Count < currentBomb.destroyedMines.Count
                && bestBombsMineAndDamage[range].damage < currentBomb.damage)
            {
                bestBombsMineAndDamage[range] = currentBomb;
            }
        }
    }

    private static void AddNextLayerElements(Bomb currentBomb, int range, int x, int y)
    {
        for (int element = 0; element < nextLayerElementsDeltaX[range].Count; element++)
        {
            int deltaX = nextLayerElementsDeltaX[range][element];
            int deltaY = nextLayerElementsDeltaY[range][element];
            DeffenseUnit currentDeffense = gameField[x + deltaX, y + deltaY];

            if (currentDeffense != null)
            {
                currentBomb.damage = currentDeffense.value;
                if (currentDeffense.strength == 0)
                {
                    //mine
                    currentBomb.destroyedMines.Add(currentDeffense.number);
                }
                else
                {
                    //chickens
                    currentBomb.destroyedChickens.Add(currentDeffense.number);
                }
            }
        }

        currentBomb.Range = range;
        currentBomb.efficiency = currentBomb.damage / currentBomb.Value;
    }

    private static void SendPigsMaxEfficiency(GameSolution solution)
    {
        int totalDestroyedValue = 0;
        int totalPigsValue = 0;
        AttackUnit attack = null;
        //try to destroy all mines
        CalcAllPigs(mines);
        if (possibleAttacks.Count > 0)
        {
            //there are living mines
            attack = bestAttackByEfficiency();

            while (attack != null && attack.value <= money)
            {
                totalDestroyedValue += PerformAttack(attack, solution);
                totalPigsValue += attack.value;
                money -= attack.value;
                CalcAllPigs(mines);
                attack = bestAttackByEfficiency();
            }
        }
        //try to destroy all chicken groups
        CalcAllPigs(chickens);

        if (possibleAttacks.Count > 0)
        {
            //there are living chickens groups
            attack = bestAttackByEfficiency();

            while (attack != null && attack.value <= money)
            {
                totalDestroyedValue += PerformAttack(attack, solution);
                totalPigsValue += attack.value;
                money -= attack.value;
                CalcAllPigs(chickens);
                attack = bestAttackByEfficiency();
            }
        }

        solution.damage += totalDestroyedValue;
        solution.value += totalPigsValue;
    }

    private static void SendPigsMaxDamage(GameSolution solution)
    {
        int totalDestroyedValue = 0;
        int totalPigsValue = 0;
        AttackUnit attack = null;
        //try to destroy all mines
        CalcAllPigs(mines);
        if (possibleAttacks.Count > 0)
        {
            //there are living mines
            attack = bestAttackByDamage();

            while (attack != null && attack.value <= money)
            {
                totalDestroyedValue += PerformAttack(attack, solution);
                totalPigsValue += attack.value;
                money -= attack.value;
                CalcAllPigs(mines);
                attack = bestAttackByDamage();
            }
        }
        //try to destroy all chicken groups
        CalcAllPigs(chickens);

        if (possibleAttacks.Count > 0)
        {
            //there are living chickens groups
            attack = bestAttackByDamage();

            while (attack != null && attack.value <= money)
            {
                totalDestroyedValue += PerformAttack(attack, solution);
                totalPigsValue += attack.value;
                money -= attack.value;
                CalcAllPigs(chickens);
                attack = bestAttackByDamage();
            }
        }

        solution.damage += totalDestroyedValue;
        solution.value += totalPigsValue;
    }

    private static void SendPigsMaxMinesDestroyed(GameSolution solution)
    {
        int totalDestroyedValue = 0;
        int totalPigsValue = 0;
        AttackUnit attack = null;
        //try to destroy all mines
        CalcAllPigs(mines);
        if (possibleAttacks.Count > 0)
        {
            //there are living mines
            attack = bestAttackByMinesDestroyed();

            while (attack != null && attack.value <= money)
            {
                totalDestroyedValue += PerformAttack(attack, solution);
                totalPigsValue += attack.value;
                money -= attack.value;
                CalcAllPigs(mines);
                attack = bestAttackByMinesDestroyed();
            }
        }
        //try to destroy all chicken groups
        CalcAllPigs(chickens);

        if (possibleAttacks.Count > 0)
        {
            //there are living chickens groups
            attack = bestAttackByMinesDestroyed();

            while (attack != null && attack.value <= money)
            {
                totalDestroyedValue += PerformAttack(attack, solution);
                totalPigsValue += attack.value;
                money -= attack.value;
                CalcAllPigs(chickens);
                attack = bestAttackByMinesDestroyed();
            }
        }

        solution.damage += totalDestroyedValue;
        solution.value += totalPigsValue;
    }

    private static AttackUnit bestAttackByEfficiency()
    {
        AttackUnit attack = null;
        if (possibleAttacks.Count > 0)
        {
            attack = possibleAttacks[0];

            for (int i = 0; i < possibleAttacks.Count; i++)
            {
                if (attack.efficiency < possibleAttacks[i].efficiency && possibleAttacks[i].value <= money)
                {
                    attack = possibleAttacks[i];
                }
            }
        }
        return attack;
    }

    private static AttackUnit bestAttackByDamage()
    {
        AttackUnit attack = null;
        if (possibleAttacks.Count > 0)
        {
            attack = possibleAttacks[0];

            for (int i = 0; i < possibleAttacks.Count; i++)
            {
                if (attack.damage < possibleAttacks[i].damage && possibleAttacks[i].value <= money)
                {
                    attack = possibleAttacks[i];
                }
            }
        }
        return attack;
    }

    private static AttackUnit bestAttackByMinesDestroyed()
    {
        AttackUnit attack = null;
        if (possibleAttacks.Count > 0)
        {
            attack = possibleAttacks[0];

            for (int i = 0; i < possibleAttacks.Count; i++)
            {
                if (attack.destroyedMines.Count < possibleAttacks[i].destroyedMines.Count && possibleAttacks[i].value <= money)
                {
                    attack = possibleAttacks[i];
                }
            }
        }
        return attack;
    }

    private static void DetonateBomb(GameSolution solution, Bomb bomb)
    {
        int damage = 0;
        for (int i = 0; i < bomb.destroyedMines.Count; i++)
        {
            int mineNumber = bomb.destroyedMines[i];
            mines[mineNumber].isAlive = false;
            damage += mines[mineNumber].value;
        }

        for (int i = 0; i < bomb.destroyedChickens.Count; i++)
        {
            int chickensNumber = bomb.destroyedChickens[i];
            chickens[chickensNumber].isAlive = false;
            damage += chickens[chickensNumber].value;
        }

        solution.damage += damage;
        solution.value += bomb.Value;
        solution.output.AppendFormat("bomb {0} {1} {2}", bomb.Range, bomb.x - Offset, bomb.y - Offset);
        solution.output.AppendLine();
        money -= bomb.Value;
    }
}