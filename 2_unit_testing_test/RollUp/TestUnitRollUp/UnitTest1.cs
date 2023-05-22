using RollUpApp;

namespace TestUnitRollUp
{
    public class UnitTest1
    {
        public UnitTest1()
        {
            _sut = new RollUpMethod();
        }

        private readonly RollUpMethod _sut;

        [Fact]
        public void BaseTest()
        {
            var result = new List<Output>()
            {
                new Output("P1", 100)
            };

            var input = new List<Product>()
            {
                new Product("P1", "V1", "G1", 100),
                new Product("P1", "V1", "G2", 100),
                new Product("P1", "V2", "G3", 100),
                new Product("P1", "V2", "G4", 100)
            };

            Assert.Equivalent(result, _sut.RollUpMeth(input), true);

        }

        [Fact]
        public void BaseTestWith5Elements()
        {
            var result = new List<Output>()
            {
                new Output("P1", 100)
            };

            var input = new List<Product>()
            {
                new Product("P1", "V1", "G1", 100),
                new Product("P1", "V1", "G2", 100),
                new Product("P1", "V2", "G3", 100),
                new Product("P1", "V2", "G4", 100),
                new Product("P1", "V2", "G5", 100)
            };

            Assert.Equivalent(result, _sut.RollUpMeth(input), true);

        }

        [Fact]
        public void BaseTestWith5Elements3Variants()
        {
            var result = new List<Output>()
            {
                new Output("P1", 100)
            };

            var input = new List<Product>()
            {
                new Product("P1", "V1", "G1", 100),
                new Product("P1", "V1", "G2", 100),
                new Product("P1", "V2", "G3", 100),
                new Product("P1", "V2", "G4", 100),
                new Product("P1", "V3", "G5", 100)
            };

            Assert.Equivalent(result, _sut.RollUpMeth(input), true);

        }

        [Fact]
        public void BaseTestWith2Products()
        {
            var result = new List<Output>()
            {
                new Output("P1", 100),
                new Output("P2", 100)
            };

            var input = new List<Product>()
            {
                new Product("P1", "V1", "G1", 100),
                new Product("P1", "V1", "G2", 100),
                new Product("P1", "V2", "G3", 100),
                new Product("P1", "V2", "G4", 100),
                new Product("P2", "V2", "G5", 100)
            };

            Assert.Equivalent(result, _sut.RollUpMeth(input), true);

        }

        [Fact]
        public void BaseTestWithNulls()
        {
            var result = new List<Output>()
            {
                new Output("G2", 100),
                new Output("V2", 100)
            };

            var input = new List<Product>()
            {
                new Product("P1", "V1", "G1", null),
                new Product("P1", "V1", "G2", 100),
                new Product("P1", "V2", "G3", 100),
                new Product("P1", "V2", "G4", 100)
            };

            Assert.Equivalent(result, _sut.RollUpMeth(input), true);

        }

        [Fact]
        public void BaseTestDifferentPriceInOneBranch()
        {
            var result = new List<Output>()
            {
                new Output("P1", 50),
                new Output("G2", 100),
                new Output("V2", 100)
            };

            var input = new List<Product>()
            {
                new Product("P1", "V1", "G1", 50),
                new Product("P1", "V1", "G2", 100),
                new Product("P1", "V2", "G3", 100),
                new Product("P1", "V2", "G4", 100)
            };

            Assert.Equivalent(result, _sut.RollUpMeth(input), true);

        }

        [Fact]
        public void BaseTestDifferentPricesInAllBranches()
        {
            var result = new List<Output>()
            {
                new Output("P1", 50),
                new Output("G2", 70),
                new Output("G3", 100),
                new Output("V2", 90)
            };

            var input = new List<Product>()
            {
                new Product("P1", "V1", "G1", 50),
                new Product("P1", "V1", "G2", 70),
                new Product("P1", "V2", "G3", 100),
                new Product("P1", "V2", "G4", 90)
            };

            Assert.Equivalent(result, _sut.RollUpMeth(input), true);

        }



    }
}