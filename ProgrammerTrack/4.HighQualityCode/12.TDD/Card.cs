using System;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            string result = "";

            switch (this.Face)
            {
                case CardFace.Ten:
                    result = "T";
                    break;
                case CardFace.Jack:
                    result = "J";
                    break;
                case CardFace.Queen:
                    result = "Q";
                    break;
                case CardFace.King:
                    result = "K";
                    break;
                case CardFace.Ace:
                    result = "A";
                    break;
                default:
                    result = ((int)this.Face).ToString();
                    break;
            }

            switch (this.Suit)
            {
                case CardSuit.Clubs:
                    result += "♣";
                    break;
                case CardSuit.Diamonds:
                    result += "♦";
                    break;
                case CardSuit.Hearts:
                    result += "♥";
                    break;
                case CardSuit.Spades:
                    result += "♠";
                    break;
            }

            return result;
        }
    }
}
