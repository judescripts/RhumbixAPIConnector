using System;
using System.Collections.Generic;

namespace RhumbixAPIConnector.Models
{
    public class OtCalculator
    {
        public string EmployeeId { get; set; }

        public List<EmployeeDetails> Details { get; set; }
    }

    public class EmployeeDetails
    {
        public string JobNumber { get; set; }
        public string CostCode { get; set; }
        public DateTime StartDate { get; set; }
        public double RegHours { get; set; }
        public double OtHours { get; set; }
    }
}
