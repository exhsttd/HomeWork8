using System;
using System.Collections.Generic;
using System.IO;

namespace TumakovLab9.Classes
{
    // Упражнение 9.1 В классе банковский счет, созданном в предыдущих упражнениях, удалить
    // методы заполнения полей. Вместо этих методов создать конструкторы.Переопределить
    // конструктор по умолчанию, создать конструктор для заполнения поля баланс, конструктор
    // для заполнения поля тип банковского счета, конструктор для заполнения баланса и типа
    // банковского счета. Каждый конструктор должен вызывать метод, генерирующий номер  счета.
    public class Account : IDisposable
    {
        private decimal balance;
        public List<BankTransaction> transactions;
        public TypeOfCheck TypeOfCheck { get; private set; }
        public int AccountNumber { get; private set; }
        private static int accountNumberCounter = 0; 
        private bool disposed = false; 
        
        public Account(decimal initialBalance, TypeOfCheck accountTypeOfCheck = TypeOfCheck.Текущий)
        {
            balance = initialBalance;
            TypeOfCheck = accountTypeOfCheck;
            AccountNumber = GenerateAccountNumber();
            transactions = new List<BankTransaction>(); 
        }
        
        public Account() : this(0, TypeOfCheck.Текущий) { }
        public Account(TypeOfCheck accountTypeOfCheck) : this(0, accountTypeOfCheck) { }
        public Account(decimal initialBalance)
        {
            balance = initialBalance;
            transactions = new List<BankTransaction>(); 
        }
        
        public void Add(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма должна быть больше нуля.");
                return;
            }

            balance += amount;
            transactions.Add(new BankTransaction(DateTime.Now, amount)); 
            Console.WriteLine($"На счет добавлено {amount}. Текущий баланс: {balance}");
        }

        public void Drop(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма должна быть больше нуля.");
                return;
            }

            if (amount > balance)
            {
                Console.WriteLine("Недостаточно средств на счете!");
            }
            else
            {
                balance -= amount;
                transactions.Add(new BankTransaction(DateTime.Now, -amount)); 
                Console.WriteLine($"Снято {amount}. Остаток на счете: {balance}");
            }
        }

        public void GetAccountDetails()
        {
            Console.WriteLine($"Тип счета: {TypeOfCheck}, Баланс: {balance}, Номер счета: {AccountNumber}");
        }

        public void Transfer(Account toAccount, decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма должна быть больше нуля.");
                return;
            }

            if (amount > balance)
            {
                Console.WriteLine("Недостаточно средств для перевода.");
                return;
            }

            this.Drop(amount);
            toAccount.Add(amount);
            Console.WriteLine(
                $"Переведено {amount} с счета типа {this.TypeOfCheck} на счет типа {toAccount.TypeOfCheck}.");
        }
        
        public IEnumerable<BankTransaction> GetTransactions()
        {
            return transactions.AsReadOnly(); 
        }

        private int GenerateAccountNumber()
        {
            return ++accountNumberCounter;
        }
        
        // Упражнение 9.3 В классе банковский счет создать метод Dispose, который данные проводках из очереди запишет в файл.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // внутри метода Dispose вызвать метод GC.SuppressFinalize
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    WriteTransactionsToFile();
                }
                
                disposed = true;
            }
        }

        private void WriteTransactionsToFile()
        {
            string directoryPath = Path.Combine("resources");
            string fileName = $"transactions_{DateTime.Now:here}.txt";
            string filePath = Path.Combine(directoryPath, fileName);
    
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                using (StreamWriter writer = new StreamWriter(filePath, true)) 
                {
                    foreach (var transaction in transactions)
                    {
                        writer.WriteLine($"{transaction.TransactionDate}; {transaction.Amount}");
                    }
                }
                Console.WriteLine($"Транзакции записаны в файл: {Path.Combine("resources", fileName)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
            }
        }
    }
}