using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballPlayers
{
    class Program
    {
        enum Roles
        {
            Goalkeeper,
            Quarterback,
            Halfback,
            Forward
        };

        struct Football_players
        {
            String Surname;
            DateTime Birthday;
            String PlaceOfBorn;
            Roles Role;
            int CountGames;
            int CountYellowLabel;
        }

        static void Main(string[] args)
        {
        }
    }
}
