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
                1 => "A", // ace
                11 => "J", // jack
                12 => "Q", // queen
                13 => "K", // king
                _ => Rank.ToString() // 2-10
            };
            return $"{rankString} of {Suit}";
        }
    }
}
