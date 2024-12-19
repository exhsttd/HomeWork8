using System;
using TumakovLab9.Classes;

namespace TumakovLab9
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
        }

        static void Task1()
        {
            Console.WriteLine("Упражнения 9.1-9.3");
            using (Account account1 = new Account(6789123.00m))
            using (Account account2 = new Account(500.00m))
            {
                account1.GetAccountDetails();
                account2.GetAccountDetails();

                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("1) Положить деньги на счет");
                Console.WriteLine("2) Снять деньги со счета");
                Console.WriteLine("3) Перевести деньги на другой счет");
                string choice = Console.ReadLine()!;

                if (choice == "1")
                {
                    Console.Write("Введите сумму для пополнения: ");
                    decimal addmoney;
                    while (!decimal.TryParse(Console.ReadLine(), out addmoney) || addmoney <= 0)
                    {
                        Console.Write("Введите сумму больше нуля: ");
                    }
                    account2.Add(addmoney);
                    account2.GetAccountDetails();
                    DisplayTransactions(account2);
                }
                else if (choice == "2")
                {
                    Console.Write("Введите сумму для снятия: ");
                    decimal dropmoney;
                    while (!decimal.TryParse(Console.ReadLine(), out dropmoney) || dropmoney <= 0)
                    {
                        Console.Write("Введите сумму больше нуля: ");
                    }
                    account1.Drop(dropmoney);
                    account1.GetAccountDetails();
                    DisplayTransactions(account1);
                }
                else if (choice == "3")
                {
                    Console.Write("Введите сумму для перевода: ");
                    decimal transferAmount;
                    while (!decimal.TryParse(Console.ReadLine(), out transferAmount) || transferAmount <= 0)
                    {
                        Console.Write("Введите сумму больше нуля: ");
                    }
                    account1.Transfer(account2, transferAmount);
                    account1.GetAccountDetails();
                    account2.GetAccountDetails();
                    DisplayTransactions(account1);
                    DisplayTransactions(account2);
                }
            }
        }

        static void DisplayTransactions(Account account)
        {
            Console.WriteLine("Транзакции для данного счета:");
            if (account.GetTransactions().Any())
            {
                foreach (var transaction in account.GetTransactions())
                {
                    Console.WriteLine($"Дата: {transaction.TransactionDate}. Сумма: {transaction.Amount}");
                }
            }
            else
            {
                Console.WriteLine("У данного счета нет транзакций");
            }
        }

        static void Task2()
        {
            Console.WriteLine("Домашнее задание 9.1");

            // Создание списка песен
            List<Song> songs = new List<Song>
            {
                new Song("Song1", "Author1"),
                new Song("Song2", "Author2"),
                new Song("Song3", "Author3"),
                new Song("Song4", "Author4")
            };

            Console.WriteLine("Список песен:");
            foreach (Song song in songs)
            {
                song.Print();
            }

            Console.WriteLine("Сравнение первой и второй песни:");
            bool equal = songs[0].Equals(songs[1]);
            Console.WriteLine($"Песни '{songs[0].Name}' и '{songs[1].Name}' " + (equal ? "равны." : "не равны."));

            Song newSong = new Song(); // В методе Main создать объект mySong.
            newSong.Print(); // выведет "-"
        }
    }
}
