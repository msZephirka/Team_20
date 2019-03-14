using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            public static bool StringIsValid(string str)
            {
                return string.IsNullOrEmpty(str) && ((!Regex.IsMatch(str, @"^[A-Za-z]$")));// || !Regex.IsMatch(str, @"^[А-Яа-я]$")));
            }
            // Метод для добавления нового футболиста 
            public bool AddNewElement()
            {
                //Фамилия
                Console.WriteLine("Введите фамилию футболиста: ");
                Surname = Console.ReadLine();
                if (StringIsValid(Surname))
                {
                    Console.WriteLine("Фамилия может содержать только буквы русского алфавита");
                    return false;
                }


                //Дата рождения
                Console.WriteLine("Введите дату рождения в формате dd.mm.yyyy: ");
                try
                {
                    Birthday = Convert.ToDateTime(Console.ReadLine());
                    TimeSpan dt = DateTime.Now.Subtract(Birthday);
                    int year = new DateTime(dt.Ticks).Year-1;
                    if (year < 16 || year > 45)
                    {
                        Console.WriteLine("Футболист должен быть старше 16 и младше 40");
                        return false;
                    }
                }
                catch
                {
                    Console.WriteLine("Неправильно ввели дату рождения");
                    return false;
                }

                //Место рождения
                Console.WriteLine("Введите место рождения: ");
                PlaceOfBorn = Console.ReadLine();

                //Амплуа
                Console.WriteLine("Введите амплуа [0 - вратарь, 1 - защитник, 2 - полузащитник, 3 - нападающий]");
                int amplua;
                bool isNum = int.TryParse(Console.ReadLine(), out amplua);
                if (!isNum)
                {
                    Console.WriteLine("Неправильно ввели амплуа");
                    return false;
                }
                switch (amplua)
                {
                    case 0:
                        Role = Roles.Goalkeeper;
                        break;
                    case 1:
                        Role = Roles.Quarterback;
                        break;
                    case 2:
                        Role = Roles.Halfback;
                        break;
                    case 3:
                        Role = Roles.Forward;
                        break;
                    default:
                        Console.WriteLine("Неправильно ввели амплуа");
                        return false;
                }

                //Количество игр
                Console.WriteLine("Введите количество игр");

                try
                {
                    int countGames = Convert.ToInt32(Console.ReadLine());
                    if (countGames > 0) CountGames = countGames;
                    else
                    {
                        Console.WriteLine("Количество игр не может быть отрицательным");
                        return false;
                    }

                }
                catch
                {
                    Console.WriteLine("Количество игр должно быть числом");
                    return false;
                }
                //Количество жёлтых карточек 
                Console.WriteLine("Введите количество жёлтых карточек");
                try
                {
                    int countYellowLabel = Convert.ToInt32(Console.ReadLine());
                    if (countYellowLabel > 0) CountYellowLabel = countYellowLabel;
                    else
                    {
                        Console.WriteLine("Количество желтых карточек не может быть отрицательным");
                        return false;
                    }

                }
                catch
                {
                    Console.WriteLine("Количество желтых карточек должно быть числом");
                    return false;
                }

                return true;
            }
        }
    

        static void Main(string[] args)
        {
            
        }
    }
}
