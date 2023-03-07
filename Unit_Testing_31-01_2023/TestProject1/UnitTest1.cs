using Unit_Testing_31_01_2023;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public static void Debit_WithValidAmount__Updatebalance()
        {
            //Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new("Mr. Bryan Walton", beginningBalance);

            //Act
            account.Debit(debitAmount);

            //Assert
            double actual = account.Balance;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            //Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account1 = new("Mr. Bryan Walton", beginningBalance);

            //Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account1.Debit(debitAmount));
        }
        [Fact]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            //Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new("Mr. Bryan Walton", beginningBalance);

            //Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //StringAssert.Contains(ex.Message, BankAccount.DebitAmountExceedBalanceMessage);
                Assert.Contains(BankAccount.DebitAmountExceedBalanceMessage,ex.Message);
                return;
            }
            Assert.True(false,"The expected exception was not thrownn.");
        }
    }
}