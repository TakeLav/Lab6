using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
public class BankAccount
{
	private string accountNumber;
	private double balance;

	public BankAccount(string accountNumber, double balance = 0.0)
	{
		if (balance < 0)
		{
			throw new ArgumentException("Начальный баланс не может быть отрицательным.");
		}
		this.accountNumber = accountNumber;
		this.balance = balance;
	}

	public void Deposit(double amount)
	{
		if (amount <= 0)
		{
			throw new ArgumentException("Сумма депозита должна быть положительной.");
		}
		balance += amount;
	}

	public void Withdraw(double amount)
	{
		if (amount <= 0)
		{
			throw new ArgumentException("Сумма вывода должна быть положительной.");
		}
		if (amount > balance)
		{
			throw new ArgumentException("Недостаточно средств.");
		}
		balance -= amount;
	}

	public double GetBalance()
	{
		return balance;
	}
}
namespace Progam
{
	public class Program
	{
	public static void Main(string[] args)
	{
		try
		{
			BankAccount myAccount = new BankAccount("123456", 100.0);
			Console.WriteLine("Баланс: " + myAccount.GetBalance());

			myAccount.Deposit(50);
			Console.WriteLine("Баланс после депозита: " + myAccount.GetBalance());

			myAccount.Withdraw(30);
			Console.WriteLine("Баланс после снятия: " + myAccount.GetBalance());

			myAccount.Withdraw(150.0); 
		}
		catch (ArgumentException ex)
		{
			Console.WriteLine("Ошибка: " + ex.Message);
		}
	}
	}
}
