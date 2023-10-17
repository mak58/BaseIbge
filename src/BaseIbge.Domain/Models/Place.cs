namespace BasePlace.Domain.Models;

public class Place
{
    public Place(int id,
        string city,
        string state)
    {
        Id = id;
        City = city;
        State = state;
    }


    public int Id { get; set; }
    public string State { get; set; }
    public string City { get; set; }
}
