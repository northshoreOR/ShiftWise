using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DeckOfCards;

namespace DeckOfCardTests
{
	[TestFixture]

	public class CardTests
	{
		[Test]
		public void DeckHas52Cards()
		{
			//arrange
			List<Card> cards = new List<Card>();
			CardDeck cardDeck = new CardDeck(cards);

			//act
			int cardCount = cardDeck.PlayingCards.Count;

			//assert
			Assert.AreEqual(cardCount, 52);
		}

		[Test]
		public void DeckHasFourDistinctSuits()
		{
			//arange
			List<Card> cards = new List<Card>();
			CardDeck cardDeck = new CardDeck(cards);

			//act
			int countSuits = cardDeck.PlayingCards.Select(x => x.Suit.ToString()).Distinct().Count();

			//assert
			Assert.AreEqual(countSuits, 4);

		}

		[Test]
		public void DeckHasOriginalOrder()
		{
			//arange
			List<Card> cards = new List<Card>();
			CardDeck cardDeck = new CardDeck(cards);

			List<Card> cardOrderTemplate = new List<Card>();
			CardDeck masterDeck = new CardDeck(cardOrderTemplate);

			//act
			cardDeck.ShuffleCards(cards);
			cardDeck.SortCards(cards);


			var sortedDeck = cardDeck.PlayingCards.OrderBy(x => x.SortValue).ToList();

			//assert
			for (int i = 0; i < masterDeck.PlayingCards.Count; i++)
			{
				Assert.AreEqual(masterDeck.PlayingCards[i].CardValue, sortedDeck[i].CardValue);
				Assert.AreEqual(masterDeck.PlayingCards[i].Suit, sortedDeck[i].Suit);

			}
		}

		[Test]
		public void DeckHasBeenShuffled()
		{
			//arange
			List<Card> cards = new List<Card>();
			CardDeck cardDeck = new CardDeck(cards);
			int sumOfOneSuitValue = 91;

			//act
			cardDeck.ShuffleCards(cards);

			var sortedDeck = cardDeck.PlayingCards.OrderBy(x => x.SortValue).ToList();

			var clubs = sortedDeck.GetRange(0, 13).Where(x => x.Suit == Suits.Clubs);
			var diamonds = sortedDeck.GetRange(13, 13).Where(x => x.Suit == Suits.Diamonds);
			var hearts = sortedDeck.GetRange(26, 13).Where(x => x.Suit == Suits.Hearts);
			var spades = sortedDeck.GetRange(39, 13).Where(x => x.Suit == Suits.Spades);

			//assert
			Assert.AreNotEqual(13, clubs.Count());
			Assert.AreNotEqual(13, diamonds);
			Assert.AreNotEqual(13, hearts);
			Assert.AreNotEqual(13, spades);

			Assert.AreNotEqual(sumOfOneSuitValue, clubs.Select(x => x.CardValue).Sum());
			Assert.AreNotEqual(sumOfOneSuitValue, diamonds.Select(x => x.CardValue).Sum());
			Assert.AreNotEqual(sumOfOneSuitValue, hearts.Select(x => x.CardValue).Sum());
			Assert.AreNotEqual(sumOfOneSuitValue, spades.Select(x => x.CardValue).Sum());
		}

	}

}
