using Xunit;

namespace Checkout.Tests
{
    public class CheckoutTest
    {

        [Fact]
        public void _Test()
        {
            var checkout = new Checkout();

            var res = checkout.Scann("");

            Assert.Equal(0, res);
        }

        [Fact]
        public void A_Test()
        {
            var checkout = new Checkout();

            var res = checkout.Scann("A");

            Assert.Equal(50, res);
        }

        [Fact]
        public void AB_Test()
        {
            var checkout = new Checkout();

            var res = checkout.Scann("AB");

            Assert.Equal(80, res);
        }

        [Fact]
        public void CDBA_Test()
        {
            var checkout = new Checkout();

            var res = checkout.Scann("CDBA");

            Assert.Equal(115, res);
        }
        [Fact]
        public void AA_Test()
        {
            var checkout = new Checkout();

            var res = checkout.Scann("AA");

            Assert.Equal(100, res);
        }
        [Fact]
        public void AAA_Test()
        {
            var checkout = new Checkout();

            var res = checkout.Scann("AAA");

            Assert.Equal(130, res);
        }
        [Fact]
        public void AAAA_Test()
        {
            var checkout = new Checkout();

            var res = checkout.Scann("AAAA");

            Assert.Equal(180, res);
        }
        [Fact]
        public void AAAAA_Test()
        {
            var checkout = new Checkout();

            var res = checkout.Scann("AAAAA");

            Assert.Equal(230, res);
        }
        [Fact]
        public void AAAAAA_Test()
        {
            var checkout = new Checkout();

            var res = checkout.Scann("AAAAAA");

            Assert.Equal(260, res);
        }
        [Fact]
        public void AAAB_Test()
        {
            var checkout = new Checkout();

            var res = checkout.Scann("AAAB");

            Assert.Equal(160, res);
        }
        [Fact]
        public void AAABB_Test()
        {
            var checkout = new Checkout();

            var res = checkout.Scann("AAABB");

            Assert.Equal(175, res);
        }
        [Fact]
        public void AAABBD_Test()
        {
            var checkout = new Checkout();

            var res = checkout.Scann("AAABBD");

            Assert.Equal(190, res);
        }
        [Fact]
        public void DABABA_Test()
        {
            var checkout = new Checkout();

            var res = checkout.Scann("DABABA");

            Assert.Equal(190, res);
        }
    }
}