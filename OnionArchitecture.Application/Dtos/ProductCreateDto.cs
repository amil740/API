using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Application.Dtos
{
    public record ProductCreateDto(string name, decimal price, int categoryid);
}
