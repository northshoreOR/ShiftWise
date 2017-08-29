using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
	public class Card
	{
		public Suits Suit { get; set; }
		public CardNames CardName { get; set; }
		public int CardValue { get; set; }
		public int SortValue { get; set; }

		public Card()
		{

		}

		public Card(Suits suit, CardNames cardName, int cardValue)
		{
			Suit = suit;
			CardName = cardName;
			CardValue = cardValue;
		}
	}
}
