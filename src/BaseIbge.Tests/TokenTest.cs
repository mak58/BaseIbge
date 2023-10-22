using Xunit;
using BaseIbge.Application.Dto;
using BaseIbge.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace BaseIbge.Tests;

public class TokenTest 
{
    public static TheoryData<string, string> Data =>
        new TheoryData<string, string>
    {
        {"marcio_koehler@live.com", "D*tn3tN3wW3b@p!"},
        {"dhani_brito@gmail.com", "D*minicT#i3m"}
    };

    [Theory]
    [MemberData(nameof(Data))]
    public async Task Must_Generate_Token(string email, string password)
    {
        // //arrange
        // var secretKey = @"D*tn3tN&wW3b@p!-oB@s&!bg3";           
        // var key = Encoding.ASCII.GetBytes(secretKey);

        // // act
        // var token = GenerateToken.CreateToken(email, key);

        // // Assert
        // Assert.True(token is not null);
        LoginRequest loginRequest = new()
        {
            Email = email,
            Password = password  
        };
        string token = string.Empty;

        Mock<ILoginApplication> loginService = new();

        loginService.Setup(x => x.GetToken(loginRequest)).ReturnsAsync(token);

        var service = new MeuObjetoDeTeste(mockServico.Object);


        
        
    }
}
