namespace RhumbixAPIConnector.Models
{
    /// <summary>
    /// Client specific transform model
    /// </summary>
    public class Transform
    {
        // Applicable for all three timekeeping, shift extra, absences type
        // Transformed from timekeeping table
        public string PersonnelNo { get; set; }
        public string Date { get; set; }
        public string ProjectNumber { get; set; }
        public string CostCode { get; set; }
        public string ActivityType { get; set; }
        public string AttendanceType { get; set; }
        public string CompanyCode { get; set; }
        public double Hours { get; set; }

        // Transformed from employees table
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeName { get; set; }
        public string Trade { get; set; }
        public string Classification { get; set; }

        // Transformed from project table (Absences not applicable)
        public string ProjectName { get; set; }

        // Transformed from cost code table (Absences not applicable)
        public string CostCodeDescription { get; set; }

        // Transformed from history table 
        public string ApprovalStatus { get; set; }
        public string ApproverFirstName { get; set; }
        public string ApproverLastName { get; set; }
        public string ApproverName { get; set; }
        public string DateApproved { get; set; }
        public string TimeApproved { get; set; }

        // Only applicable for absences type
        // Transformed from absences table 
        public string AbsenceType { get; set; }
        public string AbsenceDescription { get; set; }
    }
}
