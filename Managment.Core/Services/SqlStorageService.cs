using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Managment.Core.Model;
using PCLStorage;
using SQLite;

namespace Managment.Core.Services
{
    class SqlStorageService :  IComputerStorage
    {

        readonly SQLiteAsyncConnection connection;

        public SqlStorageService()
        {
            var local = FileSystem.Current.LocalStorage.Path;
            var datafile = Path.Combine(local, "computers.db3");
            connection = new SQLiteAsyncConnection(datafile);
            connection.GetConnection().CreateTable<Computer>();
        }

        public void AddComputer(Computer comp)
        {
            connection.InsertAsync(comp);
        }

        public async Task<List<Computer>> getAllComputers()
        {
            return await connection.Table<Computer>().ToListAsync();
        }

        public void Reset()
        {
            connection.DeleteAllAsync<Computer>();
        }

        public void UpdateComputer(Computer comp)
        {
            connection.UpdateAsync(comp);
        }
        
    }
}
