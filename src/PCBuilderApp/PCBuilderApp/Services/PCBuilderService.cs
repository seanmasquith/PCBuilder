using PCBuilderApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilderApp.Services
{
    public class PCBuilderService
    {
        //List<PCBuild> _resultList = new();
        SQLiteConnection connection;
        string _databasePath = "C:\\PCBuilder\\src\\PCBuilderApp\\PCBuilderApp\\SQLiteDatabase.db";
        int result = 0;
        public string StatusMessage;

        public PCBuilderService(string databasePath)
        {
            _databasePath = databasePath;
        }

        private void Init()
        {
            //If connection isn't null, it's already connected.
            if (connection != null)
                return;

            connection = new SQLiteConnection(_databasePath);
            connection.CreateTable<PCBuild>();
        }

        public PCBuild GetPCBuild(int id)
        {
            //Try to connect to database and create a list from the table
            try
            {
                Init();
                return connection.Table<PCBuild>().FirstOrDefault(q => q.PCBuildID == id);
            }
            //Catch all exceptions
            catch (Exception)
            {
                StatusMessage = "Could not connect to the database.";
            }
            return null;
        }

        public List<PCBuild> GetPCBuilds()
        {
            //Try to connect to database and create a list from the table
            try
            {
                Init();
                return connection.Table<PCBuild>().ToList();
            }
            //Catch all exceptions
            catch (Exception)
            {
                StatusMessage = "Could not connect to the database.";
            }

            //return empty list
            return new List<PCBuild>();
        }
        
        public void CreateBuild(PCBuild pcBuild)
        {
            try
            {
                Init();

                if (pcBuild == null)
                    throw new Exception("Invalid PC Build record");

                result = connection.Insert(pcBuild);
                StatusMessage = result == 0 ? "Create" : "Success";
            }
            catch (Exception exception)
            {
                StatusMessage = "Failed to create PC Build.";
            }
        }

        public int DeleteBuild(int id)
        {
            try
            {
                Init();
                return connection.Table<PCBuild>().Delete(q => q.PCBuildID == id);
            }
            catch (Exception exception)
            {
                StatusMessage = "Failed to delete";
            }
            return 0;
        }

        /*
        public int UpdateBuild(int id)
        {
            
        }*/
    }
}
