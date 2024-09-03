using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveSimulation
{
    public class FileReader
    {
        public string ReadFile(string path)
        {
            if(String.IsNullOrWhiteSpace(path))
            {
                if (path == null)
                    throw new ArgumentNullException("path null");

                throw new ArgumentException("path");
            }

            if (!File.Exists(path))
                throw new FileNotFoundException("File not found: ", path);

            string extension = Path.GetExtension(path).ToLower();
            if (extension!= ".json" && extension != ".txt")
                throw new ArgumentException();

            return File.ReadAllText(path);
        }

    }
}
