using Microsoft.VisualStudio.TestTools.UnitTesting;
[TestClass]
public class BankAccountTests
{
	private BankAccount account;

	[TestInitialize]
	public void Setup()
	{
		account = new BankAccount("123456", 100.0);
	}

	[TestMethod]
	public void TestInitialBalance()
	{
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(100.0, account.GetBalance(), "Начальный баланс неверный");
	}

	[TestMethod]
	public void TestDeposit()
	{
		account.Deposit(50.0);
		Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(150.0, account.GetBalance(), "Баланс после депозита неверный");
	}

	[TestMethod]
	public void TestWithdraw()
	{
		account.Withdraw(30.0);
		Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(70.0, account.GetBalance(), "Баланс после снятия неверный");
	}

	[TestMethod]
	[ExpectedException(typeof(ArgumentException))]
	public void TestWithdrawMoreThanBalance()
	{
		account.Withdraw(200.0);
	}

	[TestMethod]
	[ExpectedException(typeof(ArgumentException))]
	public void TestNegativeDeposit()
	{
		account.Deposit(-10.0);
	}

	[TestMethod]
	[ExpectedException(typeof(ArgumentException))]
	public void TestNegativeWithdraw()
	{
		account.Withdraw(-10.0);
	}
}

