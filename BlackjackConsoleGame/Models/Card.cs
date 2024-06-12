using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsoleGame.Models
{
    public class Card
    {
        public Suit Suit { get; set; }
        public int Rank { get; set; }

        // string representation of cards
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
