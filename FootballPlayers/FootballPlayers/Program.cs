using System;
using System.Collections.Generic;
using System.Globalization;
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
            Goalkeeper = 1,     //вратарь
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

<<<<<<< HEAD
            public static bool StringIsValid(string str)
            {
                return string.IsNullOrEmpty(str) && ((!Regex.IsMatch(str, @"^[A-Za-z]$")));// || !Regex.IsMatch(str, @"^[А-Яа-я]$")));
=======
            //признак, что в строке только русские буквы
            public static bool StringIsValid(string str)
            {
                if (Regex.IsMatch(str, @"[А-Яа-я]$")) return true;
                else return false;
            }

            //ограничения для даты рождения
            public static bool DateIsValid(string str)
            {
                if (Regex.IsMatch(str, @"\d{2}.\d{2}.\d{4}")) return true;
                try
                {
                    DateTime date = Convert.ToDateTime(Console.ReadLine());
                    TimeSpan dt = DateTime.Now.Subtract(date);
                    int year = new DateTime(dt.Ticks).Year - 1;
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
                return true;

>>>>>>> a72c77f7c2d878f3e7c658d8bdc7e5f7dbca4411
            }
            
            //Конструктор структуры
            public Football_players(String Surname, DateTime Birthday, String PlaceOfBorn, Roles Role, int CountGames, int CountYellowLabel)
            {
                this.Surname = Surname;
                this.Birthday = Birthday;
                this.PlaceOfBorn = PlaceOfBorn;
                this.Role = Role;
                this.CountGames = CountGames;
                this.CountYellowLabel = CountYellowLabel;
            }
            // Метод для добавления нового футболиста 
            public bool AddNewElement()
            {
                //Фамилия
                Console.WriteLine("Введите фамилию футболиста: ");
                Surname = Console.ReadLine();
<<<<<<< HEAD
                if (StringIsValid(Surname))
=======
                if (!StringIsValid(Surname))
>>>>>>> a72c77f7c2d878f3e7c658d8bdc7e5f7dbca4411
                {
                    Console.WriteLine("Фамилия может содержать только буквы русского алфавита");
                    return false;
                }


                //Дата рождения
                Console.WriteLine("Введите дату рождения в формате dd.mm.yyyy: ");
<<<<<<< HEAD
                try
                {
                    Birthday = Convert.ToDateTime(Console.ReadLine());
                    TimeSpan dt = DateTime.Now.Subtract(Birthday);
                    int year = new DateTime(dt.Ticks).Year - 1;
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
=======
                if (DateIsValid(Console.ReadLine()))
                {
                    Birthday = Convert.ToDateTime(Console.ReadLine());
                }
                    
                
                //Место рождения
                Console.WriteLine("Введите место рождения: ");
                PlaceOfBorn = Console.ReadLine();
                if (!StringIsValid(PlaceOfBorn))
                {
                    Console.WriteLine("Место рождения может содержать только буквы русского алфавита");
                    return false;
                }
>>>>>>> a72c77f7c2d878f3e7c658d8bdc7e5f7dbca4411

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

            //Метод для вывода полного списка
            public void OutFullList(List<Football_players> players)
            {
                Console.WriteLine("|Фамилия\t||Дата рождения\t||Место рождения\t||Амплуа\t|" +
                        "|Количество игр||Количество желтых карт|");
                foreach (Football_players player in players)
                {
                    Console.Write("|{0,-15}|", player.Surname);
                    Console.Write("|{0,-14}|", player.Birthday.ToString("MM/dd/yyyy"));
                    Console.Write("|{0,-22}|", player.PlaceOfBorn);
                    Console.Write("|{0,-14}|", player.Role);
                    Console.Write("|{0,-14}|", player.CountGames);
                    Console.Write("|{0,-22}|", player.CountYellowLabel);
                    Console.Write("\n");
                }
            }
        }


        static void Main(string[] args)
        {
            List<Football_players> football_Players = new List<Football_players>();
            football_Players.Add(new Football_players("Markov", new DateTime(1997, 1, 25), "Cheboksary", Roles.Forward, 3, 1));
            football_Players.Add(new Football_players("Ivanov", new DateTime(1997, 10, 13), "Cheboksary", Roles.Forward, 3, 1));
            football_Players.Add(new Football_players("Fedorov", new DateTime(1997, 11, 10), "Cheboksary", Roles.Forward, 3, 1));
            Football_players pl = new Football_players();
            pl.OutFullList(football_Players);
<<<<<<< HEAD
            
=======
            pl.AddNewElement();
>>>>>>> a72c77f7c2d878f3e7c658d8bdc7e5f7dbca4411
        }
    }
}
