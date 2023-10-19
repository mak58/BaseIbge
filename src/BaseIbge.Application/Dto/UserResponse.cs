namespace BaseIbge.Application.Dto;

public class UserResponse
{
    public UserResponse(string id, string email)
    {
        Id = id;
        Email = email;
    }

    public string  Id { get; set; }
    public string Email { get; set; }
    
}
