using FileHelpers;
using RhumbixAPIConnector.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RhumbixAPIConnector.ViewModels
{
    public class EmployeesVm
    {
        public Employee Employee { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }

        public EmployeesVm()
        {
            Employee = new Employee();
            Employees = new ObservableCollection<Employee>();

            GetEmployeesList();
        }

        public void GetEmployeesList()
        {
            try
            {
                using (var conn = new SQLiteConnection(DatabaseHelper.DbFile))
                {
                    var employees = conn.Table<Employee>().ToList();
                    Employees.Clear();
                    foreach (var item in employees)
                    {
                        Employees.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Helper method for mass importing employees data
        /// </summary>
        public static async Task ImportValidationCsvAsync()
        {
            var fileName = FileSystemsHelpers.GetFilePath();
            var engine = new FileHelperAsyncEngine<Employee>();
            var validationData = new List<Employee>();

            using (engine.BeginReadFile(fileName))
            {
                validationData.AddRange(engine);
                var confirm = await DatabaseHelper.InsertManyAsync<Employee>(validationData, true);
                DatabaseHelper.Confirm(confirm);
            }
        }

    }
}
