using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace JsonInterrogator
{
    public class Repository : IRepository
    {
        private readonly IWebHostEnvironment _environment;
        private readonly string _dataFilePath;
        public Repository(IWebHostEnvironment environment, string dataFilePath)
        {
            _environment = environment;
            _dataFilePath = dataFilePath;
        }
        public IEnumerable<T> Get<T>()
        {
            IEnumerable<T> data;
            string filePath = Path.Combine(_environment.WebRootPath, _dataFilePath);
            using (StreamReader file = System.IO.File.OpenText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                data = (IEnumerable<T>)serializer.Deserialize(file, typeof(IEnumerable<T>));
            }
            return data;
        }
    }
}
