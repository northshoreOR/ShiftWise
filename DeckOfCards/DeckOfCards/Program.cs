using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCards
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Card> cards = new List<Card>();
			CardDeck deck = new CardDeck(cards);

			deck.SortCards(cards);
			showResults(cards);

			deck.ShuffleCards(cards);
			showResults(cards);

			deck.SortCards(cards);
			showResults(cards);
		}

		private static void showResults(List<Card> cardDeck)
		{
			var cardList = cardDeck.OrderBy(x => x.SortValue);

			foreach (var card in cardList)
			{
				Console.WriteLine("{0} of {1}", card.CardName, card.Suit);
			}

			Console.ReadLine();
		}
	}

	public class CardDeck
	{
		public List<Card> PlayingCards { get; set; }

		public CardDeck(List<Card> cards)
		{
			PlayingCards = createDeck(cards);
		}

		public void SortCards(List<Card> cards)
		{
			for (int i = 0; i < cards.Count; i++)
			{
				cards[i].SortValue = i;
			}
		}

		public void ShuffleCards(List<Card> cards)
		{
			Random shuffle = new Random();

			for (int j = 0; j < cards.Count; j++)
			{
				cards[j].SortValue = shuffle.Next();
			}			
		}

		private List<Card> createDeck(List<Card> cardBox)
		{
			for (int suit = 1; suit < 5; suit++)
			{
				for (int i = 1; i < 14; i++)
				{
					Card card = new Card();

					card.CardValue = i;

					switch (i)
					{
						case 1:
							card.CardName = CardNames.Ace;
							break;
						case 2:
							card.CardName = CardNames.Two;
							break;
						case 3:
							card.CardName = CardNames.Three;
							break;
						case 4:
							card.CardName = CardNames.Four;
							break;
						case 5:
							card.CardName = CardNames.Five;
							break;
						case 6:
							card.CardName = CardNames.Six;
							break;
						case 7:
							card.CardName = CardNames.Seven;
							break;
						case 8:
							card.CardName = CardNames.Eight;
							break;
						case 9:
							card.CardName = CardNames.Nine;
							break;
						case 10:
							card.CardName = CardNames.Ten;
							break;
						case 11:
							card.CardName = CardNames.Jack;
							break;
						case 12:
							card.CardName = CardNames.Queen;
							break;
						case 13:
							card.CardName = CardNames.King;
							break;
					}

					switch (suit)
					{
						case 1:
							card.Suit = Suits.Clubs;
							break;
						case 2:
							card.Suit = Suits.Diamonds;
							break;
						case 3:
							card.Suit = Suits.Hearts;
							break;
						case 4:
							card.Suit = Suits.Spades;
							break;
					}

					cardBox.Add(card);
				}
			}
			return cardBox;
		}		
	}

	public enum Suits
	{
		Clubs,
		Diamonds,
		Hearts = 3,
		Spades = 4
	}

	public enum CardNames
	{
		Ace,
		Two,
		Three,
		Four,
		Five,
		Six,
		Seven,
		Eight,
		Nine,
		Ten,
		Jack,
		Queen,
		King
	}

}
