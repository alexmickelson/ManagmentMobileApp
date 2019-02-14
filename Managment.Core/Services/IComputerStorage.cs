using Managment.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Managment.Core.Services
{
    public interface IComputerStorage
    {
        Task<List<Computer>> getAllComputers();
        void AddComputer(Computer comp);
        void UpdateComputer(Computer comp);
        void Reset();
    }
}
