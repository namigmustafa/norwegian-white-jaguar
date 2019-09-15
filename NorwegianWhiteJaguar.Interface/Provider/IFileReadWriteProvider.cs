using System.Collections.Generic;

namespace NorwegianWhiteJaguar.Interface.Provider
{
    public interface IFileReadWriteProvider
    {
        List<string> Read(string path);
    }
}
