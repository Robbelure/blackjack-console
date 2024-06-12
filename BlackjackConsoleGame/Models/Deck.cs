using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsoleGame.Models
{
    public class Deck
    {
        /// <summary>
        /// En kø for å holde på kortene i kortstokken.
        /// </summary>
        public Queue<Card> Cards { get; private set; }

        /// <summary>
        /// Konstruktør som oppretter og blander kortstokken.
        /// </summary>
        public Deck()
        {
            Cards = new Queue<Card>();
            List<Card> allCards = new List<Card>();

            // Legger til ett kort av hver rang og sort til en midlertidig liste.
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for (int i = 1; i <= 13; i++) // inkluderer ess, knekt, dame, konge
                {
                    allCards.Add(new Card() { Rank = i, Suit = suit });
                }
            }

            // Blander listen av kort ved hjelp av en tilfeldighetsgenerator og enqueuer dem deretter.
            Shuffle(allCards);
            foreach (var card in allCards)
            {
                Cards.Enqueue(card);
            }
        }

        /// <summary>
        /// Blander kortene i en liste.
        /// </summary>
        /// <param name="cards">Listen av kort som skal blandes.</param>
        private void Shuffle(List<Card> cards)
        {
            var random = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                int k = random.Next(n--);
                Card temp = cards[n];
                cards[n] = cards[k];
                cards[k] = temp;
            }
        }

        /// <summary>
        /// Trekker det øverste kortet fra kortstokken.
        /// </summary>
        public Card DrawCard()
        {
            return Cards.Dequeue();
        }
    }
}
