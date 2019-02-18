using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Managment.Core.Model;
using Newtonsoft.Json;

namespace Managment.Core.Services
{
    public class ComputerStorage : IComputerStorage
    {

        List<Computer> computers;
        private string filePath;

        public ComputerStorage() 
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            filePath = Path.Combine(path, "computers.json");

            if (File.Exists(filePath))
            {
                var fileContents = File.ReadAllText(filePath);
                computers = JsonConvert.DeserializeObject<List<Computer>>(fileContents);
                
            }
            else
                computers = new List<Computer>();
        }
        public List<Computer> getAllComputers()
        {
            return computers;
        }

        public void AddComputer(Computer comp)
        {
            if (comp != null)
            {
                computers.Add(comp);
                var fileContents = JsonConvert.SerializeObject(computers);
                File.WriteAllText(filePath, fileContents);
            } else
            {
                throw new Exception("Cannot add null computer");
            }
        }

        public void Reset()
        {
            File.Delete(filePath);
        }
    }
}
