namespace Mathproject
{
    public class Tests
    {
        // this is where unit testing happens
        // what to test?

        // how to do unit test?

        [Test]
       [TestCase(10,10,20)]// parameterized test
       [TestCase(-10, 10, 0)]
       [TestCase(-5, -2, -7)]
       [TestCase(-3, -2, -5)]


        // [TestCaseSource(nameof(Mycombination))]
        [TestCaseSource(nameof(GetDataFromCsv))]
        public void Test1(int a, int b, int c)
        {// how to test add method?
         // step-1 Arrange
         // keeping objects and required parameter ready

            Mathproject ob = new Mathproject();
            //  int a = 5;
            //  int b = 10;


            // step-2 Act
            // executes add methods retrive the result
            int result = ob.Add(a, b);

            // step-3 Assert
            // iam expecting output as 15
            // weather program will return same output or not

            Assert.That(result, Is.EqualTo(c));


            // this method is created to test Add method

        }


        private static object[] Mycombination =
    {
     new object[] { 2, 3, 5 },
     new object[] { -1, 5, 4 },
     new object[] { 0, 0, 0 }



 };

        static IEnumerable<object[]> GetDataFromCsv()
        {
            foreach (var line in File.ReadAllLines("C:\\Users\\aasrithar\\OneDrive - Infinite Computer Solutions (India) Limited\\NOV\\24th Nov\\Mathproject"))
            {
                var parts = line.Split(',');
                yield return new object[]
                {
         int.Parse(parts[0]),
         int.Parse(parts[1]),
         int.Parse(parts[2])
                };
            }
        }


        [Test]
        public void Test2()
        {
            // this method is created to test Multiply method


            Mathproject ob = new Mathproject();
            int a = 5;
            int b = 10;

            int result = ob.Multiply(a, b);

            Assert.That(result, Is.EqualTo(50));

        }
    }
}
