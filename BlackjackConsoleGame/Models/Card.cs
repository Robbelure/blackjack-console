using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsoleGame.Models
{
    public class Card
    {
        /// <summary>
        /// Typen eller sorten av kortet (hjerter, ruter, spar, kløver).
        /// </summary>
        public Suit Suit { get; set; }

        // Rank from 1 (Ace) - King (13)
        public int Rank { get; set; }

        /// <summary>
        /// Gir en strengrepresentasjon av kortet, e.g., "A of Hearts", "10 of Spades".
        /// </summary>
        /// <returns>Strengen som representerer kortet i lesbar form.</returns>
        public override string ToString()
        {
            string rankString = Rank switch
            {
                1 => "A", // Ess
                11 => "J", // Knekt
                12 => "Q", // Dame
                13 => "K", // Konge
                _ => Rank.ToString() // Nummerkort fra 2 til 10
            };
            return $"{rankString} of {Suit}";
        }
    }
}
