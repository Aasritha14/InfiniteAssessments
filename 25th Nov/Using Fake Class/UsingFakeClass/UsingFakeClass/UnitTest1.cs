namespace UsingFakeClass
{
    public class Tests
    {
        [Test]
        public void Test2()
        {
            Fakecls f = new Fakecls();// which is using the list
            var ob = new ob(f);
            var res = ob.Equals("u");//

            Assert.That(res, Is.GreaterThan(0));
        }
    }
}
