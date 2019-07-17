using RhumbixAPIConnector.Models;
using RhumbixAPIConnector.ViewModels.Apis;
using RhumbixAPIConnector.ViewModels.Commands;
using RhumbixAPIConnector.Views;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RhumbixAPIConnector.ViewModels
{
    public class ApiConnectorVm
    {
        public Queries Queries { get; set; }
        public QueryCommand QueryCommand { get; set; }
        public ShowImportedViewCommand ShowImportedViewCommand { get; set; }
        public ShowEmployeesViewCommand ShowEmployeesViewCommand { get; set; }

        public ApiConnectorVm()
        {
            Queries = new Queries();
            QueryCommand = new QueryCommand(this);
            ShowImportedViewCommand = new ShowImportedViewCommand(this);
            ShowEmployeesViewCommand = new ShowEmployeesViewCommand(this);
        }

        /// <summary>
        /// Run Rhumbix Api utility function
        /// </summary>
        /// <param name="queries">Enum selection query type</param>
        public async void RunQueryAsync(Queries queries)
        {
            var timeList = new List<Timekeeping>();
            var shiftList = new List<ShiftExtra>();
            var employeeList = new List<Employee>();
            var projectList = new List<Project>();
            var confirm = false;

            switch (queries.QueryType.Content.ToString())
            {
                case "Timekeeping":
                    var timeResults = await RhumbixApi.GetQueryTypes<List<QueryResults>>(RhumbixApi.QueryType.TimekeepingEntries,
                        queries.StartDate, queries.EndDate);
                    foreach (var results in timeResults)
                    {
                        foreach (var result in results.Results)
                        {
                            timeList.Add((Timekeeping)result);
                        }
                    }
                    confirm = await DatabaseHelper.InsertManyAsync<Timekeeping>(timeList, true);
                    DatabaseHelper.Confirm(confirm);
                    break;
                case "Shift Extra":
                    var shiftResults = await RhumbixApi.GetQueryTypes<List<QueryResults>>(RhumbixApi.QueryType.ShiftExtraEntries,
                        queries.StartDate, queries.EndDate);
                    foreach (var results in shiftResults)
                    {
                        foreach (var result in results.Results)
                        {
                            result.AAType = result.EntryStore.AAType;

                            shiftList.Add((ShiftExtra)result);
                        }
                    }
                    confirm = await DatabaseHelper.InsertManyAsync<ShiftExtra>(shiftList, true);
                    DatabaseHelper.Confirm(confirm);
                    break;
                case "Employees":
                    var employeesResults = await RhumbixApi.GetQueryTypes<List<QueryResults>>(RhumbixApi.QueryType.Employees,
                        queries.StartDate, queries.EndDate);
                    var count = 0;
                    foreach (var results in employeesResults)
                    {
                        foreach (var result in results.Results)
                        {
                            using (var conn = new SQLiteConnection(DatabaseHelper.DbFile))
                            {
                                var checkList = conn.Table<Employee>().ToList();

                                if (checkList.Any(x => x.CompanySuppliedId == result.CompanySuppliedId)) continue;
                                employeeList.Add((Employee)result);
                                count += 1;
                            }
                        }
                    }
                    confirm = await DatabaseHelper.InsertManyAsync<Employee>(employeeList, false);
                    MessageBox.Show($"Update complete! Total {count} of records added", "Rhumbix Complete",
                        MessageBoxButton.OK, MessageBoxImage.Information);

                    break;
                case "Projects":
                    var projectsResults = await RhumbixApi.GetQueryTypes<List<QueryResults>>(RhumbixApi.QueryType.Projects,
                        queries.StartDate, queries.EndDate);
                    foreach (var results in projectsResults)
                    {
                        foreach (var result in results.Results)
                        {
                            projectList.Add((Project)result);
                        }
                    }
                    confirm = await DatabaseHelper.InsertManyAsync<Project>(projectList, true);
                    DatabaseHelper.Confirm(confirm);
                    break;
            }
        }

        public void ShowImportedView()
        {
            var importedWin = new ImportedWindow();
            importedWin.Show();
        }
        public void ShowEmployeesView()
        {
            var employeesWin = new EmployeesWindow();
            employeesWin.Show();
        }
    }
}
