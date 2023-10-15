using BaseIbge.Domain.Models;

namespace BasePlace.Domain.Models;

public class Place : Entity
{    
    public string State { get; set; }
    public string City { get; set; }
}
