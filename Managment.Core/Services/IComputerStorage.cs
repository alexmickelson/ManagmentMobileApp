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
        Task<bool> AddComputer(Computer comp);
        Task<bool> UpdateComputer(Computer comp);
        Task<bool> Reset();
    }
}
