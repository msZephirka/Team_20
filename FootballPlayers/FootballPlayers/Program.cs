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
        //��������� �������� ��� ���� ������
        enum Roles
        {
            Goalkeeper = 1,     //�������
            Quarterback,    //��������
            Halfback,       //������������
            Forward         //����������
        };

        //�������� ���������, ����������� ������ 
        struct Football_players_filter
        {
            String F_Surname;         //������ �� �������
            DateTime F_Birthday;      //����� �� ���� ��������
            String F_PlaceOfBorn;     //������ �� ����� ��������
            Roles F_Role;             //������ �� ������
            int CountGames;         //������ �� ���������� ���
            int CountYellowLabel;   //������ �� ���������� ������ ��������
        }


            //�������� ���������, ����������� �����������
            struct Football_players
        {
            String Surname;         //�������
            DateTime Birthday;      //���� ��������
            String PlaceOfBorn;     //����� ��������
            Roles Role;             //������
            int CountGames;         //���������� ���
            int CountYellowLabel;   //���������� ������ ��������


            //�������, ��� � ������ ������ ������� �����
            public static bool StringIsValid(string str)
            {
                if (Regex.IsMatch(str, @"[�-��-�]$")) return true;
                else return false;
            }

            //����������� ��� ���� ��������
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
                        Console.WriteLine("��������� ������ ���� ������ 16 � ������ 40");
                        return false;
                    }
                }
                catch
                {
                    Console.WriteLine("����������� ����� ���� ��������");
                    return false;
                }
                return true;
            }
            
            //����������� ���������
            public Football_players(String Surname, DateTime Birthday, String PlaceOfBorn, Roles Role, int CountGames, int CountYellowLabel)
            {
                this.Surname = Surname;
                this.Birthday = Birthday;
                this.PlaceOfBorn = PlaceOfBorn;
                this.Role = Role;
                this.CountGames = CountGames;
                this.CountYellowLabel = CountYellowLabel;
            }
            // ����� ��� ���������� ������ ���������� 
            public bool AddNewElement()
            {
                //�������
                Console.WriteLine("������� ������� ����������: ");
                Surname = Console.ReadLine();
                if (StringIsValid(Surname))
                {
                    Console.WriteLine("������� ����� ��������� ������ ����� �������� ��������");
                    return false;
                }


                //���� ��������
                Console.WriteLine("������� ���� �������� � ������� dd.mm.yyyy: ");

                if (DateIsValid(Console.ReadLine()))
                {
                    Birthday = Convert.ToDateTime(Console.ReadLine());
                }
                    
                
                //����� ��������
                Console.WriteLine("������� ����� ��������: ");
                PlaceOfBorn = Console.ReadLine();
                if (!StringIsValid(PlaceOfBorn))
                {
                    Console.WriteLine("����� �������� ����� ��������� ������ ����� �������� ��������");
                    return false;
                }

                //������
                Console.WriteLine("������� ������ [0 - �������, 1 - ��������, 2 - ������������, 3 - ����������]");
                int amplua;
                bool isNum = int.TryParse(Console.ReadLine(), out amplua);
                if (!isNum)
                {
                    Console.WriteLine("����������� ����� ������");
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
                        Console.WriteLine("����������� ����� ������");
                        return false;
                }

                //���������� ���
                Console.WriteLine("������� ���������� ���");

                try
                {
                    int countGames = Convert.ToInt32(Console.ReadLine());
                    if (countGames > 0) CountGames = countGames;
                    else
                    {
                        Console.WriteLine("���������� ��� �� ����� ���� �������������");
                        return false;
                    }

                }
                catch
                {
                    Console.WriteLine("���������� ��� ������ ���� ������");
                    return false;
                }
                //���������� ����� �������� 
                Console.WriteLine("������� ���������� ����� ��������");
                try
                {
                    int countYellowLabel = Convert.ToInt32(Console.ReadLine());
                    if (countYellowLabel > 0) CountYellowLabel = countYellowLabel;
                    else
                    {
                        Console.WriteLine("���������� ������ �������� �� ����� ���� �������������");
                        return false;
                    }

                }
                catch
                {
                    Console.WriteLine("���������� ������ �������� ������ ���� ������");
                    return false;
                }

                return true;
            }

            //����� ��� ������ ������� ������
            public void OutFullList(List<Football_players> players)
            {
                Console.WriteLine("|�������\t||���� ��������\t||����� ��������\t||������\t|" +
                        "|���������� ���||���������� ������ ����|");
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
            pl.AddNewElement();
        }
    }
}
