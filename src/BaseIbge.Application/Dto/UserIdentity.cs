using Microsoft.AspNetCore.Identity;

namespace BaseIbge.Application.Dto;

public class UserIdentity
{
    public IdentityUser User { get; set; }
    public IdentityResult Result { get; set; }
}
