using Negotation.Domain.ValueObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Negotation.Domain.Entities;

public class User
{
    public UserId Id { get; set; }
    public UserName Name { get; set; }

    public ICollection<Negotiation>? Negotiations { get; set; }
}
