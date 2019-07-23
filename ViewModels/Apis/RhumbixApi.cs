using RhumbixAPIConnector.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RhumbixAPIConnector.ViewModels.Apis
{
    /// <summary>
    /// Utility function to work with Rhumbix public API endpoints
    /// </summary>
    public class RhumbixApi
    {
        public const string BaseUrl = "https://prod.rhumbix.com/public_api/v2/";
        public enum QueryType
        {
            TimekeepingEntries,
            ShiftExtraEntries,
            Employees,
            Projects,
            Absences,
            CostCodes,
            TimeKeepingHistory,
            ShiftExtraHistory,
            AbsencesHistory
        }
        /// <summary>
        /// Select type of query and initiate api call
        /// </summary>
        /// <typeparam name="T">Convertible generic types for callback</typeparam>
        /// <param name="queryType">Enum type for selection of queries</param>
        /// <param name="startDate">Effective query start date</param>
        /// <param name="endDate">Effective query end date</param>
        /// <returns></returns>
        public static async Task<T> GetQueryTypes<T>(QueryType queryType, string startDate, string endDate, string ids, string key)
        {
            var type = "";
            var queryParams = "";

            startDate = Convert.ToDateTime(startDate).ToString("yyyy-MM-dd");
            endDate = Convert.ToDateTime(endDate).ToString("yyyy-MM-dd");

            switch (queryType)
            {
                case QueryType.TimekeepingEntries:
                    type = "timekeeping_entries";
                    queryParams = $"&start_date={startDate}&end_date={endDate}";
                    var query = $"{type}/?page_size=200{queryParams}";
                    var url = BaseUrl + query;
                    var result = await GetQueries(url, key);
                    return (T)Convert.ChangeType(result, typeof(T));
                case QueryType.ShiftExtraEntries:
                    type = "shift_extra_entries";
                    queryParams = $"&start_date={startDate}&end_date={endDate}";
                    query = $"{type}/?page_size=200{queryParams}";
                    url = BaseUrl + query;
                    result = await GetQueries(url, key);
                    return (T)Convert.ChangeType(result, typeof(T));
                case QueryType.Employees:
                    type = "employees";
                    queryParams = $"&is_active=true";
                    query = $"{type}/?page_size=200{queryParams}";
                    url = BaseUrl + query;
                    var employees = await GetQueries(url, key);
                    return (T)Convert.ChangeType(employees, typeof(T));
                case QueryType.Projects:
                    type = "projects";
                    queryParams = $"&start_date={startDate}&end_date={endDate}";
                    query = $"{type}/?page_size=200{queryParams}";
                    url = BaseUrl + query;
                    var projects = await GetQueries(url, key);
                    return (T)Convert.ChangeType(projects, typeof(T));
                case QueryType.CostCodes:
                    type = "cost_codes";
                    queryParams = $"&start_date={startDate}&end_date={endDate}";
                    query = $"{type}/?page_size=200{queryParams}";
                    url = BaseUrl + query;
                    var costCodes = await GetQueries(url, key);
                    return (T)Convert.ChangeType(costCodes, typeof(T));

                case QueryType.Absences:
                    type = "absences";
                    queryParams = $"&start_date={startDate}&end_date={endDate}";
                    query = $"{type}/?page_size=200{queryParams}";
                    url = BaseUrl + query;
                    var absences = await GetQueries(url, key);
                    return (T)Convert.ChangeType(absences, typeof(T));
                case QueryType.TimeKeepingHistory:
                    type = "timekeeping_entries/history";
                    queryParams = $"&ids={ids}";
                    query = $"{type}/?page_size=200{queryParams}";
                    url = BaseUrl + query;
                    var timekeepingHistory = await GetQueries(url, key);
                    return (T)Convert.ChangeType(timekeepingHistory, typeof(T));
                case QueryType.ShiftExtraHistory:
                    type = "shift_extra_entries/history";
                    queryParams = $"&ids={ids}";
                    query = $"{type}/?page_size=200{queryParams}";
                    url = BaseUrl + query;
                    var shiftExtraHistory = await GetQueries(url, key);
                    return (T)Convert.ChangeType(shiftExtraHistory, typeof(T));
                case QueryType.AbsencesHistory:
                    type = "absences/history";
                    queryParams = $"&ids={ids}";
                    query = $"{type}/?page_size=200{queryParams}";
                    url = BaseUrl + query;
                    var absencesHistory = await GetQueries(url, key);
                    return (T)Convert.ChangeType(absencesHistory, typeof(T));
            }
            return (T)Convert.ChangeType(null, typeof(T));
        }

        private static async Task<List<QueryResults>> GetQueries(string url, string key)
        {
            var resultPages = new List<QueryResults>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-api-key", key);
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    FileSystemsHelpers.WriteToFile($"Access denied");

                    return null;
                }

                var json = await response.Content.ReadAsStringAsync();
                var timeEntries = QueryResults.FromJson(json);

                if (timeEntries.Next != null)
                {
                    resultPages.Add(timeEntries);
                    url = timeEntries.Next.ToString();
                    await PaginateQueriesCalls(url, resultPages, key);
                    return resultPages;
                }
                else
                {
                    resultPages.Add(timeEntries);
                    return resultPages;
                }
            }
        }
        private static async Task<List<QueryResults>> PaginateQueriesCalls(string url, List<QueryResults> resultPages, string key)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-api-key", key);
                var response = await client.GetAsync(url);
                if ((int)response.StatusCode != 200)
                {
                    return null;
                }
                var json = await response.Content.ReadAsStringAsync();
                var timeEntries = QueryResults.FromJson(json);

                if (timeEntries.Next != null)
                {
                    resultPages.Add(timeEntries);
                    url = timeEntries.Next.ToString();
                    await PaginateQueriesCalls(url, resultPages, key);
                    return resultPages;
                }
                else
                {
                    resultPages.Add(timeEntries);
                    return resultPages;
                }
            }
        }
    }
}
