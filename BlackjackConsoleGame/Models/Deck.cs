using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsoleGame.Models
{
    public class Deck
    {
        public Queue<Card> Cards { get; private set; }
        public Deck()
        {
            Cards = new Queue<Card>();
            List<Card> allCards = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit))) {
                for (int i = 1; i <= 13; i++) {
                    allCards.Add(new Card() { Rank = i, Suit = suit });
                }
            }

            // shuffle -> randomize -> enqueue
            Shuffle(allCards);
            foreach (var card in allCards) {
                Cards.Enqueue(card);
            }
        }

        private void Shuffle(List<Card> cards)
        {
            var random = new Random();
            int n = cards.Count;
            while (n > 1) {
                int k = random.Next(n--);
                Card temp = cards[n];
                cards[n] = cards[k];
                cards[k] = temp;
            }
        }

        // draws the card thats on top from deck
        public Card DrawCard()
        {
            return Cards.Dequeue();
        }
    }
}
