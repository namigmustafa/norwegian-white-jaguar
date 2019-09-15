using System.Collections.Generic;

namespace NorwegianWhiteJaguar.Interface.Facade
{
    public interface IFileReadWriteFacade //TODO is name should be that?
    {
        List<string> Read(string path);//TODO should it be List?IEnum?
        void Write(string path, string searchText);
    }
}
