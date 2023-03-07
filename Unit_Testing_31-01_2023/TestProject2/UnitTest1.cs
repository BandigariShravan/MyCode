using Unit_Testing_31_01_2023;

namespace TestProject2
{
    public class Tests
    {
        [TestFixture]
        public class BankAccounttests 
        {
            [Test]
            public void Debit_WithWalidAmount_UpdatesBalance()
            {
                //Arrange
                double beginningBalance = 11.99;
                double debitAmount = 4.55;
                double expected = 7.44;
                BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

                //Act
                account.Debit(debitAmount);

                //Assert
                double actual=account.Balance;
                Assert.AreEqual(expected, actual);
            }
        }
    }
}