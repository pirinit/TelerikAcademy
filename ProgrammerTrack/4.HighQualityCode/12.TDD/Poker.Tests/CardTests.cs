using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void CreateTwoOfSpades()
        {
            Card card = new Card(CardFace.Two, CardSuit.Spades);

            string actual = card.ToString();
            string expected = "2♠";

            Assert.AreEqual(expected, actual, "Not working ToString() method.");
        }

        [TestMethod]
        public void CreateTenOfClubs()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Clubs);

            string actual = card.ToString();
            string expected = "T♣";

            Assert.AreEqual(expected, actual, "Not working ToString() method.");
        }

        [TestMethod]
        public void CreateAceOfDiamondss()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Diamonds);

            string actual = card.ToString();
            string expected = "A♦";

            Assert.AreEqual(expected, actual, "Not working ToString() method.");
        }

        [TestMethod]
        public void CreateNineOfHearts()
        {
            Card card = new Card(CardFace.Nine, CardSuit.Hearts);

            string actual = card.ToString();
            string expected = "9♥";

            Assert.AreEqual(expected, actual, "Not working ToString() method.");
        }
    }
}
