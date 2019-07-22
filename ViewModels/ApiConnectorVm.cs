using RhumbixAPIConnector.Models;
using RhumbixAPIConnector.ViewModels.Apis;
using RhumbixAPIConnector.ViewModels.Commands;
using RhumbixAPIConnector.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RhumbixAPIConnector.ViewModels
{
    public class ApiConnectorVm
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public Queries Queries { get; set; }
        public QueryCommand QueryCommand { get; set; }
        public ShowImportedViewCommand ShowImportedViewCommand { get; set; }
        public ShowEmployeesViewCommand ShowEmployeesViewCommand { get; set; }
        public ShowApiKeyViewCommand ShowApiKeyViewCommand { get; set; }
        public ShowStatusViewCommand ShowStatusViewCommand { get; set; }
        public ApiConnectorVm()
        {
            Queries = new Queries();
            QueryCommand = new QueryCommand(this);
            ShowImportedViewCommand = new ShowImportedViewCommand(this);
            ShowEmployeesViewCommand = new ShowEmployeesViewCommand(this);
            ShowApiKeyViewCommand = new ShowApiKeyViewCommand(this);
            ShowStatusViewCommand = new ShowStatusViewCommand(this);
        }

        /// <summary>
        /// Multi task queues for calling Rhumbix Api
        /// </summary>
        /// <param name="queries">Query start date and end date</param>
        public async void RhumbixApiTaskQueues(Queries queries)
        {
            var key = FetchApiToken(queries.Pin);

            FileSystemsHelpers.ClearAllTexts();
            FileSystemsHelpers.WriteToFile($"Last imported time: {DateTime.Now}");

            // If no date is selected, abort method call
            if (queries.StartDate == "" || queries.EndDate == "") return;

            await RunQueryAsync(queries, "Timekeeping", key);
            await RunQueryAsync(queries, "Shift Extra", key);
            await RunQueryAsync(queries, "Employees", key);
            await RunQueryAsync(queries, "Projects", key);
            await RunQueryAsync(queries, "Cost Codes", key);
            await RunQueryAsync(queries, "Absences", key);
            await RunQueryAsync(queries, "Timekeeping History", key);
            await RunQueryAsync(queries, "Shift Extra History", key);
            await RunQueryAsync(queries, "Absences History", key);

            MessageBox.Show("Import complete! Please review status menu for detailed results", "Rhumbix API Connector", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Retrieve array of unique Ids for each history api endpoint call
        /// </summary>
        /// <param name="type">Select Query Enum Type</param>
        /// <returns>Formatted string of Id arrays for history api endpoint call</returns>
        public static string GetIdArrays(RhumbixApi.QueryType type)
        {
            using (var conn = new SQLiteConnection(DatabaseHelper.DbFile))
            {
                try
                {
                    Logger.Info("GetIdArrays Method");
                    switch (type)
                    {
                        case RhumbixApi.QueryType.TimekeepingEntries:
                            var timeList = conn.Table<Timekeeping>().Select(x => x.Id).Distinct().ToList();
                            var stringArray = "";
                            foreach (var item in timeList)
                            {
                                stringArray += item + ",";
                            }
                            return stringArray.TrimEnd(',');
                        case RhumbixApi.QueryType.ShiftExtraEntries:
                            var shiftList = conn.Table<Timekeeping>().Select(x => x.Id).Distinct().ToList();
                            stringArray = "";
                            foreach (var item in shiftList)
                            {
                                stringArray += item + ",";
                            }
                            return stringArray.TrimEnd(',');
                        case RhumbixApi.QueryType.Absences:
                            var absencesList = conn.Table<Timekeeping>().Select(x => x.Id).Distinct().ToList();
                            stringArray = "";
                            foreach (var item in absencesList)
                            {
                                Debug.WriteLine(item);
                            }
                            return stringArray.TrimEnd(',');
                        default:
                            return string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "Exception occured from getting id arrays");
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Call Rhumbix Api utility function
        /// </summary>
        /// <param name="queries">Enum selection query type</param>
        public async Task RunQueryAsync(Queries queries, string selection, string key)
        {
            var timeList = new List<Timekeeping>();
            var shiftList = new List<ShiftExtra>();
            var employeeList = new List<Employee>();
            var projectList = new List<Project>();
            var costCodesList = new List<CostCodes>();
            var absencesList = new List<Absences>();
            var timeHistoryList = new List<TimekeepingHistory>();
            var shiftHistoryList = new List<ShiftExtraHistory>();
            var absencesHistoryList = new List<AbsencesHistory>();
            var ids = string.Empty;

            switch (selection)
            {
                case "Timekeeping":
                    var timeResults = await RhumbixApi.GetQueryTypes<List<QueryResults>>(RhumbixApi.QueryType.TimekeepingEntries,
                        queries.StartDate, queries.EndDate, string.Empty, key);
                    foreach (var results in timeResults)
                    {
                        foreach (var result in results.Results)
                        {
                            timeList.Add((Timekeeping)result);
                        }
                    }
                    var numOfRows = await DatabaseHelper.InsertManyAsync<Timekeeping>(timeList, true);
                    FileSystemsHelpers.WriteToFile($"Number of timekeeping records imported: {numOfRows}");
                    break;
                case "Shift Extra":
                    var shiftResults = await RhumbixApi.GetQueryTypes<List<QueryResults>>(RhumbixApi.QueryType.ShiftExtraEntries,
                        queries.StartDate, queries.EndDate, string.Empty, key);
                    foreach (var results in shiftResults)
                    {
                        foreach (var result in results.Results)
                        {
                            result.AAType = result.EntryStore.AAType;

                            shiftList.Add((ShiftExtra)result);
                        }
                    }
                    numOfRows = await DatabaseHelper.InsertManyAsync<ShiftExtra>(shiftList, true);
                    FileSystemsHelpers.WriteToFile($"Number of shift extra records imported: {numOfRows}");
                    break;
                case "Employees":
                    var employeesResults = await RhumbixApi.GetQueryTypes<List<QueryResults>>(RhumbixApi.QueryType.Employees,
                        queries.StartDate, queries.EndDate, string.Empty, key);
                    foreach (var results in employeesResults)
                    {
                        foreach (var result in results.Results)
                        {
                            using (var conn = new SQLiteConnection(DatabaseHelper.DbFile))
                            {
                                employeeList.Add((Employee)result);
                            }
                        }
                    }
                    numOfRows = await DatabaseHelper.InsertManyAsync<Employee>(employeeList, true);
                    FileSystemsHelpers.WriteToFile($"Number of employee records imported: {numOfRows}");
                    break;
                case "Projects":
                    var projectsResults = await RhumbixApi.GetQueryTypes<List<QueryResults>>(RhumbixApi.QueryType.Projects,
                        queries.StartDate, queries.EndDate, string.Empty, key);
                    foreach (var results in projectsResults)
                    {
                        foreach (var result in results.Results)
                        {
                            projectList.Add((Project)result);
                        }
                    }
                    numOfRows = await DatabaseHelper.InsertManyAsync<Project>(projectList, true);
                    FileSystemsHelpers.WriteToFile($"Number of projects records imported: {numOfRows}");
                    break;
                case "Cost Codes":
                    var costCodesResults = await RhumbixApi.GetQueryTypes<List<QueryResults>>(RhumbixApi.QueryType.CostCodes,
                        queries.StartDate, queries.EndDate, string.Empty, key);
                    foreach (var results in costCodesResults)
                    {
                        foreach (var result in results.Results)
                        {
                            costCodesList.Add((CostCodes)result);
                        }
                    }
                    numOfRows = await DatabaseHelper.InsertManyAsync<CostCodes>(costCodesList, true);
                    FileSystemsHelpers.WriteToFile($"Number of cost codes records imported: {numOfRows}");
                    break;
                case "Absences":
                    var absencesResults = await RhumbixApi.GetQueryTypes<List<QueryResults>>(RhumbixApi.QueryType.Absences,
                        queries.StartDate, queries.EndDate, string.Empty, key);
                    foreach (var results in absencesResults)
                    {
                        foreach (var result in results.Results)
                        {
                            absencesList.Add((Absences)result);
                        }
                    }
                    numOfRows = await DatabaseHelper.InsertManyAsync<Absences>(absencesList, true);
                    FileSystemsHelpers.WriteToFile($"Number of absences records imported: {numOfRows}");
                    break;
                case "Timekeeping History":
                    ids = GetIdArrays(RhumbixApi.QueryType.TimekeepingEntries).Trim(); // Call helper method to retrieve all unique ids
                    var timeHistoryResults = await RhumbixApi.GetQueryTypes<List<QueryResults>>(RhumbixApi.QueryType.TimeKeepingHistory,
                        queries.StartDate, queries.EndDate, ids, key);
                    foreach (var results in timeHistoryResults)
                    {
                        foreach (var result in results.Results)
                        {
                            timeHistoryList.Add((TimekeepingHistory)result);
                        }
                    }
                    numOfRows = await DatabaseHelper.InsertManyAsync<TimekeepingHistory>(timeHistoryList, true);
                    FileSystemsHelpers.WriteToFile($"Number of timekeeping history records imported: {numOfRows}");
                    break;
                case "Shift Extra History":
                    ids = GetIdArrays(RhumbixApi.QueryType.ShiftExtraHistory).Trim(); // Call helper method to retrieve all unique ids
                    var shiftHistoryResults = await RhumbixApi.GetQueryTypes<List<QueryResults>>(RhumbixApi.QueryType.ShiftExtraHistory,
                        queries.StartDate, queries.EndDate, ids, key);
                    foreach (var results in shiftHistoryResults)
                    {
                        foreach (var result in results.Results)
                        {
                            shiftHistoryList.Add((ShiftExtraHistory)result);
                        }
                    }
                    numOfRows = await DatabaseHelper.InsertManyAsync<ShiftExtraHistory>(shiftHistoryList, true);
                    FileSystemsHelpers.WriteToFile($"Number of shift extra history records imported: {numOfRows}");
                    break;
                case "Absences History":
                    ids = GetIdArrays(RhumbixApi.QueryType.AbsencesHistory).Trim(); // Call helper method to retrieve all unique ids
                    var absencesHistoryResults = await RhumbixApi.GetQueryTypes<List<QueryResults>>(RhumbixApi.QueryType.AbsencesHistory,
                        queries.StartDate, queries.EndDate, ids, key);
                    foreach (var results in absencesHistoryResults)
                    {
                        foreach (var result in results.Results)
                        {
                            absencesHistoryList.Add((AbsencesHistory)result);
                        }
                    }
                    numOfRows = await DatabaseHelper.InsertManyAsync<AbsencesHistory>(absencesHistoryList, true);
                    FileSystemsHelpers.WriteToFile($"Number of absence history records imported: {numOfRows}");
                    break;
            }
        }
        private static string FetchApiToken(string pin)
        {
            var hashedKey = DatabaseHelper.GetList<Tokens>();
            return Crypto.DecryptStringAES(hashedKey[0].ApiToken, pin);
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
        public void ShowApiKeyView()
        {
            var apiKeyWin = new ApiKeysWindow();
            apiKeyWin.Show();
        }
        public void ShowStatusView()
        {
            var statusWin = new StatusWindow();
            statusWin.Show();
        }

    }
}
