using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsoleGame.Models
{
    public class Player
    {
        public string Name { get; private set; }
        public List<Card> Hand { get; private set; }
        public bool IsDealer { get; private set; }

        public Player(string name, bool isDealer = false)
        {
            Name = name;
            Hand = new List<Card>();
            IsDealer = isDealer;
        }

        public void AddCard(Card card)
        {
            Hand.Add(card);
        }

        public void ResetHand()
        {
            Hand.Clear();
        }

        public int ComputeHandTotal()
        {
            return ComputeHandTotal(Hand);
        }

        public static int ComputeHandTotal(List<Card> hand)
        {
            int total = 0;
            int aceCount = hand.Count(card => card.Rank == 1);
            foreach (var card in hand) {
                int cardValue = card.Rank > 10 ? 10 : card.Rank;
                total += cardValue == 1 ? 11 : cardValue;
            }
            while (total > 21 && aceCount > 0) {
                total -= 10;
                aceCount--;
            }
            return total;
        }

        public void PlayTurn(Deck deck)
        {
            int initialHandTotal = ComputeHandTotal();
            Console.WriteLine($"\n{Name}'s hand ({initialHandTotal}): {string.Join(", ", Hand)}");

            if (initialHandTotal == 21) {
                Console.WriteLine("Blackjack!!");
                return;
            }

            while (true) {
                Console.WriteLine("Hit or stand? (h/s)");
                string choice = Console.ReadLine().ToLower();

                if (choice == "s") break;
                if (choice == "h") {
                    Card card = deck.DrawCard();
                    AddCard(card);                   
                    int handTotal = ComputeHandTotal();

                    Console.WriteLine($"\nYou hit: {card}");
                    Console.WriteLine($"{Name}'s hand ({handTotal}): {string.Join(", ", Hand)}");

                    if (handTotal > 21) {
                        Console.WriteLine("Bust! You lose.");
                        break;
                    }
                    if (handTotal == 21) {
                        Console.WriteLine("Blackjack!!");
                        break;
                    }
                }
            }
        }

        public void CompareHands(List<Card> dealerHand)
        {
            int playerTotal = ComputeHandTotal();
            int dealerTotal = ComputeHandTotal(dealerHand);
            if (playerTotal > 21 && dealerTotal > 21) {
                Console.WriteLine($"{Name} busts! Dealer busts. It's a tie.");
            }
            else if (playerTotal > 21) {
                Console.WriteLine($"{Name} busts! Dealer wins.");
            }
            // Sjekk om dealeren har bustet
            else if (dealerTotal > 21) {
                Console.WriteLine($"{Name} wins! Dealer busts.");
            }
            else if (playerTotal > dealerTotal) {
                Console.WriteLine($"{Name} wins!");
            }
            // Sjekk om dealeren har høyere håndverdi enn spilleren
            else if (playerTotal < dealerTotal) {
                Console.WriteLine($"{Name} loses. Dealer wins.");
            }
            else {
                Console.WriteLine($"{Name} ties with the dealer.");
            }
        }
    }
}
