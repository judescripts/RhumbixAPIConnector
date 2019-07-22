using RhumbixAPIConnector.Models;
using SQLite;
using System;
using System.Collections.ObjectModel;

namespace RhumbixAPIConnector.ViewModels
{
    public class ImportedVm
    {
        public Timekeeping Timekeeping { get; set; }
        public ShiftExtra ShiftExtra { get; set; }
        public Transform Transform { get; set; }
        public ObservableCollection<Timekeeping> TimeList { get; set; }
        public ObservableCollection<ShiftExtra> ShiftExtraList { get; set; }
        public ImportedVm()
        {
            Timekeeping = new Timekeeping();
            ShiftExtra = new ShiftExtra();
            Transform = new Transform();
            TimeList = new ObservableCollection<Timekeeping>();
            ShiftExtraList = new ObservableCollection<ShiftExtra>();

            GetTimeKeepingList();
            GetShiftExtraList();
        }
        public void GetTimeKeepingList()
        {
            try
            {
                using (var conn = new SQLiteConnection(DatabaseHelper.DbFile))
                {
                    var timeList = conn.Table<Timekeeping>().ToList();
                    TimeList.Clear();
                    foreach (var item in timeList)
                    {
                        TimeList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void GetShiftExtraList()
        {
            try
            {
                using (var conn = new SQLiteConnection(DatabaseHelper.DbFile))
                {
                    var shiftExtraList = conn.Table<ShiftExtra>().ToList();
                    ShiftExtraList.Clear();
                    foreach (var item in shiftExtraList)
                    {
                        ShiftExtraList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        // TODO: Implmeent user controls for absences

        // TODO: Implement transformation method for Turner
        public void TransformTurnerData()
        {






        }
    }
}
