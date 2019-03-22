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
        static void Main(string[] args)
        {
            // Список футболистов
            List<Football_players> football_Players = new List<Football_players>();
            Football_players.filter = new Football_players_filter(); 
            
            // Вводимое значение
            string ReadCh;

            // Бесконечный цикл аботы программы
            do
            {
                // Вывод главного меню
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Ввод нового футболиста");
                Console.WriteLine("2. Вывод футболистов");
                Console.WriteLine("3. Ввод значений фильтра");
                Console.WriteLine("4. Вывод отфильтрованного списка футболистов");

                // Читаем введеный символ
                ReadCh = Console.ReadLine();

                // Выполнить выбранную команду
                switch (ReadCh)
                {
                    case "1": // Ввод нового работника
                        Console.Clear();
                        Console.WriteLine("Ввод нового футболиста: \n");
                        Football_players.AddNewElement(football_Players);
                        break;

                    case "2": // Вывод работников
                        Console.Clear();
                        Console.WriteLine("Вывод полного списка футболистов: ");
                        break;

                    case "3": // Ввод значений фильтра
                        Console.Clear();
                        Console.WriteLine("Ввод фильтра: ");
                        break;

                    case "4": // Вывод отфильтрованного списка работников
                        Console.Clear();
                        Console.WriteLine("Вывод отфильтрованного списка футболистов: ");
                        break;

                    default: // Выход из программы
                        Environment.Exit(0);
                        break;
                }

                // Очистка экрана
                Console.ReadKey();
                Console.Clear();
            } while (true);

            /*football_Players.Add(new Football_players("Markov", new DateTime(1997, 1, 25), "Cheboksary", Roles.Forward, 3, 1));
            football_Players.Add(new Football_players("Ivanov", new DateTime(1997, 10, 13), "Cheboksary", Roles.Forward, 3, 1));
            football_Players.Add(new Football_players("Fedorov", new DateTime(1997, 11, 10), "Cheboksary", Roles.Forward, 3, 1));
            Football_players pl = new Football_players();
            pl.OutFullList(football_Players);
            pl.AddNewElement();*/
        }
                
        /// <summary>
        /// Футболисты
        /// </summary>
        struct Football_players
        {
            String Surname;         // Фамилия
            DateTime Birthday;      // Дата рождения
            String PlaceOfBorn;     // Место рождения
            Roles Role;             // Амплуа
            int CountGames;         // Количество игр
            int CountYellowLabel;   // Количество желтых карточек

            public static Football_players_filter filter; // Фильтр

            // Признак, что в строке только русские буквы
            public static bool StringIsValid(string str)
            {
                if (Regex.IsMatch(str, @"[А-Яа-я]$")) return true;
                else return false;
            }
            // Конструктор структуры
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
            public static void AddNewElement(List<Football_players> players)
            {
                Football_players player = new Football_players();
                // Фамилия
                 Console.WriteLine("Введите фамилию футболиста: ");
                player.Surname = Console.ReadLine();
                while (!StringIsValid(player.Surname))
                {
                    Console.WriteLine("Фамилия может содержать только буквы русского алфавита. Повторите ввод:");
                    player.Surname = Console.ReadLine();
                }

                // Дата рождения
                Console.WriteLine("Введите дату рождения в формате dd.mm.yyyy: ");
                string str = Console.ReadLine();
                while (!Regex.IsMatch(str, @"\d{2}.\d{2}.\d{4}"))
                {
                    try
                    {
                        DateTime date = Convert.ToDateTime(str);
                        TimeSpan dt = DateTime.Now.Subtract(date);
                        int year = new DateTime(dt.Ticks).Year - 1;
                        if (year < 16 || year > 45)
                        {
                            Console.WriteLine("Футболист должен быть старше 16 и младше 40. Повтрите ввод: ");
                            str = Console.ReadLine();
                        }
                        player.Birthday = date;
                    }
                    catch
                    {
                        Console.WriteLine("Неправильно ввели дату рождения. Повтрите ввод: ");
                        str = Console.ReadLine();
                    }
                }

                // Место рождения
                Console.WriteLine("Введите место рождения: ");
                player.PlaceOfBorn = Console.ReadLine();
                while (!StringIsValid(player.PlaceOfBorn))
                {
                    Console.WriteLine("Место рождения может содержать только буквы русского алфавита. Повторите ввод:");
                    player.PlaceOfBorn = Console.ReadLine();
                }

                // Амплуа
                Console.WriteLine("Введите амплуа [0 - вратарь, 1 - защитник, 2 - полузащитник, 3 - нападающий]");
                int amplua;
                bool isNum = int.TryParse(Console.ReadLine(), out amplua);
                while (!isNum)
                {
                    Console.WriteLine("Неправильно ввели амплуа. Повторите ввод:");
                    isNum = int.TryParse(Console.ReadLine(), out amplua);

                    switch (amplua)
                    {
                        case 0:
                            player.Role = Roles.Goalkeeper;
                            break;
                        case 1:
                            player.Role = Roles.Quarterback;
                            break;
                        case 2:
                            player.Role = Roles.Halfback;
                            break;
                        case 3:
                            player.Role = Roles.Forward;
                            break;
                        default:
                            Console.WriteLine("Неправильно ввели амплуа. Повторите ввод:");
                            isNum = int.TryParse(Console.ReadLine(), out amplua);
                            break;

                    }
                }

                // Количество игр
                Console.WriteLine("Введите количество игр");
                int countGames = Convert.ToInt32(Console.ReadLine());

                while (countGames < 0)
                {
                    Console.WriteLine("Количество игр не может быть отрицательным. Повторите ввод: ");
                    countGames = Convert.ToInt32(Console.ReadLine());
                }
                // Количество жёлтых карточек 
                Console.WriteLine("Введите количество жёлтых карточек");
                int countYellowLabel = Convert.ToInt32(Console.ReadLine());

                while (countYellowLabel < 0)
                {
                    Console.WriteLine("Количество игр не может быть отрицательным. Повторите ввод: ");
                    countYellowLabel = Convert.ToInt32(Console.ReadLine());
                }

                players.Add(player);
                Console.WriteLine("Футболист добавлен! Нажмите enter для возврата в меню");
            }

            /// <summary>
            /// Вывод полного списка
            /// </summary>
            /// <param name="players"></param>
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

            /// <summary>
            /// Проверка футболистов 
            /// </summary>
            /// <returns></returns>
            public bool isChecked()
            {
                // Проверка фамилии
                
                // Проверка даты рождения
                // Проверка места рождения
                // Проверка амплуа
                // Проверка количества игр
                // Проверка количетсва желтых карточек
                return true;
            }

            /// <summary>
            /// Вывод с применением фильтра
            /// </summary>
            /// <param name="players"></param>
            public void OutFilterList(List<Football_players> players)
            {

            }


        }

        /// <summary>
        /// Фильтр
        /// </summary>
        struct Football_players_filter
        {
            String F_Surname;               //Фильтр по фамилии
            DateTime F_Birthday_min;        //Фильр по дате рождения
            DateTime F_Birthday_max;        //Фильр по дате рождения
            String F_PlaceOfBorn;           //Фильтр по месту рождения
            Roles F_Role;                   //Фильтр по амплуа
            int CountGames;                 //Фильтр по количеству игр
            int CountYellowLabel;           //Фильтр по Количеству желтых карточек

            // Добавление фильтра
            public void AddFilter()
            {
                // Фамилия
                Console.WriteLine("Введите фильтр для фамилии: ");
                F_Surname = Console.ReadLine();

                // Дата рождения(max)
                Console.WriteLine("Введите верхнюю границу даты рождения: ");
                F_Birthday_max = Convert.ToDateTime(Console.ReadLine());

                // Дата рождения(min)
                Console.WriteLine("Введите нижнюю границу даты рождения: ");
                F_Birthday_min = Convert.ToDateTime(Console.ReadLine());

                // Место рождения
                Console.WriteLine("Введите фильтр для места рождения: ");
                F_PlaceOfBorn = Console.ReadLine();

                // Роль
                Console.WriteLine("Введите фильтр для амплуа: ");
                int amplua = Convert.ToInt32(Console.ReadLine());
                switch (amplua)
                {
                    case 0:
                        F_Role = Roles.Goalkeeper;
                        break;
                    case 1:
                        F_Role = Roles.Quarterback;
                        break;
                    case 2:
                        F_Role = Roles.Halfback;
                        break;
                    case 3:
                        F_Role = Roles.Forward;
                        break;
                    default:
                        break;
                }

                // Количество игр
                Console.WriteLine("Введите фильтр для количества игр: ");
                CountGames = Convert.ToInt32(Console.ReadLine());

                // Количество жёлтых карточек
                Console.WriteLine("Введите фильтр для количества жёлтых карточек: ");
                CountYellowLabel = Convert.ToInt32(Console.ReadLine());
            }
        }

        /// <summary>
        /// Возможные значения амплуа
        /// </summary>
        enum Roles
        {
            Goalkeeper = 1,     //вратарь
            Quarterback,    //защитник
            Halfback,       //полузащитник
            Forward         //нападающий
        };

    }
}
