using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void CreateSampleValidHand()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            string actual = hand.ToString();
            string expected = "2♣6♣J♣7♣T♣";

            Assert.AreEqual(expected, actual, "Not working ToString() method.");
        }

        [TestMethod]
        public void CreateSampleShorterHand()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            string actual = hand.ToString();
            string expected = "2♣6♣7♣T♣";

            Assert.AreEqual(expected, actual, "Not working ToString() method.");
        }

        [TestMethod]
        public void CreateSampleLongerHand()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            string actual = hand.ToString();
            string expected = "2♣6♣J♣7♣T♣Q♣";

            Assert.AreEqual(expected, actual, "Not working ToString() method.");
        }
    }
}
