using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class PokerHandsCheckerTests
    {
        [TestMethod]
        public void CheckValidHand()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool actual = checker.IsValidHand(hand);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckInvalidHandDuplicatingCards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool actual = checker.IsValidHand(hand);
            bool expected = false;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckInvalidHandLessCards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool actual = checker.IsValidHand(hand);
            bool expected = false;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckInvalidHandMoreCards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool actual = checker.IsValidHand(hand);
            bool expected = false;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsFourOfKindValidHand()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool actual = checker.IsFourOfAKind(hand);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsFourOfKindInvalidHand()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Three, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool actual = checker.IsFourOfAKind(hand);
            bool expected = false;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsFlushValidHand()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool actual = checker.IsFlush(hand);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsFlushInvalidHand()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool actual = checker.IsFlush(hand);
            bool expected = false;

            Assert.AreEqual(expected, actual);
        }
    }
}
