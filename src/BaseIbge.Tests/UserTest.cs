using BaseIbge.Application.Repositories;
using Xunit;

namespace BaseIbge.Tests;

public class UserTest 
{   
    /// <summary>
    /// When this test takes place, the user with email and password has already been validated
    /// </summary>
    [Fact]    
    public void Must_Generate_Token()
    {
        // arrange        
        var email = "marcio_koehler@live.com";

        // act
        var token = LoginApplication.GetToken(email);

        // Assert
        Assert.True(token is not null);
    }


}
