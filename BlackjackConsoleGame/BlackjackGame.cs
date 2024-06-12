using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackjackConsoleGame.Models;

namespace BlackjackConsoleGame
{
    public class BlackjackGame
    {
        private List<Player> players;
        private Deck deck;
        private Player dealer;

        public BlackjackGame()
        {
            players = new List<Player>();
            InitializePlayers();
        }

        private void InitializePlayers()
        {
            dealer = new Player("Dealer", isDealer: true);
            players.Add(dealer);
            players.Add(new Player("Alice"));
            players.Add(new Player("Bob"));
        }

        public void StartGame()
        {
            bool playAgain = true;
            while (playAgain) {
                PlayRound();
                Console.WriteLine("Play again? (y/n)");
                playAgain = Console.ReadLine().ToLower() == "y";
            }
        }

        // plays a single round of blackjack
        private void PlayRound()
        {
            deck = new Deck();

            foreach (Player player in players) {
                player.ResetHand();
            }

            DealInitialCards();
            DisplayDealerCard();
            PlayerTurns();
            DealerTurn();
            CompareHands();
        }

        private void DealInitialCards()
        {
            foreach (Player player in players) {
                player.AddCard(deck.DrawCard());
                if (!player.IsDealer)
                {
                    player.AddCard(deck.DrawCard());
                }
            }
        }

        // displays dealers first card
        private void DisplayDealerCard()
        {
            Console.WriteLine($"Dealer shows: {dealer.Hand[0]}");
        }

        private void PlayerTurns()
        {
            foreach (Player player in players.Where(p => !p.IsDealer)) {
                player.PlayTurn(deck);
            }
        }

        private void DealerTurn()
        {
            while (dealer.ComputeHandTotal() < 17) {
                dealer.AddCard(deck.DrawCard());
            }
            Console.WriteLine($"\nDealer's final hand ({dealer.ComputeHandTotal()}): {string.Join(", ", dealer.Hand)}");
        }

        // compares the hands of all players with the dealers hand 
        private void CompareHands()
        {
            foreach (Player player in players.Where(p => !p.IsDealer)) {
                player.CompareHands(dealer.Hand);
            }
        }
    }
}
