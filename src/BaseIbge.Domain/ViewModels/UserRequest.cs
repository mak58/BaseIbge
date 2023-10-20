using Flunt.Notifications;
using Flunt.Validations;

namespace BaseIbge.Application.Dto;

public class UserRequest : Notifiable<Notification>
{    
    public string Email { get; set; }    
    public string Password { get; set; }    
    public string Name { get; set; }


    public UserRequest MapTo()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()            
            .IsNotEmpty(Email,"Email", "Email cannot be empty")                        
            .IsNotEmpty(Password, "Password", "Password cannot be empty")
            .IsNotEmpty(Name, "Name", "Name cannot be empty!")
            .IsEmail(Email, "Email", "Email invalid!"));
        
        return new UserRequest();
    }
}
