using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace RhumbixAPIConnector.ViewModels
{
    public class DatabaseHelper
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public static readonly string DbFile = Path.Combine(Environment.CurrentDirectory, "TURNER_LOCALDB.db3");
        public static async Task<int> InsertManyAsync<T>(List<T> lists, bool dropTable)
        {
            return await Task.Run((() =>
             {
                 try
                 {
                     Logger.Info("DbHelper InsertManyAsync Method");
                     using (var conn = new SQLiteConnection(DbFile))
                     {
                         if (dropTable)
                         {
                             conn.DropTable<T>();
                         }
                         conn.CreateTable<T>();
                         return conn.InsertAll(lists); // Return number of rows affected
                     }
                 }
                 catch (Exception ex)
                 {

                     Logger.Error(ex, "Exception occured while persisting data to the database");
                     return 0;
                 }
             }));
        }

        public static List<T> GetList<T>() where T : new()
        {
            try
            {
                Logger.Info("DbHelper GetList Method");
                using (var conn = new SQLiteConnection(DatabaseHelper.DbFile))
                {
                    return conn.Table<T>().ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Exception occured while retrieving data from the database");
                return null;
            }
        }

        public static bool Insert<T>(T item)
        {
            var result = false;

            using (var conn = new SQLiteConnection(DbFile))
            {
                conn.CreateTable<T>();
                var numberOfRows = conn.Insert(item);
                if (numberOfRows > 0)
                    result = true;
            }

            return result;
        }

        public static bool Update<T>(T item)
        {
            var result = false;

            using (var conn = new SQLiteConnection(DbFile))
            {
                conn.CreateTable<T>();
                var numberOfRows = conn.Update(item);
                if (numberOfRows > 0)
                    result = true;
            }

            return result;
        }

        public static bool Delete<T>(T item)
        {
            var result = false;

            using (var conn = new SQLiteConnection(DbFile))
            {
                conn.CreateTable<T>();
                var numberOfRows = conn.Delete(item);
                if (numberOfRows > 0)
                    result = true;
            }

            return result;
        }

        public static void Confirm(bool result)
        {
            if (result)
            {
                MessageBox.Show("Import complete!", "Rhumbix Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("An error has occured, please try again", "Rhumbix Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}
