using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilderApp
{
    public class SQLiteDatabase
    {
        List<PCBuild> _resultList = new();
        SQLiteAsyncConnection connection;
        string databasePath = "C:\\PCBuilder\\src\\PCBuilderApp\\PCBuilderApp\\SQLiteDatabase.db";

        public SQLiteDatabase()
        {
            connection = new SQLiteAsyncConnection(databasePath);
        }

        public async Task<List<PCBuild>> ReadPCBuilds()
        {
            await connection.CreateTableAsync<PCBuild>();
            List<PCBuild> results = await connection.Table<PCBuild>().ToListAsync();
            if (results.Count != 0)
            {
                _resultList = results;
            }
            return _resultList;
        }

    }
}
