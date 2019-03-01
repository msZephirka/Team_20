using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballPlayers
{
    class Program
    {
        //Возможные значения для поля амплуа
        enum Roles
        {
            Goalkeeper,     //вратарь
            Quarterback,    //защитник
            Halfback,       //полузащитник
            Forward         //нападающий
        };

        //Описание структуры, описывающей футболистов
        struct Football_players
        {
            String Surname;         //Фамилия
            DateTime Birthday;      //Дата рождения
            String PlaceOfBorn;     //Место рождения
            Roles Role;             //Амплуа
            int CountGames;         //Количество игр
            int CountYellowLabel;   //Количество желтых карточек
        }

        static void Main(string[] args)
        {
        }
    }
}
