namespace TumakovLab9.Classes;

public class BankTransaction
{
    // Упражнение 9.2 Создать новый класс BankTransaction, который будет хранить информацию о всех банковских операциях.
    public DateTime TransactionDate { get; } // Поля класса должны быть только для чтения (readonly).
    public decimal Amount { get; } 
    public BankTransaction(DateTime now, decimal amount)
    {
        TransactionDate = DateTime.Now;
        Amount = amount;
    }
}
