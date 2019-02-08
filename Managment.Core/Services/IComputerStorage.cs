using Managment.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managment.Core.Services
{
    public interface IComputerStorage
    {
        List<Computer> getAllComputers();
        void AddComputer(Computer comp);
        void Reset();
    }
}
