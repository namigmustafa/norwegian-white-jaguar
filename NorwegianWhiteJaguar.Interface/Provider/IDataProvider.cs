using NorwegianWhiteJaguar.Model.Entities;
using System.Collections.Generic;

namespace NorwegianWhiteJaguar.Interface.Provider
{
    public interface IDataProvider
    {
        List<Customer> Get();
    }
}
