namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        public Suite() { }

        public Suite(string suiteType, int capacity, decimal dailyValue)
        {
            SuiteType = suiteType;
            Capacity = capacity;
            DailyValue = dailyValue;
        }

        public string SuiteType { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public decimal DailyValue { get; set; }
    }
}
