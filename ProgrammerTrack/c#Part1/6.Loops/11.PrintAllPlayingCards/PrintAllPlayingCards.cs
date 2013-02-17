using System;

class PrintAllPlayingCards
{
    static void Main()
    {
        string suit = "";
        string rank = "";
        for (int i = 1; i <= 4; i++)
        {
            switch (i)
            {
                case 1:
                    suit = "spades";
                    break;
                case 2:
                    suit = "hearts";
                    break;
                case 3:
                    suit = "diamonds";
                    break;
                case 4:
                    suit = "clubs";
                    break;
            }
            for (int j = 1; j <= 13; j++)
            {
                switch (j)
                {
                    case 1:
                        rank = "Ace";
                        break;
                    case 2:
                        rank = "Two";
                        break;
                    case 3:
                        rank = "Three";
                        break;
                    case 4:
                        rank = "Four";
                        break;
                    case 5:
                        rank = "Five";
                        break;
                    case 6:
                        rank = "Six";
                        break;
                    case 7:
                        rank = "Seven";
                        break;
                    case 8:
                        rank = "Eight";
                        break;
                    case 9:
                        rank = "Nine";
                        break;
                    case 10:
                        rank = "Ten";
                        break;
                    case 11:
                        rank = "Jack";
                        break;
                    case 12:
                        rank = "Queen";
                        break;
                    case 13:
                        rank = "King";
                        break;
                }
                Console.WriteLine("{0} of {1}.", rank, suit);
            }
        }
    }
}