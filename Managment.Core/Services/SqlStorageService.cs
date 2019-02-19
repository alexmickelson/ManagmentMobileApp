using System.Collections.Generic;
using System.Threading.Tasks;
using Managment.Core.Model;
using SQLite;
using PCLStorage;
using System.IO;
using System;

namespace Managment.Core.Services
{
    public class SqlStorageService :  IComputerStorage
    {
        private readonly string filePath;
        SQLiteAsyncConnection connection;

        public SqlStorageService()
        {
            var path = FileSystem.Current.LocalStorage.Path;
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

        public async Task<List<Computer>> getAllComputers()
        {
            return await connection.Table<Computer>().ToListAsync();
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
