using System;
using System.Collections.Generic;
using System.Text;
using Managment.Core.Model;

namespace Managment.Core.Services
{
    class DummyComputerStorage : IComputerStorage
    {
        public void AddComputer(Computer comp)
        {
            throw new NotImplementedException();
        }

        public List<Computer> getAllComputers()
        {
            var list = new List<Computer>();
            var comp = new Computer();
            comp.IPAddress = "1";
            comp.Location = "1";
            list.Add(comp);

            comp = new Computer();
            comp.IPAddress = "2";
            comp.Location = "2";
            list.Add(comp);
            return list;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
