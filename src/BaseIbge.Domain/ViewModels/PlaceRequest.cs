using BasePlace.Domain.Models;
using Flunt.Notifications;
using Flunt.Validations;

namespace BaseIbge.Domain.ViewModels;

public class PlaceRequest : Notifiable<Notification>
{
    public int Id { get; set; }
    public string City { get; set; }
    public string State { get; set; }

    public Place MapTo()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()            
            .IsNotNull(Id, "Id" , "Id cannot be empty!")            
            .IsTrue(Id.ToString().Length == 7, "Id", "Id should have 7 numbers!")
            .IsNotEmpty(City, "City", "City cannot be empty")
            .IsNotEmpty(State, "State", "State cannot be empty!")
            .IsTrue(State.Length == 2, "State", "State must have only 2 caracters!"));
        
        return new Place(Id, City, State);
    }    
}