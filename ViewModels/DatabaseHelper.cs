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
        public static readonly string DbFile = Path.Combine(Environment.CurrentDirectory, "TURNER_LOCALDB.db3");

        public static async Task<bool> InsertManyAsync<T>(List<T> lists, bool dropTable)
        {
            var result = false;

            await Task.Run((() =>
            {
                using (var conn = new SQLiteConnection(DbFile))
                {
                    if (dropTable)
                    {
                        conn.DropTable<T>();
                    }
                    conn.CreateTable<T>();
                    foreach (var item in lists)
                    {
                        var numberOfRows = conn.Insert(item);
                        if (numberOfRows > 0)
                            result = true;
                    }
                }
                return result;
            }));
            return result;
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
