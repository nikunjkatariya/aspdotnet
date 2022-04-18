using InvoiceGenerater.Validation;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        private readonly GSTNumberValidation _validation;
        public UnitTest1() =>
            _validation = new GSTNumberValidation();
        [Fact]
        public void IsValid_Pincode_ReturnTrue()
            => Assert.True(_validation.IsValid("09AAACH7409R1ZZ","AAAAA1234A"));
    }
}