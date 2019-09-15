using NorwegianWhiteJaguar.Interface.Facade;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NorwegianWhiteJaguar.Service.Facade
{
    public class FileReadWriteFacade : IFileReadWriteFacade
    {
        public List<string> Read(string path)
        {
            var allLines = File.ReadAllLines(path);

            return allLines.ToList();// TODO should i do it? tolist?
        }

        public void Write(string path, string searchText)
        {
            var searchedQueries = Read(path);
            searchedQueries.Add(searchText);

            if (searchedQueries.Count > 5)
            {
                searchedQueries.RemoveAt(0);
            }

            File.Delete(path);
            File.AppendAllLines(path, searchedQueries.ToArray());
        }

        public string MapPath(string path)
        {
            //var mapPath = HttpContext.Current.Server.MapPath(IOFile.Path);

            return ""; //mapPath;
        }
    }
}
