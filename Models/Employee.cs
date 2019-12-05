namespace Payslip_Round_2
{
    interface IEmployee
    {
        string Firstname { get; set; }
        string Lastname { get; set; }
        decimal Salary { get; set; }
        decimal SuperPercent { get; set; }
        Country Country { get; set; }
    }
    public class Employee : IEmployee
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public decimal Salary { get; set; }
        public decimal SuperPercent { get; set; }
        public Country Country { get; set; }
    }
}