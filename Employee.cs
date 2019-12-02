namespace Payslip_Round_2
{
    interface IEmployee
    {
        string Firstname { get; set; }
        string Lastname { get; set; }
        double Salary { get; set; }
        double SuperPercent { get; set; }
        Country Country { get; set; }
    }
    public class Employee : IEmployee
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public double Salary { get; set; }
        public double SuperPercent { get; set; }
        public Country Country { get; set; }
    }
}