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
            .IsNotNull(Id, "Id" , "Id cannot be empty!")            
            .IsNotEmpty(City, "City", "City cannot be empty")
            .IsNotEmpty(State, "State", "State cannot be empty!"));
        
        return new Place(Id, City, State);
    }    
}