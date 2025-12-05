using static Stub_MOQ.Stub_MOQ;

namespace Stub_MOQ
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            //Real class r = new RealClass();

            FakeClass f = new FakeClass();
            Client ob = new Client(f);
            var res = ob.AddClient(10, 20);// 

            Assert.That(res, Is.EqualTo("the sum is 30"));
        }
    }
}
