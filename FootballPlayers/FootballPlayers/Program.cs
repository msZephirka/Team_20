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
            // Список футболистов, фильтр
            List<Football_players> football_Players = new List<Football_players>();
            Football_players.filter = new Football_players_filter();
            string ReadCh;

            do
            {
                // Вывод главного меню
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Ввод нового футболиста");
                Console.WriteLine("2. Вывод футболистов");
                Console.WriteLine("3. Ввод значений фильтра");
                Console.WriteLine("4. Вывод отфильтрованного списка футболистов");

                // Пользватель выбирает один пункт из главного меню
                ReadCh = Console.ReadLine();
                
                // Если пользователь выбрал:
                switch (ReadCh)
                {
                    case "1": // Ввод нового футолиста - Открывается форма добавления нового футболиста
                        Console.Clear();
                        Console.WriteLine("Ввод нового футболиста: \n");
                        Football_players.AddNewElement(football_Players);
                        break;

                    case "2": // Вывод футболистов - Выводится полный список футболистов
                        Console.Clear();
                        Console.WriteLine("Вывод полного списка футболистов: ");
                        Football_players.OutFullList(football_Players);
                        break;

                    case "3": // Ввод значений фильтра - Открывается форма для ввода значений фильтра
                        Console.Clear();
                        Console.WriteLine("Ввод фильтра: ");
                        Football_players.filter.AddFilter();
                        break;

                    case "4": // Вывод отфильтрованного списка - Выводится список футболистов, удоавлетворяющих условиям теущего введенного фильтра
                        Console.Clear();
                        Console.WriteLine("Вывод отфильтрованного списка футболистов: ");
                        Football_players.OutFilterList(football_Players);
                        break;

                    default: // Выход из программы
                        Environment.Exit(0);
                        break;
                }

                // Очистка экрана
                Console.ReadKey();
                Console.Clear();
            } while (true);
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
            uint CountGames;         // Количество игр
            uint CountYellowLabel;   // Количество желтых карточек

            public static Football_players_filter filter; // Фильтр

            /// <summary>
            /// Проверить, все ли буквы в строке русские
            /// </summary>
            /// <param name="str">Проверяемая строка</param> 
            /// <return>Результат проверки</return>
            public static bool IsRussianStr(string str)
            {
                if (Regex.IsMatch(str, @"[А-Яа-я]$")) return true;
                else return false;
            }

            /// <summary>
            /// Конструктор структуры
            /// </summary>
            /// <param name="Surname">Фамилия футболиста</param> 
            /// <param name="Birthday">День рождения</param> 
            /// <param name="PlaceOfBorn">Место рождения</param> 
            /// <param name="Role">Амплуа</param> 
            /// <param name="CountGames">Количество игр</param> 
            /// <param name="CountYellowLabel">Количество жёлтых карточек</param> 
            public Football_players(String Surname, DateTime Birthday, String PlaceOfBorn, Roles Role, uint CountGames, uint CountYellowLabel)
            {
                this.Surname = Surname;
                this.Birthday = Birthday;
                this.PlaceOfBorn = PlaceOfBorn;
                this.Role = Role;
                this.CountGames = CountGames;
                this.CountYellowLabel = CountYellowLabel;
            }

            /// <summary>
            /// Добавление нового футболиста
            /// </summary>
            /// <param name="players">Список футболистов</param>            
            public static void AddNewElement(List<Football_players> players)
            {
                // Новый футболист
                Football_players player = new Football_players();

                // Ввод фамилии
                Console.WriteLine("Введите фамилию футболиста: ");
                player.Surname = Console.ReadLine();
                while (!IsRussianStr(player.Surname))
                {
                    Console.WriteLine("Фамилия может содержать только буквы русского алфавита. Повторите ввод:");
                    player.Surname = Console.ReadLine();
                }

                // Ввод даты рождения
                Console.WriteLine("Введите дату рождения в формате dd.mm.yyyy: ");
                string str = Console.ReadLine();
                do
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
                } while (!Regex.IsMatch(str, @"\d{2}.\d{2}.\d{4}"));

                // Ввод места рождения
                Console.WriteLine("Введите место рождения: ");
                player.PlaceOfBorn = Console.ReadLine();
                while (!IsRussianStr(player.PlaceOfBorn))
                {
                    Console.WriteLine("Место рождения может содержать только буквы русского алфавита. Повторите ввод:");
                    player.PlaceOfBorn = Console.ReadLine();
                }

                // Ввод амплуа
                Console.WriteLine("Введите амплуа [0 - вратарь, 1 - защитник, 2 - полузащитник, 3 - нападающий]");
                int amplua;
                bool isNum;
                do
                {
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
                } while (!isNum);

                // Ввод количества игр
                Console.WriteLine("Введите количество игр");
                bool ok = false;                
                while (!ok)
                {
                    try
                    {
                        uint countGames = Convert.ToUInt32(Console.ReadLine());
                        player.CountGames = countGames;
                        ok = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Количество игр не может быть отрицательным. Повторите ввод: ");
                    }
                }

                // Ввод количества жёлтых карточек 
                Console.WriteLine("Введите количество жёлтых карточек");
                ok = false;
                while (!ok)
                {
                    try
                    {
                        uint countYellowLabel = Convert.ToUInt32(Console.ReadLine());
                        player.CountYellowLabel = countYellowLabel;
                        ok = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Количество игр не может быть отрицательным. Повторите ввод: ");
                    }
                }

                // Добавление нового футолиста
                players.Add(player);
                Console.WriteLine("Футболист добавлен! Нажмите enter для возврата в меню");
            }

            /// <summary>
            /// Вывод полного списка
            /// </summary>
            /// <param name="players">Список футболистов</param>
            public static void OutFullList(List<Football_players> players)
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
            /// <returns>Признак того, что футболист удовлетворяет условиям фильтра</returns>
            public bool isChecked()
            {
                // Проверка фамилии
                if ((filter.F_Surname != null) && (!this.Surname.Contains(filter.F_Surname)))
                    return false;

                // Проверка даты рождения (min)
                if ((filter.F_Birthday_min != null) && (this.Birthday > filter.F_Birthday_min))
                    return false;

                // Проверка даты рождения (max)
                if ((filter.F_Birthday_max != null) && (this.Birthday < filter.F_Birthday_max))
                    return false;

                // Проверка места рождения
                if ((filter.F_PlaceOfBorn != null) && (!this.PlaceOfBorn.Contains(filter.F_PlaceOfBorn)))
                    return false;

                // Проверка амплуа
                if ((filter.F_Role != null) && (this.Role != filter.F_Role))
                    return false;

                // Проверка количества игр (min)
                if ((filter.CountGames_min != null) && (this.CountGames > filter.CountGames_min))
                    return false;

                // Проверка количества игр (max)
                if ((filter.CountGames_max != null) && (this.CountGames < filter.CountGames_max))
                    return false;

                // Проверка количетсва желтых карточек (min)
                if ((filter.CountYellowLabel_min != null) && (this.CountYellowLabel > filter.CountYellowLabel_min))
                    return false;

                // Проверка количетсва желтых карточек (max)
                if ((filter.CountYellowLabel_max != null) && (this.CountYellowLabel < filter.CountYellowLabel_max))
                    return false;

                // если поля удовлетворяют фильтру
                return true;
            }

            /// <summary>
            /// Вывод с применением фильтра
            /// </summary>
            /// <param name="players">Список футболистов</param>
            public static void OutFilterList(List<Football_players> players)
            {
                // Отфильтрованный список футболистов
                List<Football_players> list = new List<Football_players>();

                // Каждый футболист проверяется на удовлетворение условиям фильтра
                foreach (var player in players)
                {
                    // Если удовлетворяет, добавляем в отфильтрованный список
                    if (player.isChecked())
                    {
                        list.Add(player);
                    }
                }

                // Выводим отфильтрованный список на экран
                OutFullList(list);
            }


        }

        /// <summary>
        /// Фильтр
        /// </summary>
        struct Football_players_filter
        {
            public String F_Surname;               //Фильтр по фамилии
            public DateTime? F_Birthday_min;        //Фильр по дате рождения (min)
            public DateTime? F_Birthday_max;        //Фильр по дате рождения (max)
            public String F_PlaceOfBorn;           //Фильтр по месту рождения
            public Roles? F_Role;                   //Фильтр по амплуа
            public int? CountGames_min;             //Фильтр по количеству игр (min)
            public int? CountGames_max;             //Фильтр по количеству игр (max)
            public int? CountYellowLabel_min;       //Фильтр по Количеству желтых карточек (min)
            public int? CountYellowLabel_max;       //Фильтр по Количеству желтых карточек (max)

            /// <summary>
            /// Ввод даты
            /// </summary>
            /// <return>Введённая дата</return>
            public DateTime? InputDate()
            {
                DateTime date;
                // Ввод даты
                string str = Console.ReadLine();

                // Если строка пустая, возвращаем значение null
                if (str == String.Empty) return null;

                // Преобразовываем строку в дату
                try
                {
                    date = Convert.ToDateTime(str);
                    return date;
                }
                catch
                {
                    Console.WriteLine("Неправильно ввели дату. Повторите ввод");
                    return null;
                }
            }

            /// <summary>
            /// Ввод амплуа
            /// </summary>
            /// <return>Введённое амплуа</return>
            public Roles? InputRole()
            {
                int amplua;
                bool isNum;
                try
                {
                    isNum = int.TryParse(Console.ReadLine(), out amplua);
                    switch (amplua)
                    {
                        case 0:
                            return Roles.Goalkeeper;
                        case 1:
                            return Roles.Quarterback;
                        case 2:
                            return Roles.Halfback;
                        case 3:
                            return Roles.Forward;
                        default:
                            Console.WriteLine("Неправильно ввели амплуа. Повторите ввод:");
                            return null;
                    }
                }
                catch
                {
                    Console.WriteLine("Неправильно ввели амплуа. Повторите ввод:");
                    return null;
                }               
            }

            /// <summary>
            /// Ввод числа
            /// </summary>
            /// <return>Введённое число</return>
            public int? InputInt()
            {
                // Ввод числа
                string str = Console.ReadLine();

                // Если строка пустая, возвращаем значение null
                if (str == String.Empty) return null;

                // Преобразовываем строку в число
                try
                {
                    var result = Convert.ToInt32(str);
                    return result;
                }
                catch
                {
                    Console.WriteLine("Неправильно ввели число. Повторите ввод");
                    return null;
                }
            }

            /// <summary>
            /// Добавление фильтра
            /// </summary>
            public void AddFilter()
            {
                // Ввод фильтра для фамилии
                Console.WriteLine("Введите фильтр для фамилии: ");
                F_Surname = Console.ReadLine();

                // Ввод фильтра для верхней границы даты рождения(max)
                Console.WriteLine("Введите верхнюю границу даты рождения: ");
                F_Birthday_max = InputDate();

                // Ввод фильтра для нижней границы даты рождения(min)
                Console.WriteLine("Введите нижнюю границу даты рождения: ");
                F_Birthday_min = InputDate();

                // Ввод фильтра для места рождения
                Console.WriteLine("Введите фильтр для места рождения: ");
                F_PlaceOfBorn = Console.ReadLine();

                // Ввод фильтра для роли 
                Console.WriteLine("Введите фильтр для амплуа: ");
                F_Role = InputRole();

                // Ввод нижней границы фильтра для количества игр
                Console.WriteLine("Введите нижнюю границу фильтра для количества игр: ");
                CountGames_min = InputInt();

                // Ввод верхней границы фильтра для количества игр
                Console.WriteLine("Введите верхнюю границу фильтра для количества игр: ");
                CountGames_max = InputInt();

                // Ввод нижней границы фильтра для количества жёлтых карточек
                Console.WriteLine("Введите нижнюю границу фильтр для количества жёлтых карточек: ");
                CountYellowLabel_min = InputInt();

                // Ввод верхней границы фильтра для количества жёлтых карточек
                Console.WriteLine("Введите верхнюю границу фильтр для количества жёлтых карточек: ");
                CountYellowLabel_max = InputInt();
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
