using NorwegianWhiteJaguar.Interface.Facade;
using NorwegianWhiteJaguar.Interface.Provider;
using System.Collections.Generic;

namespace NorwegianWhiteJaguar.Service.Provider
{
    public class FileReadWriteProvider : IFileReadWriteProvider
    {
        private readonly IFileReadWriteFacade _fileReadWriteFacade;

        public FileReadWriteProvider(IFileReadWriteFacade fileReadWriteFacade)
        {
            _fileReadWriteFacade = fileReadWriteFacade;
        }
        public List<string> Read(string path)
        {
            return _fileReadWriteFacade.Read(path);
        }
    }
}
