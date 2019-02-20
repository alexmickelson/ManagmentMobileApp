using System.Collections.Generic;
using System.Threading.Tasks;
using Managment.Core.Model;
using SQLite;
using PCLStorage;
using System.IO;
using System;
using System.Collections.ObjectModel;

namespace Managment.Core.Services
{
    public class SqlStorageService :  IComputerStorage
    {
        private readonly string filePath;
        SQLiteAsyncConnection connection;

        public SqlStorageService()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            filePath = Path.Combine(path, "computers.db3");
            connection = new SQLiteAsyncConnection(filePath);
            connection.GetConnection().CreateTable<Computer>();
        }

        public async Task<bool> AddComputer(Computer comp)
        {
            if (comp == null)
            {
                throw new Exception("Cannot add null computer");
            }
            await connection.InsertAsync(comp);
            return true;
        }

        public async Task<ObservableCollection<Computer>> getAllComputers()
        {
            return new ObservableCollection<Computer>(await connection.Table<Computer>().ToListAsync());
        }

        public async Task<bool> Reset()
        {
            await connection.DeleteAllAsync<Computer>();
            return true;
        }

        public async Task<bool> UpdateComputer(Computer comp)
        {
            await connection.UpdateAsync(comp);
            return true;
        }
        
    }
}
