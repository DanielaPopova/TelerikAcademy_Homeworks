namespace Deck.Test
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;
    using Santase.Logic;
    using Santase.Logic.Cards;

    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void DeckConstructor_TrumpCard_ShouldNotBeNull()
        {
            var deck = new Deck();

            Assert.IsNotNull(deck.TrumpCard);
        }

        [Test]
        public void CardsLeft_ShouldBe24()
        {
            var deck = new Deck();

            Assert.AreEqual(24, deck.CardsLeft);
        }

        [Test]
        public void GetNextCard_AfterLastCardIsDrawn_ShouldThrowAnException()
        {
            var deck = new Deck();

            for (int i = 0; i < 24; i++)
            {
                deck.GetNextCard();
            }

            Assert.Throws<InternalGameException>(() => deck.GetNextCard());
        }

        [Test]
        public void GetNextCard_If24CardsAreDrawn_CardsLeftShouldBe0()
        {
            var deck = new Deck();

            for (int i = 0; i < 24; i++)
            {
                deck.GetNextCard();
            }

            Assert.AreEqual(0, deck.CardsLeft);
        }

        [TestCase(5, 24 - 5)]
        [TestCase(10, 24 - 10)]
        [TestCase(15, 24 - 15)]
        public void GetNextCard_CardsLeft_ShouldDecreaseNTimesAfterNDrawings(int drawings, int expectedCardsLeft)
        {
            var deck = new Deck();

            for (int i = 0; i < drawings; i++)
            {
                deck.GetNextCard();
            }

            Assert.AreEqual(expectedCardsLeft, deck.CardsLeft);
        }

        [Test]
        public void GetNextCard_ShouldNotReturnNullCard()
        {
            var deck = new Deck();

            for (int i = 0; i < 24; i++)
            {
                Assert.IsNotNull(deck.GetNextCard());
            }
        }

        [TestCase(9)]
        [TestCase(15)]
        [TestCase(21)]
        public void GetNextCard_ShouldReturnDifferentCardEveryTime(int drawings)
        {
            var deck = new Deck();
            var drawnCards = new List<Card>();

            for (int i = 0; i < drawings; i++)
            {
                drawnCards.Add(deck.GetNextCard());
            }

            for (int i = 0; i < drawnCards.Count - 1; i++)
            {
                Card card = drawnCards[i];

                for (int j = i + 1; j < drawnCards.Count; j++)
                {
                    if (card.Equals(drawnCards[j]))
                    {
                        Assert.Fail("Duplicate card is drawn! Method should remove card after it's drawn!");
                    }
                }
            }
        }
        
        [Test]
        public void ChangeTrumpCard_ShouldChangeTrumpCardCorrectly()
        {
            var deck = new Deck();           
            Card newTrumpCard = Card.GetCard(CardSuit.Heart, CardType.Jack);
            deck.ChangeTrumpCard(newTrumpCard);
            Card changedTrumpCard = deck.TrumpCard;

            Assert.AreEqual(newTrumpCard, changedTrumpCard);
        }

        [Test]
        public void ChangeTrumpCard_LastCardOfDeck_ShoulBeTheTrumpCard()
        {
            var deck = new Deck();
            Card newTrumpCard = new Card(CardSuit.Spade, CardType.Nine);
            deck.ChangeTrumpCard(newTrumpCard);
            int cardsCount = deck.CardsLeft;

            for (int i = 0; i < cardsCount - 1; i++)
            {
                deck.GetNextCard();
            }

            Assert.AreEqual(newTrumpCard, deck.GetNextCard());
        }
    }
}
