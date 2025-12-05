using static Unit_Test_Assignment.Asynchronous_Method;
using static Unit_Test_Assignment.NUnit_Framework;

namespace Unit_Test_Assignment
{
    public class Calculator
    {
        [Test]
        [TestCase(2, 4)]

        [TestCase(0, 0)]
        [TestCase(-3, 9)]
        [TestCase(5, 25)]


        public void Sqaure_ShouldreturnCorrectSum(int a, int c)
        {
            CalculatorTest ob = new CalculatorTest();
            int result = ob.Square(a);
            Assert.That(result, Is.EqualTo(c));
        }

        //Question-2
        [Test]

        public void TestofString()
        {

            string input = "hello";

            StringHelper ob1 = new StringHelper();
            string result = ob1.ToUpper(input);

            Assert.That(result, Is.EqualTo("Hello"));
            Assert.That(result.Length, Is.EqualTo(5));
            Assert.That(result[0], Is.EqualTo('H'));

        }

        //Question-3
        [Test]
        [TestCase(2, 3, 6)]
        [TestCase(-1, 5, -5)]
        [TestCase(0, 19, 0)]

        public void TestOfMul(int a, int b, int c)
        {
            Parameterized_Multiply parameterized_Multiply = new Parameterized_Multiply();
            int result = parameterized_Multiply.Parameterized_Mul(a, b);
            Assert.That(result, Is.EqualTo(c));
        }

        //Question-4
        [Test]
        [TestCase(-1, "Invalid Age")]

        public void TestOfStudent(int age, string message)
        {
            StudentService studentService = new StudentService();

            var ex = Assert.Throws<ArgumentException>(() => studentService.ValidateAge(age));

            Assert.That(ex, Is.EqualTo(ex));
        }

        //Question-6
        public void GetEvenNumbers_Assertions()
        {

            var numbers = new List<int> { 2, 4, 6, 8 };

            Assert.That(numbers, Has.Count.EqualTo(4));                // Length
            Assert.That(numbers, Is.Ordered);                          // Ascending order
            Assert.That(numbers.All(n => n % 2 == 0), Is.True);        // All even

        }

        //Question-7


        public void NUnitFramework_StringConstraints()
        {
            var s = new StringService().GetFrameworkName();

            Assert.That(s, Does.StartWith("NUnit"));     // StartsWith
            Assert.That(s, Does.EndWith("work"));        // EndsWith
            Assert.That(s, Does.Contain("Frame"));       // Contains
            Assert.That(s, Has.Length.EqualTo(14));      // Length
        }

        //Question-8
        [Test]

        public async Task GetMarksAsync_Returns90()
        {
            var svc = new MarksService();
            var result = await svc.GetMarksAsync(); //proper await
            Assert.That(result, Is.EqualTo(90));
        }

        //Question-9
        [TestFixture]

        public class MarksTests
        {

            //Custom data source 

            private static readonly int[] Marks = { 45, 60, 78, 41, 90 };

            [TestCaseSource(nameof(Marks))]
            public void Marks_ShouldBeGreaterThan40(int mark)
            {
                Assert.That(mark, Is.GreaterThan(40));
            }

        }

        //Exercise-1 BankAccount
        [Test]
        public void OpeningBalance_IsStored()
        {
            var account = new BankAccount(500m);
            Assert.That(account.Balance, Is.EqualTo(500m));
        }
        //Exercise-2 Test Deposit Method 
        public void Deposit_200Into1000_ShouldBe1200()
        {
            var account = new BankAccount(1000m);
            account.Deposit(200m);
            Assert.That(account.Balance, Is.EqualTo(1200m));
        }
        //Exercise-3 Test Withdraw Method 
        [Test]

        public void Withdraw_300From500_BalanceIs200()
        {
            var acct = new BankAccount(500m);
            acct.Withdraw(300m);
            Assert.That(acct.Balance, Is.EqualTo(200m));
        }

        [Test]
        public void Withdraw_600From500_ThrowsInsufficientFunds()
        {
            var acct = new BankAccount(500m);
            Assert.That(() => acct.Withdraw(600m),
                        Throws.TypeOf<InvalidOperationException>()
                              .With.Message.EqualTo("Insufficient funds"));
        }

        //Exercise-4 TestCase Attribute 
        [Test]
        [TestCase(100, 50, 150)]
        [TestCase(0, 100, 100)]
        [TestCase(500, 0, 500)]

        public void Deposit_Scenarios(decimal opening, decimal deposit, decimal expected)
        {
            var account = new BankAccount(opening);
            account.Deposit(deposit);
            Assert.That(account.Balance, Is.EqualTo(expected));
        }

        //Exercise-5 Transaction History Account
        [Test]

        public void AfterTwoDeposits_HistoryCountIs2()
        {
            var acct = new BankAccount(0m);

            acct.Deposit(100m);
            acct.Deposit(50m);

            Assert.That(acct.History, Has.Count.EqualTo(2));
        }

        //Exercise-6 Using Testcasesource

        [TestFixture]
        public class BankAccountWithdrawalTests
        {
            // opening, withdraw, expected
            private static readonly object[] Cases =
            {
        new object[] { 1000m, 200m, 800m },
        new object[] { 500m,  100m, 400m },
        new object[] { 250m,   50m, 200m }
    };

            [TestCaseSource(nameof(Cases))]
            public void Withdraw_SetsRemainingBalance(decimal opening, decimal withdraw, decimal expected)
            {
                var acct = new BankAccount(opening);
                acct.Withdraw(withdraw);
                Assert.That(acct.Balance, Is.EqualTo(expected));
            }

            //Exercise-7
            [TestFixture]
            public class BankAccountNegativeDepositsTests
            {
                [Test]

                public void Deposit_Negative_ThrowsWithMessage() =>
                        Assert.That(() => new BankAccount(100m).Deposit(-50m),
                            Throws.TypeOf<ArgumentException>().With.Message.Contains("positive"));

            }


        }
    }
}
