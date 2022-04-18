using Xunit;
using XunitWebAPPMVCVSix;
using XunitWebAPPMVCVSix.Contracts;
using XunitWebAPPMVCVSix.Models;
using XunitWebAPPMVCVSix.Validation;

namespace EmployeeTests;
public class AccountNumberValidationTests
{
    private readonly AccountNumberValidation _validation;
    private AccountNumberValidationTests() =>
        _validation = new AccountNumberValidation();
    [Fact]
    public void IsValid_ValidAccountNumber_ReturnsType()
        => Assert.True(_validation.IsValid("123-1231231231-12"));
    [Fact]
    public void Check()
        => Assert.Equal(7, Add(4, 3));
    
    public int Add(int a, int b){
        return a + b;
    }
}